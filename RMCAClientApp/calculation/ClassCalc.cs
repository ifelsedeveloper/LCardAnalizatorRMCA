using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Record;
using System.IO;

namespace WindowsFormsGraphickOpenGL
{
    class ClassCalc
    {
        ClassRecord record = new ClassRecord();

        int ch_vu=0;
        public int with_diff=5;
        public int OutStep = 10;
        public int InStep = 5;

        double median_vu;   //среднее значения датчика частоты вращения
        int kol_front_vu;   //количество точек пересечения со средней линией
        double [] front_vu; //фронты (точки пересечения)

        public int kol_vu;     //количество частот которые удалось вычислить
        public double[] t_vu;  //время частоты вращения
        public double[] degree_vu;  //градусы частоты вращения
        public double[] vu;    //массив частот
        public double max_vu;  //масимальна частота
        public double min_vu;  //минимальная частота

        public int kol_ac;     //количество ускорений которые удалось вычислить
        public double[] t_ac;  //время ускорений
        public double[] degree_ac; //градусы ускорения
        public double[] vu_ac; //массив частот ускорений
        public double[] ac;    //массив ускорений
        public double max_ac;  //максимальное ускорение
        public double min_ac;  //минимальное ускорение

        int number_zub=360; //

        public ClassCalc()
        {
            
        }

        void GetMedianVu()
        {
	        int i;
	        median_vu=0;
	        //int kol=2048;
	        for(i=0;i<record.KadrsNumber;i++)
	        {
		        median_vu+=record.ch[ch_vu][i];
	        }
            median_vu = median_vu / record.KadrsNumber;
        }

        void GetFrontVu()
        {
            int q = 0;
            int i;
            //подсчёт количества фронтов
            for (i = 0; i < record.KadrsNumber - 4; i++)
            {

                if (record.ch[ch_vu][i] > median_vu && record.ch[ch_vu][i + 1] > median_vu && record.ch[ch_vu][i + 2] > median_vu)
                {
                    q++; i++;
                    for (; (i < record.KadrsNumber - 4) && record.ch[ch_vu][i] > median_vu && record.ch[ch_vu][i + 1] > median_vu && record.ch[ch_vu][i + 2] > median_vu; i++) ;
                }
            }
            kol_front_vu = q;

            q = 0;
            front_vu = new double[kol_front_vu];
            for (i = 0; i < record.KadrsNumber - 4; i++)
            {
                if (record.ch[ch_vu][i] > median_vu && record.ch[ch_vu][i + 1] > median_vu && record.ch[ch_vu][i + 2] > median_vu)
                {
                    front_vu[q] = record.time[i]; q++; i++;
                    for (; (i < record.KadrsNumber - 4) && record.ch[ch_vu][i] > median_vu && record.ch[ch_vu][i + 1] > median_vu && record.ch[ch_vu][i + 2] > median_vu; i++)
                    { }
                }
            }

        }

        void GetVu()
        {
            kol_vu = (kol_front_vu / OutStep - 1) * (OutStep / InStep) + kol_front_vu / OutStep;
            vu = new double[kol_vu];
            t_vu = new double[kol_vu];
            degree_vu = new double[kol_vu];

            double[] T = new double[kol_vu];
            double start_time;
            double end_time;
            int i,j;
            int s = 0;

            for (i = 0; i < kol_front_vu / OutStep-1; i=i+1)
            {
                for (j = i*OutStep; j < i*OutStep + OutStep; j = j + InStep)
                {
                    
                    start_time = front_vu[j];
                    end_time = front_vu[j + OutStep];
                    T[s] = (end_time - start_time) * number_zub / (1.0 + OutStep);
                    vu[s] = 60.0 / T[s];
                    degree_vu[s] = j + OutStep / 2;
                    t_vu[s] = (start_time + end_time) / 2;
                    s++;
                }
                
            }
            
            kol_vu = s-2;
            double[] vu2 = new double[kol_vu];
            Array.Copy(vu, 0, vu2, 0, kol_vu);
            vu = vu2;
            max_vu = vu.Max();
            min_vu = vu.Min();
        }

        double p1 = 1.0 / Math.Sqrt(2 * Math.PI) * 0.37;
        double p2 = -1.0 / (2.0 * 0.37 * 0.37);
        double gaussK(double t)
        {
            double res;
            res = p1 * Math.Exp(t*t*p2);
            return res;
        }

        public double gaussB=0.02;
        void GetVuGauss(double in_gaussB)
        {
            kol_vu = kol_front_vu - 1;
            double []data_vu = new double[kol_vu];
            t_vu = new double[kol_vu];
            degree_vu = new double[kol_vu];
            int i;
            for (i = 0; i < kol_vu; i++)
            {
                data_vu[i] = 60.0 / ((front_vu[i + 1] - front_vu[i])*Convert.ToDouble(number_zub));
                t_vu[i]=(front_vu[i + 1] + front_vu[i])/2.0;
                degree_vu[i] = i + 0.5;
            }
            double sum_numerator, sum_denumerator;
            double val;
            int j;
            vu = new double[kol_vu];
            if (Math.Abs(in_gaussB) > 1e-10)
                for (i = 0; i < kol_vu; i++)
                {
                    sum_numerator = sum_denumerator = 0;
                    for (j = 0; j < kol_vu; j++)
                    {
                        val = gaussK((t_vu[i] - t_vu[j]) / in_gaussB);
                        sum_numerator += val * data_vu[j];
                        sum_denumerator += val;
                    }
                    vu[i] = sum_numerator / sum_denumerator;
                }
            else
            {
                for (i = 0; i < kol_vu; i++)
                {
                    vu[i] = data_vu[i];
                }
            }
        }

        void GetAcceleration()
        {
            kol_ac = kol_vu -2-2*with_diff;
            vu_ac = new double[kol_ac];
            ac = new double[kol_ac];
            t_ac = new double[kol_ac];
            degree_ac = new double[kol_ac];
            double k;   //пароизводная частоты вращения по времени
            double x;   //параметр прямой
            int i;
            double v1;
            double v2;
            double t1;
            double t2;
            int j;

            //расчёт ускорения
            for (i = 0; i < kol_ac; i++)
            {
                v1=0;
                v2=0;
                t1 = 0;
                t2 = 0;
                for (j = i; j < i + with_diff; j++)
                {
                    v1 += vu[j];
                    v2 += vu[j + with_diff];
                    t1 += t_vu[j];
                    t2 += t_vu[j + with_diff];

                }
                k = ((v2 - v1) / 60.0) / (t2 - t1);
                x = (t1 + t2) / (2.0*with_diff);
                vu_ac[i] = (v2 + v1) / (2.0*with_diff);
                ac[i] = k * 2 * Math.PI;
                t_ac[i] = x;
                degree_ac[i] = (degree_vu[i] + degree_vu[i + with_diff - 1]) / 2.0;
            }

        }

        public double[] max_loc;
        public double[] min_loc;
        public double[] t_max_loc;
        public double[] t_min_loc;
        public int[] pos_min_loc;
        public int[] pos_max_loc;

        public double[] InEng;
        public double[] t_InEng;
        public int kolInEng;
        public int[] pos_InEng;

        public double[] max_loc_ac;
        public double[] min_loc_ac;
        public double[] InEng_ac;

        void GetMaxMin()
        {
            double mid_value;
            mid_value = (vu.Max() + vu.Min()) / 2.0;
            int i;
            int kol_max = 0;
            bool flag_start=false;
            for (i = 0; i < kol_vu; i++)
            {
                if (vu[i] > mid_value)
                {
                    kol_max++;
                    while (i<kol_vu && vu[i] > mid_value  ) i++;
                }
                
            }
            if (kol_max > 0)
            {
                max_loc = new double[kol_max];
                min_loc = new double[kol_max-1];
                t_max_loc = new double[kol_max];
                t_min_loc = new double[kol_max-1];
                max_loc_ac = new double[kol_max];
                min_loc_ac = new double[kol_max - 1];


                pos_max_loc = new int[kol_max];
                //находим максимальные значения
                kol_max = 0;
                for (i = 0; i < kol_vu; i++)
                {
                    if (vu[i] > mid_value)
                    {
                        
                        max_loc[kol_max] = vu[i];
                        max_loc_ac[kol_max] = ac[i];
                        t_max_loc[kol_max] = t_vu[i];
                        pos_max_loc[kol_max] = i;
                        while (i < kol_vu && vu[i] > mid_value)
                        {
                            if (vu[i] > max_loc[kol_max])
                            {
                                max_loc[kol_max] = vu[i];
                                t_max_loc[kol_max] = t_vu[i];
                                max_loc_ac[kol_max] = ac[i];
                                pos_max_loc[kol_max] = i;
                            }
                            i++; 
                        }
                        kol_max++;
                    }
                }
                //находим мимимальные значения
                int j;
                pos_min_loc = new int[kol_max];
                InEng = new double[(kol_max-2) * 4];
                t_InEng = new double[(kol_max-2) * 4];
                InEng_ac = new double[(kol_max - 2)*4];
                pos_InEng=new int[(kol_max - 2)*4];
                kolInEng = kol_max * 3;
                for (j = 0; j < kol_max-1; j++)
                {
                    i = pos_max_loc[j];
                    min_loc[j] = vu[i];
                    t_min_loc[j] = t_vu[i];
                    pos_min_loc[j] = i;
                    for (; i < pos_max_loc[j + 1]; i++)
                        if (vu[i] < min_loc[j])
                        {
                            min_loc[j] = vu[i];
                            t_min_loc[j] = t_vu[i];
                            pos_min_loc[j] = i;
                        }
                }
                i = pos_min_loc[0];
                for (j = 0; j < kol_max - 2; j++)
                {
                    i = pos_min_loc[j];
                    

                    if (i + 180 >= kol_front_vu - 1)
                    {
                        t_InEng[j * 4] = front_vu[kol_front_vu - 2];
                        InEng[j * 4] = vu[kol_front_vu - 2];
                        InEng_ac[j * 4] = ac[kol_front_vu - 3];
                        pos_InEng[j * 4] = kol_front_vu - 2;
                    }
                    else
                    {
                        t_InEng[j * 4] = front_vu[i + 180];
                        InEng[j * 4] = vu[i + 180];
                        InEng_ac[j * 4] = ac[i + 180];
                        pos_InEng[j * 4] = i+180;
                    }

                    if (i + 360 >= kol_front_vu - 1)
                    {
                        t_InEng[j * 4 + 1] = front_vu[kol_front_vu - 2];
                        InEng[j * 4 + 1] = vu[kol_front_vu - 2];
                        InEng_ac[j * 4 + 1] = ac[kol_front_vu - 3];
                        pos_InEng[j * 4+1] = kol_front_vu - 2;
                    }
                    else
                    {
                        t_InEng[j * 4 + 1] = front_vu[i + 360];
                        InEng[j * 4 + 1] = vu[i + 360];
                        InEng_ac[j * 4 + 1] = ac[i + 360];
                        pos_InEng[j * 4 + 1] = i+360;
                    }

                    if (i + 360 + 180 >= kol_front_vu - 1)
                    {
                        InEng[j * 4 + 2] = vu[kol_front_vu - 2];
                        InEng_ac[j * 4 + 2] = ac[kol_front_vu - 2];
                        t_InEng[j * 4 + 2] = front_vu[kol_front_vu-3];
                        pos_InEng[j * 4 + 2] = kol_front_vu - 2;
                    }
                    else
                    {
                        InEng[j * 4 + 2] = vu[i + 360 + 180];
                        InEng_ac[j * 4 + 2] = ac[i + 360 + 180];
                        t_InEng[j * 4 + 2] = front_vu[i + 360 + 180];
                        pos_InEng[j * 4 + 2] = i+360+180;
                    }

                    if (i + 360 + 360 >= kol_front_vu - 1)
                    {
                        InEng[j * 4 + 3] = vu[kol_front_vu - 2];
                        InEng_ac[j * 4 + 3] = ac[kol_front_vu - 2];
                        t_InEng[j * 4 + 3] = front_vu[kol_front_vu - 3];
                        pos_InEng[j * 4 + 3] = kol_front_vu - 3;
                    }
                    else
                    {
                        InEng[j * 4 + 3] = vu[i + 360 + 360];
                        InEng_ac[j * 4 + 3] = ac[i + 360 + 360];
                        t_InEng[j * 4 + 3] = front_vu[i + 360 + 360];
                        pos_InEng[j * 4 + 3] = i+720;
                    }
                }
            }
            else
            {
                max_loc = null;
                min_loc = null;
                t_max_loc = null;
                t_min_loc = null;
            }
            

        }

        public int TypeSmooth = 0;
        public void Calculate2(ClassRecord __record, int in_with_diff, int in_OutStep, int in_InStep,int in_Number_zub,double in_gaussB,int in_TypeSmooth)
        {
            number_zub = in_Number_zub;
            with_diff = in_with_diff;
            InStep = in_InStep;
            OutStep = in_OutStep;
            record = __record;
            GetMedianVu();
            GetFrontVu();
            TypeSmooth = in_TypeSmooth;
            if (TypeSmooth==0)
                GetVu();
            else
                GetVuGauss(in_gaussB);
            GetAcceleration();
            
        }

        public void Calculate3(ClassRecord __record, int in_with_diff, int in_OutStep, int in_InStep, bool flagVu, int in_Number_zub, double in_gaussB, int in_TypeSmooth)
        {
            number_zub = in_Number_zub;
            with_diff = in_with_diff;
            InStep = in_InStep;
            OutStep = in_OutStep;
            record = __record;
            TypeSmooth = in_TypeSmooth;
            if(flagVu)
                if (TypeSmooth == 0)
                    GetVu();
                else
                    GetVuGauss(in_gaussB);
            GetAcceleration();
            
        }

        public void CalculateMaxMin()
        {
            GetMaxMin();
        }

        public void OutputData(string path)
        {
            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);

            string path_to_front,path_to_vu,path_to_acc,path_to_vu_ac,path_to_MaxMin,path_to_DegreeVu,path_to_DegreeAc;
            path_to_DegreeAc = path_to_DegreeVu = path_to_MaxMin = path_to_front = path_to_vu = path_to_acc = path_to_vu_ac = path;
            path_to_front += @"\\исходные данные.txt";
            path_to_vu += @"\\время - частота вращения.txt";
            path_to_DegreeVu += @"\\градусы - частота вращения.txt";
            path_to_acc += @"\\время - ускорение.txt";
            path_to_DegreeAc += @"\\градусы - ускорение.txt";
            path_to_vu_ac += @"\\частота вращения - ускорение.txt";
            path_to_MaxMin += @"\\Локальные минимумы и максимумы.txt";

            System.IO.StreamWriter file = new System.IO.StreamWriter(path_to_front);
            file.WriteLine(kol_front_vu);
            file.WriteLine("");
            int i;
            for (i = 0; i < kol_front_vu; i++)
                file.WriteLine(front_vu[i]);
            file.Close();

            file = new System.IO.StreamWriter(path_to_vu);
            file.WriteLine(kol_vu);
            file.WriteLine("");
            for (i = 0; i < kol_vu; i++)
                file.WriteLine(t_vu[i].ToString() + "\t" + vu[i].ToString() + "\n");
            file.Close();

            file = new System.IO.StreamWriter(path_to_DegreeVu);
            file.WriteLine(kol_vu);
            file.WriteLine("");
            for (i = 0; i < kol_vu; i++)
                file.WriteLine(degree_vu[i].ToString() + "\t" + vu[i].ToString() + "\n");
            file.Close();

            file = new System.IO.StreamWriter(path_to_acc);
            file.WriteLine(kol_ac);
            file.WriteLine("");
            for (i = 0; i < kol_ac; i++)
                file.WriteLine(t_ac[i].ToString() + "\t" + ac[i].ToString() + "\n");
            file.Close();

            file = new System.IO.StreamWriter(path_to_DegreeAc);
            file.WriteLine(kol_ac);
            file.WriteLine("");
            for (i = 0; i < kol_ac; i++)
                file.WriteLine(degree_ac[i].ToString() + "\t" + ac[i].ToString() + "\n");
            file.Close();

            file = new System.IO.StreamWriter(path_to_vu_ac);
            file.WriteLine(kol_ac);
            file.WriteLine("");
            for (i = 0; i < kol_ac; i++)
                file.WriteLine(vu_ac[i].ToString() + "\t" + ac[i].ToString() + "\n");
            file.Close();
        }

        public void OutputDataMaxMin(string path)
        {
            if (Directory.Exists(path) == false)
                Directory.CreateDirectory(path);

            string  path_to_MaxMin;
            path_to_MaxMin = path;

            path_to_MaxMin += @"\\Локальные минимумы и максимумы.txt";
            System.IO.StreamWriter file = new System.IO.StreamWriter(path_to_MaxMin);
            int i;
            if (min_loc != null)
            {
                file.WriteLine("Минимумы:");
                file.WriteLine(min_loc.Length);
                for (i = 0; i < min_loc.Length; i++)
                    file.WriteLine("t" + i.ToString() + "=" + t_min_loc[i].ToString() + "  " + min_loc[i].ToString());
            }

            if (max_loc != null)
            {
                file.WriteLine("Максимумы:");
                file.WriteLine(max_loc.Length);
                for (i = 0; i < max_loc.Length; i++)
                    file.WriteLine("t" + i.ToString() + "=" + t_max_loc[i].ToString() + "  " + max_loc[i].ToString());
                file.Close();
            }
        }
    }
    }

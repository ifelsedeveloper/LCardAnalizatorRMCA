using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Threading;

namespace Record
{
    class ClassRecord
    {
        public string title;//заголовок
        public string ExperimentTime;//время эксперимента
        public int NumberOfChannels;//количество каналов
        public int KadrsNumber;//число элементов записи
        public double InputRateInkHz;//входная частота в кГц
        public double InputTimeInSec;//время записи
        public int Decimation;
        public string Time_markers_scale;
        public double []time;//время 
        public double [][]ch;//записанные каналы

        public string[] head = new string[20];

        public bool[] flags_ch = new bool[4];

        

        public ClassRecord()
        {
            Thread.CurrentThread.CurrentCulture =new CultureInfo("en-CA");
            int j;
                for(j=0;j<4;j++)
                    flags_ch[j]=true;
        }

        public int ValidateRecord(string path)//возвращает 1 если запись корректна, 0 если нет
        {
            //открытие файла
            StreamReader file = new StreamReader(path, System.Text.Encoding.GetEncoding(1251));
            int j;
            int kol_d = 0;//количесво двоеточий
            int kol_n = 0;//количество строк

            string line;
            char d = ':';

            if (file != null)
            {
                //проверка первой строки
                line = file.ReadLine();
                if (line == null)
                {
                    file.Close();
                    return 0; 
                }
                else
                {
                    head[kol_n] = line;
                    kol_n++;
                }

                //проверка второй строки
                line = file.ReadLine();
                if (line == null) { file.Close(); return 0; }
                else
                {
                    head[kol_n] = line;
                    kol_d = kol_d + line.Split(d).Length-1;
                    kol_n++;
                }
                if (kol_d != 3) {file.Close();return 0;}

                //проверка оставшихся семи строк
                for (j = 0; j < 7; j++)
                {
                    line = file.ReadLine();
                    if (line == null) { file.Close(); return 0; }
                    else
                    {
                        head[kol_n] = line;
                        kol_d = kol_d+ line.Split(d).Length-1;
                        kol_n++;
                    }
                    if (kol_d != 4 + j) { file.Close(); return 0; }
                }
            }
            else { file.Close(); return 0; }

            file.Close();

            return 1;
        }

        public int ValidateRecordWindows7(string path)//возвращает 1 если запись корректна, 0 если нет
        {
            //открытие файла
            StreamReader file = new StreamReader(path, System.Text.Encoding.GetEncoding(1251));
            int j;
            int kol_d = 0;//количесво двоеточий
            int kol_n = 0;//количество строк

            string line;
            char d = ':';

            if (file != null)
            {
                //проверка первой строки
                line = file.ReadLine();
                if (line == null)
                {
                    file.Close();
                    return 0;
                }
                else
                {
                    head[kol_n] = line;
                    kol_n++;
                }

                //проверка второй строки
                line = file.ReadLine();
                if (line == null) { file.Close(); return 0; }
                else
                {
                    head[kol_n] = line;
                    kol_d = kol_d + line.Split(d).Length - 1;
                    kol_n++;
                }
                if (kol_d != 3) { file.Close(); return 0; }

                //проверка оставшихся 12 строк
                for (j = 0; j < 12; j++)
                {
                    line = file.ReadLine();
                    if (line == null) { file.Close(); return 0; }
                    else
                    {
                        head[kol_n] = line;
                        kol_d = kol_d + line.Split(d).Length - 1;
                        kol_n++;
                    }
                    
                }
                if (kol_d != 13) { file.Close(); return 0; }
            }
            else { file.Close(); return 0; }

            file.Close();

            return 1;
        }

        public int ReadRecordWindows7(string path)//считывает данные из текстового файла 
        {
            file_path = path;
            //открытие файла
            StreamReader file = new StreamReader(path, System.Text.Encoding.GetEncoding(1251));

            string line;
            string[] spline;
            string[] spline2 = new string[5];
            char d = ':', l = ' ';

            //ввод шапки
            if (file != null)
            {
                //первая строка заголовок
                title = file.ReadLine();
                head[0] = title;

                //вторая строка время эксперимента
                line = file.ReadLine();
                head[1] = line;
                ExperimentTime = line.Split(d)[1] + line.Split(d)[2] + line.Split(d)[3];

                //3 строка число кадров
                line = file.ReadLine();
                head[3] = line;
                KadrsNumber = Convert.ToInt32(line.Split(d)[1], info);

                //4 пустая строка
                line = file.ReadLine();
                //5 модуль
                line = file.ReadLine();
                //6 пустая строка
                line = file.ReadLine();

                //7 строка число каналов
                line = file.ReadLine();
                head[2] = line;
                NumberOfChannels = Convert.ToInt32(line.Split(d)[1], info);

                //8 строка частота в КГц
                line = file.ReadLine();
                head[4] = line;
                InputRateInkHz = Convert.ToDouble(line.Split(d)[1], info);

                //9 время записи
                line = file.ReadLine();
                head[5] = line;
                InputTimeInSec = Convert.ToDouble(line.Split(d)[1], info);

                //10 Decimation
                line = file.ReadLine();
                head[6] = line;
                Decimation = Convert.ToInt32(line.Split(d)[1], info);

                //11 формат данных
                line = file.ReadLine();

                //12 еденизы измерения времени
                line = file.ReadLine();
                head[7] = line;
                Time_markers_scale = line.Split(d)[1];
                

                //13 
                head[8] = file.ReadLine();

                //14
                head[9] = file.ReadLine();

                //15
                head[10] = file.ReadLine();

                //16
                head[11] = file.ReadLine();

                //17
                head[12] = file.ReadLine();
            }

            //ввод основного потока данных
            int i, j, s, k;
            time = new double[KadrsNumber];
            ch = new double[NumberOfChannels][];

            for (i = 0; i < NumberOfChannels; i++) ch[i] = new double[KadrsNumber];

            for (i = 0; i < KadrsNumber; i++)
            {
                line = file.ReadLine();
                spline = line.Split(l);
                for (k = 0, s = 0; k < spline.Count(); k++)
                    if (spline[k].Count() != 0)
                    {
                        spline2[s] = spline[k];
                        s++;
                    }

                time[i] = Convert.ToDouble(spline2[0], info);

                for (j = 0; j < NumberOfChannels; j++)
                    ch[j][i] = Convert.ToDouble(spline2[j + 1], info);


            }
            //закрытие файла

            file.Close();
            return 1;
        }
        CultureInfo info = new System.Globalization.CultureInfo("en-GB");
        public int ReadRecord(string path)//считывает данные из текстового файла 
        {
            file_path = path;
            //открытие файла
            StreamReader file = new StreamReader(path, System.Text.Encoding.GetEncoding(1251));

            string line;
            string[] spline;
            string[] spline2 = new string[5];
            char d = ':', l = ' ';
            
            //ввод шапки
            if (file != null)
            {
                //первая строка заголовок
                title = file.ReadLine();
                head[0] = title;

                //вторая строка время эксперимента
                line = file.ReadLine();
                head[1] = line;
                ExperimentTime = line.Split(d)[1] + line.Split(d)[2] + line.Split(d)[3];

                //третья строка число каналов
                line = file.ReadLine();
                head[2] = line;
                NumberOfChannels = Convert.ToInt32(line.Split(d)[1], info);

                //4 строка число кадров
                line = file.ReadLine();
                head[3] = line;
                KadrsNumber = Convert.ToInt32(line.Split(d)[1], info);

                //5 строка частота в КГц
                line = file.ReadLine();
                head[4] = line;
                InputRateInkHz = Convert.ToDouble(line.Split(d)[1], info);

                //6 время записи
                line = file.ReadLine();
                head[5] = line;
                InputTimeInSec = Convert.ToDouble(line.Split(d)[1], info);

                //7 Decimation
                line = file.ReadLine();
                head[6] = line;
                Decimation = Convert.ToInt32(line.Split(d)[1], info);

                //8 еденизы измерения времени
                line = file.ReadLine();
                Time_markers_scale = line.Split(d)[1];
                head[7] = line;

                //9 
                head[8] = file.ReadLine();

                //10
                head[9] = file.ReadLine();
            }

            //ввод основного потока данных
            int i,j,s,k;
            time = new double[KadrsNumber];
            ch = new double[NumberOfChannels][];

            for(i=0;i<NumberOfChannels;i++) ch[i]=new double[KadrsNumber];
            
            for (i = 0; i < KadrsNumber; i++)
            {
                line = file.ReadLine();
                spline = line.Split(l);
                for(k=0,s=0;k<spline.Count();k++)
                    if (spline[k].Count() != 0)
                    {
                        spline2[s] = spline[k];
                        s++;
                    }

                time[i] = Convert.ToDouble(spline2[0], info);

                for (j = 0; j < NumberOfChannels; j++)
                    ch[j][i] = Convert.ToDouble(spline2[j + 1], info);
                
                
            }
            //закрытие файла

            file.Close();
            return 1;
        }

        bool flag_head=false;
        string file_path;
        public string file_name;

        public bool ValidateReadHead(string path)
        {
            file_path = path;
            //открытие файла
            StreamReader file = new StreamReader(path, System.Text.Encoding.GetEncoding(1251));
            int j;
            int kol_d = 0;//количесво двоеточий
            int kol_n = 0;//количество строк

            string line;
            char d = ':';

            file_name = Path.GetFileName(path);

            if (file != null)
            {
                //проверка первой строки
                line = file.ReadLine();
                if (line == null)
                {
                    file.Close();
                    return false;
                }
                else
                {
                    head[kol_n] = line;
                    kol_n++;
                }

                //проверка второй строки
                line = file.ReadLine();
                if (line == null) { file.Close(); return false; }
                else
                {
                    head[kol_n] = line;
                    kol_d = kol_d + line.Split(d).Length - 1;
                    kol_n++;
                }
                if (kol_d != 3) { file.Close(); return false; }

                //проверка оставшихся семи строк
                for (j = 0; j < 7; j++)
                {
                    line = file.ReadLine();
                    if (line == null) { file.Close(); return false; }
                    else
                    {
                        head[kol_n] = line;
                        kol_d = kol_d + line.Split(d).Length - 1;
                        kol_n++;
                    }
                    if (kol_d != 4 + j) { file.Close(); return false; }
                }
            }
            else { file.Close(); return false; }

            file.Close();

            //создание заголовка файла
            //первая строка заголовок
            title=head[0];

            //вторая строка время эксперимента
            line = head[1];
            ExperimentTime = line.Split(d)[1] + ":" +line.Split(d)[2];

            //третья строка число каналов
            line = head[2];
            NumberOfChannels = Convert.ToInt32(line.Split(d)[1]);

            //4 строка число кадров
            line = head[3];
            KadrsNumber = Convert.ToInt32(line.Split(d)[1]);

            //5 строка частота в КГц
            line = head[4];
            InputRateInkHz = Convert.ToDouble(line.Split(d)[1]);

            //6 время записи
            line=head[5];
            InputTimeInSec = Convert.ToDouble(line.Split(d)[1]);

            //7 Decimation
            line=head[6];
            Decimation = Convert.ToInt32(line.Split(d)[1]);

            //8 еденизы измерения времени
            line = head[7];
            Time_markers_scale = line.Split(d)[1];

            flag_head = true;

            return true;
        }
        public bool ValidateReadHeadWindows7(string path)
        {
            file_path = path;
            //открытие файла
            StreamReader file = new StreamReader(path, System.Text.Encoding.GetEncoding(1251));
            int j;
            int kol_d = 0;//количесво двоеточий
            int kol_n = 0;//количество строк

            string line;
            char d = ':';

            file_name = Path.GetFileName(path);

            if (file != null)
            {
                //проверка первой строки
                line = file.ReadLine();
                if (line == null)
                {
                    file.Close();
                    return false;
                }
                else
                {
                    head[kol_n] = line;
                    kol_n++;
                }

                //проверка второй строки
                line = file.ReadLine();
                if (line == null) { file.Close(); return false; }
                else
                {
                    head[kol_n] = line;
                    kol_d = kol_d + line.Split(d).Length - 1;
                    kol_n++;
                }
                if (kol_d != 3) { file.Close(); return false; }

                //проверка оставшихся 12 строк
                for (j = 0; j < 12; j++)
                {
                    line = file.ReadLine();
                    if (line == null) { file.Close(); return false; }
                    else
                    {
                        head[kol_n] = line;
                        kol_d = kol_d + line.Split(d).Length - 1;
                        kol_n++;
                    }

                }
                if (kol_d != 13) { file.Close(); return false; }
            }
            else { file.Close(); return false; }

            file.Close();

            //создание заголовка файла
            //первая строка заголовок
            title = head[0];

            //вторая строка время эксперимента
            line = head[1];
            ExperimentTime = line.Split(d)[1]+':' + line.Split(d)[2];

            //3 строка число кадров
            line = head[2];
            KadrsNumber = Convert.ToInt32(line.Split(d)[1]);

            //4 пустая строка
            
            //5 модуль
            
            //6 пустая строка
            

            //7 строка число каналов
            line = head[6];
            NumberOfChannels = Convert.ToInt32(line.Split(d)[1]);

            //8 строка частота в КГц
            line = head[7];
            InputRateInkHz = Convert.ToDouble(line.Split(d)[1]);

            //9 время записи
            line = head[8];
            InputTimeInSec = Convert.ToDouble(line.Split(d)[1]);

            //10 Decimation
            line = head[9];
            Decimation = Convert.ToInt32(line.Split(d)[1]);

            //11 формат данных

            //12 еденизы измерения времени
            line =head[11];
            Time_markers_scale = line.Split(d)[1];

            //13 
            
            //14
            
            //15
            
            //16
            
            //17
            

            flag_head = true;

            return true;
        }
        static string tagExperimentTime = "Experiment Time : ";
        static string tagNumberOfFrames = "Number of frames: ";
        static string tagKadrsNumber = "Kadrs Number :";
        static string tagNumberOfChannels = "Number Of Channels :";
        static string tagInputRateInkHz = "Input Rate In kHz:";
        static string tagInputTimeInSec = "Input Time In Sec:";
        static string tagDataFormat = "Data Format:";
        static string tagTimeMarkersScale = "Time markers scale:";
        static string tagDataAsTimeSequence = "Data as Time Sequence:";
  
        public bool ValidateReadHeadCommonFormat(string path)
        {
            try
            {
                file_path = path;
                //открытие файла
                StreamReader file = new StreamReader(path, System.Text.Encoding.GetEncoding(1251));
                string data50Lines = "";

                for (int i = 0; i < 50; i++)
                    data50Lines += file.ReadLine();

                file.Close();

                if (data50Lines.Contains(tagExperimentTime) &&
                    (data50Lines.Contains(tagNumberOfFrames) || data50Lines.Contains(tagKadrsNumber)) &&
                    data50Lines.Contains(tagNumberOfChannels) &&
                    data50Lines.Contains(tagInputRateInkHz) &&
                    data50Lines.Contains(tagInputTimeInSec) &&
                    data50Lines.Contains(tagTimeMarkersScale) &&
                    data50Lines.Contains(tagDataAsTimeSequence)) return true;

                return false;
            }
            catch
            {
                return false;
            }
        }

        string findLineString(string[] lines,string searchStr)
        {
            string res = "";
            for (int i = 0; i < lines.Count(); i++)
            {
                if (lines[i].Contains(searchStr)) return lines[i];
            }

            return res;
        }

        int findLineNumber(string[] lines, string searchStr, int startSearch = 0)
        {
            int res = -1;
            for (int i = startSearch; i < lines.Count(); i++)
            {
                if (lines[i].Contains(searchStr)) return i;
            }

            return res;
        }

        public bool ReadInCommonFormat(string path)
        {
            file_path = path;
            file_name = Path.GetFileName(path);
            //открытие файла
            StreamReader file = new StreamReader(path, System.Text.Encoding.GetEncoding(1251));

            int numberLines = 50;
            string[] linesData = new string[numberLines];
            for (int i = 0; i < numberLines; i++) linesData[i] = file.ReadLine();
            char d = ':', l = ' '; ;
            string line;
            //вторая строка время эксперимента
            line = findLineString(linesData, tagExperimentTime);
            if (!string.IsNullOrEmpty(line))
            {
                ExperimentTime = line.Split(d)[1] + line.Split(d)[2] + line.Split(d)[3];
            }
            else return false;

            //третья строка число каналов
            line = findLineString(linesData, tagNumberOfChannels);
            if (!string.IsNullOrEmpty(line))
            {
                NumberOfChannels = Convert.ToInt32(line.Split(d)[1], info);
            }
            else return false;
            //4 строка число кадров
            line = findLineString(linesData, tagNumberOfFrames);
            if (string.IsNullOrEmpty(line)) line = findLineString(linesData, tagKadrsNumber);
            if (!string.IsNullOrEmpty(line))
            {
                KadrsNumber = Convert.ToInt32(line.Split(d)[1], info);
            }
            else return false;
            //5 строка частота в КГц
            line = findLineString(linesData, tagInputRateInkHz);
            if (!string.IsNullOrEmpty(line))
            {
                InputRateInkHz = Convert.ToDouble(line.Split(d)[1], info);
            }
            else return false;
            //6 время записи
            line = findLineString(linesData, tagInputTimeInSec);
            if (!string.IsNullOrEmpty(line))
            {
                InputTimeInSec = Convert.ToDouble(line.Split(d)[1], info);
            }
            else return false;
            //8 еденизы измерения времени
            line = findLineString(linesData, tagTimeMarkersScale);
            if (!string.IsNullOrEmpty(line))
            {
                Time_markers_scale = line.Split(d)[1];
            }
            else return false;
            
            //находим начало записи
            int startLine = 0;

            startLine = findLineNumber(linesData, tagDataAsTimeSequence);

            startLine = findLineNumber(linesData, "0.00", startLine);
            //
            file.Close();

            //считываем данные
            file = new StreamReader(path, System.Text.Encoding.GetEncoding(1251));
            for (int i = 0; i < startLine; i++) file.ReadLine();
            //ввод основного потока данных
            int j, s, k;
            string[] spline;
            string[] spline2 = new string[5];
            time = new double[KadrsNumber];
            ch = new double[NumberOfChannels][];

            for (int i = 0; i < NumberOfChannels; i++) ch[i] = new double[KadrsNumber];

            for (int i = 0; i < KadrsNumber; i++)
            {
                line = file.ReadLine();
                spline = line.Split(l);
                for (k = 0, s = 0; k < spline.Count(); k++)
                    if (spline[k].Count() != 0)
                    {
                        spline2[s] = spline[k];
                        s++;
                    }

                time[i] = Convert.ToDouble(spline2[0], info);

                for (j = 0; j < NumberOfChannels; j++)
                    ch[j][i] = Convert.ToDouble(spline2[j + 1], info);
            }
            //for (int i = 1; i < ch[2].Count()-1; i++)
            //{
            //    ch[i] = ch[i-1]*0.85 + ch[i]
            //}
            //DateTime time1, time2;
            //time1 = DateTime.Now;
            //double sum_numerator, val;
            //int count = 4;
            //for (int i = count; i < ch[2].Count() - count; i++)
            //{
            //    sum_numerator = 0;
            //    for (j = i - count; j < i + count; j++)
            //    {
            //        sum_numerator += ch[2][j];
            //    }
            //    val = sum_numerator / (count * 2);
            //    if (ch[2][i] < val * 2.5) ch[2][i] = val;
            //}
            //time2 = DateTime.Now;
            //double seconds = (time2 - time1).TotalSeconds;
            file.Close();
            return true;
        }
        public double gaussB = 0.02;
        double p1 = 1.0 / Math.Sqrt(2 * Math.PI) * 0.37;
        double p2 = -1.0 / (2.0 * 0.37 * 0.37);
        double gaussK(double t)
        {
            double res;
            res = p1 * Math.Exp(t * t * p2);
            return res;
        }

        public bool ValidateReadHeadInCommonFormat(string path)
        {
            try
            {
                file_path = path;
                file_name = Path.GetFileName(path);
                //открытие файла
                StreamReader file = new StreamReader(path, System.Text.Encoding.GetEncoding(1251));

                int numberLines = 50;
                string[] linesData = new string[numberLines];
                for (int i = 0; i < numberLines; i++) linesData[i] = file.ReadLine();
                char d = ':', l = ' '; ;
                string line;
                //вторая строка время эксперимента
                line = findLineString(linesData, tagExperimentTime);
                if (!string.IsNullOrEmpty(line))
                {
                    ExperimentTime = line.Split(d)[1] + line.Split(d)[2] + line.Split(d)[3];
                }
                else return false;

                //третья строка число каналов
                line = findLineString(linesData, tagNumberOfChannels);
                if (!string.IsNullOrEmpty(line))
                {
                    NumberOfChannels = Convert.ToInt32(line.Split(d)[1], info);
                }
                else return false;
                //4 строка число кадров
                line = findLineString(linesData, tagNumberOfFrames);
                if (string.IsNullOrEmpty(line)) line = findLineString(linesData, tagKadrsNumber);
                if (!string.IsNullOrEmpty(line))
                {
                    KadrsNumber = Convert.ToInt32(line.Split(d)[1], info);
                }
                else return false;
                //5 строка частота в КГц
                line = findLineString(linesData, tagInputRateInkHz);
                if (!string.IsNullOrEmpty(line))
                {
                    InputRateInkHz = Convert.ToDouble(line.Split(d)[1], info);
                }
                else return false;
                //6 время записи
                line = findLineString(linesData, tagInputTimeInSec);
                if (!string.IsNullOrEmpty(line))
                {
                    InputTimeInSec = Convert.ToDouble(line.Split(d)[1], info);
                }
                else return false;
                //8 еденизы измерения времени
                line = findLineString(linesData, tagTimeMarkersScale);
                if (!string.IsNullOrEmpty(line))
                {
                    Time_markers_scale = line.Split(d)[1];
                }
                else return false;

                //находим начало записи
                int startLine = 0;

                startLine = findLineNumber(linesData, tagDataAsTimeSequence);

                startLine = findLineNumber(linesData, "0.00", startLine);
                //
                file.Close();
                return true;
            }
            catch { return false; }
        }
    }



}

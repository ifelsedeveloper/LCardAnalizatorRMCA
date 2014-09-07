using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// для работы с библиотекой OpenGL 
using Tao.OpenGl;
// для работы с библиотекой FreeGLUT 
using Tao.FreeGlut;
// для работы с элементом управления SimpleOpenGLControl 
using Tao.Platform.Windows;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace WindowsFormsGraphickOpenGL
{
    class ClassOpenGLGraphick2D
    {
        //данные оси ox
        double max_x;
        double min_x;
        double hx;
        int nx;
        double div_x, pow_x;
        int idx;
        double ddx;
        double prx;
        public int width;
        public string name_x;
        int dec_x;
        double sup_max_x;
        double sup_min_x;

        //данные оси oy
        double max_y;
        double min_y;
        double hy;
        int ny;
        double div_y, pow_y;
        int idy;
        double pry;
        double ddy;
        public int height;
        public string name_y;
        int dec_y;

        //данные для построения графиков
        double[] x;
        double[][] y;
        int[] m;
        string[] names;
        int n=0;


        public bool[] flags_ch = new bool[4];

        public ClassOpenGLGraphick2D()
        {
            idx  = 90; //отступ для надписей 30 пикселей
            idy = 60;
            int i;
            for (i = 0; i < 4; i++)
            {
                colors_func[i] = new float[3];
                flags_ch[i] = true;
            }


            colors_func[0][0] = (float)(Color.DarkGreen.R/255.0); colors_func[0][1] = (float)(Color.DarkGreen.G/255.0); colors_func[0][2] = (float)(Color.DarkGreen.B/255.0);

            colors_func[1][0] = 255;
            
            
            colors_func[2][2] = 255;
            colors_func[3][0] = 124; colors_func[3][1] = 65; colors_func[3][2] = 0;
        }

        public void SetData(double[] in_x, double[][] in_y, int[] in_m, string[] in_names, int in_n)
        {
            x = in_x;
            y = in_y;
            m = in_m;
            names = in_names;
            n = in_n;
        }

        //вспомгательные функции ось X
        public void init_X(int in_width,string in_name_x)
        {
            if (n > 0)
            {
                name_x = in_name_x;
                width = in_width;
                max_x = x.Max();
                min_x = x.Min();

                pow_x = Math.Floor(Math.Log10(Math.Abs(max_x - min_x)));
                double imax, imin, idiv;
                idiv = Math.Pow(10, pow_x);
                if (pow_x < 0)
                {
                    int round;
                    double newdiv;
                    if (Math.Abs(pow_x) <= 15)
                    {
                        imax = Math.Round(max_x, Convert.ToInt32(Math.Abs(pow_x)));
                        imin = Math.Round(min_x, Convert.ToInt32(Math.Abs(pow_x)));
                    }
                    else
                    {
                        round = Convert.ToInt32(Math.Abs(pow_x)) % 15;
                        newdiv = Math.Pow(10, Convert.ToInt32(pow_x) - Convert.ToInt32(pow_x) % 15);
                        imax = Math.Round(max_x / newdiv, round) * newdiv;
                        imin = Math.Round(min_x / newdiv, round) * newdiv;

                    }
                }
                else
                {
                    imax = Math.Floor(max_x / idiv) * idiv;
                    imin = Math.Floor(min_x / idiv) * idiv;
                }


                while (imax < max_x)
                    imax = imax + idiv;

                while (imin > min_x)
                    imin = imin - idiv;

                max_x = imax;
                min_x = imin;

                div_x = max_x - min_x;

                hx = idiv;

                nx = Convert.ToInt32(div_x / hx);


                if (max_x > (nx + 2) * hx)
                {
                    double pow_max;
                    pow_max = Math.Floor(Math.Log10(Math.Abs(max_x)));

                    if ((pow_x > 0 && pow_max > 0) || (pow_x < 0 && pow_max < 0))
                        dec_x = Convert.ToInt32(Math.Abs(pow_x - pow_max));
                    else
                        dec_x = Convert.ToInt32(Math.Abs(pow_x) + Math.Abs(pow_max));
                }
                else
                    dec_x = 1;

                if (dec_x == 0) dec_x = 1;

                if (nx == 1 || nx == 2 || nx == 3) { nx = nx * 2; hx = hx / 2; }

                prx = div_x / (width - 2 * idx);

                ddx = prx * idx;
            }
        }

        public void init_XW(int in_width)
        {
            if (n > 0)
            {
                width = in_width;
                prx = div_x / (width - 2 * idx);
                ddx = prx * idx;
            }
        }

        public void init_X_zoom()
        {
            pow_x = Math.Floor(Math.Log10(Math.Abs(max_x - min_x)));
            double imax, imin, idiv;
            idiv = Math.Pow(10, pow_x);
            if (pow_x < 0)
            {
                int round;
                double newdiv;
                if (Math.Abs(pow_x) <= 15)
                {
                    imax = Math.Round(max_x, Convert.ToInt32(Math.Abs(pow_x)));
                    imin = Math.Round(min_x, Convert.ToInt32(Math.Abs(pow_x)));
                }
                else
                {
                    round = Convert.ToInt32(Math.Abs(pow_x)) % 15;
                    newdiv = Math.Pow(10, Convert.ToInt32(pow_x) - Convert.ToInt32(pow_x) % 15);
                    imax = Math.Round(max_x / newdiv, round) * newdiv;
                    imin = Math.Round(min_x / newdiv, round) * newdiv;

                }
            }
            else
            {
                imax = Math.Floor(max_x / idiv) * idiv;
                imin = Math.Floor(min_x / idiv) * idiv;
            }


            while (imax < max_x)
                imax = imax + idiv;

            while (imin > min_x)
                imin = imin - idiv;

            max_x = imax;
            min_x = imin;

            div_x = max_x - min_x;

            hx = idiv;

            nx = Convert.ToInt32(div_x / hx);


            if (max_x > (nx + 2) * hx)
            {
                double pow_max;
                pow_max = Math.Floor(Math.Log10(Math.Abs(max_x)));

                if ((pow_x > 0 && pow_max > 0) || (pow_x < 0 && pow_max < 0))
                    dec_x = Convert.ToInt32(Math.Abs(pow_x - pow_max));
                else
                    dec_x = Convert.ToInt32(Math.Abs(pow_x) + Math.Abs(pow_max));
            }
            else
                dec_x = 1;

            if (dec_x == 0) dec_x = 1;

            if (nx == 1 || nx == 2 || nx == 3) { nx = nx * 2; hx = hx / 2; }

            prx = div_x / (width - 2 * idx);

            ddx = prx * idx;
        }

        //вспомгательные функции ось Y
        public void init_Y(int in_height, string in_name_y)
        {
            if (n > 0)
            {
                int j;
                name_y = in_name_y;
                height = in_height;
                if (flags_ch[0])
                {
                    max_y = y[0].Max();
                    min_y = y[0].Min();
                }
                for (j = 1; j < n; j++)
                {
                    if (flags_ch[j])
                    {
                        if (max_y < y[j].Max()) max_y = y[j].Max();
                        if (min_y > y[j].Min()) min_y = y[j].Min();
                    }
                }

                for (j = 0; j < n; j++)
                    if (flags_ch[j]) break;

                if (j == n)
                {
                    max_y = y[0].Max();
                    min_y = y[0].Min();
                }

                pow_y = Math.Floor(Math.Log10(Math.Abs(max_y - min_y)));
                double imax, imin, idiv;

                idiv = Math.Pow(10, pow_y);

                if (pow_y < 0)
                {
                    int round;
                    double newdiv;
                    if (Math.Abs(pow_y) <= 15)
                    {
                        imax = Math.Round(max_y, Convert.ToInt32(Math.Abs(pow_y)));
                        imin = Math.Round(min_y, Convert.ToInt32(Math.Abs(pow_y)));
                    }
                    else
                    {
                        round = Convert.ToInt32(Math.Abs(pow_y)) % 15;
                        newdiv = Math.Pow(10, Convert.ToInt32(pow_y) - Convert.ToInt32(pow_y) % 15);
                        imax = Math.Round(max_y / newdiv, round) * newdiv;
                        imin = Math.Round(min_y / newdiv, round) * newdiv;

                    }
                }
                else
                {
                    imax = Math.Floor(max_y / idiv) * idiv;
                    imin = Math.Floor(min_y / idiv) * idiv;
                }


                while (imax < max_y)
                    imax = imax + idiv;

                while (imin > min_y)
                    imin = imin - idiv;

                max_y = imax;
                min_y = imin;

                div_y = max_y - min_y;

                hy = idiv;

                if (max_y > (ny + 2) * hy)
                {
                    double pow_max;
                    pow_max = Math.Floor(Math.Log10(Math.Abs(max_y)));

                    if ((pow_y > 0 && pow_max > 0) || (pow_x < 0 && pow_max < 0))
                        dec_y = Convert.ToInt32(Math.Abs(pow_y - pow_max));
                    else
                        dec_y = Convert.ToInt32(Math.Abs(pow_y) + Math.Abs(pow_max));
                }
                else
                    dec_y = 1;

                if (dec_y == 0) dec_y = 1;

                ny = Convert.ToInt32(div_y / hy);
                if (ny == 1 || ny == 2 || ny == 3) { ny = ny * 2; hy = hy / 2; }

                pry = div_y / (height - 2 * idy);

                ddy = pry * idy;
            }
        }
        public void init_YH(int in_height)
        {
            if (n > 0)
            {
                height = in_height;
                pry = div_y / (height - 2 * idy);
                ddy = pry * idy;
            }
        }

        public void init_Y_update()
        {
            int j;
            if (flags_ch[0])
            {
                max_y = y[0].Max();
                min_y = y[0].Min();
            }
            for (j = 1; j < n; j++)
            {
                if (flags_ch[j])
                {
                    if (max_y < y[j].Max()) max_y = y[j].Max();
                    if (min_y > y[j].Min()) min_y = y[j].Min();
                }
            }

            for (j = 0; j < n; j++)
                if (flags_ch[j]) break;

            if (j == n)
            {
                max_y = y[0].Max();
                min_y = y[0].Min();
            }
            
            pow_y = Math.Floor(Math.Log10(Math.Abs(max_y - min_y)));
            double imax, imin, idiv;

            idiv = Math.Pow(10, pow_y);

            if (pow_y < 0)
            {
                int round;
                double newdiv;
                if (Math.Abs(pow_y) <= 15)
                {
                    imax = Math.Round(max_y, Convert.ToInt32(Math.Abs(pow_y)));
                    imin = Math.Round(min_y, Convert.ToInt32(Math.Abs(pow_y)));
                }
                else
                {
                    round = Convert.ToInt32(Math.Abs(pow_y)) % 15;
                    newdiv = Math.Pow(10, Convert.ToInt32(pow_y) - Convert.ToInt32(pow_y) % 15);
                    imax = Math.Round(max_y / newdiv, round) * newdiv;
                    imin = Math.Round(min_y / newdiv, round) * newdiv;

                }
            }
            else
            {
                imax = Math.Floor(max_y / idiv) * idiv;
                imin = Math.Floor(min_y / idiv) * idiv;
            }


            while (imax < max_y)
                imax = imax + idiv;

            while (imin > min_y)
                imin = imin - idiv;

            max_y = imax;
            min_y = imin;

            div_y = max_y - min_y;

            hy = idiv;

            if (max_y > (ny + 2) * hy)
            {
                double pow_max;
                pow_max = Math.Floor(Math.Log10(Math.Abs(max_y)));

                if ((pow_y > 0 && pow_max > 0) || (pow_x < 0 && pow_max < 0))
                    dec_y = Convert.ToInt32(Math.Abs(pow_y - pow_max));
                else
                    dec_y = Convert.ToInt32(Math.Abs(pow_y) + Math.Abs(pow_max));
            }
            else
                dec_y = 1;

            if (dec_y == 0) dec_y = 1;

            ny = Convert.ToInt32(div_y / hy);
            if (ny == 1 || ny == 2 || ny == 3) { ny = ny * 2; hy = hy / 2; }

            pry = div_y / (height - 2 * idy);

            ddy = pry * idy;
        }

        public void Init()
        {
            
            // очитка окна 
            Gl.glClearColor(255, 255, 255, 1);

            // установка порта вывода в соотвествии с размерами элемента anT 
            Gl.glViewport(0, 0, width, height);

            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            
            Glu.gluOrtho2D(min_x-ddx, max_x+ddx,min_y-ddy , max_y+ddy);

            //Glu.gluOrtho2D(0, 30, 0, 30);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            // очищаем буфер цвета 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glLoadIdentity();
        }

        public void DrawSystem()
        {
            if (n > 0 )
            {
                // очищаем буфер цвета 
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

                // очищаем текущую матрицу 
                Gl.glLoadIdentity();

                // устанавливаем текущий цвет - красный 
                Gl.glColor3i(0, 0, 0);

                //отрисовка ограничивающего прямоугольника

                Gl.glBegin(Gl.GL_LINE);
                Gl.glVertex2d(min_x, min_y);
                Gl.glVertex2d(max_x, min_y);
                Gl.glVertex2d(max_x, max_y);
                Gl.glVertex2d(min_x, max_y);
                Gl.glEnd();


                int i, j;
                double x1, x2, y1, y2;
                double hx5, hy5;

                //чёрточки жирные
                Gl.glLineWidth(1);
                Gl.glBegin(Gl.GL_LINES);

                //ось oy
                hx5 = hx / 5.0;
                hy5 = hy / 5.0;
                //левая часть прямоугольника
                x1 = x2 = min_x;
                double lsx;
                lsx = 11 * prx;
                x1 = x1 - lsx / 2;
                x2 = x2 + lsx / 2;

                Gl.glVertex2d((x1 + x2) / 2, min_y);
                Gl.glVertex2d((x1 + x2) / 2, max_y);

                for (j = 0; j < ny + 1; j++)
                {
                    //крупная чёрточка
                    y2 = y1 = min_y + j * hy;
                    Gl.glVertex2d(x1, y1);
                    Gl.glVertex2d(x2, y2);

                    //мелкие чёрточки
                    if (j < ny)
                        for (i = 1; i < 5; i++)
                        {
                            y2 = y1 = min_y + j * hy + i * hy5;
                            Gl.glVertex2d(min_x + lsx / 4, y1);
                            Gl.glVertex2d(min_x - lsx / 4, y2);
                        }



                }

                //правая часть прямоугольника
                x1 = x2 = max_x;
                x2 = x2 - lsx / 2;

                Gl.glVertex2d(x1, min_y);
                Gl.glVertex2d(x1, max_y);

                for (j = 0; j < ny + 1; j++)
                {
                    y2 = y1 = min_y + j * hy;
                    Gl.glVertex2d(x1, y1);
                    Gl.glVertex2d(x2, y2);

                    //мелкие чёрточки
                    if (j < ny)
                        for (i = 1; i < 5; i++)
                        {
                            y2 = y1 = min_y + j * hy + i * hy5;
                            Gl.glVertex2d(max_x - lsx / 4, y1);
                            Gl.glVertex2d(max_x, y2);
                        }
                }

                //ось ox

                //нижняя часть прямоугольника
                double lsy;
                lsy = pry * 11;
                y1 = y2 = min_y;
                y1 = y1 - lsy / 2;
                y2 = y2 + lsy / 2;
                Gl.glVertex2d(min_x, (y1 + y2) / 2);
                Gl.glVertex2d(max_x, (y1 + y2) / 2);
                for (j = 0; j < nx + 1; j++)
                {
                    x2 = x1 = min_x + j * hx;
                    Gl.glVertex2d(x1, y1);
                    Gl.glVertex2d(x2, y2);

                    //мелкие чёрточки
                    if (j < nx)
                        for (i = 1; i < 5; i++)
                        {
                            x2 = x1 = min_x + j * hx + i * hx5;
                            Gl.glVertex2d(x1, min_y - lsy / 4);
                            Gl.glVertex2d(x2, min_y + lsy / 4);
                        }

                }

                //верхняя часть прямоугольника
                y1 = y2 = max_y;
                y2 = y2 - lsy / 2;
                Gl.glVertex2d(min_x, max_y);
                Gl.glVertex2d(max_x, max_y);
                for (j = 0; j < nx + 1; j++)
                {
                    x2 = x1 = min_x + j * hx;
                    Gl.glVertex2d(x1, y1);
                    Gl.glVertex2d(x2, y2);
                    //мелкие чёрточки
                    if (j < nx)
                        for (i = 1; i < 5; i++)
                        {
                            x2 = x1 = min_x + j * hx + i * hx5;
                            Gl.glVertex2d(x1, max_y - lsy / 2);
                            Gl.glVertex2d(x2, max_y);
                        }
                }

                Gl.glEnd();

                //надписи
                //ось oy
                string value;
                int hmark, lmark;
                hmark = Glut.glutBitmapHeight(Glut.GLUT_BITMAP_HELVETICA_18);

                x1 = min_x;
                for (j = 0; j < ny + 1; j++)
                {
                    //значение
                    y1 = min_y + j * hy - 5 * pry;
                    value = (Math.Round((min_y + j * hy), Convert.ToInt32(Math.Abs(pow_x) + 1))).ToString();
                    lmark = Glut.glutBitmapLength(Glut.GLUT_BITMAP_HELVETICA_18, value);
                    Gl.glRasterPos2d(x1 - lmark * prx - 6 * prx, y1);    // Set the position for the string (text)
                    Glut.glutBitmapString(Glut.GLUT_BITMAP_HELVETICA_18, value);
                }
                //подпись оси oy
                //y1 = min_y + j * hy - 5 * pry;
                //value = name_y;
                //lmark = Glut.glutBitmapLength(Glut.GLUT_BITMAP_HELVETICA_18, value);
                //Gl.glRasterPos2d(x1 - lmark * prx - 6 * prx, y1);    // Set the position for the string (text)
                //Glut.glutBitmapString(Glut.GLUT_BITMAP_TIMES_ROMAN_24, value);

                creatLabelY();
                LoadTexture(labelY);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
                Gl.glEnable(Gl.GL_TEXTURE_2D);
                y1 = min_y + j * hy - hy + 31 * pry;

                Gl.glColor3f(255, 255, 255);
                Gl.glBegin(Gl.GL_QUADS);
                Gl.glTexCoord2d(1, 0); Gl.glVertex2d(x1 - ddx + 128 * prx, y1 + 32 * pry);
                Gl.glTexCoord2d(1, 1); Gl.glVertex2d(x1 - ddx + 128 * prx, y1);
                Gl.glTexCoord2d(0, 1); Gl.glVertex2d(x1 - ddx, y1);
                Gl.glTexCoord2d(0, 0); Gl.glVertex2d(x1 - ddx, y1 + 32 * pry);
                Gl.glEnd();
                Gl.glDisable(Gl.GL_TEXTURE_2D);


                //ось ox
                Gl.glColor3f(0, 0, 0);
                y1 = min_y - hmark * pry;
                for (j = 0; j < nx + 1; j++)
                {
                    //значение
                    value = (Math.Round((min_x + j * hx), Convert.ToInt32(Math.Abs(pow_x) + 1))).ToString();
                    lmark = Glut.glutBitmapLength(Glut.GLUT_BITMAP_HELVETICA_18, value);
                    x1 = min_x + j * hx - 0.5 * lmark * prx;
                    Gl.glRasterPos2d(x1, y1);    // Set the position for the string (text)
                    Glut.glutBitmapString(Glut.GLUT_BITMAP_HELVETICA_18, value);
                }

                //подпись оси oх
                //creatLabelX();
                //value = name_x;
                //y1 = min_y - (hmark + Glut.glutBitmapHeight(Glut.GLUT_BITMAP_TIMES_ROMAN_24)) * pry;
                //x1 = (min_x+max_x)/2 - 7.5 * value.Count() * prx;
                //Gl.glRasterPos2d(x1, y1);    // Set the position for the string (text)
                //Glut.glutBitmapString(Glut.GLUT_BITMAP_TIMES_ROMAN_24, value);

                creatLabelX();
                LoadTexture(labelX);
                Gl.glEnable(Gl.GL_TEXTURE_2D);

                y1 = min_y - hmark * pry - 33 * pry;
                x1 = (min_x + max_x) / 2;

                Gl.glColor3f(255, 255, 255);
                Gl.glBegin(Gl.GL_QUADS);
                Gl.glTexCoord2d(1, 0); Gl.glVertex2d(x1 + 64 * prx, y1 + 31 * pry);
                Gl.glTexCoord2d(1, 1); Gl.glVertex2d(x1 + 64 * prx, y1);
                Gl.glTexCoord2d(0, 1); Gl.glVertex2d(x1 - 55 * prx, y1);
                Gl.glTexCoord2d(0, 0); Gl.glVertex2d(x1 - 55 * prx, y1 + 31 * pry);
                Gl.glEnd();
                Gl.glDisable(Gl.GL_TEXTURE_2D);
                //labelX.Save("lx.bmp");
            }

        }

        float[][] colors_func=new float[4][];

        public void DrawFunc()
        {
            if (n > 0)
            {
                int i, j;

                // очищаем текущую матрицу 
                Gl.glLoadIdentity();
                bool flag = false;

                for (j = 0; j < n; j++)
                {
                    if (flags_ch[j])
                    {
                        // устанавливаем текущий цвет 
                        Gl.glColor3f(colors_func[j][0], colors_func[j][1], colors_func[j][2]);
                        //Gl.glColor3i(0, 100, 0);
                        // активируем режим рисования линий, на основе 
                        // последовательного соединения всех вершин в отрезки 
                        Gl.glBegin(Gl.GL_LINE_STRIP);
                        // первая вершина будет находиться в начале координат 

                        for (i = 0; i < m[j] - 1; i++)
                        {
                            if (x[i] >= max_x)
                            {
                                flag = true;
                                break;
                            }

                            if (x[i] >= min_x)
                            {
                                Gl.glVertex2d(x[i], y[j][i]);
                                Gl.glVertex2d(x[i + 1], y[j][i + 1]);
                            }

                        }

                        // завершаем режим рисования 
                        Gl.glEnd();
                        if (j == n - 1 && flag) break;
                    }
                }
            }
            DrawEventsForChannel();

        }

        void DrawEvents()
        {
            if (vinf!=null && vinf.Length > 0)
            {
                int i, j;

                // очищаем текущую матрицу 
                Gl.glLoadIdentity();
                bool flag = false;

                for (j = 0; j < n; j++)
                {
                    if (flags_ch[j])
                    {
                        // устанавливаем текущий цвет 
                        Gl.glColor3f(colors_func[j][0], colors_func[j][1], colors_func[j][2]);
                        //Gl.glColor3i(0, 100, 0);
                        // активируем режим рисования линий, на основе 
                        // последовательного соединения всех вершин в отрезки 
                        
                        // первая вершина будет находиться в начале координат 

                        for (i = 0; i<vinf.Length; i++)
                        {
                            double x1, x2, y1, y2;
                            x1 = tinf[i] - 3 * prx;
                            x2 = tinf[i] + 3 * prx;
                            y1 = vinf[i] - 3 * pry;
                            y2 = vinf[i] + 3 * pry;

                            if (x1 >= min_x && x2 <= max_x)
                            {
                                Gl.glBegin(Gl.GL_LINE_LOOP);
                                Gl.glVertex2d(x1, y1);
                                Gl.glVertex2d(x2, y1);
                                Gl.glVertex2d(x2, y2);
                                Gl.glVertex2d(x1, y2);
                                // завершаем режим рисования 
                                Gl.glEnd();
                            }
                        }

                        
                        if (j == n - 1 && flag) break;
                    }
                }
            }
        }
        int n_chevent;
        public void DrawEvents(double[] tinf, double[] vinf, int n_chevent)
        {
            this.tinf = tinf;
            this.vinf = vinf;
            this.n_chevent = n_chevent;

            Gl.glClearColor(255, 255, 255, 1);

            // установка порта вывода в соотвествии с размерами элемента anT 
            Gl.glViewport(0, 0, width, height);

            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Glu.gluOrtho2D(min_x - ddx, max_x + ddx, min_y - ddy, max_y + ddy);

            //Glu.gluOrtho2D(0, 30, 0, 30);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            // очищаем буфер цвета 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glLoadIdentity();

            //Init();
            DrawSystem();
            DrawFunc();
            // дожидаемся конца визуализации кадра 
            Gl.glFlush();


        }

        void DrawEventsForChannel()
        {
            if (vinf != null && vinf.Length > 0)
            {
                int i, j;

                // очищаем текущую матрицу 
                Gl.glLoadIdentity();
                bool flag = false;

                for (j = 0; j < n; j++)
                {
                    if (n_chevent == j)
                    {
                        // устанавливаем текущий цвет 
                        Gl.glColor3f(colors_func[(j + 1) % 4][0], colors_func[(j + 1) % 4][1], colors_func[(j + 1) % 4][2]);
                        Gl.glLineWidth(3);
                        //Gl.glColor3i(0, 100, 0);
                        // активируем режим рисования линий, на основе 
                        // последовательного соединения всех вершин в отрезки 

                        // первая вершина будет находиться в начале координат 

                        for (i = 0; i < vinf.Length; i++)
                        {
                            double x1, x2, y1, y2;
                            x1 = tinf[i] - 6 * prx;
                            x2 = tinf[i] + 6 * prx;
                            y1 = vinf[i] - 6 * pry;
                            y2 = vinf[i] + 6 * pry;
                            if (x1 >= min_x && x2 <= max_x)
                            {
                                Gl.glBegin(Gl.GL_LINE_LOOP);
                                Gl.glVertex2d(x1, y1);
                                Gl.glVertex2d(x2, y1);
                                Gl.glVertex2d(x2, y2);
                                Gl.glVertex2d(x1, y2);
                                // завершаем режим рисования 
                                Gl.glEnd();
                            }
                        }


                        if (j == n - 1 && flag) break;
                    }
                }
            }
        }

        Bitmap labelY=new Bitmap(128,32);

        public void creatLabelY()
        {
            Graphics G = Graphics.FromImage(labelY);
            // Create font and brush.
            Font drawFont = new Font("Times New Roman", 20);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Create point for upper-left corner of drawing.
            PointF drawPoint = new PointF(0.0F, 0.0F);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DisplayFormatControl;

            G.FillRectangle(Brushes.White,0,0,128,32);
            // Draw string to screen.
            G.DrawString(name_y, drawFont, drawBrush, drawPoint, drawFormat);


            //labelY.Save("ly.bmp");
        }


        Bitmap labelX = new Bitmap(256, 64);

        public void creatLabelX()
        {
            Graphics G = Graphics.FromImage(labelX);
            // Create font and brush.
            Font drawFont = new Font("Times New Roman", 40);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Create point for upper-left corner of drawing.
            PointF drawPoint = new PointF(0.0F, 0.0F);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DisplayFormatControl;

            G.FillRectangle(Brushes.White, 0, 0, 256, 64);
            // Draw string to screen.
            G.DrawString(name_x, drawFont, drawBrush, drawPoint, drawFormat);

            //labelX.Save("lx.bmp");
        }

        public void DrawGraphick(
            double[] in_x,string in_name_x, double[][] in_y, string in_name_y,int[] in_m, string[] in_names, int in_n,
            int Width,int Height
            )
        {
            SetData( in_x,  in_y,  in_m,  in_names, in_n);
            init_X(Width, in_name_x);
            sup_max_x = max_x;
            sup_min_x = min_x;
            v_max.Clear();
            v_min.Clear();
            my_scale = 1;
            init_Y(Height, in_name_y);
            Init();
            DrawSystem();
            DrawFunc();
           
            // дожидаемся конца визуализации кадра 
            Gl.glFlush();
        }

        double[] tsup;
        double[] vsup;
        double[] tinf;
        double[] vinf;
        public void DrawGraphickWithEventMaxMin(
            double[] in_x, string in_name_x, double[][] in_y, string in_name_y, int[] in_m, string[] in_names, int in_n,
            int Width, int Height, double[] in_tsup, double[] in_vsup, double[] in_tinf, double[] in_vinf
            )
        {
            SetData(in_x, in_y, in_m, in_names, in_n);
            init_X(Width, in_name_x);
            sup_max_x = max_x;
            sup_min_x = min_x;
            v_max.Clear();
            v_min.Clear();
            my_scale = 1;
            init_Y(Height, in_name_y);
            Init();
            DrawSystem();
            DrawFunc();
            tsup = in_tsup;
            vsup = in_vsup;

            tinf = in_tinf;
            vinf = in_vinf;
            DrawEvents();
            // дожидаемся конца визуализации кадра 
            Gl.glFlush();
        }

        public void UpdateGraphick()
        {
            init_Y_update();
            // очитка окна 
            Gl.glClearColor(255, 255, 255, 1);

            // установка порта вывода в соотвествии с размерами элемента anT 
            Gl.glViewport(0, 0, width, height);

            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Glu.gluOrtho2D(min_x - ddx, max_x + ddx, min_y - ddy, max_y + ddy);

            //Glu.gluOrtho2D(0, 30, 0, 30);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            // очищаем буфер цвета 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glLoadIdentity();

            
            DrawSystem();
            DrawFunc();
            // дожидаемся конца визуализации кадра 
            Gl.glFlush();
        }

        int my_scale = 1;
        Stack<double> v_max=new Stack<double>();
        Stack<double> v_min = new Stack<double>();

        public void Zoom_plus()
        {
            if (my_scale < 512)
            {
                my_scale = my_scale * 2;
                v_min.Push(min_x);
                v_max.Push(max_x);
                diff_right = 0;
                max_x = min_x + div_x / 2;


                init_X_zoom();
                // очитка окна 
                Gl.glClearColor(255, 255, 255, 1);

                // установка порта вывода в соотвествии с размерами элемента anT 
                Gl.glViewport(0, 0, width, height);

                // настройка проекции 
                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glLoadIdentity();

                Glu.gluOrtho2D(min_x - ddx, max_x + ddx, min_y - ddy, max_y + ddy);

                //Glu.gluOrtho2D(0, 30, 0, 30);
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                // очищаем буфер цвета 
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                Gl.glLoadIdentity();

                //Init();
                DrawSystem();
                DrawFunc();
                // дожидаемся конца визуализации кадра 
                Gl.glFlush();
                //Gl.glFlush();
            }
        }

        public void UpdateZoom()
        {
            // установка порта вывода в соотвествии с размерами элемента anT 
            Gl.glViewport(0, 0, width, height);

            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Glu.gluOrtho2D(min_x - ddx, max_x + ddx, min_y - ddy, max_y + ddy);

            //Glu.gluOrtho2D(0, 30, 0, 30);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            // очищаем буфер цвета 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glLoadIdentity();
            DrawSystem();
            DrawFunc();
            //Glut.glutSwapBuffers();
            Gl.glFlush();
        }

        public void Zoom_minus()
        {
            if (my_scale > 1)
            {
                my_scale = my_scale / 2;
                double lmax, lmin;
                if (v_max.Count() > 0)
                {
                    lmax = v_max.Pop();
                    lmin = v_min.Pop();
                    if (lmax + diff_right <= sup_max_x + x[m.Min() - 1] - x[m.Min() - 2])
                    {
                        max_x = lmax + diff_right;
                        min_x = lmin + diff_right;
                    }
                    else
                    {
                        max_x = sup_max_x;
                        min_x = sup_max_x-(lmax-lmin);
                        if (min_x < sup_min_x-hx)
                        {
                            min_x = sup_min_x;
                            diff_right = 0;
                        }

                    }
                    init_X_zoom();
                    // очитка окна 
                    Gl.glClearColor(255, 255, 255, 1);

                    // установка порта вывода в соотвествии с размерами элемента anT 
                    Gl.glViewport(0, 0, width, height);

                    // настройка проекции 
                    Gl.glMatrixMode(Gl.GL_PROJECTION);
                    Gl.glLoadIdentity();

                    Glu.gluOrtho2D(min_x - ddx, max_x + ddx, min_y - ddy, max_y + ddy);

                    //Glu.gluOrtho2D(0, 30, 0, 30);
                    Gl.glMatrixMode(Gl.GL_MODELVIEW);
                    // очищаем буфер цвета 
                    Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                    Gl.glLoadIdentity();

                    //Init();
                    DrawSystem();
                    DrawFunc();
                    // дожидаемся конца визуализации кадра 
                    Gl.glFlush();
                    //Gl.glFlush();
                }
            }
            
        }

        public void Zoom_full()
        {

            my_scale = 1;
            double lmax, lmin;
            v_max.Clear();
            v_min.Clear();
            max_x = sup_max_x;
            min_x=sup_min_x;

            init_X_zoom();
            // очитка окна 
            Gl.glClearColor(255, 255, 255, 1);

            // установка порта вывода в соотвествии с размерами элемента anT 
            Gl.glViewport(0, 0, width, height);

            // настройка проекции 
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Glu.gluOrtho2D(min_x - ddx, max_x + ddx, min_y - ddy, max_y + ddy);

            //Glu.gluOrtho2D(0, 30, 0, 30);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            // очищаем буфер цвета 
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glLoadIdentity();

            //Init();
            DrawSystem();
            DrawFunc();
            // дожидаемся конца визуализации кадра 
            Gl.glFlush();
            //Gl.glFlush();

        }

        double diff_right=0;

        public void Move_right()
        {
            if (max_x <= sup_max_x)
            {
                min_x = min_x + hx;
                max_x = max_x + hx;
                diff_right += hx;
                min_x = Math.Round(min_x, Convert.ToInt32(Math.Abs(pow_x) + 1));
                max_x = Math.Round(max_x, Convert.ToInt32(Math.Abs(pow_x) + 1));
                // очитка окна 
                Gl.glClearColor(255, 255, 255, 1);

                // установка порта вывода в соотвествии с размерами элемента anT 
                Gl.glViewport(0, 0, width, height);

                // настройка проекции 
                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glLoadIdentity();

                Glu.gluOrtho2D(min_x - ddx, max_x + ddx, min_y - ddy, max_y + ddy);

                //Glu.gluOrtho2D(0, 30, 0, 30);
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                // очищаем буфер цвета 
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                Gl.glLoadIdentity();

                //Init();
                DrawSystem();
                DrawFunc();
                // дожидаемся конца визуализации кадра 
                Gl.glFlush();
            }

        }

        public void Move_left()
        {
            if (min_x>= sup_min_x)
            {
                min_x = min_x - hx;
                max_x = max_x - hx;
                diff_right -= hx;

                // очитка окна 
                Gl.glClearColor(255, 255, 255, 1);

                // установка порта вывода в соотвествии с размерами элемента anT 
                Gl.glViewport(0, 0, width, height);

                // настройка проекции 
                Gl.glMatrixMode(Gl.GL_PROJECTION);
                Gl.glLoadIdentity();

                Glu.gluOrtho2D(min_x - ddx, max_x + ddx, min_y - ddy, max_y + ddy);

                //Glu.gluOrtho2D(0, 30, 0, 30);
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                // очищаем буфер цвета 
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                Gl.glLoadIdentity();

                //Init();
                DrawSystem();
                DrawFunc();
                // дожидаемся конца визуализации кадра 
                Gl.glFlush();
            }

        }



        public int get_max_move()
        {
            return Math.Abs(Convert.ToInt32( (sup_max_x- sup_min_x) / hx -(max_x-min_x)/hx));
        }

        public int get_current_pos()
        {
            return Convert.ToInt32(min_x / hx);
        }

        public static void LoadTexture(Bitmap bmp)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB, data.Width, data.Height, 0,
                Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, data.Scan0);
            bmp.UnlockBits(data);
        }

        public Bitmap GetBitmap()
        {
            Gl.glFlush();
            Bitmap bitmap = new Bitmap(width, height);
            BitmapData bitmapData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            Gl.glReadBuffer(Gl.GL_FRONT);
            Gl.glReadPixels(0, 0, bitmap.Width, bitmap.Height,
                Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);
            bitmap.UnlockBits(bitmapData);
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return bitmap;
        }

        public Bitmap GetBitmapDiff()
        {
            Gl.glFlush();
            Bitmap bitmap = new Bitmap(width, height-2);
            BitmapData bitmapData = bitmap.LockBits(
                new Rectangle(0, 2, bitmap.Width, bitmap.Height-2),
                ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            Gl.glReadBuffer(Gl.GL_FRONT);
            Gl.glReadPixels(0, 2, bitmap.Width, bitmap.Height-2,
                Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapData.Scan0);
            bitmap.UnlockBits(bitmapData);
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return bitmap;
        }
    }
}

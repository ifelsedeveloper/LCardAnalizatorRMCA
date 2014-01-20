using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZedGraph;

namespace LCardAnalizator.graphicks
{
    static public class ZedGraphHelper
    {
        public static void CreateGraph(ref ZedGraphControl zgc, 
            ref double[] x, 
            string label_x, 
            ref double[] y, 
            string label_y, 
            int n, 
            string name, 
            string title)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;
            // Set the Titles
            myPane.Title.Text = title;
            myPane.XAxis.Title.Text = label_x;
            myPane.YAxis.Title.Text = label_y;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            myPane.CurveList.Clear();

            // Make up some data arrays based on the Sine function

            // Включаем отображение сетки напротив крупных рисок по оси Y
            myPane.YAxis.MajorGrid.IsVisible = true;


            // Включаем отображение сетки напротив мелких рисок по оси X
            myPane.YAxis.MinorGrid.IsVisible = true;

            LineItem myCurve = myPane.AddCurve(name, x, y, System.Drawing.Color.Blue, SymbolType.None);

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zgc.ZoomOutAll(myPane);
            zgc.AxisChange();
            zgc.Invalidate();
        }


        public static void CreateGraph(ref ZedGraphControl zgc,
            ref double[] x,
            string label_x,
            ref double[] y,
            string label_y,
            int n,
            ref double[] xPoints,
            ref double[] yPoints,
            string name,
            string title)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;
            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            myPane.CurveList.Clear();

            {
                LineItem myCurveSup = myPane.AddCurve("События", xPoints, yPoints, System.Drawing.Color.Red, SymbolType.Circle);

                // !!!
                // У кривой линия будет невидимой
                myCurveSup.Line.IsVisible = false;

                // !!!
                // Цвет заполнения отметок (ромбиков) - колубой
                myCurveSup.Symbol.Fill.Color = System.Drawing.Color.Red;

                // !!!
                // Тип заполнения - сплошная заливка
                myCurveSup.Symbol.Fill.Type = FillType.Solid;

                // !!!
                // Размер ромбиков
                myCurveSup.Symbol.Size = 7;
            }

            // Set the Titles
            myPane.Title.Text = title;
            myPane.XAxis.Title.Text = label_x;
            myPane.YAxis.Title.Text = label_y;
            // Make up some data arrays based on the Sine function

            // Включаем отображение сетки напротив крупных рисок по оси Y
            myPane.YAxis.MajorGrid.IsVisible = true;


            // Включаем отображение сетки напротив мелких рисок по оси X
            myPane.YAxis.MinorGrid.IsVisible = true;

            LineItem myCurve = myPane.AddCurve(name, x, y, System.Drawing.Color.Blue, SymbolType.None);

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zgc.ZoomOutAll(myPane);
            zgc.AxisChange();
            zgc.Invalidate();
        }

        static public void CreateGraphPercent(ref ZedGraphControl zgc, 
            ref double[] x, 
            string label_x, 
            ref double[] y1, 
            ref double[] y2, 
            string label_y, 
            int n, 
            string name, 
            string title)
        {
            double maxY1 = y1[0], minY1 = y1[0], maxY2 = y2[0], minY2 = y2[0];

            for (int i = 0; i < n; i++)
            {
                if (y1[i] > maxY1) maxY1 = y1[i];
                if (y1[i] < minY1) minY1 = y1[i];
                if (y2[i] > maxY2) maxY2 = y2[i];
                if (y2[i] < minY2) minY2 = y2[i];
            }

            double[] py1 = new double[n];
            double[] py2 = new double[n];

            double max = 100, min = -100;
            for (int i = 0; i < n; i++)
            {
                if (minY1 < 0)
                {
                    if (y1[i] >= 0)
                        py1[i] = max * y1[i] / maxY1;
                    else
                        py1[i] = min * y1[i] / minY1;
                }

                if (minY2 < 0)
                {
                    if (y2[i] >= 0)
                        py2[i] = max * y2[i] / maxY2;
                    else
                        py2[i] = min * y2[i] / minY2;
                }

                if (y2[i] >= 0 && minY2 > 0)
                    py2[i] = max * (y2[i] - minY2) / (maxY2 - minY2);

                if (y1[i] >= 0 && minY1 > 0)
                    py1[i] = max * (y1[i] - minY1) / (maxY1 - minY1);

            }

            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;
            
            // Set the Titles
            myPane.Title.Text = title;
            myPane.XAxis.Title.Text = label_x;
            myPane.YAxis.Title.Text = label_y;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            myPane.CurveList.Clear();

            // Make up some data arrays based on the Sine function

            // Включаем отображение сетки напротив крупных рисок по оси Y
            myPane.YAxis.MajorGrid.IsVisible = true;


            // Включаем отображение сетки напротив мелких рисок по оси X
            myPane.YAxis.MinorGrid.IsVisible = true;

            LineItem myCurve1 = myPane.AddCurve(name, x, py1, System.Drawing.Color.Green, SymbolType.None);
            LineItem myCurve2 = myPane.AddCurve(name, x, py2, System.Drawing.Color.Blue, SymbolType.None);

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zgc.ZoomOutAll(myPane);
            zgc.AxisChange();
            zgc.Invalidate();

        }

        public static void CreateGraphMaxMin(ref ZedGraphControl zgc, 
            ref double[] x, 
            string label_x, 
            ref double[] y, 
            string label_y, 
            int n, 
            string name, 
            string title, 
            double[] in_tsup, 
            double[] in_vsup, 
            double[] in_tinf, 
            double[] in_vinf, 
            double[] t_InEng, 
            double[] InEng)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;
            // Set the Titles
            myPane.Title.Text = title;
            myPane.XAxis.Title.Text = label_x;
            myPane.YAxis.Title.Text = label_y;

            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            myPane.CurveList.Clear();

            // Make up some data arrays based on the Sine function

            // Включаем отображение сетки напротив крупных рисок по оси Y
            myPane.YAxis.MajorGrid.IsVisible = true;


            // Включаем отображение сетки напротив мелких рисок по оси X
            myPane.YAxis.MinorGrid.IsVisible = true;

            LineItem myCurve = myPane.AddCurve(name, x, y, System.Drawing.Color.Green, SymbolType.None);


            // !!! Минимум
            // Создадим кривую с названием "Scatter".
            // Обводка ромбиков будут рисоваться голубым цветом (Color.Blue),
            // Опорные точки - ромбики (SymbolType.Diamond)
            LineItem myCurveInf = myPane.AddCurve("Минимум", in_tinf, in_vinf, System.Drawing.Color.Blue, SymbolType.Diamond);

            // !!!
            // У кривой линия будет невидимой
            myCurveInf.Line.IsVisible = false;

            // !!!
            // Цвет заполнения отметок (ромбиков) - колубой
            myCurveInf.Symbol.Fill.Color = System.Drawing.Color.Blue;

            // !!!
            // Тип заполнения - сплошная заливка
            myCurveInf.Symbol.Fill.Type = FillType.None;

            // !!!
            // Размер ромбиков
            myCurveInf.Symbol.Size = 7;
            //..............................................

            // !!! Максимум
            // Создадим кривую с названием "Scatter".
            // Обводка ромбиков будут рисоваться голубым цветом (Color.Blue),
            // Опорные точки - ромбики (SymbolType.Diamond)
            LineItem myCurveSup = myPane.AddCurve("Максимум", in_tsup, in_vsup, System.Drawing.Color.Red, SymbolType.Circle);

            // !!!
            // У кривой линия будет невидимой
            myCurveSup.Line.IsVisible = false;

            // !!!
            // Цвет заполнения отметок (ромбиков) - колубой
            myCurveSup.Symbol.Fill.Color = System.Drawing.Color.Blue;

            // !!!
            // Тип заполнения - сплошная заливка
            myCurveSup.Symbol.Fill.Type = FillType.None;

            // !!!
            // Размер ромбиков
            myCurveSup.Symbol.Size = 7;
            //..............................................


            // !!! Промежуточные точки
            // Создадим кривую с названием "Scatter".
            // Обводка ромбиков будут рисоваться голубым цветом (Color.Blue),
            // Опорные точки - ромбики (SymbolType.Diamond)
            LineItem myCurveMid = myPane.AddCurve("", t_InEng, InEng, System.Drawing.Color.Black, SymbolType.Square);

            // !!!
            // У кривой линия будет невидимой
            myCurveMid.Line.IsVisible = false;

            // !!!
            // Цвет заполнения отметок (ромбиков) - колубой
            myCurveMid.Symbol.Fill.Color = System.Drawing.Color.Blue;

            // !!!
            // Тип заполнения - сплошная заливка
            myCurveMid.Symbol.Fill.Type = FillType.None;

            // !!!
            // Размер ромбиков
            myCurveMid.Symbol.Size = 7;
            //..............................................

            // Tell ZedGraph to refigure the
            // axes since the data have changed

            zgc.AxisChange();
            zgc.Invalidate();
        }

        public static void AppendEventsToGraph(ref ZedGraphControl zgc, 
            double[] in_tsup, 
            double[] in_vsup, 
            double[] in_tinf, 
            double[] in_vinf, 
            double[] t_InEng, 
            double[] InEng, 
            string name_minum)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;
            if (in_tinf != null)
            {
                // !!! Минимум
                // Создадим кривую с названием "Scatter".
                // Обводка ромбиков будут рисоваться голубым цветом (Color.Blue),
                // Опорные точки - ромбики (SymbolType.Diamond)
                LineItem myCurveInf = myPane.AddCurve(name_minum, in_tinf, in_vinf, System.Drawing.Color.Blue, SymbolType.Diamond);

                // !!!
                // У кривой линия будет невидимой
                myCurveInf.Line.IsVisible = false;

                // !!!
                // Цвет заполнения отметок (ромбиков) - колубой
                myCurveInf.Symbol.Fill.Color = System.Drawing.Color.Blue;

                // !!!
                // Тип заполнения - сплошная заливка
                myCurveInf.Symbol.Fill.Type = FillType.None;

                // !!!
                // Размер ромбиков
                myCurveInf.Symbol.Size = 7;
                //..............................................
            }

            if (in_tsup != null)
            {
                // !!! Максимум
                // Создадим кривую с названием "Scatter".
                // Обводка ромбиков будут рисоваться голубым цветом (Color.Blue),
                // Опорные точки - ромбики (SymbolType.Diamond)
                LineItem myCurveSup = myPane.AddCurve("Максимум", in_tsup, in_vsup, System.Drawing.Color.Red, SymbolType.Circle);

                // !!!
                // У кривой линия будет невидимой
                myCurveSup.Line.IsVisible = false;

                // !!!
                // Цвет заполнения отметок (ромбиков) - колубой
                myCurveSup.Symbol.Fill.Color = System.Drawing.Color.Blue;

                // !!!
                // Тип заполнения - сплошная заливка
                myCurveSup.Symbol.Fill.Type = FillType.None;

                // !!!
                // Размер ромбиков
                myCurveSup.Symbol.Size = 7;
                //..............................................
            }

            if (t_InEng != null)
            {
                // !!! Промежуточные точки
                // Создадим кривую с названием "Scatter".
                // Обводка ромбиков будут рисоваться голубым цветом (Color.Blue),
                // Опорные точки - ромбики (SymbolType.Diamond)
                LineItem myCurveMid = myPane.AddCurve("", t_InEng, InEng, System.Drawing.Color.Black, SymbolType.Square);

                // !!!
                // У кривой линия будет невидимой
                myCurveMid.Line.IsVisible = false;

                // !!!
                // Цвет заполнения отметок (ромбиков) - колубой
                myCurveMid.Symbol.Fill.Color = System.Drawing.Color.Blue;

                // !!!
                // Тип заполнения - сплошная заливка
                myCurveMid.Symbol.Fill.Type = FillType.None;

                // !!!
                // Размер ромбиков
                myCurveMid.Symbol.Size = 7;
                //..............................................
            }
            // Tell ZedGraph to refigure the
            // axes since the data have changed

            zgc.AxisChange();
            zgc.Invalidate();
        }

        public static void AppendEventsToGraph(ref ZedGraphControl zgc,
            double[] x,
            double[] y)
        {
            if (y != null)
            {
                // Получим панель для рисования
                GraphPane pane = zgc.GraphPane;

                // Создадим список точек
                PointPairList list = new PointPairList();

                // Заполняем список точек
                for (int i = 0; i < x.Length; i++)
                {
                    list.Add(x[i], y[i]);
                }

                // !!!
                // Создадим кривую с названием "Scatter".
                // Обводка ромбиков будут рисоваться голубым цветом (Color.Blue),
                // Опорные точки - ромбики (SymbolType.Diamond)
                
                LineItem myCurve = pane.AddCurve("События", list, System.Drawing.Color.Red, SymbolType.Diamond);

                // !!!
                // У кривой линия будет невидимой
                myCurve.Line.IsVisible = false;

                // !!!
                // Цвет заполнения отметок (ромбиков) - колубой
                myCurve.Symbol.Fill.Color = System.Drawing.Color.Red;

                // !!!
                // Тип заполнения - сплошная заливка
                myCurve.Symbol.Fill.Type = FillType.Solid;

                // !!!
                // Размер ромбиков
                myCurve.Symbol.Size = 20;

                // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
                // В противном случае на рисунке будет показана только часть графика, 
                // которая умещается в интервалы по осям, установленные по умолчанию
                zgc.AxisChange();

                // Обновляем график
                zgc.Invalidate();
            }
        }

        public static void AppendEventsToGraph(ref ZedGraphControl zgc,
        double[] x,
        double[] y,
            string name, SymbolType typeSymbol, System.Drawing.Color color)
        {
            if (y != null)
            {
                // Получим панель для рисования
                GraphPane pane = zgc.GraphPane;

                // Создадим список точек
                PointPairList list = new PointPairList();

                // Заполняем список точек
                for (int i = 0; i < x.Length; i++)
                {
                    list.Add(x[i], y[i]);
                }

                // !!!
                // Создадим кривую с названием "Scatter".
                // Обводка ромбиков будут рисоваться голубым цветом (Color.Blue),
                // Опорные точки - ромбики (SymbolType.Diamond)

                LineItem myCurve = pane.AddCurve(name, list, color, typeSymbol);

                // !!!
                // У кривой линия будет невидимой
                myCurve.Line.IsVisible = false;

                // !!!
                // Цвет заполнения отметок (ромбиков) - колубой
                myCurve.Symbol.Fill.Color = color;

                // !!!
                // Тип заполнения - сплошная заливка
                myCurve.Symbol.Fill.Type = FillType.None;

                // !!!
                // Размер ромбиков
                myCurve.Symbol.Size = 10;

                // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
                // В противном случае на рисунке будет показана только часть графика, 
                // которая умещается в интервалы по осям, установленные по умолчанию
                zgc.AxisChange();

                // Обновляем график
                zgc.Invalidate();
            }
        }
    }
}

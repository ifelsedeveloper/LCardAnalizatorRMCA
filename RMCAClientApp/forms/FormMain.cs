﻿﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Management;
using System.Globalization;
using System.Reflection;
using System.Collections.Generic;
using System.Threading;
using DW.RtfWriter;
using Record;
using System.Threading.Tasks;
// для работы с библиотекой OpenGL 
using Tao.OpenGl;
// для работы с библиотекой FreeGLUT 
using Tao.FreeGlut;
// для работы с элементом управления SimpleOpenGLControl 
using Tao.Platform.Windows;
using ZedGraph;
using Microsoft.Office.Interop.Word;
using System.Xml;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using LCardAnalizator.graphicks;
using LCardAnalizator;
using LCardAnalizator.calculation;
using LCardAnalizator.forms.reports.graphicks;


namespace WindowsFormsGraphickOpenGL
{

    public partial class FormMain : Form
    {
        ClassRecord record = new ClassRecord();
        bool flag_record=false;
        bool flag_graph = false;
        bool flag_calc = false;
        ClassOpenGLGraphick2D cl2d=new ClassOpenGLGraphick2D();
        ClassCalc calc_record;
        string home_directory = @"";
        int TypeAlgorithmFindingPeriods = 0;
        static long state = 0;

        FormProgressBar progressForm = null;

        public int with_diff_parm = 5;
        int number_zub = 360;

        int width_w=1374;
        int height_w=772;

        public FormMain()
        {

            InitializeComponent();
            LoadParametrs();

            toolStripTextBoxParam.TextBox.Text = with_diff_parm.ToString();
            toolStripTextBoxOutStep.TextBox.Text = OutStep.ToString();
            toolStripTextBoxInStep.TextBox.Text = InStep.ToString();
            OpenGlControlGraph.InitializeContexts();

            // инициализация Glut
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH  );

        }



        private void FormMain_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            LoadFileList(explorerTreeMain.SelectedPath);
            ShowFileList();
            pictureBoxGraphData.Hide();
            OpenGlControlGraph.Invalidate();

            dataGridViewFiles.ColumnHeadersHeight = dataGridViewFiles.ColumnHeadersHeight * 2;

            removePages();
            
            pos_splitX2=pos_splitX1 = splitContainerMain.SplitterDistance;
            cl2d.width = OpenGlControlGraph.Width;
            cl2d.height = OpenGlControlGraph.Height;
            ClearDrawArea();

        }

        public void removePages()
        {
            tabControlMain.TabPages.Remove(tabPageTimeAcceleration);
            tabControlMain.TabPages.Remove(tabPageSpeedAcceleration);
            tabControlMain.TabPages.Remove(tabPageReport);
            tabControlMain.TabPages.Remove(tabPageTimeSpeed);
            tabControlMain.TabPages.Remove(tabPageTimeSpeedAcc);
            tabControlMain.TabPages.Remove(tabPageDegreeSpeed);
            tabControlMain.TabPages.Remove(tabPageDegreeAcc);
            tabControlMain.TabPages.Remove(tabPageFilter);
        }

        int posX_window;
        int posY_window;
        int split_tree_file_list;
        int height_split_tree_file_list;
        int split_main;
        int width_split_main;
        int TypeSmooth=0;

        #region Save and Load Parametrs

        void LoadParametrs()
        {
            FileInfo aFile = new FileInfo("config");
            if (aFile.Exists == false)
            {
                goto M1;
            }
            else 
            {
                try
                {
                    System.IO.StreamReader fconfig = new System.IO.StreamReader(@"config", System.Text.Encoding.GetEncoding("windows-1251"));

                    //дериктория
                    home_directory = fconfig.ReadLine();
                    DirectoryInfo di = new DirectoryInfo(home_directory);
                    if (di.Exists)
                        explorerTreeMain.SelectedPath = home_directory;
                    else
                        explorerTreeMain.SelectedPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    explorerTreeMain.Refresh();
                    string sfile;

                    //позиция+разрешение
                    sfile = fconfig.ReadLine();
                    if (sfile == null) goto M1;
                    posX_window = Convert.ToInt32(sfile.Split(' ')[0]);
                    posY_window = Convert.ToInt32(sfile.Split(' ')[1]);
                    width_w = Convert.ToInt32(sfile.Split(' ')[2]);
                    height_w = Convert.ToInt32(sfile.Split(' ')[3]);
                    bool resolut = false;

                    if (posX_window >= 0 && (posX_window + width_w) <= Screen.PrimaryScreen.WorkingArea.Width && posY_window >= 0 && (posY_window + height_w) <= Screen.PrimaryScreen.WorkingArea.Height)
                    {
                        this.Size = new System.Drawing.Size(width_w, height_w);
                        this.Location = new System.Drawing.Point(posX_window, posY_window);
                        resolut = true;
                    }
                    else
                    {
                        posX_window = posY_window = 0;
                        width_w = Screen.PrimaryScreen.WorkingArea.Width;
                        height_w = Screen.PrimaryScreen.WorkingArea.Height;
                        this.Size = new System.Drawing.Size(width_w, height_w);
                    }

                    //настройки меню
                    sfile = fconfig.ReadLine();
                    if (sfile == null) goto M1;
                    bool[] bmn = new bool[8];
                    string[] smn;
                    smn = sfile.Split(' ');

                    int i;
                    for (i = 0; i < 8; i++)
                        bmn[i] = Convert.ToBoolean(smn[i]);

                    mnuSA.Checked = bmn[0];
                    mnuST.Checked = bmn[1];
                    mnuSD.Checked = bmn[2];
                    mnuSN.Checked = bmn[3];
                    mnuSF.Checked = bmn[4];
                    mnuSFExperimentTime.Checked = bmn[5];
                    mnuSFKadrsNumber.Checked = bmn[6];
                    mnuSFInputTimeInSec.Checked = bmn[7];

                    explorerTreeMain.ShowAddressbar = mnuSA.Checked;
                    explorerTreeMain.ShowToolbar = mnuST.Checked;
                    explorerTreeMain.ShowMyDocuments = mnuSD.Checked;
                    explorerTreeMain.ShowMyNetwork = mnuSN.Checked;
                    explorerTreeMain.ShowMyFavorites = mnuSF.Checked;

                    fKadrsNumber = mnuSFKadrsNumber.Checked;
                    if (!fKadrsNumber) fNumCol--;
                    fInputTimeInSec = mnuSFInputTimeInSec.Checked;
                    if (!fInputTimeInSec) fNumCol--;
                    fExperimentTime = mnuSFExperimentTime.Checked;
                    if (!fExperimentTime) fNumCol--;
                    //разделитель дерево-список файлов
                    sfile = fconfig.ReadLine();
                    if (sfile == null) goto M1;
                    split_tree_file_list = Convert.ToInt32(sfile.Split(' ')[0]);
                    height_split_tree_file_list = Convert.ToInt32(sfile.Split(' ')[1]);
                    if (resolut)
                        splitContainerTreeFilePath.SplitterDistance = split_tree_file_list;
                    else
                    {
                        double value;
                        value = (double)split_tree_file_list / (double)height_split_tree_file_list * (double)splitContainerTreeFilePath.Height;
                        splitContainerTreeFilePath.SplitterDistance = Convert.ToInt32(value);
                    }

                    //разделитель главный
                    sfile = fconfig.ReadLine();
                    if (sfile == null) goto M1;
                    split_main = Convert.ToInt32(sfile.Split(' ')[0]);
                    width_split_main = Convert.ToInt32(sfile.Split(' ')[1]);
                    if (resolut)
                        splitContainerMain.SplitterDistance = split_main;
                    else
                    {
                        double value;
                        value = (double)split_main / (double)width_split_main * (double)splitContainerMain.Width;
                        splitContainerMain.SplitterDistance = Convert.ToInt32(value);
                    }

                    //тип сглаживания
                    sfile = fconfig.ReadLine();
                    if (sfile == null) goto M1;
                    TypeSmooth = Convert.ToInt32(sfile);
                    toolStripComboBoxSmooth.SelectedIndex = TypeSmooth;
                    if (TypeSmooth == 0)
                    {
                        MakeVisibelGaussSmooth(false);
                        MakeVisibel2ParamSmooth(true);
                    }
                    else
                    {
                        MakeVisibelGaussSmooth(true);
                        MakeVisibel2ParamSmooth(false);
                    }


                    //параметр + внешний + внутренний шаг
                    sfile = fconfig.ReadLine();
                    if (sfile == null) goto M1;
                    with_diff_parm = Convert.ToInt32(sfile.Split(' ')[0]);
                    with_diff_parm = 1;
                    toolStripTextBoxParam.Text = with_diff_parm.ToString();
                    OutStep = Convert.ToInt32(sfile.Split(' ')[1]);
                    toolStripTextBoxOutStep.Text = OutStep.ToString();
                    InStep = Convert.ToInt32(sfile.Split(' ')[2]);
                    toolStripTextBoxInStep.Text = InStep.ToString();

                    //ширина окна сглаживания
                    sfile = fconfig.ReadLine();
                    if (sfile == null) goto M1;
                    currentTextWidth = sfile;
                    toolStripTextBoxWidthGauss.Text = currentTextWidth;
                    gaussB = Convert.ToDouble(currentTextWidth);

                    //число зубьев
                    sfile = fconfig.ReadLine();
                    if (sfile == null) goto M1;
                    number_zub = Convert.ToInt32(sfile);

                    //toolStripComboBoxSmooth.SelectedIndex = 0;

                    toolStripComboBoxSelectTypeSeach.SelectedIndex = 0;



                    fconfig.Close();
                    return;
                }
                catch
                {
                    goto M1;
                }
            }
            M1:
            width_w = Screen.PrimaryScreen.WorkingArea.Width;
            height_w = Screen.PrimaryScreen.WorkingArea.Height;
            toolStripComboBoxSmooth.SelectedIndex = 0;
            toolStripTextBoxWidthGauss.Text = "57";
            this.Size = new System.Drawing.Size(width_w, height_w);
            MakeVisibelGaussSmooth(false);
            MakeVisibel2ParamSmooth(true);
            return;

        }

        void SaveParametrs()
        {
            try
            {
                System.IO.StreamWriter fconfig = new System.IO.StreamWriter(@"config", false, System.Text.Encoding.GetEncoding("windows-1251"));

                //дериктория
                string sfile;
                home_directory = explorerTreeMain.SelectedPath;
                fconfig.WriteLine(home_directory);
                //позиция+разрешение
                width_w = this.Size.Width;
                height_w = this.Size.Height;
                posX_window = this.Location.X;
                posY_window = this.Location.Y;
                sfile = posX_window.ToString() + ' ' + posY_window.ToString() + ' ' + width_w.ToString() + ' ' + height_w.ToString();
                fconfig.WriteLine(sfile);

                //настройки меню
                sfile = mnuSA.Checked.ToString() + ' ' + mnuST.Checked.ToString() + ' ' + mnuSD.Checked.ToString() + ' ' + mnuSN.Checked.ToString() + ' ' + mnuSF.Checked.ToString() + ' ' +
                mnuSFExperimentTime.Checked.ToString() + ' ' + mnuSFKadrsNumber.Checked.ToString() + ' ' + mnuSFInputTimeInSec.Checked.ToString();
                fconfig.WriteLine(sfile);

                //разделитель дерево-список файлов
                split_tree_file_list = splitContainerTreeFilePath.SplitterDistance;
                height_split_tree_file_list = splitContainerTreeFilePath.Height;
                sfile = split_tree_file_list.ToString() + ' ' + height_split_tree_file_list.ToString();
                fconfig.WriteLine(sfile);

                //разделитель главный
                split_main = splitContainerMain.SplitterDistance;
                width_split_main = splitContainerMain.Width;
                sfile = split_main.ToString() + ' ' + width_split_main.ToString();
                fconfig.WriteLine(sfile);

                //тип сглаживания
                sfile = toolStripComboBoxSmooth.SelectedIndex.ToString();
                fconfig.WriteLine(sfile);

                //параметр + внешний + внутренний шаг
                sfile = with_diff_parm.ToString() + ' ' + OutStep.ToString() + ' ' + InStep.ToString();
                fconfig.WriteLine(sfile);

                //ширина окна сглаживания
                sfile = toolStripTextBoxWidthGauss.Text;
                fconfig.WriteLine(sfile);

                //число зубьев
                sfile = number_zub.ToString();
                fconfig.WriteLine(sfile);

                fconfig.Close();
            }
            catch
            { }
        }

        #endregion

        int old_pos=-1;

        #region OpenGl graphick Functions
        void ClearDrawArea()
        {
            // очитка окна 
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            
            Gl.glFlush();
        }


        int my_scale = 1;

        private void plus_Click(object sender, EventArgs e)
        {
            if (my_scale < 32)
            {
                my_scale = my_scale * 2;
                cl2d.Zoom_plus();
                hScrollBarGraph.Maximum = cl2d.get_max_move();
                if (cl2d.get_current_pos() >= 0)
                    hScrollBarGraph.Value = cl2d.get_current_pos();
                else
                    hScrollBarGraph.Value = 0;

                OpenGlControlGraph.Invalidate();

            }
        }

        private void minus_Click(object sender, EventArgs e)
        {
            if (my_scale > 1)
            {
                my_scale = my_scale / 2;
                cl2d.Zoom_minus();
                hScrollBarGraph.Maximum = cl2d.get_max_move();
                if (cl2d.get_current_pos() >= 0)
                    hScrollBarGraph.Value = cl2d.get_current_pos();
                else
                    hScrollBarGraph.Value = 0;

                OpenGlControlGraph.Invalidate();
            }
        }

        private void buttonR_Click(object sender, EventArgs e)
        {
            cl2d.Move_right();
            OpenGlControlGraph.Invalidate();
        }

        private void buttonL_Click(object sender, EventArgs e)
        {
            cl2d.Move_left();
            OpenGlControlGraph.Invalidate();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                bool flag_right = false;
                if (e.NewValue - e.OldValue > 0)
                    flag_right = true;
                else
                    if (e.NewValue - e.OldValue < 0)
                        flag_right = false;
                int i, size;
                size = Math.Abs(e.NewValue - e.OldValue);
                if (flag_right)
                    for (i = 0; i < size; i++)
                        cl2d.Move_right();
                else
                    for (i = 0; i < size; i++)
                        cl2d.Move_left();

                OpenGlControlGraph.Invalidate();
            }
        }

        #endregion

        #region File List and Tree functions
        private void mnuSA_Click(object sender, EventArgs e)
        {
            //строка адреса
            explorerTreeMain.ShowAddressbar = mnuSA.Checked;
            explorerTreeMain.refreshView();
        }

        private void mnuST_Click(object sender, EventArgs e)
        {
            //панель инструментов
            explorerTreeMain.ShowToolbar = mnuST.Checked;
            explorerTreeMain.refreshView();
        }

        private void mnuSD_Click(object sender, EventArgs e)
        {
            //мои документы
            explorerTreeMain.ShowMyDocuments = mnuSD.Checked;
            home_directory=explorerTreeMain.SelectedPath;
            //explorerTreeMain.refreshFolders();
            explorerTreeMain.SelectedPath = home_directory;

            explorerTreeMain.GetDirectory();

            explorerTreeMain.setCurrentPath(home_directory);

            explorerTreeMain.btnGo_Click(this, e);

            explorerTreeMain.refreshView();
        }

        private void mnuSN_Click(object sender, EventArgs e)
        {
            //моя есть
            explorerTreeMain.ShowMyNetwork = mnuSN.Checked;
            home_directory = explorerTreeMain.SelectedPath;
            //explorerTreeMain.refreshFolders();
            explorerTreeMain.SelectedPath = home_directory;

            explorerTreeMain.GetDirectory();

            explorerTreeMain.setCurrentPath(home_directory);

            explorerTreeMain.btnGo_Click(this, e);

            explorerTreeMain.refreshView();
        }

        private void mnuSF_Click(object sender, EventArgs e)
        {
            //избранное
            explorerTreeMain.ShowMyFavorites = mnuSF.Checked;
            home_directory = explorerTreeMain.SelectedPath;
            //explorerTreeMain.refreshFolders();
            explorerTreeMain.SelectedPath = home_directory;

            explorerTreeMain.GetDirectory();

            explorerTreeMain.setCurrentPath(home_directory);

            explorerTreeMain.btnGo_Click(this, e);

            explorerTreeMain.refreshView();

        }
       
        bool fExperimentTime=true;
        bool fKadrsNumber=true;
        bool fInputTimeInSec=true;
        int fNumCol = 4;

        //коллекция записей
        List<ClassRecord> vrecords = new List<ClassRecord>();

        protected void InitFileList()
        {


            //init dataview control
            dataGridViewFiles.Columns.Clear();
            dataGridViewFiles.ColumnCount = fNumCol;

            int i = 0;

            dataGridViewFiles.Columns[i].Name = "Имя файла"; dataGridViewFiles.Columns[i].AutoSizeMode= DataGridViewAutoSizeColumnMode.AllCells; i++;

            if (fExperimentTime)
            {
                dataGridViewFiles.Columns[i].Name = "Время эксперимента"; dataGridViewFiles.Columns[i].AutoSizeMode=DataGridViewAutoSizeColumnMode.AllCells; i++;
            }

            if (fKadrsNumber)
            {
                dataGridViewFiles.Columns[i].Name = "Число кадров"; dataGridViewFiles.Columns[i].AutoSizeMode=DataGridViewAutoSizeColumnMode.AllCells; i++;
            }

            if (fInputTimeInSec)
            {
                dataGridViewFiles.Columns[i].Name = "Длительность записи, сек"; dataGridViewFiles.Columns[i].AutoSizeMode=DataGridViewAutoSizeColumnMode.ColumnHeader; i++;
            }

        }

        private void mnuSFExperimentTime_Click(object sender, EventArgs e)
        {
            fExperimentTime = mnuSFExperimentTime.Checked;
            if (fExperimentTime) fNumCol++;
            else fNumCol--;
                ShowFileList();
        }


        private void mnuSFKadrsNumber_Click(object sender, EventArgs e)
        {
            fKadrsNumber = mnuSFKadrsNumber.Checked;
            if (fKadrsNumber) fNumCol++;
            else fNumCol--;
            ShowFileList();
        }

        private void mnuSFInputTimeInSec_Click(object sender, EventArgs e)
        {
            fInputTimeInSec = mnuSFInputTimeInSec.Checked;
            if (fInputTimeInSec) fNumCol++;
            else fNumCol--;
            ShowFileList();
        }


        private void mnuSCA_Click(object sender, EventArgs e)
        {

        }

        private void mnuSCO_Click(object sender, EventArgs e)
        {

        }

        private void explorerTreeMain_PathChanged(object sender, EventArgs e)
        {
            //отображаем файлы из дериктории
            home_directory = explorerTreeMain.SelectedPath;
            LoadFileList(explorerTreeMain.SelectedPath);
            ShowFileList();
            old_pos = -1;
        }

        

        protected void LoadFileList(string dir)
        {
            //загружаем файлы из дериктории
            string[] filePaths = Directory.GetFiles(dir, "*.txt");
            int i;
            flag_record = false;
            vrecords.Clear();
            for (i = 0; i < filePaths.Length; i++)
            {
                ClassRecord local_rec = new ClassRecord();
                if (local_rec.ValidateReadHead(filePaths[i]) || local_rec.ValidateReadHeadWindows7(filePaths[i]))
                {
                    vrecords.Add(local_rec);
                }
            }
            
        }

        protected void ShowFileList()
        {
            dataGridViewFiles.AllowUserToAddRows = true;
            InitFileList();
            //отображаем файлы в окне просмотра файлов

            int i, j;
            for (i = 0; i < vrecords.Count; i++)
            {
                j = 0;
                string[] lvData = new string[fNumCol];

                //имя файла
                lvData[j] = vrecords[i].file_name; j++;
                //время проведения эксперимента
                if (fExperimentTime) { lvData[j] = vrecords[i].ExperimentTime; j++; }
                //число кадров
                if (fKadrsNumber) { lvData[j] = vrecords[i].KadrsNumber.ToString(); j++; }
                //длительность эксперимента
                if (fInputTimeInSec) { lvData[j] = vrecords[i].InputTimeInSec.ToString(); j++; }

                dataGridViewFiles.Rows.Add(lvData);
            }
            dataGridViewFiles.AllowUserToAddRows = false;
        }

        private void dataGridViewFiles_SelectionChanged(object sender, EventArgs e)
        {
            flag_record = false;
            flag_calc = false;
            if (vrecords.Count > 0)
            {
                int index = dataGridViewFiles.CurrentCell.RowIndex;
                if (vrecords[index].NumberOfChannels == 1)
                {
                    toolStripComboBoxSelectTypeSeach.SelectedIndex = 0;
                    toolStripComboBoxSelectTypeSeach.Enabled = false;
                }
                if (vrecords[index].NumberOfChannels > 1)
                {
                    toolStripComboBoxSelectTypeSeach.SelectedIndex = 1;
                    toolStripComboBoxSelectTypeSeach.Enabled = true;
                }
            }
            else
            {
                toolStripComboBoxSelectTypeSeach.SelectedIndex = 0;
                toolStripComboBoxSelectTypeSeach.Enabled = false;
            }
        }

        #endregion

        private void menuShowGrap_Click(object sender, EventArgs e)
        {
            ShowGrapAsync();
        }

        private void toolStripButtonShowGraph_Click(object sender, EventArgs e)
        {
            ShowGrapAsync();
        }

        

        private void toolStripButtonGraphZoomIn_Click(object sender, EventArgs e)
        {
            if(flag_graph)
            if (my_scale < 512)
            {
                my_scale = my_scale * 2;
                cl2d.Zoom_plus();
                hScrollBarGraph.Maximum = cl2d.get_max_move();
                if (cl2d.get_current_pos() >= 0)
                    hScrollBarGraph.Value = cl2d.get_current_pos();
                else
                    hScrollBarGraph.Value = 0;

                OpenGlControlGraph.Invalidate();

            }
        }

        private void toolStripButtonGraphZoomOut_Click(object sender, EventArgs e)
        {
            if(flag_graph)
            if (my_scale > 1)
            {
                my_scale = my_scale / 2;
                cl2d.Zoom_minus();
                hScrollBarGraph.Maximum = cl2d.get_max_move();
                if (cl2d.get_current_pos() >= 0)
                    hScrollBarGraph.Value = cl2d.get_current_pos();
                else
                    hScrollBarGraph.Value = 0;

                OpenGlControlGraph.Invalidate();
            }
        }

        private void toolStripButtonGraphFullView_Click(object sender, EventArgs e)
        {
            if (flag_graph)
            {
                my_scale = 1;
                cl2d.Zoom_full();
                hScrollBarGraph.Value = 0;
                hScrollBarGraph.Maximum = 0;
                OpenGlControlGraph.Invalidate();
            }
        }

        string name_file_graph = "";
        void SaveGraph()
        {
            if (flag_graph)
            {
                saveFileDialogGraph.FileName = name_file_graph;
                Bitmap bmpsv = cl2d.GetBitmap();
                if (saveFileDialogGraph.ShowDialog() == DialogResult.OK)
                {
                    //name_file_graph=saveFileDialogBmp.
                    bmpsv.Save(saveFileDialogGraph.FileName);
                    name_file_graph = Path.GetFileName(saveFileDialogGraph.FileName);
                    name_file_graph = name_file_graph.Remove(name_file_graph.Length - 4);
                }
                bmpsv.Dispose();

            }
        }

        private void toolStripButtonGraphSave_Click(object sender, EventArgs e)
        {
            SaveGraph();
        }

        private void ToolStripMenuItemSaveGraph_Click(object sender, EventArgs e)
        {
            SaveGraph();
        }

        #region Create Report

        public string[] column_name =  {"такт работа","такт выхлоп","такт всасывания","такт сжатие" };
        string name_minum = @"Минимум";
        void CreateReport()
        {
            richTextBoxReport.Clear();
            RtfDocument doc = new RtfDocument(PaperSize.Letter, PaperOrientation.Landscape,
                Lcid.English);
            /// Create fonts and colors for later use
            FontDescriptor times = doc.createFont("Times New Roman");
            FontDescriptor courier = doc.createFont("Courier New");

            /// Don't instantiate RtfTable, RtfParagraph, and RtfImage objects by using
            /// ``new'' keyword. Instead, use add* method in objects derived from 
            /// RtfBlockList class. (See Demos.)
            
            RtfParagraph par;
            RtfImage img;
            /// Don't instantiate RtfCharFormat by using ``new'' keyword, either. 
            /// An addCharFormat method are provided by RtfParagraph objects.
            RtfCharFormat fmt;

            par = doc.addParagraph();
            par.DefaultCharFormat.Font = times;
            par.Alignment = Align.Center;
            par.DefaultCharFormat.FontSize = 20;
            par.Text = "Отчёт";

            par = doc.addParagraph();
            par.DefaultCharFormat.Font = times;
            par.Alignment = Align.Left;
            par.DefaultCharFormat.FontSize = 15;
            
            /// ==========================================================================
            /// Image1: Image speed
            /// ==========================================================================
            /// 
            par.Text = "Зависимость частоты вращения от времени";
            System.Drawing.Image imagets = zedGraphControlTimeSpeed.GetImage();
            img = doc.addImage(imagets, ImageFileType.Wmf);
            img.StartNewPage = true;
            img.Width = 640;
            img.Width = 480;

            par = doc.addParagraph();
            par.DefaultCharFormat.Font = times;
            par.Alignment = Align.Left;
            par.DefaultCharFormat.FontSize = 15;
            
            /// ==========================================================================
            /// Image2: Image accesseleration
            /// ==========================================================================
            par.Text = "Зависимость ускорения от времени";
            imagets = zedGraphControlTimeAcceleration.GetImage();
            img = doc.addImage(imagets, ImageFileType.Wmf);
            img.StartNewPage = true;
            img.Width = 640;
            img.Width = 480;


            par = doc.addParagraph();
            par.DefaultCharFormat.Font = times;
            par.Alignment = Align.Left;
            par.DefaultCharFormat.FontSize = 15;
            

            /// ==========================================================================
            /// Image2.1: Image accesseleration
            /// ==========================================================================
            par.Text = "Зависимость частоты вращения от угла поворота";
            imagets = zedGraphControlDegreeSpeed.GetImage();
            img = doc.addImage(imagets, ImageFileType.Wmf);
            img.StartNewPage = true;
            img.Width = 640;
            img.Width = 480;

            par = doc.addParagraph();
            par.DefaultCharFormat.Font = times;
            par.Alignment = Align.Left;
            par.DefaultCharFormat.FontSize = 15;

            /// ==========================================================================
            /// Image2.1: Image accesseleration
            /// ==========================================================================
            par.Text = "Зависимость ускорения от угла поворота";
            imagets = zedGraphControlDegreeAcc.GetImage();
            img = doc.addImage(imagets, ImageFileType.Wmf);
            img.StartNewPage = true;
            img.Width = 640;
            img.Width = 480;

            par = doc.addParagraph();
            par.DefaultCharFormat.Font = times;
            par.Alignment = Align.Left;
            par.DefaultCharFormat.FontSize = 15;

            /// ==========================================================================
            /// Image3: Image speed acc
            /// ==========================================================================
            par.Text = "Зависимость ускорения от частоты вращения";
            imagets = zedGraphControlSpeedAcceleration.GetImage();
            img = doc.addImage(imagets, ImageFileType.Wmf);
            img.StartNewPage = true;
            img.Width = 640;
            img.Width = 480;

            RtfTable table;
            if (calc_record.min_loc != null)
            {
                par = doc.addParagraph();
                par.DefaultCharFormat.Font = times;
                par.Alignment = Align.Left;
                par.DefaultCharFormat.FontSize = 15;
                par.Text = "Циклы подачи";
                

                if (TypeAlgorithmFindingPeriods == 0)
                    table = doc.addTable(calc_record.t_min_loc.Length, 18);
                else
                {
                    table = doc.addTable(calc_record.t_min_loc.Length, 3);
                    name_minum = @"Синхроимпульс";
                }

                table.Margins[Direction.Bottom] = 20;
                table.DefaultCharFormat.FontSize = 8;
                /// Step 3. (Optional) Set text alignment for each cell, row height, column width,
                ///			border style, etc.
                /// header 0
                table.cell(0, 0).Width = 50;
                table.cell(0, 0).Alignment = Align.Left;
                table.cell(0, 0).AlignmentVertical = AlignVertical.Middle;
                table.cell(0, 0).addParagraph().Text = name_minum;

                table.cell(0, 1).Width = 40;
                table.cell(0, 1).Alignment = Align.Left;
                table.cell(0, 1).AlignmentVertical = AlignVertical.Middle;
                table.cell(0, 1).addParagraph().Text = @"";

                table.cell(0, 2).Width = 70;
                table.cell(0, 2).Alignment = Align.Left;
                table.cell(0, 2).AlignmentVertical = AlignVertical.Middle;
                table.cell(0, 2).addParagraph().Text = @"";
                table.merge(0, 0,1, 3);

                if (TypeAlgorithmFindingPeriods == 0)
                {
                    table.cell(0, 3).Width = 50;
                    table.cell(0, 3).Alignment = Align.Left;
                    table.cell(0, 3).AlignmentVertical = AlignVertical.Middle;
                    table.cell(0, 3).addParagraph().Text = @"Максимум";

                    table.cell(0, 4).Width = 40;
                    table.cell(0, 4).Alignment = Align.Left;
                    table.cell(0, 4).AlignmentVertical = AlignVertical.Middle;
                    table.cell(0, 4).addParagraph().Text = @"";

                    table.cell(0, 5).Width = 70;
                    table.cell(0, 5).Alignment = Align.Left;
                    table.cell(0, 5).AlignmentVertical = AlignVertical.Middle;
                    table.cell(0, 5).addParagraph().Text = @"";
                    table.merge(0, 3, 1, 3);
                }

                for (int j = 6; j < table.ColCount; j++)
                {

                    if (j % 3 == 0)
                        table.cell(0, j).Width = 50;
                    else if ((j - 1) % 3 == 0)
                        table.cell(0, j).Width = 40;
                    else if ((j - 2) % 3 == 0)
                        table.cell(0, j).Width = 70;
                    table.cell(0, j).Alignment = Align.Left;
                    table.cell(0, j).AlignmentVertical = AlignVertical.Middle;     
                }

                for (int j = 6; j < table.ColCount; j++)
                {
                    if (j % 3 == 0)
                    {
                        table.merge(0, j, 1, 3);
                        table.cell(0, j).addParagraph().Text = column_name[j/3 - 2];
                    }
                    else
                        table.cell(0, j).addParagraph().Text = @"";
                }

                int i = 1;
                for (int j = 0; j < table.ColCount; j++)
                {
                    

                    table.cell(i, j).Alignment = Align.Left;
                    table.cell(i, j).AlignmentVertical = AlignVertical.Middle;
                    if (j % 3 == 0)
                    {
                        table.cell(i, j).Width = 50;
                        table.cell(i, j).addParagraph().Text = "№ импульса";
                    }
                    else if ((j - 1) % 3 == 0)
                    {
                        table.cell(i, j).Width = 40;
                        table.cell(i, j).addParagraph().Text = "Время, с";
                    }
                    else if ((j - 2) % 3 == 0)
                    {
                        table.cell(i, j).Width = 70;
                        table.cell(i, j).addParagraph().Text = "Частота, об/мин";
                    }
                }

                for (i = 2; i < table.RowCount; i++)
                {
                    for (int j = 0; j < table.ColCount; j++)
                    {
                        if (j % 3 == 0)
                            table.cell(i, j).Width = 50;
                        else if ((j - 1) % 3 == 0)
                            table.cell(i, j).Width = 40;
                        else if ((j - 2) % 3 == 0)
                            table.cell(i, j).Width = 70;

                        table.cell(i, j).Alignment = Align.Left;
                        table.cell(i, j).AlignmentVertical = AlignVertical.Middle;

                        if (j < 3)
                        {
                            if (j % 3 == 0)
                                table.cell(i, j).addParagraph().Text = calc_record.pos_min_loc[i - 2].ToString();
                            else if ((j - 1) % 3 == 0)
                                table.cell(i, j).addParagraph().Text = Math.Round(calc_record.t_min_loc[i - 2], 4).ToString();
                            else if ((j - 2) % 3 == 0)
                                table.cell(i, j).addParagraph().Text = Math.Round(calc_record.min_loc[i - 2], 2).ToString();
                            
                        }
                        if (j < 6 && j > 2)
                        {
                            if (j % 3 == 0)
                                table.cell(i, j).addParagraph().Text = calc_record.pos_max_loc[i - 2+1].ToString();
                            else if ((j - 1) % 3 == 0)
                                table.cell(i, j).addParagraph().Text = Math.Round(calc_record.t_max_loc[i - 2+1], 4).ToString();
                            else if ((j - 2) % 3 == 0)
                                table.cell(i, j).addParagraph().Text = Math.Round(calc_record.max_loc[i - 2+1], 2).ToString();
                        }
                        else if (j >= 6)
                        {
                            if (j % 3 == 0)
                                table.cell(i, j).addParagraph().Text = calc_record.pos_InEng[(i - 2) * 4 + j / 3 - 2].ToString();
                            else if ((j - 1) % 3 == 0)
                                table.cell(i, j).addParagraph().Text = Math.Round(calc_record.t_InEng[(i - 2) * 4 + j / 3 - 2], 4).ToString();
                            else if ((j - 2) % 3 == 0)
                                table.cell(i, j).addParagraph().Text = Math.Round(calc_record.InEng[(i - 2) * 4 + j / 3 - 2], 2).ToString();
                        }
                    }
                    table.setInnerBorder(DW.RtfWriter.BorderStyle.Dotted, 1f);
                    table.setOuterBorder(DW.RtfWriter.BorderStyle.Single, 1f);
                }
                
                par = doc.addParagraph();
                if(TypeAlgorithmFindingPeriods == 0)
                    par.Text = @"Поиск событий осуществлен по минимуму и максимуму.";
                if (TypeAlgorithmFindingPeriods == 1)
                    par.Text = @"Поиск событий осуществлен с использованием второго канала.";
                if (TypeAlgorithmFindingPeriods == 2)
                    par.Text = @"События установлены вручную.";
            }

            if (pointsDiffDegreeX != null)
            {
                par = doc.addParagraph();
                par.DefaultCharFormat.Font = times;
                par.Alignment = Align.Left;
                par.DefaultCharFormat.FontSize = 15;
                par.Text = "Точки смещения";


                table = doc.addTable(pointsDiffDegreeX.Length, 4);

                table.Margins[Direction.Bottom] = 20;
                table.DefaultCharFormat.FontSize = 8;
                /// Step 3. (Optional) Set text alignment for each cell, row height, column width,
                ///			border style, etc.
                /// header 0
                /// 
                int[] widths = { 100, 100, 120, 120 };

                table.cell(0, 0).Width = widths[0];
                table.cell(0, 0).Alignment = Align.Left;
                table.cell(0, 0).AlignmentVertical = AlignVertical.Middle;
                table.cell(0, 0).addParagraph().Text = @"Время, с";

                table.cell(0, 1).Width = widths[1];
                table.cell(0, 1).Alignment = Align.Left;
                table.cell(0, 1).AlignmentVertical = AlignVertical.Middle;
                table.cell(0, 1).addParagraph().Text = @"Градусы";

                table.cell(0, 2).Width = widths[2];
                table.cell(0, 2).Alignment = Align.Left;
                table.cell(0, 2).AlignmentVertical = AlignVertical.Middle;
                table.cell(0, 2).addParagraph().Text = @"Частота, об/мин";

                table.cell(0, 3).Width = widths[3];
                table.cell(0, 3).Alignment = Align.Left;
                table.cell(0, 3).AlignmentVertical = AlignVertical.Middle;
                table.cell(0, 3).addParagraph().Text = @"Ускорение, рад/с^2";
                int i;
                for (i = 1; i < table.RowCount; i++)
                {
                    for (int j = 0; j < table.ColCount; j++)
                    {
                        table.cell(i, j).Width = widths[j];
                        table.cell(i, j).Alignment = Align.Left;
                        table.cell(i, j).AlignmentVertical = AlignVertical.Middle;

                        switch (j)
                        {
                            case 0:
                                table.cell(i, j).addParagraph().Text = pointsDiffTimeX[i - 1].ToString();
                                break;
                            case 1:
                                table.cell(i, j).addParagraph().Text = pointsDiffDegreeX[i - 1].ToString();
                                break;
                            case 2:
                                table.cell(i, j).addParagraph().Text = pointsDiffTimeYVu[i - 1].ToString();
                                break;
                            case 3:
                                table.cell(i, j).addParagraph().Text = pointsDiffTimeYAc[i - 1].ToString();
                                break;
                        }
                    }
                }
                table.setInnerBorder(DW.RtfWriter.BorderStyle.Dotted, 1f);
                table.setOuterBorder(DW.RtfWriter.BorderStyle.Single, 1f);
            }

            if (SelectedIndexSmooth == 0)
            {
                par = doc.addParagraph();
                par.Text = @"Двухпараметрическое сглаживание";
                par = doc.addParagraph();
                par.Text = @"Коэфициент накопления: " + OutStep.ToString();
                par = doc.addParagraph();
                par.Text = @"Коэфициент смещения: " + InStep.ToString();
            }
            else
            {
                par = doc.addParagraph();
                par.Text = @"Сглаживание Гаусса";
                par = doc.addParagraph();
                par.Text = @"Ширина окна сглаживания: " + gaussB.ToString();
            }

            

            par = doc.addParagraph();
            par.Text =@"Расчёт произведён для файла: " + name_file;

            doc.save("REPORT.rtf");
            richTextBoxReport.Rtf = doc.render();
            //richTextBoxReport.LoadFile("Tabel1.rtf");
        }

        private void AppendReportEvents()
        {
            
            if (calc_record.max_loc != null && calc_record.min_loc != null)
            {
                int i;
                richTextBoxReport.AppendText(@"Минимальные значения:");
                richTextBoxReport.AppendText("\r\n");
                for (i = 0; i < calc_record.min_loc.Length; i++)
                {
                    richTextBoxReport.AppendText("t" + i.ToString() + "=" + calc_record.t_min_loc[i].ToString() + "  " + calc_record.min_loc[i].ToString());
                    richTextBoxReport.AppendText("\r\n");
                }
                richTextBoxReport.AppendText(@"Максимальные значения:");
                richTextBoxReport.AppendText("\r\n");
                for (i = 0; i < calc_record.max_loc.Length; i++)
                {
                    richTextBoxReport.AppendText("t" + i.ToString() + "=" + calc_record.t_max_loc[i].ToString() + "  " + calc_record.max_loc[i].ToString());
                    richTextBoxReport.AppendText("\r\n");
                }
            }
        }

        #endregion

        #region Create graphics

        public void createDrawGraphCreateReport()
        {
            //вывод графиков
            ZedGraphHelper.CreateGraph(ref zedGraphControlTimeAcceleration, ref calc_record.t_ac, "время, с", ref calc_record.ac, "ускорение, рад/c^2", calc_record.kol_ac, "", "");
            ZedGraphHelper.CreateGraph(ref zedGraphControlSpeedAcceleration, ref calc_record.vu, "частота вращения, об/мин", ref calc_record.ac, "ускорение, рад/c^2", calc_record.kol_ac, "", "");
            ZedGraphHelper.CreateGraph(ref zedGraphControlTimeSpeed, ref calc_record.t_vu, "время, сек", ref calc_record.vu, "частота вращения, об/мин", calc_record.kol_vu, "", "");
            ZedGraphHelper.CreateGraph(ref zedGraphControlTimeSpeedAcc, ref calc_record.t_vu, "время, сек", ref calc_record.vu, "частота вращения, об/мин", calc_record.kol_vu, "", "");
            ZedGraphHelper.CreateGraphPercent(ref zedGraphControlTimeSpeedAcc, ref calc_record.t_ac, "время, с", ref calc_record.vu, ref calc_record.ac, "Относительные ед., %", calc_record.kol_ac, "", "");
            ZedGraphHelper.CreateGraph(ref zedGraphControlDegreeSpeed, ref calc_record.degree_vu, "градусы", ref calc_record.vu, "частота вращения, об/мин", calc_record.kol_vu, "", "");
            ZedGraphHelper.CreateGraph(ref zedGraphControlDegreeAcc, ref calc_record.degree_ac, "градусы", ref calc_record.ac, "ускорение, рад/c^2", calc_record.kol_ac, "", "");
            CreateReport();
            if (tabControlMain.TabPages.Count < 2)
            {
                tabControlMain.TabPages.Add(tabPageTimeSpeed);
                tabControlMain.TabPages.Add(tabPageTimeAcceleration);
                tabControlMain.TabPages.Add(tabPageSpeedAcceleration);
                tabControlMain.TabPages.Add(tabPageTimeSpeedAcc);
                tabControlMain.TabPages.Add(tabPageDegreeSpeed);
                tabControlMain.TabPages.Add(tabPageDegreeAcc);
                tabControlMain.TabPages.Add(tabPageReport);
            }

            flag_calc = true;
            tabControlMain.SelectedTab = tabPageReport;

            my_scale = 1;
            cl2d.Zoom_full();
            hScrollBarGraph.Value = 0;
            hScrollBarGraph.Maximum = 0;
            OpenGlControlGraph.Invalidate();
        }

        private static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }


        
        #endregion

        #region Calculate With Bg Worker
        BackgroundWorker bw;

        protected bool DrawGraph(string path)
        {
            lock (record)
            {
                if (record.ReadInCommonFormat(path))
                {
                    flag_record = true;
                    flag_graph = true;
                }
                else
                {
                    flag_record = false;
                }
            }
            if (bw.CancellationPending == true) { this.Enabled = true; return false; }
            bw.ReportProgress(statesWork.startCalc);

            return true;
        }

        string dir_file;
        string path_file;
        string name_file;

        protected bool ShowGraph()
        {
            if (tabControlMain.TabPages.Count > 1)
            {
                removePages();
            }
            flag_record = false;
            flag_record = false;
            if (vrecords.Count > 0)
            {

                name_file = dataGridViewFiles.SelectedCells[0].Value.ToString();
                dir_file = explorerTreeMain.SelectedPath;
                path_file = dir_file + "\\" + name_file;
                bw.ReportProgress(statesWork.startRead);
                //progressForm.setProgress(10, "Ввод данных и построение графика");
                if (DrawGraph(path_file))
                {
                    my_scale = 1;
                    hScrollBarGraph.Maximum = 0;
                    flag_record = true;
                }
                else
                {
                    if (bw.CancellationPending == true) { this.Enabled = true; return false; }
                    flag_record = false;
                    MessageBox.Show("Файл повреждён или отстутсвует");
                }
            }
            else
            {
                flag_record = false;
                MessageBox.Show("Не выбрано ни одного файла");
            }
            return true;
        }

        void Calculate()
        {
            flag_events = false;
            ShowGraph();
            if (bw.CancellationPending == true) { bw.ReportProgress(statesWork.stop); return; }
            if (flag_record)
            {
                //рассчёт 
                calc_record = new ClassCalc();
                //calc_record.Calculate(record);
                gaussB = gauss_width;
                calc_record.Calculate2(record, with_diff_parm, OutStep, InStep, number_zub, gaussB, SelectedIndexSmooth);
                if (bw.CancellationPending == true) { bw.ReportProgress(statesWork.stop); return; }
                bw.ReportProgress(statesWork.finishCalc);
                if (bw.CancellationPending == true) { bw.ReportProgress(statesWork.stop); return; }
                //tabControlMain.Invalidate();
            }

        }

        double gauss_width = 0.01;
        private void ReCalc(bool flagTimeSpeed, bool flagTimeAcceleration, bool flagSpeedAcceleration)
        {
            if (!flag_calc && flag_record) Calculate();
            if (flag_calc && flag_record)
            {

                flag_events = false;
                gaussB = gauss_width;
                calc_record.Calculate3(record, with_diff_parm, OutStep, InStep, flagTimeSpeed, number_zub, gaussB, SelectedIndexSmooth);

                bw.ReportProgress(statesWork.finishCalc);
                flag_calc = true;

            }
        }

        bool flag_events = false;
        private void CalcEvents()
        {
            try
            {
                if (!flag_calc && flag_record) Calculate();
                if (flag_calc && flag_record)
                {
                    //рассчёт 
                    calc_record.CalculateMaxMin(toolStripComboBoxSelectTypeSeach.SelectedIndex);
                    //дополнение графиков
                    TypeAlgorithmFindingPeriods = toolStripComboBoxSelectTypeSeach.SelectedIndex;
                    if (TypeAlgorithmFindingPeriods == 0)
                    {
                        ZedGraphHelper.AppendEventsToGraph(ref zedGraphControlTimeSpeed, calc_record.t_max_loc, calc_record.max_loc, calc_record.t_min_loc, calc_record.min_loc, calc_record.t_InEng, calc_record.InEng, name_minum);
                        ZedGraphHelper.AppendEventsToGraph(ref zedGraphControlTimeAcceleration, calc_record.t_max_loc, calc_record.max_loc_ac, calc_record.t_min_loc, calc_record.min_loc_ac, calc_record.t_InEng, calc_record.InEng_ac, name_minum);
                    }
                    else
                    {
                        name_minum = "Оптический";
                        ZedGraphHelper.AppendEventsToGraph(ref zedGraphControlTimeSpeed, null, null, calc_record.t_min_loc, calc_record.min_loc, null, null,name_minum);
                        ZedGraphHelper.AppendEventsToGraph(ref zedGraphControlTimeAcceleration, null, null, calc_record.t_min_loc, calc_record.min_loc_ac, null, null, name_minum);
                    }
                    //отчёт
                    CreateReport();

                    flag_calc = true;
                    flag_events = true;

                }
            }
            catch
            {
                MessageBox.Show("Неудалось найти события, измените коэфициент сглаживания");
            }
        }

        private void CreateBackgroundWorker(DoWorkEventHandler action)
        {
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.WorkerSupportsCancellation = true;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            bw.DoWork += action;
        }

        private void launchBgWorker()
        {
            progressForm = new FormProgressBar(ref bw);
            progressForm.Show();
            bw.RunWorkerAsync(null);
        }

        private void ShowGrapAsync()
        {
            CreateBackgroundWorker(bw_DoWorkShowGraph);
            launchBgWorker();
        }

        public void CalculateAsync()
        {
            CreateBackgroundWorker(bw_DoWork);
            gauss_width = Convert.ToDouble(toolStripTextBoxWidthGauss.Text);
            launchBgWorker();
        }

        private void RecalcAsync()
        {
            CreateBackgroundWorker(bw_DoWorkRecalc);
            gauss_width = Convert.ToDouble(toolStripTextBoxWidthGauss.Text);
            launchBgWorker();
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            lock (this)
            {
                bw.ReportProgress(statesWork.start);

                Calculate();
                //            System.Threading.Thread.Sleep(5000);
                bw.ReportProgress(statesWork.stop);
                //            System.Threading.Thread.Sleep(100);
            }
        }

        void bw_DoWorkShowGraph(object sender, DoWorkEventArgs e)
        {
            bw.ReportProgress(statesWork.start);
            ShowGraph();
            //System.Threading.Thread.Sleep(5000);
            bw.ReportProgress(statesWork.stop);
        }

        void bw_DoWorkRecalc(object sender, DoWorkEventArgs e)
        {
            bw.ReportProgress(statesWork.startCalc);
            ReCalc(true,true,true);
            bw.ReportProgress(statesWork.stop);
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Enabled = true;
        }
        
        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == statesWork.stop)
            {
                this.Enabled = true;
                //menuStrip1.Enabled = true;
                //toolStripMainMenu.Enabled = true;
                //explorerTreeMain.Enabled = true;

                progressForm.setProgress(100, "Готово");
                progressForm.Hide();
            }
            
            if (e.ProgressPercentage == statesWork.start)
            {
                this.Enabled = false;
            }

            if (bw.CancellationPending == true) { this.Enabled = true; return; }
            if (e.ProgressPercentage == statesWork.startRead)
            {
                progressForm.setProgress(e.ProgressPercentage, "Ввод данных и построение графиков");
            }

            if (e.ProgressPercentage == statesWork.startCalc)
            {
                string[] names = new string[4];
                names[0] = "канал 1";
                names[1] = "канал 2";
                names[2] = "канал 3";
                names[3] = "канал 4";
                int[] m = new int[4];
                m[0] = m[1] = m[2] = m[3] = record.KadrsNumber;
                int i, j;

                cl2d.DrawGraphick(record.time, "t, секунды", record.ch, "U, В", m, names, record.NumberOfChannels, OpenGlControlGraph.Width, OpenGlControlGraph.Height);
                if (old_pos > -1)
                    dataGridViewFiles.Rows[old_pos].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                old_pos = dataGridViewFiles.CurrentRow.Index;
                dataGridViewFiles.Rows[old_pos].DefaultCellStyle.BackColor = System.Drawing.Color.Green;

                OpenGlControlGraph.Invalidate();
                progressForm.setProgress(e.ProgressPercentage, "Расчет и построение графиков");
            }

            if (e.ProgressPercentage == statesWork.finishCalc)
            {
                progressForm.setProgress(e.ProgressPercentage, "Генерация отчета");
                this.Enabled = true;
                createDrawGraphCreateReport();
                progressForm.setProgress(100, "Готово");
                progressForm.Hide();
                //this.Show();

            }
            

        }

        #endregion

        private void toolStripButtonCalc_Click(object sender, EventArgs e)
        {
            CalculateAsync();
        }

        private void calcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalculateAsync();
        }

        #region Save Report
        string namemy_file="";
        private void ToolStripMenuItemSaveReportAs_Click(object sender, EventArgs e)
        {

            if (flag_calc)
            {
                if (namemy_file.Length == 0)
                {
                    namemy_file = name_file;
                    namemy_file = name_file.Remove(namemy_file.Length - 4);
                }
                saveFileReportDialog.FileName = namemy_file;
                if (saveFileReportDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBoxReport.SaveFile(saveFileReportDialog.FileName);
                    namemy_file = saveFileReportDialog.FileName;
                    namemy_file = Path.GetFileNameWithoutExtension(namemy_file);
                    calc_record.OutputData(Path.GetDirectoryName(saveFileReportDialog.FileName) + "\\" + namemy_file);
                    if (flag_events) calc_record.OutputDataMaxMin(Path.GetDirectoryName(saveFileReportDialog.FileName) + "\\" + namemy_file);
                }
            }
        }

        private void toolStripButtonSaveReport_Click(object sender, EventArgs e)
        {
            
            if (flag_calc)
            {
                if (namemy_file.Length == 0)
                {
                    namemy_file = name_file;
                    namemy_file = name_file.Remove(namemy_file.Length - 4);
                }
                saveFileReportDialog.FileName = namemy_file;
                if (saveFileReportDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBoxReport.SaveFile(saveFileReportDialog.FileName);
                    namemy_file = saveFileReportDialog.FileName;
                    namemy_file = Path.GetFileNameWithoutExtension(namemy_file);


                    calc_record.OutputData(Path.GetDirectoryName(saveFileReportDialog.FileName) + "\\" + namemy_file);
                    if (flag_events) calc_record.OutputDataMaxMin(Path.GetDirectoryName(saveFileReportDialog.FileName) + "\\" + namemy_file);

                }
            }
        }

        #endregion

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //System.Environment.SetEnvironmentVariable("HomeDir", explorerTreeMain.SelectedPath, EnvironmentVariableTarget.User);
            SaveParametrs();
        }

        int max_with_diff=50;
        int min_with_diff=3;

        private void toolStripButtonIncParam_Click(object sender, EventArgs e)
        {
            if (with_diff_parm < max_with_diff)
            {
                with_diff_parm++;
                toolStripTextBoxParam.TextBox.Text = with_diff_parm.ToString();
            }
            //ReCalc();
        }

        private void toolStripButtonDecParam_Click(object sender, EventArgs e)
        {
            if (with_diff_parm > min_with_diff )
            {
                with_diff_parm--;
                toolStripTextBoxParam.TextBox.Text = with_diff_parm.ToString();
            }
            //ReCalc();
        }

        private void toolStripTextBoxParam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void toolStripTextBoxParam_TextChanged(object sender, EventArgs e)
        {
            bool flag = false;
            if (toolStripTextBoxParam.TextBox.Text == "")
            {
                with_diff_parm = 0;
                flag = true;
            }
            else
            {
                with_diff_parm = Convert.ToInt32(toolStripTextBoxParam.TextBox.Text);
            }

            if (with_diff_parm < min_with_diff) { with_diff_parm = min_with_diff; flag = true; }
            if (with_diff_parm > max_with_diff) {with_diff_parm = max_with_diff; flag = true; }
            
            if(flag) toolStripTextBoxParam.TextBox.Text = with_diff_parm.ToString();
            
            //ReCalc(false,true,true);
        }

        #region OpenGL Graph

        private void OpenGlControlGraph_SizeChanged(object sender, EventArgs e)
        {
            ClearDrawArea();
            cl2d.init_XW(OpenGlControlGraph.Width);
            cl2d.init_YH(OpenGlControlGraph.Height);
            cl2d.Init();
            cl2d.UpdateZoom();
        }

        private void OpenGlControlGraph_Paint(object sender, PaintEventArgs e)
        {
            cl2d.DrawSystem();
            cl2d.DrawFunc();
            Gl.glFlush();
        }

        private void OpenGlControlGraph_Resize(object sender, EventArgs e)
        {
            ClearDrawArea();
        }

        int pos_splitX1=-1;
        int pos_splitX2 =-10;
        bool split=true;
        private void splitContainerMain_SplitterMoving(object sender, SplitterCancelEventArgs e)
        {

            //заменяем на картинку

            if (split && (tabControlMain.SelectedIndex==0))
            {
                pictureBoxGraphData.Image = cl2d.GetBitmapDiff();
                
                pictureBoxGraphData.Show();
                OpenGlControlGraph.Hide();
                split = !split;
            }

        }

        private void splitContainerMain_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (!split && (tabControlMain.SelectedIndex == 0))
            {
                split = !split;
                OpenGlControlGraph.Show();
                pictureBoxGraphData.Hide();
                splitContainerMain.Invalidate();
            }
        }

        #endregion

        #region Two Way Smooth
        //////////////////////////////внешний шаг////////////////////////
        #region Inner Step
        int max_with_OutStep = 720;
        int min_with_OutStep = 1;
        int OutStep = 10;

        private void toolStripButtonIncOutStep_Click(object sender, EventArgs e)
        {
            if (OutStep < max_with_OutStep)
            {
                OutStep++;
                toolStripTextBoxOutStep.TextBox.Text = OutStep.ToString();
            }
        }

        private void toolStripButtonDecOutStep_Click(object sender, EventArgs e)
        {
            if (OutStep > min_with_OutStep)
            {
                OutStep--;
                toolStripTextBoxOutStep.TextBox.Text = OutStep.ToString();
            }
        }

        private void toolStripTextBoxOutStep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void toolStripTextBoxOutStep_TextChanged(object sender, EventArgs e)
        {
            bool flag = false;
            if (toolStripTextBoxOutStep.TextBox.Text == "")
            {
                OutStep = 1;
                toolStripTextBoxOutStep.TextBox.Text = OutStep.ToString();
                flag = true;
            }
            else
            {
                OutStep = Convert.ToInt32(toolStripTextBoxOutStep.TextBox.Text);
            }

            if (OutStep < min_with_OutStep) { OutStep = min_with_OutStep; flag = true; }
            if (OutStep > max_with_OutStep) { OutStep = max_with_OutStep; flag = true; }

            if (flag) toolStripTextBoxOutStep.TextBox.Text = OutStep.ToString();

            ReCalc(true,true,true);
        }
        #endregion
        ////////////////////////////////////////////////////////////////////////////////////

        //////////////////////////////внутренний шаг////////////////////////
        #region Outer Step
        int max_with_InStep = 720;
        int min_with_InStep = 1;
        int InStep = 5;

        private void toolStripButtonIncInStep_Click(object sender, EventArgs e)
        {
            if (InStep < max_with_InStep && InStep < OutStep-1)
            {
                InStep++;
                toolStripTextBoxInStep.TextBox.Text = InStep.ToString();
            }
        }

        private void toolStripButtonDecInStep_Click(object sender, EventArgs e)
        {
            if (InStep > min_with_OutStep)
            {
                InStep--;
                toolStripTextBoxInStep.TextBox.Text = InStep.ToString();
            }
        }

        private void toolStripTextBoxInStep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;
                }
            }
        }

        private void toolStripTextBoxInStep_TextChanged(object sender, EventArgs e)
        {
            bool flag = false;
            if (toolStripTextBoxInStep.TextBox.Text == "")
            {
                InStep = 1;
                toolStripTextBoxInStep.TextBox.Text = InStep.ToString();
                flag = true;
            }
            else
            {
                InStep = Convert.ToInt32(toolStripTextBoxInStep.TextBox.Text);
            }

            if (InStep < min_with_InStep && InStep < OutStep - 1) { InStep = min_with_InStep; flag = true; }
            if (InStep > max_with_InStep) { InStep = max_with_InStep; flag = true; }

            if (flag) toolStripTextBoxInStep.TextBox.Text = InStep.ToString();

            ReCalc(true, true, true);
        }
        #endregion
        ////////////////////////////////////////////////////////
        #endregion

        //////////// Сглаживание Гаусса
        #region Gauss Smooth
        private void toolStripTextBoxWidthGauss_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private string currentTextWidth="0.02";
        double gaussB=0.2;
        private void toolStripTextBoxWidthGauss_TextChanged(object sender, EventArgs e)
        {
            if (toolStripTextBoxWidthGauss.Text.Length > 0)
            {
                float result;
                bool isNumeric = float.TryParse(toolStripTextBoxWidthGauss.Text, out result);

                if (isNumeric)
                {
                    currentTextWidth = toolStripTextBoxWidthGauss.Text;
                }
                else
                {
                    toolStripTextBoxWidthGauss.Text = currentTextWidth;
                    toolStripTextBoxWidthGauss.Select(toolStripTextBoxWidthGauss.Text.Length, 0);
                }
            }

        }

        private void toolStripTextBoxWidthGauss_Leave(object sender, EventArgs e)
        {
            
        }
        #endregion
        //////////////////////

        #region Change Type Smooth
        void MakeVisibelGaussSmooth(bool value)
        {
            toolStripLabelGauss.Visible = value;
            toolStripTextBoxWidthGauss.Visible = value;
        }

        void MakeVisibel2ParamSmooth(bool value)
        {
            toolStripOutStep.Visible = value;
            toolStripTextBoxOutStep.Visible = value;
            toolStripButtonIncOutStep.Visible = value;
            toolStripButtonDecOutStep.Visible = value;
            toolStripSeparator3.Visible = value;
            toolStripLabelInStep.Visible = value;
            toolStripTextBoxInStep.Visible = value;
            toolStripButtonIncInStep.Visible = value;
            toolStripButtonDecInStep.Visible = value;
        }

        int SelectedIndexSmooth = 0;
        private void toolStripComboBoxSmooth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxSmooth.SelectedIndex == 0)
            {
                MakeVisibelGaussSmooth(false);
                MakeVisibel2ParamSmooth(true);
                SelectedIndexSmooth = 0;
            }
            else
            {
                MakeVisibelGaussSmooth(true);
                MakeVisibel2ParamSmooth(false);
                SelectedIndexSmooth = 1;
            }
        }

        #endregion

        private void toolStripButtonReCalc_Click(object sender, EventArgs e)
        {
            RecalcAsync();
        }

        private void ReCalcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecalcAsync();
        }

        private void toolStripButtonFindEvent_Click(object sender, EventArgs e)
        {
            if(!flag_events)
            CalcEvents();
        }

        private void findEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!flag_events)
                CalcEvents();
        }

        private void toolStripComboBoxSelectTypeSeach_SelectedIndexChanged(object sender, EventArgs e)
        {
            flag_events = false;
        }

        private void ToolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("RMCA " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        FormPickEvents formEvevnts = new FormPickEvents();
        int manualStep;
        int manualStartPoint;
        int diffPoints;
        //опорные точки
        double[] pointsX;
        double[] pointsDegreeX;
        double[] pointsY;
        double[] pointsDegreeY;
        double[] pointsTimeX;
        double[] pointsTimeYVu;
        double[] pointsTimeYAc;
        //точки смещения
        double[] pointsDiffX;
        double[] pointsDiffDegreeX;
        double[] pointsDiffY;
        double[] pointsDiffDegreeY;
        double[] pointsDiffTimeX;
        double[] pointsDiffTimeYVu;
        double[] pointsDiffTimeYAc;
        bool isAddedEvents = false;
        //add events manually
        private void addEventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show dialog
            DialogResult res = formEvevnts.ShowDialog();
            if (res == DialogResult.OK)
            {
                //setup events
                manualStartPoint = formEvevnts.StartPoint;
                manualStep = formEvevnts.Step;
                diffPoints = formEvevnts.DiffPoints;
                //show events
                if(record!= null && flag_record && flag_graph)
                {
                    //calculate points
                        

                    if (calc_record == null)
                    {
                        calc_record = new ClassCalc();
                    }
                    calc_record.CalculateDegree(record);

                    int numberPoints = Convert.ToInt32((calc_record.front_vu.LongLength - manualStartPoint) / manualStep); 
                    pointsX = new double[numberPoints];
                    pointsDegreeX = new double[numberPoints];
                    pointsY = new double[numberPoints];
                    pointsDegreeY = new double[numberPoints];
                    pointsTimeX = new double[numberPoints];
                    pointsTimeYVu = new double[numberPoints];
                    pointsTimeYAc = new double[numberPoints];

                    int numberPointsDiff = Convert.ToInt32((calc_record.front_vu.LongLength - manualStartPoint - diffPoints) / manualStep);
                    pointsDiffX = new double[numberPointsDiff];
                    pointsDiffDegreeX = new double[numberPointsDiff];
                    pointsDiffY = new double[numberPointsDiff];
                    pointsDiffDegreeY = new double[numberPointsDiff];
                    pointsDiffTimeX = new double[numberPointsDiff];
                    pointsDiffTimeYVu = new double[numberPointsDiff];
                    pointsDiffTimeYAc = new double[numberPointsDiff];

                    for(int i = 0; i < numberPoints; i++)
                    {
                        pointsX[i] = calc_record.front_vu[manualStartPoint + i * manualStep];
                        pointsDegreeX[i] = manualStartPoint + i * manualStep;
                        if (calc_record.t_vu != null)
                        {
                            pointsTimeX[i] = calc_record.t_vu[manualStartPoint + i * manualStep];
                            pointsTimeYVu[i] = calc_record.vu[manualStartPoint + i * manualStep];
                        }

                        if (calc_record.t_ac != null && calc_record.ac != null)
                            pointsTimeYAc[i] = calc_record.GetValueFunc(pointsTimeX[i], calc_record.t_ac, calc_record.ac).y;
                        else
                            pointsTimeYAc[i] = 0;
                        pointsDegreeY[i] = pointsY[i] = 0;
                        if (flag_calc)
                        {
                            var point = calc_record.GetValueFunc(pointsDegreeX[i], calc_record.degree_vu, calc_record.vu);
                            pointsDegreeY[i] = point.y;
                        }
                    }

                    for (int i = 0; i < numberPointsDiff; i++)
                    {
                        pointsDiffX[i] = calc_record.front_vu[manualStartPoint + i * manualStep + diffPoints];
                        pointsDiffDegreeX[i] = manualStartPoint + i * manualStep + diffPoints;
                        if (calc_record.t_vu != null)
                        {
                            pointsDiffTimeX[i] = calc_record.t_vu[manualStartPoint + i * manualStep + diffPoints];
                            pointsDiffTimeYVu[i] = calc_record.vu[manualStartPoint + i * manualStep + diffPoints];
                        }

                        if (calc_record.t_ac != null && calc_record.ac != null)
                            pointsDiffTimeYAc[i] = calc_record.GetValueFunc(pointsDiffTimeX[i], calc_record.t_ac, calc_record.ac).y;
                        else
                            pointsDiffTimeYAc[i] = 0;

                        pointsDiffDegreeY[i] = pointsDiffY[i] = 0;
                        if (flag_calc)
                        {
                            var point = calc_record.GetValueFunc(pointsDiffDegreeX[i], calc_record.degree_vu, calc_record.vu);
                            pointsDiffDegreeY[i] = point.y;
                        }
                    }

                    cl2d.DrawEvents(pointsX, pointsY, 2);

                    if (nChannel > 0 && tabControlMain.Contains(tabPageFilter))
                    {
                        ZedGraphHelper.CreateGraph(ref zedGraphControlSource, ref record.time, "Время, сек", ref record.ch[nChannel - 1], "", record.KadrsNumber, ref pointsX, ref pointsY, "Опорные точки", StylePoint.getStyleStartPoint(), "График исходных данных");
                        ZedGraphHelper.CreateGraph(ref zedGraphControlFiltered, ref record.time, "Время, сек", ref filterY, "", record.KadrsNumber, ref pointsX, ref pointsY, "Опорные точки", StylePoint.getStyleStartPoint(), "График отфильтрованных данных");
                    }
                    ZedGraphHelper.CreateGraph(ref zedGraphControlDegreeSpeed, ref calc_record.degree_vu, "градусы", ref calc_record.vu, "частота вращения, об/мин", calc_record.kol_vu, ref pointsDegreeX, ref pointsDegreeY, "Опорные точки", StylePoint.getStyleStartPoint(), "");
                    ZedGraphHelper.CreateGraph(ref zedGraphControlDegreeAcc, ref calc_record.degree_ac, "градусы", ref calc_record.ac, "ускорение, рад/c^2", calc_record.kol_ac, ref pointsDegreeX, ref pointsY, "Опорные точки", StylePoint.getStyleStartPoint(), "");

                    ZedGraphHelper.AppendEventsToGraph(ref zedGraphControlTimeSpeed, pointsTimeX, pointsTimeYVu, "Опорные точки", StylePoint.getStyleStartPoint());
                    ZedGraphHelper.AppendEventsToGraph(ref zedGraphControlTimeAcceleration, pointsTimeX, pointsTimeYAc, "Опорные точки", StylePoint.getStyleStartPoint());

                    ZedGraphHelper.AppendEventsToGraph(ref zedGraphControlTimeSpeed, pointsDiffTimeX, pointsDiffTimeYVu, "Точки смещения", StylePoint.getStyleDiffPoint());
                    ZedGraphHelper.AppendEventsToGraph(ref zedGraphControlTimeAcceleration, pointsDiffTimeX, pointsDiffTimeYAc, "Точки смещения", StylePoint.getStyleDiffPoint());

                    ZedGraphHelper.AppendEventsToGraph(ref zedGraphControlDegreeSpeed, pointsDiffDegreeX, pointsDiffTimeYVu, "Точки смещения", StylePoint.getStyleDiffPoint());
                    ZedGraphHelper.AppendEventsToGraph(ref zedGraphControlDegreeAcc, pointsDiffDegreeX, pointsDiffTimeYAc, "Точки смещения", StylePoint.getStyleDiffPoint());

                    isAddedEvents = true;
                    OpenGlControlGraph.Invalidate();
                    zedGraphControlFiltered.Invalidate();
                    zedGraphControlSource.Invalidate();
                    CreateReport();
                }
            }
        }


        //задание фильрации 

        FormFilterConfig formFilter = new FormFilterConfig();
        int typeFilter;
        int nChannel;
        int numberPoints;
        void backWorkerFilter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Invoke(new Action(() => Filter()));
        }

        private void FilterDataSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!flag_record)
            {
                CreateBackgroundWorker(bw_DoWorkShowGraph);
                bw.RunWorkerCompleted += backWorkerFilter_RunWorkerCompleted;
                launchBgWorker();
            }
            else
                Filter();
        }

        double[] filterY;
        void Filter()
        {
            if (flag_record)
            {
                formFilter.maxChannels = record.NumberOfChannels;
                DialogResult dialogRes = formFilter.ShowDialog();
                tabControlMain.TabPages.Remove(tabPageFilter);
                if (dialogRes == DialogResult.OK)
                {
                    typeFilter = formFilter.typeFilter;
                    nChannel = formFilter.numberChannel;
                    numberPoints = formFilter.numberPoints;
                    //calculate filter
                    filterY = ClassFilter.filterSmooth(record.time, record.ch[nChannel - 1],numberPoints,typeFilter);

                    //create graphics

                    tabControlMain.TabPages.Add(tabPageFilter);
                    ZedGraphHelper.CreateGraph(ref zedGraphControlSource, ref record.time, "Время, сек", ref record.ch[nChannel - 1], "", record.KadrsNumber, "", "График исходных данных");
                    ZedGraphHelper.CreateGraph(ref zedGraphControlFiltered, ref record.time, "Время, сек", ref filterY, "", record.KadrsNumber, "", "График отфильтрованных данных");
                    tabControlMain.SelectedTab = tabPageFilter;
                }
            }
        }

        private void zedGraphControlSource_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
        {
            GraphPane pane ;

            using (var g = sender.CreateGraphics())
                pane = sender.MasterPane.FindPane(sender.PointToClient(MousePosition));

            // The excludedGraphPane has to remain independant
            if (pane == null || sender == zedGraphControlFiltered)
                return;


            GraphPane penFiltered = zedGraphControlFiltered.GraphPane;
            penFiltered.XAxis.Scale.Min = pane.XAxis.Scale.Min;
            penFiltered.XAxis.Scale.Max = pane.XAxis.Scale.Max;
            penFiltered.YAxis.Scale.Min = pane.YAxis.Scale.Min;
            penFiltered.YAxis.Scale.Max = pane.YAxis.Scale.Max;
            penFiltered.AxisChange(); // Only necessary if one or more scale property is set to Auto.
            zedGraphControlFiltered.Invalidate();
        }

        private void zedGraphControlFiltered_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
        {
            GraphPane pane;

            using (var g = sender.CreateGraphics())
                pane = sender.MasterPane.FindPane(sender.PointToClient(MousePosition));

            // The excludedGraphPane has to remain independant
            if (pane == null || sender == zedGraphControlSource)
                return;


            GraphPane penFiltered = zedGraphControlSource.GraphPane;
            penFiltered.XAxis.Scale.Min = pane.XAxis.Scale.Min;
            penFiltered.XAxis.Scale.Max = pane.XAxis.Scale.Max;
            penFiltered.YAxis.Scale.Min = pane.YAxis.Scale.Min;
            penFiltered.YAxis.Scale.Max = pane.YAxis.Scale.Max;
            penFiltered.AxisChange(); // Only necessary if one or more scale property is set to Auto.
            zedGraphControlSource.Invalidate();
        }

        private void aboutSmoothGaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //http://docs.opencv.org/doc/tutorials/imgproc/gausian_median_blur_bilateral_filter/gausian_median_blur_bilateral_filter.html
            ProcessStartInfo sInfo = new ProcessStartInfo("http://docs.opencv.org/doc/tutorials/imgproc/gausian_median_blur_bilateral_filter/gausian_median_blur_bilateral_filter.html");
            Process.Start(sInfo);
        }




        //////////////////////////////////////////////////////////////////////
    }
}

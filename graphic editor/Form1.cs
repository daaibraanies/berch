using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Windows.Forms;
using graphic_editor;

namespace graphic_editor
{
    public partial class Form1 : Form
    {
        #region Global DATA
        
        const int TEMP_PEN_WIDTH = 3;                                       //Толщина  линии

        Graphics g;                                                         //ПОверхность отрисовки

        static public Line SelectedItem = null;                             //Выбранная линия (нужна в какой - то конкретной функции)
        static public Line WrapperForSelectedLines = null;                  //Сюда при выделении кладется единственная линия, с которой будут работать функции 
        static public List<Line> TreeSelectedLines = new List<Line>();      //Список линий для вывода в ГУИ
        static public ComplexLines WrapperForComplexlines = null;           //Сюда зыпоминиается объект - скрепленные линии
        public static List<Line> _allLines = new List<Line>();              //список всех линий на полотне

        public static int TOP_BORDER;                                       //Границы
        public static int BOTTOM_BORDER;
        public static int LEFT_BORDER;
        public static int RIGHT_BORDER;


        static Action CURRENT_ACTION = Action.Draw;                         //По дефолту действие - рисование

        public enum Action                                                      //Действия и функции объектов
        {
            Draw,                                                               //Росивание
            Transfer,                                                          //Перемещение
            Select,                                                            //Выделение
            Delete,                                                            //УДаление
            Fix,                                                               //Фиксирование                
            AlignVertically,                                                   //выровнять по вертикали        
            AlignHorizontally,                                                 //выровнять по горизонтали        
            MakeParallelTo,                                                    //Сдлелать линию параллельной другой         
            MakeOrthogonal,                                                    //Сдлелать линию перепендикулярной другой            
            Angle,                                                             //Вывести угол между линиями
            Combine,
            FixPoint
        }


        #endregion

        #region Functional
       
        /// <summary>
        /// Создание компонентов формы и их инициализация
        /// </summary>
        public Form1()
        {
            MyLogger.LogIt("Form's initialized", MyLogger.Importance.SYSTEM);
            InitializeComponent();

            TOP_BORDER = drawingPanel.Height;
            BOTTOM_BORDER = drawingPanel.Bottom;
            LEFT_BORDER = drawingPanel.Left;
            RIGHT_BORDER = drawingPanel.Right;

            TreeListControl.Enabled = true;                                         //Вывод списка линий в ГУИ
            TreeListControl.TreeSource = listTree;

            InfoPanel.lineLenghtInfo = lineLengthFLD;                               //Вся инфа на ГУИ панелях назначается тут, инициализируется ниже
            InfoPanel.startPointInfo = startPointUI;
            InfoPanel.endPointInfo = endPointUI;
            InfoPanel.currentActionInfo = currentActionUI;
            InfoPanel.INFOPANEL_INIT();

            g = drawingPanel.CreateGraphics();                                      //Создаем графическое полотно на панели
          
            this.DoubleBuffered = true;                                             //двойная буферизация что бы не мелькало при рисованиии
        }

        /// <summary>
        /// Начало выполнения какого либо {ВЫБРАННОГО} действия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drawingPanel_MouseDown(object sender, MouseEventArgs e)
        {

            InfoPanel.toDefault();

            if(e.Button == MouseButtons.Left)                                               //В соотвествии с текущим действием включается функция
            {
                if(CURRENT_ACTION==Action.Draw)
                    Line.StartDrawingLine(e);
                if (CURRENT_ACTION == Action.Transfer)
                    Line.TransferLine(e);
                if (CURRENT_ACTION == Action.Select)
                    Line.SelectLine(e);
                if (CURRENT_ACTION == Action.Delete)
                    Line.DeleteLine(e);
                if (CURRENT_ACTION == Action.Fix)
                    Line.FixLine(e);
                if (CURRENT_ACTION == Action.AlignHorizontally)
                    Line.AlignHorizontally(e);  
                if (CURRENT_ACTION == Action.AlignVertically)
                    Line.AlignVertivally(e);
                if (CURRENT_ACTION == Action.MakeOrthogonal)
                    Line.MakePerpendicularLine(e.Location);
                if (CURRENT_ACTION == Action.MakeParallelTo)
                    Line.MakeParallelLine(e.Location);
                if (CURRENT_ACTION == Action.Angle)
                    Line.ShowAngleBetween(e.Location);
                if (CURRENT_ACTION == Action.FixPoint)
                    Line.FixPointOnLine(e.Location);

            }
            drawingPanel.Refresh();    
        }

        /// <summary>
        /// Обработчик клавиш-команд, шорткаты
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) 
        {

            #region CLosing and MassDelete
            if (keyData == Keys.Escape)
            {
                return true;
            }
            if(keyData == Keys.Delete)
            {
                if(TreeSelectedLines.Count>0)
                {
                    foreach(var line in TreeSelectedLines)
                    {
                        TreeListControl.RemoveInfoLine(line);
                        _allLines.Remove(line);
                    }
                    drawingPanel.Refresh();
                    TreeListControl.TreeSource.Refresh();
                }
            }
            #endregion

            #region Manage ShortCuts
            //шорткаты
            if (keyData == Keys.P)
            {
                CURRENT_ACTION = Action.MakeParallelTo;
                InfoPanel.currentActionInfo.Text = "Параллельность к.";
                
            }

            if(keyData == Keys.U && TreeSelectedLines.Count>1)
            {
                TightUper.TightUp(TreeSelectedLines);
                TreeListControl.TreeSource.Refresh();
            }
            
            if (keyData ==  Keys.D)
            {
                CURRENT_ACTION = Action.Draw;
                InfoPanel.currentActionInfo.Text = "Рисование.";
            }

            if (keyData == Keys.C)
            {
                CURRENT_ACTION = Action.Delete;
                InfoPanel.currentActionInfo.Text = "Удаление.";
            }

            if (keyData == Keys.S)
            { 
                CURRENT_ACTION = Action.Select;
                InfoPanel.currentActionInfo.Text = "Выбор.";
            }

            if (keyData == Keys.T)
            {
                CURRENT_ACTION = Action.Transfer;
                InfoPanel.currentActionInfo.Text = "Перемещение.";
            }
                
            if (keyData == Keys.F)
            {
                CURRENT_ACTION = Action.Fix;
                InfoPanel.currentActionInfo.Text = "Фиксация";
            }

            if (keyData == Keys.Q)
            {
                CURRENT_ACTION = Action.AlignHorizontally;
                InfoPanel.currentActionInfo.Text = "Выровнять гор.";
            }
            if (keyData == Keys.W)
            {
                CURRENT_ACTION = Action.AlignVertically;
                InfoPanel.currentActionInfo.Text = "Выровнять верт.";
            }
            if (keyData == Keys.E)
            {
                CURRENT_ACTION = Action.MakeParallelTo;
                InfoPanel.currentActionInfo.Text = "Параллельность к.";
            }

            if(keyData == Keys.O)
            {
                CURRENT_ACTION = Action.MakeOrthogonal;
                InfoPanel.currentActionInfo.Text = "Ортогональность к.";

                string message = "Линия которая будет повернута, затем относительно которой будет повернута."; 
                string caption = "Виберите линию.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }

            if(keyData == Keys.A)
            {
                CURRENT_ACTION = Action.Angle;
                InfoPanel.currentActionInfo.Text = "Угол.";
            }

            if(keyData==Keys.N)
            {
                CURRENT_ACTION = Action.FixPoint;
                InfoPanel.currentActionInfo.Text = "Фиксация точки";
            }

            return base.ProcessCmdKey(ref msg, keyData);
            #endregion
        }


        /// <summary>
        /// Действия выполняющиеся при закрытии программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyLogger.LogIt("-----------------------------------------------------------------------------", MyLogger.Importance.SYSTEM);
        }

        /// <summary>
        /// Действия выполняемые над объектами, преобразования, с удержаением ЛКМ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            #region DRAW
            /*Установка конечно точки линнии, дополнение неполного объекта и добавление в дерево*/
                    if (e.Button == MouseButtons.Left)
            {                    /*Начальная стадия отрисовки линии, добавление точки начала и объкта линия в общий массив*/
                    if (CURRENT_ACTION == Action.Draw)             
                    {
                            InfoPanel.endPointInfo.Text = e.Location.ToString();
                            Line.FinishDrawingLine(e, _allLines.Last());
                            drawingPanel.Invalidate();
                    }
                drawingPanel.Refresh();
                #endregion

            #region Transer    
                /*Перемещение объектов*/
                if (CURRENT_ACTION==Action.Transfer)             
                    {
                        /*Перемещение единственной линии*/
                        if (WrapperForSelectedLines != null && !WrapperForSelectedLines.Fixed)              
                        {
                            WrapperForSelectedLines.PenColor = Line.EDITORIAL_COLOR;

                            WrapperForSelectedLines.StartPoint = new Point(
                                   WrapperForSelectedLines.DeltaStart.X + e.Location.X,
                                   WrapperForSelectedLines.DeltaStart.Y + e.Location.Y
                                   );
                            WrapperForSelectedLines.EndPoint = new Point(
                                   WrapperForSelectedLines.DeltaEnd.X + e.Location.X,
                                   WrapperForSelectedLines.DeltaEnd.Y + e.Location.Y
                                   );

                            foreach(Line randomline in _allLines)
                            {
                            if (randomline != WrapperForSelectedLines)
                            { 
                                if (randomline.isEndPoint(WrapperForSelectedLines.StartPoint))
                                {
                                    WrapperForSelectedLines.PenColor = Line.NEARBY_COLOR;
                                    WrapperForSelectedLines.StartPoint = randomline.EndPoint;
                                    
                                }
                                else if (randomline.isEndPoint(WrapperForSelectedLines.EndPoint))
                                {
                                    WrapperForSelectedLines.PenColor = Line.NEARBY_COLOR;
                                    WrapperForSelectedLines.EndPoint = randomline.EndPoint;
                                    
                                }
                                else if(randomline.isStartPoint(WrapperForSelectedLines.StartPoint))
                                {
                                    WrapperForSelectedLines.PenColor = Line.NEARBY_COLOR;
                                    WrapperForSelectedLines.StartPoint = randomline.StartPoint;
                                    
                                }
                                else if(randomline.isStartPoint(WrapperForSelectedLines.EndPoint))
                                {
                                    WrapperForSelectedLines.PenColor = Line.NEARBY_COLOR;
                                    WrapperForSelectedLines.EndPoint = randomline.StartPoint;
                                }
                            }
                        }

                        }
                        else
                        {
                            MyLogger.LogIt("Line hadnt been selected correctly, no reference.", MyLogger.Importance.Fatal);
                        }
                        /*Перемещение единственной комплекса линий*/
                        if (WrapperForComplexlines!=null)           
                        {
                            foreach(Line particalLine in WrapperForComplexlines.Lines)
                            {
                                particalLine.StartPoint = new Point(
                                    particalLine.DeltaStart.X + e.Location.X,
                                    particalLine.DeltaStart.Y + e.Location.Y
                                    );
                                particalLine.EndPoint = new Point(
                                    particalLine.DeltaEnd.X + e.Location.X,
                                     particalLine.DeltaEnd.Y + e.Location.Y);
                            }
                        }
                        else
                        {
                            MyLogger.LogIt("Line hadnt been selected correctly, no reference.", MyLogger.Importance.Fatal);
                        }
                        drawingPanel.Refresh();
                    }
            }
            #endregion
        }

        /// <summary>
        /// Заверщающий этап какого либо {ВЫБРАННОГО} действия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            /*Завершение перемещения линии*/
            if(CURRENT_ACTION == Action.Transfer)            
            {
                if (WrapperForSelectedLines!=null)
                {
                    if(!WrapperForSelectedLines.Fixed)
                    {
                        WrapperForSelectedLines.PenColor = Line.GENERAL_COLOR;
                        drawingPanel.Refresh();

                        MyLogger.LogIt(
                                    "Line's been transfered "
                                     + WrapperForSelectedLines.Id.ToString() +
                                     " |" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()
                                     + "|", MyLogger.Importance.Info
                                      );
                        WrapperForSelectedLines = null;
                    }
                }
                else if(WrapperForComplexlines!=null)
                {
                    WrapperForComplexlines = null;
                }
            }
            /*Завершение создания линии*/
            if (CURRENT_ACTION == Action.Draw)          
            {
                Line line = _allLines.Last();
                Line.FinishDrawingLine(e, line);
                InfoPanel.lineLenghtInfo.Text = line.Length.ToString();

                /*Пополнение информационных таблиц*/
                TreeListControl.AddNewInfoLine(line);
                MyLogger.LogIt(
                                "Line's been made "
                                + line.Id.ToString() +
                                " |" + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString()
                               + "|", MyLogger.Importance.Info
                              );
            }
        }

        /// <summary>
        /// Орисовка всех объектов панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            if (_allLines != null && _allLines.Count != 0)
            {
                Line drawingLine = _allLines.Last();
                drawingLine.DrawStartPoints(e);

                using (Pen pn = new Pen(drawingLine.PenColor, drawingLine.PenSize))
                {
                    e.Graphics.DrawLine(pn, drawingLine.StartPoint, drawingLine.EndPoint);
                   
                }
            }
            foreach (Line line in _allLines)
            {
                using (Pen pn = new Pen(line.PenColor, line.PenSize))
                { 
                    e.Graphics.DrawLine(pn, line.StartPoint, line.EndPoint);
                    line.DrawStartPoints(e);
                }
                
            }
        }
    
        /// <summary>
        /// Настройки панели, необходимые перед началом работы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }

        private void drawingPanel_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }

        #endregion

        #region UIstuff

        //реакция на нажатие различных ГУИ штуковин
        private void listTree_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(ListViewItem lineItem in listTree.SelectedItems)
            {
                int lineId = int.Parse(lineItem.Text);
                Line selectedLine = _allLines.Find(x => x.Id == lineId);
                if(!TreeSelectedLines.Contains(selectedLine))
                {
                    TreeSelectedLines.Add(selectedLine);
                    selectedLine.PenColor = Line.SELECTED_COLOR;
                }
                else
                {
                    TreeSelectedLines.Remove(selectedLine);
                    selectedLine.PenColor = Line.GENERAL_COLOR;
                }
                drawingPanel.Refresh();
            }
        }

        private void tranferBtn_Click(object sender, EventArgs e)
        {
            CURRENT_ACTION = Action.Transfer;
            InfoPanel.currentActionInfo.Text = "Перемещение";
        }
        private void selectBtn_Click(object sender, EventArgs e)
        {
            CURRENT_ACTION = Action.Select;
            InfoPanel.currentActionInfo.Text = "Выбор";
        }
        private void drawBtn_Click_1(object sender, EventArgs e)
        {
            CURRENT_ACTION = Action.Draw;
            InfoPanel.currentActionInfo.Text = "Рисование";
        }
        private void clearBtn_Click_1(object sender, EventArgs e)
        {
            CURRENT_ACTION = Action.Delete;
            InfoPanel.currentActionInfo.Text = "Удаление";
        }
        private void fixBTN_Click(object sender, EventArgs e)
        {
            CURRENT_ACTION = Action.Fix;
            InfoPanel.currentActionInfo.Text = "Фиксация";
        }
        private void perpendicularBTN_Click(object sender, EventArgs e)
        {
            CURRENT_ACTION = Action.MakeOrthogonal;
            InfoPanel.currentActionInfo.Text = "Ортогональность к.";
        }
        #endregion

        private void parallelBTN_Click(object sender, EventArgs e)
        {
            CURRENT_ACTION = Action.MakeParallelTo;
            InfoPanel.currentActionInfo.Text = "Паралльность к.";
        }

        private void AngleBTN_Click(object sender, EventArgs e)
        {
            CURRENT_ACTION = Action.Angle;
            InfoPanel.currentActionInfo.Text = "Угол.";
        }

        private void VertAlignBTN_Click(object sender, EventArgs e)
        {
            CURRENT_ACTION = Action.AlignVertically;
            InfoPanel.currentActionInfo.Text = "Выравнять верт.";
        }

        private void HorizontalAlignBTN_Click(object sender, EventArgs e)
        {
            CURRENT_ACTION = Action.AlignHorizontally;
            InfoPanel.currentActionInfo.Text = "Выравнять гор.";
        }

        private void ComplexBTN_Click(object sender, EventArgs e)
        {
            if(TreeSelectedLines.Count>1)
            {
                InfoPanel.currentActionInfo.Text = "Объединение";
                TightUper.TightUp(TreeSelectedLines);
                TreeListControl.TreeSource.Refresh();
            }else
            {
                string message = "Выделите 2 и более линий для объединения.";
                string caption = "Действие невозможно.";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }

        }

        private void FIxPointBTN_Click(object sender, EventArgs e)
        {
            CURRENT_ACTION = Action.FixPoint;
            InfoPanel.currentActionInfo.Text = "Фиксация точки";
        }
    }

}

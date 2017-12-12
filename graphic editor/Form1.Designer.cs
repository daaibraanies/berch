using System.Windows.Forms;
using System.Drawing;

namespace graphic_editor
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SectionControlTable = new System.Windows.Forms.TableLayoutPanel();
            this.listTree = new System.Windows.Forms.ListView();
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Information = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.informPanel = new System.Windows.Forms.Panel();
            this.lineLengthFLD = new System.Windows.Forms.Label();
            this.currentActionUI = new System.Windows.Forms.Label();
            this.labelAction = new System.Windows.Forms.Label();
            this.endPointUI = new System.Windows.Forms.Label();
            this.startPointUI = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.ComplexBTN = new System.Windows.Forms.Button();
            this.drawBtn = new System.Windows.Forms.Button();
            this.selectBtn = new System.Windows.Forms.Button();
            this.tranferBtn = new System.Windows.Forms.Button();
            this.fixBTN = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.parallelBTN = new System.Windows.Forms.Button();
            this.perpendicularBTN = new System.Windows.Forms.Button();
            this.AngleBTN = new System.Windows.Forms.Button();
            this.VertAlignBTN = new System.Windows.Forms.Button();
            this.HorizontalAlignBTN = new System.Windows.Forms.Button();
            this.FIxPointBTN = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.drawingPanel = new System.Windows.Forms.PictureBox();
            this.SectionControlTable.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.informPanel.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawingPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // SectionControlTable
            // 
            this.SectionControlTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.SectionControlTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.SectionControlTable.ColumnCount = 3;
            this.SectionControlTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.48014F));
            this.SectionControlTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.51986F));
            this.SectionControlTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 203F));
            this.SectionControlTable.Controls.Add(this.listTree, 2, 0);
            this.SectionControlTable.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.SectionControlTable.Controls.Add(this.drawingPanel, 1, 0);
            this.SectionControlTable.Location = new System.Drawing.Point(0, 1);
            this.SectionControlTable.Margin = new System.Windows.Forms.Padding(0);
            this.SectionControlTable.Name = "SectionControlTable";
            this.SectionControlTable.RowCount = 2;
            this.SectionControlTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.19355F));
            this.SectionControlTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.80645F));
            this.SectionControlTable.Size = new System.Drawing.Size(1364, 621);
            this.SectionControlTable.TabIndex = 0;
            // 
            // listTree
            // 
            this.listTree.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.listTree.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.Information});
            this.listTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listTree.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listTree.FullRowSelect = true;
            this.listTree.GridLines = true;
            this.listTree.Location = new System.Drawing.Point(1160, 1);
            this.listTree.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.listTree.Name = "listTree";
            this.listTree.Size = new System.Drawing.Size(203, 229);
            this.listTree.TabIndex = 1;
            this.listTree.UseCompatibleStateImageBehavior = false;
            this.listTree.View = System.Windows.Forms.View.Details;
            this.listTree.SelectedIndexChanged += new System.EventHandler(this.listTree_SelectedIndexChanged);
            // 
            // No
            // 
            this.No.Text = "No";
            this.No.Width = 34;
            // 
            // Information
            // 
            this.Information.Text = "Information";
            this.Information.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Information.Width = 157;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.informPanel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.49541F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.50459F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(207, 527);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // informPanel
            // 
            this.informPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.informPanel.Controls.Add(this.lineLengthFLD);
            this.informPanel.Controls.Add(this.currentActionUI);
            this.informPanel.Controls.Add(this.labelAction);
            this.informPanel.Controls.Add(this.endPointUI);
            this.informPanel.Controls.Add(this.startPointUI);
            this.informPanel.Controls.Add(this.label);
            this.informPanel.Controls.Add(this.label2);
            this.informPanel.Controls.Add(this.label1);
            this.informPanel.ForeColor = System.Drawing.SystemColors.Control;
            this.informPanel.Location = new System.Drawing.Point(3, 279);
            this.informPanel.Name = "informPanel";
            this.informPanel.Size = new System.Drawing.Size(200, 224);
            this.informPanel.TabIndex = 0;
            // 
            // lineLengthFLD
            // 
            this.lineLengthFLD.AutoSize = true;
            this.lineLengthFLD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lineLengthFLD.Location = new System.Drawing.Point(52, 35);
            this.lineLengthFLD.Name = "lineLengthFLD";
            this.lineLengthFLD.Size = new System.Drawing.Size(15, 15);
            this.lineLengthFLD.TabIndex = 8;
            this.lineLengthFLD.Text = "0";
            // 
            // currentActionUI
            // 
            this.currentActionUI.AutoSize = true;
            this.currentActionUI.Location = new System.Drawing.Point(66, 9);
            this.currentActionUI.Name = "currentActionUI";
            this.currentActionUI.Size = new System.Drawing.Size(62, 13);
            this.currentActionUI.TabIndex = 7;
            this.currentActionUI.Text = "Рисование";
            // 
            // labelAction
            // 
            this.labelAction.AutoSize = true;
            this.labelAction.Location = new System.Drawing.Point(0, 9);
            this.labelAction.Name = "labelAction";
            this.labelAction.Size = new System.Drawing.Size(60, 13);
            this.labelAction.TabIndex = 6;
            this.labelAction.Text = "Действие:";
            // 
            // endPointUI
            // 
            this.endPointUI.AutoSize = true;
            this.endPointUI.ForeColor = System.Drawing.SystemColors.Control;
            this.endPointUI.Location = new System.Drawing.Point(105, 95);
            this.endPointUI.Margin = new System.Windows.Forms.Padding(3);
            this.endPointUI.Name = "endPointUI";
            this.endPointUI.Size = new System.Drawing.Size(13, 13);
            this.endPointUI.TabIndex = 4;
            this.endPointUI.Text = "0";
            // 
            // startPointUI
            // 
            this.startPointUI.AutoSize = true;
            this.startPointUI.ForeColor = System.Drawing.SystemColors.Control;
            this.startPointUI.Location = new System.Drawing.Point(105, 65);
            this.startPointUI.Margin = new System.Windows.Forms.Padding(3);
            this.startPointUI.Name = "startPointUI";
            this.startPointUI.Size = new System.Drawing.Size(13, 13);
            this.startPointUI.TabIndex = 5;
            this.startPointUI.Text = "0";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.ForeColor = System.Drawing.SystemColors.Control;
            this.label.Location = new System.Drawing.Point(3, 95);
            this.label.Margin = new System.Windows.Forms.Padding(3);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(89, 13);
            this.label.TabIndex = 4;
            this.label.Text = "Конечная точка:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(3, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Начальная точка:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(0, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Длиина:";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.ComplexBTN, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.drawBtn, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.selectBtn, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tranferBtn, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.fixBTN, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.clearBtn, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.parallelBTN, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.perpendicularBTN, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.AngleBTN, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.VertAlignBTN, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.HorizontalAlignBTN, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.FIxPointBTN, 1, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.16667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.83333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(201, 123);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // ComplexBTN
            // 
            this.ComplexBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ComplexBTN.BackgroundImage")));
            this.ComplexBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ComplexBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComplexBTN.Location = new System.Drawing.Point(4, 84);
            this.ComplexBTN.Name = "ComplexBTN";
            this.ComplexBTN.Size = new System.Drawing.Size(33, 34);
            this.ComplexBTN.TabIndex = 11;
            this.ComplexBTN.Click += new System.EventHandler(this.ComplexBTN_Click);
            // 
            // drawBtn
            // 
            this.drawBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("drawBtn.BackgroundImage")));
            this.drawBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.drawBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.drawBtn.Location = new System.Drawing.Point(4, 4);
            this.drawBtn.Name = "drawBtn";
            this.drawBtn.Size = new System.Drawing.Size(32, 35);
            this.drawBtn.TabIndex = 1;
            this.drawBtn.Click += new System.EventHandler(this.drawBtn_Click_1);
            // 
            // selectBtn
            // 
            this.selectBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("selectBtn.BackgroundImage")));
            this.selectBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.selectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.selectBtn.Location = new System.Drawing.Point(4, 46);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(32, 31);
            this.selectBtn.TabIndex = 2;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // tranferBtn
            // 
            this.tranferBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tranferBtn.BackgroundImage")));
            this.tranferBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tranferBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tranferBtn.Location = new System.Drawing.Point(44, 4);
            this.tranferBtn.Name = "tranferBtn";
            this.tranferBtn.Size = new System.Drawing.Size(33, 35);
            this.tranferBtn.TabIndex = 3;
            this.tranferBtn.Click += new System.EventHandler(this.tranferBtn_Click);
            // 
            // fixBTN
            // 
            this.fixBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("fixBTN.BackgroundImage")));
            this.fixBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.fixBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fixBTN.Location = new System.Drawing.Point(84, 4);
            this.fixBTN.Name = "fixBTN";
            this.fixBTN.Size = new System.Drawing.Size(33, 35);
            this.fixBTN.TabIndex = 5;
            this.fixBTN.Click += new System.EventHandler(this.fixBTN_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("clearBtn.BackgroundImage")));
            this.clearBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearBtn.Location = new System.Drawing.Point(44, 46);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(33, 31);
            this.clearBtn.TabIndex = 4;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click_1);
            // 
            // parallelBTN
            // 
            this.parallelBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("parallelBTN.BackgroundImage")));
            this.parallelBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.parallelBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.parallelBTN.Location = new System.Drawing.Point(164, 4);
            this.parallelBTN.Name = "parallelBTN";
            this.parallelBTN.Size = new System.Drawing.Size(33, 35);
            this.parallelBTN.TabIndex = 7;
            this.parallelBTN.Click += new System.EventHandler(this.parallelBTN_Click);
            // 
            // perpendicularBTN
            // 
            this.perpendicularBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("perpendicularBTN.BackgroundImage")));
            this.perpendicularBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.perpendicularBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.perpendicularBTN.Location = new System.Drawing.Point(164, 46);
            this.perpendicularBTN.Name = "perpendicularBTN";
            this.perpendicularBTN.Size = new System.Drawing.Size(33, 31);
            this.perpendicularBTN.TabIndex = 6;
            this.perpendicularBTN.Click += new System.EventHandler(this.perpendicularBTN_Click);
            // 
            // AngleBTN
            // 
            this.AngleBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AngleBTN.BackgroundImage")));
            this.AngleBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AngleBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AngleBTN.Location = new System.Drawing.Point(84, 46);
            this.AngleBTN.Name = "AngleBTN";
            this.AngleBTN.Size = new System.Drawing.Size(33, 31);
            this.AngleBTN.TabIndex = 8;
            this.AngleBTN.Click += new System.EventHandler(this.AngleBTN_Click);
            // 
            // VertAlignBTN
            // 
            this.VertAlignBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("VertAlignBTN.BackgroundImage")));
            this.VertAlignBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.VertAlignBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.VertAlignBTN.Location = new System.Drawing.Point(124, 4);
            this.VertAlignBTN.Name = "VertAlignBTN";
            this.VertAlignBTN.Size = new System.Drawing.Size(33, 35);
            this.VertAlignBTN.TabIndex = 9;
            this.VertAlignBTN.Click += new System.EventHandler(this.VertAlignBTN_Click);
            // 
            // HorizontalAlignBTN
            // 
            this.HorizontalAlignBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HorizontalAlignBTN.BackgroundImage")));
            this.HorizontalAlignBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HorizontalAlignBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.HorizontalAlignBTN.Location = new System.Drawing.Point(124, 46);
            this.HorizontalAlignBTN.Name = "HorizontalAlignBTN";
            this.HorizontalAlignBTN.Size = new System.Drawing.Size(33, 30);
            this.HorizontalAlignBTN.TabIndex = 10;
            this.HorizontalAlignBTN.Click += new System.EventHandler(this.HorizontalAlignBTN_Click);
            // 
            // FIxPointBTN
            // 
            this.FIxPointBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FIxPointBTN.BackgroundImage")));
            this.FIxPointBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FIxPointBTN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FIxPointBTN.Location = new System.Drawing.Point(44, 84);
            this.FIxPointBTN.Name = "FIxPointBTN";
            this.FIxPointBTN.Size = new System.Drawing.Size(33, 34);
            this.FIxPointBTN.TabIndex = 12;
            this.FIxPointBTN.Click += new System.EventHandler(this.FIxPointBTN_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 509);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 15);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.Color.White;
            this.drawingPanel.Location = new System.Drawing.Point(216, 1);
            this.drawingPanel.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(942, 550);
            this.drawingPanel.TabIndex = 0;
            this.drawingPanel.TabStop = false;
            this.drawingPanel.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.drawingPanel_LoadCompleted);
            this.drawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingPanel_Paint);
            this.drawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseDown);
            this.drawingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseMove);
            this.drawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 622);
            this.Controls.Add(this.SectionControlTable);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SectionControlTable.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.informPanel.ResumeLayout(false);
            this.informPanel.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawingPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel SectionControlTable;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader Information;
        public System.Windows.Forms.PictureBox drawingPanel;
        private Panel optionsControl;
        public ListView listTree;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private Label endPointUI;
        private Label startPointUI;
        private Label label;
        private Label label2;
        protected internal Panel informPanel;
        private Label labelAction;
        private Label currentActionUI;
        private Label lineLengthFLD;
        private TableLayoutPanel tableLayoutPanel3;
        private Button drawBtn;
        private Button selectBtn;
        private Button tranferBtn;
        private Button clearBtn;
        private Button fixBTN;
        private Button perpendicularBTN;
        private Button parallelBTN;
        private Button AngleBTN;
        private Button VertAlignBTN;
        private Button HorizontalAlignBTN;
        private Button ComplexBTN;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button FIxPointBTN;
    }
}


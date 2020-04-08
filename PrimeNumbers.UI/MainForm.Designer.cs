using PrimeNumbers.BLL;

namespace PrimeNumbers.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exportAsXmlButton = new System.Windows.Forms.Button();
            this.stopCycleButton = new System.Windows.Forms.Button();
            this.startCyclesButton = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.allCyclesReportTable = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cycleNumberTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.breakTimeTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.wholeTimeTextBox = new System.Windows.Forms.TextBox();
            this.wholeTimeLabel = new System.Windows.Forms.Label();
            this.cycleTimeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.generalTimer = new System.Windows.Forms.Timer(this.components);
            this.cycleTimer = new System.Windows.Forms.Timer(this.components);
            this.breakTimer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.allCyclesReportTable.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AllowDrop = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.67332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.32668F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.37194F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.62806F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(804, 464);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.exportAsXmlButton);
            this.panel1.Controls.Add(this.stopCycleButton);
            this.panel1.Controls.Add(this.startCyclesButton);
            this.panel1.Location = new System.Drawing.Point(5, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 373);
            this.panel1.TabIndex = 6;
            // 
            // exportAsXmlButton
            // 
            this.exportAsXmlButton.Location = new System.Drawing.Point(6, 85);
            this.exportAsXmlButton.Name = "exportAsXmlButton";
            this.exportAsXmlButton.Size = new System.Drawing.Size(229, 32);
            this.exportAsXmlButton.TabIndex = 2;
            this.exportAsXmlButton.Text = "Export data to xml";
            this.exportAsXmlButton.UseVisualStyleBackColor = true;
            this.exportAsXmlButton.Click += new System.EventHandler(this.exportAsXmlButton_Click);
            // 
            // stopCycleButton
            // 
            this.stopCycleButton.Location = new System.Drawing.Point(6, 44);
            this.stopCycleButton.Name = "stopCycleButton";
            this.stopCycleButton.Size = new System.Drawing.Size(229, 35);
            this.stopCycleButton.TabIndex = 4;
            this.stopCycleButton.Text = "Stop cycle of generating primes";
            this.stopCycleButton.UseVisualStyleBackColor = true;
            this.stopCycleButton.Click += new System.EventHandler(this.stopCycleButton_Click);
            // 
            // startCyclesButton
            // 
            this.startCyclesButton.Location = new System.Drawing.Point(6, 3);
            this.startCyclesButton.Name = "startCyclesButton";
            this.startCyclesButton.Size = new System.Drawing.Size(229, 35);
            this.startCyclesButton.TabIndex = 3;
            this.startCyclesButton.Text = "Start next cycle of generating primes";
            this.startCyclesButton.UseVisualStyleBackColor = true;
            this.startCyclesButton.Click += new System.EventHandler(this.startCyclesButton_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(5, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(238, 73);
            this.panel4.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(23, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Prime numbers generator";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Location = new System.Drawing.Point(251, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(548, 373);
            this.panel2.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(543, 370);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(535, 344);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Previous cycle details";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(-2, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(534, 325);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Calculated primes in previous cycle";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.allCyclesReportTable);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(535, 344);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Report from all cycles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // allCyclesReportTable
            // 
            this.allCyclesReportTable.AutoScroll = true;
            this.allCyclesReportTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.allCyclesReportTable.ColumnCount = 4;
            this.allCyclesReportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.allCyclesReportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.75F));
            this.allCyclesReportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.allCyclesReportTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.allCyclesReportTable.Controls.Add(this.label7, 3, 0);
            this.allCyclesReportTable.Controls.Add(this.label6, 2, 0);
            this.allCyclesReportTable.Controls.Add(this.label5, 1, 0);
            this.allCyclesReportTable.Controls.Add(this.label4, 0, 0);
            this.allCyclesReportTable.Location = new System.Drawing.Point(3, 0);
            this.allCyclesReportTable.Name = "allCyclesReportTable";
            this.allCyclesReportTable.RowCount = 1;
            this.allCyclesReportTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.allCyclesReportTable.Size = new System.Drawing.Size(529, 338);
            this.allCyclesReportTable.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(416, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Cycle time";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Prime compute time";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(88, 1);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Largest prime computed";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cycle Id";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cycleNumberTextBox);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.breakTimeTextBox);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.wholeTimeTextBox);
            this.panel3.Controls.Add(this.wholeTimeLabel);
            this.panel3.Controls.Add(this.cycleTimeTextBox);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(251, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(538, 73);
            this.panel3.TabIndex = 8;
            // 
            // cycleNumberTextBox
            // 
            this.cycleNumberTextBox.Location = new System.Drawing.Point(379, 43);
            this.cycleNumberTextBox.Name = "cycleNumberTextBox";
            this.cycleNumberTextBox.Size = new System.Drawing.Size(130, 20);
            this.cycleNumberTextBox.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(287, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Cycle number:";
            // 
            // breakTimeTextBox
            // 
            this.breakTimeTextBox.Location = new System.Drawing.Point(379, 14);
            this.breakTimeTextBox.Name = "breakTimeTextBox";
            this.breakTimeTextBox.Size = new System.Drawing.Size(130, 20);
            this.breakTimeTextBox.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(287, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Break time:";
            // 
            // wholeTimeTextBox
            // 
            this.wholeTimeTextBox.Location = new System.Drawing.Point(136, 43);
            this.wholeTimeTextBox.Name = "wholeTimeTextBox";
            this.wholeTimeTextBox.Size = new System.Drawing.Size(130, 20);
            this.wholeTimeTextBox.TabIndex = 8;
            // 
            // wholeTimeLabel
            // 
            this.wholeTimeLabel.AutoSize = true;
            this.wholeTimeLabel.Location = new System.Drawing.Point(5, 46);
            this.wholeTimeLabel.Name = "wholeTimeLabel";
            this.wholeTimeLabel.Size = new System.Drawing.Size(117, 13);
            this.wholeTimeLabel.TabIndex = 7;
            this.wholeTimeLabel.Text = "Whole calculation time:";
            // 
            // cycleTimeTextBox
            // 
            this.cycleTimeTextBox.Location = new System.Drawing.Point(136, 14);
            this.cycleTimeTextBox.Name = "cycleTimeTextBox";
            this.cycleTimeTextBox.Size = new System.Drawing.Size(130, 20);
            this.cycleTimeTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cycle calculation  time:";
            // 
            // generalTimer
            // 
            this.generalTimer.Tick += new System.EventHandler(this.generalTimer_Tick);
            // 
            // cycleTimer
            // 
            this.cycleTimer.Tick += new System.EventHandler(this.cycleTimer_Tick);
            // 
            // breakTimer
            // 
            this.breakTimer.Tick += new System.EventHandler(this.breakTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 484);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "Prime numbers generator - Pivotal recruitment";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.allCyclesReportTable.ResumeLayout(false);
            this.allCyclesReportTable.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button startCyclesButton;
        private System.Windows.Forms.Button stopCycleButton;
        private System.Windows.Forms.Button exportAsXmlButton;
        private System.Windows.Forms.TextBox cycleTimeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox wholeTimeTextBox;
        private System.Windows.Forms.Label wholeTimeLabel;
        private System.Windows.Forms.Timer generalTimer;
        private System.Windows.Forms.Timer cycleTimer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel allCyclesReportTable;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cycleNumberTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox breakTimeTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer breakTimer;
    }
}


namespace Mega_Project
{
    partial class VisualiseForm
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
            this.ddTypeOfData = new System.Windows.Forms.ComboBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkAnimation = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSamples = new System.Windows.Forms.Label();
            this.tbSamples = new System.Windows.Forms.TrackBar();
            this.pnlSort2 = new System.Windows.Forms.PictureBox();
            this.cmdSort = new System.Windows.Forms.Button();
            this.cboAlg2 = new System.Windows.Forms.ComboBox();
            this.cboAlg1 = new System.Windows.Forms.ComboBox();
            this.pnlSort1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort1)).BeginInit();
            this.SuspendLayout();
            // 
            // ddTypeOfData
            // 
            this.ddTypeOfData.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ddTypeOfData.FormattingEnabled = true;
            this.ddTypeOfData.Items.AddRange(new object[] {
            "Random",
            "Reversed",
            "Sorted",
            "Nearly Sorted",
            "Few Unique"});
            this.ddTypeOfData.Location = new System.Drawing.Point(349, 288);
            this.ddTypeOfData.Name = "ddTypeOfData";
            this.ddTypeOfData.Size = new System.Drawing.Size(83, 21);
            this.ddTypeOfData.TabIndex = 50;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSelectFolder.Location = new System.Drawing.Point(438, 350);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(31, 23);
            this.btnSelectFolder.TabIndex = 49;
            this.btnSelectFolder.Text = "...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtOutputFolder.Location = new System.Drawing.Point(217, 352);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(215, 20);
            this.txtOutputFolder.TabIndex = 48;
            this.txtOutputFolder.Text = ".\\Sort";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Output folder:";
            // 
            // chkAnimation
            // 
            this.chkAnimation.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkAnimation.AutoSize = true;
            this.chkAnimation.Location = new System.Drawing.Point(410, 320);
            this.chkAnimation.Name = "chkAnimation";
            this.chkAnimation.Size = new System.Drawing.Size(106, 17);
            this.chkAnimation.TabIndex = 46;
            this.chkAnimation.Text = "Create Animation";
            this.chkAnimation.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Max";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Min";
            // 
            // tbSpeed
            // 
            this.tbSpeed.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbSpeed.Location = new System.Drawing.Point(231, 320);
            this.tbSpeed.Maximum = 20;
            this.tbSpeed.Minimum = 1;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(120, 45);
            this.tbSpeed.TabIndex = 43;
            this.tbSpeed.Value = 7;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 320);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Sorting speed:";
            // 
            // lblSamples
            // 
            this.lblSamples.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSamples.AutoSize = true;
            this.lblSamples.Location = new System.Drawing.Point(104, 288);
            this.lblSamples.Name = "lblSamples";
            this.lblSamples.Size = new System.Drawing.Size(121, 13);
            this.lblSamples.TabIndex = 41;
            this.lblSamples.Text = "Number of samples: 100";
            // 
            // tbSamples
            // 
            this.tbSamples.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tbSamples.LargeChange = 10;
            this.tbSamples.Location = new System.Drawing.Point(231, 288);
            this.tbSamples.Maximum = 1000;
            this.tbSamples.Minimum = 10;
            this.tbSamples.Name = "tbSamples";
            this.tbSamples.Size = new System.Drawing.Size(120, 45);
            this.tbSamples.TabIndex = 40;
            this.tbSamples.TickFrequency = 100;
            this.tbSamples.Value = 100;
            // 
            // pnlSort2
            // 
            this.pnlSort2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlSort2.BackColor = System.Drawing.Color.White;
            this.pnlSort2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSort2.Location = new System.Drawing.Point(313, 43);
            this.pnlSort2.Name = "pnlSort2";
            this.pnlSort2.Size = new System.Drawing.Size(200, 200);
            this.pnlSort2.TabIndex = 39;
            this.pnlSort2.TabStop = false;
            // 
            // cmdSort
            // 
            this.cmdSort.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cmdSort.Location = new System.Drawing.Point(438, 288);
            this.cmdSort.Name = "cmdSort";
            this.cmdSort.Size = new System.Drawing.Size(75, 23);
            this.cmdSort.TabIndex = 37;
            this.cmdSort.Text = "Sort";
            this.cmdSort.UseVisualStyleBackColor = true;
            //this.cmdSort.Click += new System.EventHandler(this.cmdSort_Click);
            // 
            // cboAlg2
            // 
            this.cboAlg2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cboAlg2.FormattingEnabled = true;
            this.cboAlg2.Items.AddRange(new object[] {
            "",
            "BiDirectional Bubble Sort",
            "Bubble Sort",
            "Comb Sort",
            "Counting Sort",
            "Cycle Sort",
            "Gnome Sort",
            "Heap Sort",
            "Insertion Sort",
            "Merge Sort (In Place)",
            "Merge Sort (Double Storage)",
            "Odd-Even Sort",
            "Pigeonhole Sort",
            "Quicksort",
            "Quicksort with Insertion Sort",
            "Radix Sort",
            "Selection Sort",
            "Shell Sort",
            "Smoothsort",
            "Timsort"});
            this.cboAlg2.Location = new System.Drawing.Point(313, 251);
            this.cboAlg2.Name = "cboAlg2";
            this.cboAlg2.Size = new System.Drawing.Size(200, 21);
            this.cboAlg2.TabIndex = 36;
            // 
            // cboAlg1
            // 
            this.cboAlg1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cboAlg1.FormattingEnabled = true;
            this.cboAlg1.Items.AddRange(new object[] {
            "",
            "BiDirectional Bubble Sort",
            "Bubble Sort",
            "Comb Sort",
            "Counting Sort",
            "Cycle Sort",
            "Gnome Sort",
            "Heap Sort",
            "Insertion Sort",
            "Merge Sort (In Place)",
            "Merge Sort (Double Storage)",
            "Odd-Even Sort",
            "Pigeonhole Sort",
            "Quicksort",
            "Quicksort with Insertion Sort",
            "Radix Sort",
            "Selection Sort",
            "Shell Sort",
            "Smoothsort",
            "Timsort"});
            this.cboAlg1.Location = new System.Drawing.Point(107, 251);
            this.cboAlg1.Name = "cboAlg1";
            this.cboAlg1.Size = new System.Drawing.Size(200, 21);
            this.cboAlg1.TabIndex = 35;
            // 
            // pnlSort1
            // 
            this.pnlSort1.BackColor = System.Drawing.Color.White;
            this.pnlSort1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSort1.Location = new System.Drawing.Point(107, 43);
            this.pnlSort1.Name = "pnlSort1";
            this.pnlSort1.Size = new System.Drawing.Size(200, 200);
            this.pnlSort1.TabIndex = 38;
            this.pnlSort1.TabStop = false;
            // 
            // VisualiseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 417);
            this.Controls.Add(this.ddTypeOfData);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.txtOutputFolder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkAnimation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSamples);
            this.Controls.Add(this.tbSamples);
            this.Controls.Add(this.pnlSort2);
            this.Controls.Add(this.cmdSort);
            this.Controls.Add(this.cboAlg2);
            this.Controls.Add(this.cboAlg1);
            this.Controls.Add(this.pnlSort1);
            this.Name = "VisualiseForm";
            this.Text = "VisualiseForm";
            this.Load += new System.EventHandler(this.VisualiseForm_Load);
            this.Resize += new System.EventHandler(this.VisualiseForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSort1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddTypeOfData;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkAnimation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSamples;
        private System.Windows.Forms.TrackBar tbSamples;
        private System.Windows.Forms.PictureBox pnlSort2;
        private System.Windows.Forms.Button cmdSort;
        private System.Windows.Forms.ComboBox cboAlg2;
        private System.Windows.Forms.ComboBox cboAlg1;
        private System.Windows.Forms.PictureBox pnlSort1;
    }
}
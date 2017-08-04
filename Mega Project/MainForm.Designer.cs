namespace Mega_Project
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
            this.projectTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.numbersSubprojectTabControl = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.findPiResultLabel = new System.Windows.Forms.Label();
            this.findPiAutogenerateCheckbox = new System.Windows.Forms.CheckBox();
            this.findPiGenerateButton = new System.Windows.Forms.Button();
            this.findPiValueLabel = new System.Windows.Forms.Label();
            this.findPiSubprojectDesriptionLabel = new System.Windows.Forms.Label();
            this.findPiTrackBar = new System.Windows.Forms.TrackBar();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.fineEResultLabel = new System.Windows.Forms.Label();
            this.findEAutoenerateCheckBox = new System.Windows.Forms.CheckBox();
            this.findEGenerateButton = new System.Windows.Forms.Button();
            this.findEValueLabel = new System.Windows.Forms.Label();
            this.findEDescriptionLabel = new System.Windows.Forms.Label();
            this.findETrackBar = new System.Windows.Forms.TrackBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.debugRichTextBox = new System.Windows.Forms.RichTextBox();
            this.debugLabel = new System.Windows.Forms.Label();
            this.projectTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.numbersSubprojectTabControl.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findPiTrackBar)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findETrackBar)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // projectTabControl
            // 
            this.projectTabControl.Controls.Add(this.tabPage1);
            this.projectTabControl.Controls.Add(this.tabPage2);
            this.projectTabControl.Location = new System.Drawing.Point(12, 12);
            this.projectTabControl.Name = "projectTabControl";
            this.projectTabControl.SelectedIndex = 0;
            this.projectTabControl.Size = new System.Drawing.Size(709, 317);
            this.projectTabControl.TabIndex = 0;
            this.projectTabControl.SelectedIndexChanged += new System.EventHandler(this.projectTabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.numbersSubprojectTabControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(701, 291);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Numbers";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // numbersSubprojectTabControl
            // 
            this.numbersSubprojectTabControl.Controls.Add(this.tabPage3);
            this.numbersSubprojectTabControl.Controls.Add(this.tabPage4);
            this.numbersSubprojectTabControl.Location = new System.Drawing.Point(6, 6);
            this.numbersSubprojectTabControl.Name = "numbersSubprojectTabControl";
            this.numbersSubprojectTabControl.SelectedIndex = 0;
            this.numbersSubprojectTabControl.Size = new System.Drawing.Size(689, 279);
            this.numbersSubprojectTabControl.TabIndex = 0;
            this.numbersSubprojectTabControl.SelectedIndexChanged += new System.EventHandler(this.numbersSubprojectTabControl_SelectedIndexChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.findPiResultLabel);
            this.tabPage3.Controls.Add(this.findPiAutogenerateCheckbox);
            this.tabPage3.Controls.Add(this.findPiGenerateButton);
            this.tabPage3.Controls.Add(this.findPiValueLabel);
            this.tabPage3.Controls.Add(this.findPiSubprojectDesriptionLabel);
            this.tabPage3.Controls.Add(this.findPiTrackBar);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(681, 253);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Find PI to the Nth Digit";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // findPiResultLabel
            // 
            this.findPiResultLabel.AutoSize = true;
            this.findPiResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.findPiResultLabel.Location = new System.Drawing.Point(6, 187);
            this.findPiResultLabel.Name = "findPiResultLabel";
            this.findPiResultLabel.Size = new System.Drawing.Size(249, 54);
            this.findPiResultLabel.TabIndex = 5;
            this.findPiResultLabel.Text = "Result: Pi=";
            // 
            // findPiAutogenerateCheckbox
            // 
            this.findPiAutogenerateCheckbox.AutoSize = true;
            this.findPiAutogenerateCheckbox.Location = new System.Drawing.Point(472, 123);
            this.findPiAutogenerateCheckbox.Name = "findPiAutogenerateCheckbox";
            this.findPiAutogenerateCheckbox.Size = new System.Drawing.Size(175, 17);
            this.findPiAutogenerateCheckbox.TabIndex = 4;
            this.findPiAutogenerateCheckbox.Text = "auto-generate on value change";
            this.findPiAutogenerateCheckbox.UseVisualStyleBackColor = true;
            // 
            // findPiGenerateButton
            // 
            this.findPiGenerateButton.Location = new System.Drawing.Point(9, 94);
            this.findPiGenerateButton.Name = "findPiGenerateButton";
            this.findPiGenerateButton.Size = new System.Drawing.Size(457, 72);
            this.findPiGenerateButton.TabIndex = 3;
            this.findPiGenerateButton.Text = "Generate";
            this.findPiGenerateButton.UseVisualStyleBackColor = true;
            this.findPiGenerateButton.Click += new System.EventHandler(this.findPiGenerateButton_Click);
            // 
            // findPiValueLabel
            // 
            this.findPiValueLabel.AutoSize = true;
            this.findPiValueLabel.Location = new System.Drawing.Point(6, 27);
            this.findPiValueLabel.Name = "findPiValueLabel";
            this.findPiValueLabel.Size = new System.Drawing.Size(49, 13);
            this.findPiValueLabel.TabIndex = 2;
            this.findPiValueLabel.Text = "Value : 0";
            // 
            // findPiSubprojectDesriptionLabel
            // 
            this.findPiSubprojectDesriptionLabel.AutoSize = true;
            this.findPiSubprojectDesriptionLabel.Location = new System.Drawing.Point(6, 3);
            this.findPiSubprojectDesriptionLabel.Name = "findPiSubprojectDesriptionLabel";
            this.findPiSubprojectDesriptionLabel.Size = new System.Drawing.Size(593, 13);
            this.findPiSubprojectDesriptionLabel.TabIndex = 1;
            this.findPiSubprojectDesriptionLabel.Text = "Select a value and have the program generate PI up to that many decimal places. K" +
    "eep a limit to how far the program will go.";
            // 
            // findPiTrackBar
            // 
            this.findPiTrackBar.BackColor = System.Drawing.SystemColors.Window;
            this.findPiTrackBar.Location = new System.Drawing.Point(6, 43);
            this.findPiTrackBar.Maximum = 15;
            this.findPiTrackBar.Name = "findPiTrackBar";
            this.findPiTrackBar.Size = new System.Drawing.Size(669, 45);
            this.findPiTrackBar.TabIndex = 0;
            this.findPiTrackBar.Scroll += new System.EventHandler(this.findPiTrackBar_Scroll);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.fineEResultLabel);
            this.tabPage4.Controls.Add(this.findEAutoenerateCheckBox);
            this.tabPage4.Controls.Add(this.findEGenerateButton);
            this.tabPage4.Controls.Add(this.findEValueLabel);
            this.tabPage4.Controls.Add(this.findEDescriptionLabel);
            this.tabPage4.Controls.Add(this.findETrackBar);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(681, 253);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Find e to the Nth Digit";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // fineEResultLabel
            // 
            this.fineEResultLabel.AutoSize = true;
            this.fineEResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fineEResultLabel.Location = new System.Drawing.Point(6, 187);
            this.fineEResultLabel.Name = "fineEResultLabel";
            this.fineEResultLabel.Size = new System.Drawing.Size(234, 54);
            this.fineEResultLabel.TabIndex = 11;
            this.fineEResultLabel.Text = "Result: e=";
            // 
            // findEAutoenerateCheckBox
            // 
            this.findEAutoenerateCheckBox.AutoSize = true;
            this.findEAutoenerateCheckBox.Location = new System.Drawing.Point(472, 123);
            this.findEAutoenerateCheckBox.Name = "findEAutoenerateCheckBox";
            this.findEAutoenerateCheckBox.Size = new System.Drawing.Size(175, 17);
            this.findEAutoenerateCheckBox.TabIndex = 10;
            this.findEAutoenerateCheckBox.Text = "auto-generate on value change";
            this.findEAutoenerateCheckBox.UseVisualStyleBackColor = true;
            // 
            // findEGenerateButton
            // 
            this.findEGenerateButton.Location = new System.Drawing.Point(9, 94);
            this.findEGenerateButton.Name = "findEGenerateButton";
            this.findEGenerateButton.Size = new System.Drawing.Size(457, 72);
            this.findEGenerateButton.TabIndex = 9;
            this.findEGenerateButton.Text = "Generate";
            this.findEGenerateButton.UseVisualStyleBackColor = true;
            this.findEGenerateButton.Click += new System.EventHandler(this.fineEGenerateButton_Click);
            // 
            // findEValueLabel
            // 
            this.findEValueLabel.AutoSize = true;
            this.findEValueLabel.Location = new System.Drawing.Point(6, 27);
            this.findEValueLabel.Name = "findEValueLabel";
            this.findEValueLabel.Size = new System.Drawing.Size(49, 13);
            this.findEValueLabel.TabIndex = 8;
            this.findEValueLabel.Text = "Value : 0";
            // 
            // findEDescriptionLabel
            // 
            this.findEDescriptionLabel.AutoSize = true;
            this.findEDescriptionLabel.Location = new System.Drawing.Point(6, 3);
            this.findEDescriptionLabel.Name = "findEDescriptionLabel";
            this.findEDescriptionLabel.Size = new System.Drawing.Size(589, 13);
            this.findEDescriptionLabel.TabIndex = 7;
            this.findEDescriptionLabel.Text = "Select a value and have the program generate e up to that many decimal places. Ke" +
    "ep a limit to how far the program will go.";
            // 
            // findETrackBar
            // 
            this.findETrackBar.BackColor = System.Drawing.SystemColors.Window;
            this.findETrackBar.Location = new System.Drawing.Point(6, 43);
            this.findETrackBar.Maximum = 15;
            this.findETrackBar.Name = "findETrackBar";
            this.findETrackBar.Size = new System.Drawing.Size(669, 45);
            this.findETrackBar.TabIndex = 6;
            this.findETrackBar.Scroll += new System.EventHandler(this.findETrackBar_Scroll);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(701, 291);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TBD";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(7, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(688, 278);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(680, 252);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(192, 74);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // debugRichTextBox
            // 
            this.debugRichTextBox.Location = new System.Drawing.Point(16, 353);
            this.debugRichTextBox.Name = "debugRichTextBox";
            this.debugRichTextBox.Size = new System.Drawing.Size(701, 110);
            this.debugRichTextBox.TabIndex = 1;
            this.debugRichTextBox.Text = "";
            // 
            // debugLabel
            // 
            this.debugLabel.AutoSize = true;
            this.debugLabel.Location = new System.Drawing.Point(16, 336);
            this.debugLabel.Name = "debugLabel";
            this.debugLabel.Size = new System.Drawing.Size(39, 13);
            this.debugLabel.TabIndex = 2;
            this.debugLabel.Text = "Debug";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 475);
            this.Controls.Add(this.debugLabel);
            this.Controls.Add(this.debugRichTextBox);
            this.Controls.Add(this.projectTabControl);
            this.Name = "MainForm";
            this.Text = "Mega Project";
            this.projectTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.numbersSubprojectTabControl.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findPiTrackBar)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findETrackBar)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl projectTabControl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl numbersSubprojectTabControl;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label findPiValueLabel;
        private System.Windows.Forms.Label findPiSubprojectDesriptionLabel;
        private System.Windows.Forms.TrackBar findPiTrackBar;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label findPiResultLabel;
        private System.Windows.Forms.CheckBox findPiAutogenerateCheckbox;
        private System.Windows.Forms.Button findPiGenerateButton;
        private System.Windows.Forms.Label fineEResultLabel;
        private System.Windows.Forms.CheckBox findEAutoenerateCheckBox;
        private System.Windows.Forms.Button findEGenerateButton;
        private System.Windows.Forms.Label findEValueLabel;
        private System.Windows.Forms.Label findEDescriptionLabel;
        private System.Windows.Forms.TrackBar findETrackBar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.RichTextBox debugRichTextBox;
        private System.Windows.Forms.Label debugLabel;
    }
}


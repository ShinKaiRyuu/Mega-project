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
            this.findPiTabPage = new System.Windows.Forms.TabPage();
            this.findPiResultLabel = new System.Windows.Forms.Label();
            this.findPiAutogenerateCheckbox = new System.Windows.Forms.CheckBox();
            this.findPiGenerateButton = new System.Windows.Forms.Button();
            this.findPiValueLabel = new System.Windows.Forms.Label();
            this.findPiSubprojectDesriptionLabel = new System.Windows.Forms.Label();
            this.findPiTrackBar = new System.Windows.Forms.TrackBar();
            this.findETabPage = new System.Windows.Forms.TabPage();
            this.fineEResultLabel = new System.Windows.Forms.Label();
            this.findEAutoenerateCheckBox = new System.Windows.Forms.CheckBox();
            this.findEGenerateButton = new System.Windows.Forms.Button();
            this.findEValueLabel = new System.Windows.Forms.Label();
            this.findEDescriptionLabel = new System.Windows.Forms.Label();
            this.findETrackBar = new System.Windows.Forms.TrackBar();
            this.findFibonachiSequenceTabPage = new System.Windows.Forms.TabPage();
            this.findFibonachiSequenceResultlabel = new System.Windows.Forms.Label();
            this.findFibonachiSequenceAutogenerateCheckBox = new System.Windows.Forms.CheckBox();
            this.findFibonachiSequenceGenerateButton = new System.Windows.Forms.Button();
            this.findFibonachiSequenceValueLabel = new System.Windows.Forms.Label();
            this.findFibonachiSequenceDescriptionLabel = new System.Windows.Forms.Label();
            this.findFibonachiSequenceTrackBar = new System.Windows.Forms.TrackBar();
            this.findPrimeFactorTabPage = new System.Windows.Forms.TabPage();
            this.findPrimeFactorResultLabel = new System.Windows.Forms.Label();
            this.findPrimeFactorAutogenerateCheckBox = new System.Windows.Forms.CheckBox();
            this.findPrimeFactorGenerateButton = new System.Windows.Forms.Button();
            this.findPrimeFactorValueLabel = new System.Windows.Forms.Label();
            this.findPrimeFactorDescriptionLabel = new System.Windows.Forms.Label();
            this.findPrimeFactorTrackBar = new System.Windows.Forms.TrackBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.debugRichTextBox = new System.Windows.Forms.RichTextBox();
            this.debugLabel = new System.Windows.Forms.Label();
            this.projectTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.numbersSubprojectTabControl.SuspendLayout();
            this.findPiTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findPiTrackBar)).BeginInit();
            this.findETabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findETrackBar)).BeginInit();
            this.findFibonachiSequenceTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findFibonachiSequenceTrackBar)).BeginInit();
            this.findPrimeFactorTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findPrimeFactorTrackBar)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // projectTabControl
            // 
            this.projectTabControl.Controls.Add(this.tabPage1);
            this.projectTabControl.Controls.Add(this.tabPage2);
            this.projectTabControl.Location = new System.Drawing.Point(12, 11);
            this.projectTabControl.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.projectTabControl.Name = "projectTabControl";
            this.projectTabControl.SelectedIndex = 0;
            this.projectTabControl.Size = new System.Drawing.Size(710, 317);
            this.projectTabControl.TabIndex = 0;
            this.projectTabControl.SelectedIndexChanged += new System.EventHandler(this.projectTabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.numbersSubprojectTabControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Size = new System.Drawing.Size(702, 291);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Numbers";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // numbersSubprojectTabControl
            // 
            this.numbersSubprojectTabControl.Controls.Add(this.findPiTabPage);
            this.numbersSubprojectTabControl.Controls.Add(this.findETabPage);
            this.numbersSubprojectTabControl.Controls.Add(this.findFibonachiSequenceTabPage);
            this.numbersSubprojectTabControl.Controls.Add(this.findPrimeFactorTabPage);
            this.numbersSubprojectTabControl.Location = new System.Drawing.Point(6, 6);
            this.numbersSubprojectTabControl.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.numbersSubprojectTabControl.Name = "numbersSubprojectTabControl";
            this.numbersSubprojectTabControl.SelectedIndex = 0;
            this.numbersSubprojectTabControl.Size = new System.Drawing.Size(690, 279);
            this.numbersSubprojectTabControl.TabIndex = 0;
            this.numbersSubprojectTabControl.SelectedIndexChanged += new System.EventHandler(this.numbersSubprojectTabControl_SelectedIndexChanged);
            // 
            // findPiTabPage
            // 
            this.findPiTabPage.Controls.Add(this.findPiResultLabel);
            this.findPiTabPage.Controls.Add(this.findPiAutogenerateCheckbox);
            this.findPiTabPage.Controls.Add(this.findPiGenerateButton);
            this.findPiTabPage.Controls.Add(this.findPiValueLabel);
            this.findPiTabPage.Controls.Add(this.findPiSubprojectDesriptionLabel);
            this.findPiTabPage.Controls.Add(this.findPiTrackBar);
            this.findPiTabPage.Location = new System.Drawing.Point(4, 22);
            this.findPiTabPage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.findPiTabPage.Name = "findPiTabPage";
            this.findPiTabPage.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.findPiTabPage.Size = new System.Drawing.Size(682, 253);
            this.findPiTabPage.TabIndex = 0;
            this.findPiTabPage.Text = "Find PI to the Nth Digit";
            this.findPiTabPage.UseVisualStyleBackColor = true;
            // 
            // findPiResultLabel
            // 
            this.findPiResultLabel.AutoSize = true;
            this.findPiResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.findPiResultLabel.Location = new System.Drawing.Point(5, 196);
            this.findPiResultLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.findPiResultLabel.Name = "findPiResultLabel";
            this.findPiResultLabel.Size = new System.Drawing.Size(249, 54);
            this.findPiResultLabel.TabIndex = 5;
            this.findPiResultLabel.Text = "Result: Pi=";
            // 
            // findPiAutogenerateCheckbox
            // 
            this.findPiAutogenerateCheckbox.AutoSize = true;
            this.findPiAutogenerateCheckbox.Location = new System.Drawing.Point(468, 149);
            this.findPiAutogenerateCheckbox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.findPiAutogenerateCheckbox.Name = "findPiAutogenerateCheckbox";
            this.findPiAutogenerateCheckbox.Size = new System.Drawing.Size(175, 17);
            this.findPiAutogenerateCheckbox.TabIndex = 4;
            this.findPiAutogenerateCheckbox.Text = "auto-generate on value change";
            this.findPiAutogenerateCheckbox.UseVisualStyleBackColor = true;
            // 
            // findPiGenerateButton
            // 
            this.findPiGenerateButton.Location = new System.Drawing.Point(5, 120);
            this.findPiGenerateButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.findPiGenerateButton.Name = "findPiGenerateButton";
            this.findPiGenerateButton.Size = new System.Drawing.Size(458, 72);
            this.findPiGenerateButton.TabIndex = 3;
            this.findPiGenerateButton.Text = "Generate";
            this.findPiGenerateButton.UseVisualStyleBackColor = true;
            this.findPiGenerateButton.Click += new System.EventHandler(this.findPiGenerateButton_Click);
            // 
            // findPiValueLabel
            // 
            this.findPiValueLabel.AutoSize = true;
            this.findPiValueLabel.Location = new System.Drawing.Point(5, 51);
            this.findPiValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.findPiValueLabel.Name = "findPiValueLabel";
            this.findPiValueLabel.Size = new System.Drawing.Size(49, 13);
            this.findPiValueLabel.TabIndex = 2;
            this.findPiValueLabel.Text = "Value : 0";
            // 
            // findPiSubprojectDesriptionLabel
            // 
            this.findPiSubprojectDesriptionLabel.AutoSize = true;
            this.findPiSubprojectDesriptionLabel.Location = new System.Drawing.Point(5, 3);
            this.findPiSubprojectDesriptionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.findPiSubprojectDesriptionLabel.Name = "findPiSubprojectDesriptionLabel";
            this.findPiSubprojectDesriptionLabel.Size = new System.Drawing.Size(593, 13);
            this.findPiSubprojectDesriptionLabel.TabIndex = 1;
            this.findPiSubprojectDesriptionLabel.Text = "Select a value and have the program generate PI up to that many decimal places. K" +
    "eep a limit to how far the program will go.";
            // 
            // findPiTrackBar
            // 
            this.findPiTrackBar.BackColor = System.Drawing.SystemColors.Window;
            this.findPiTrackBar.Location = new System.Drawing.Point(5, 67);
            this.findPiTrackBar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.findPiTrackBar.Maximum = 14;
            this.findPiTrackBar.Name = "findPiTrackBar";
            this.findPiTrackBar.Size = new System.Drawing.Size(670, 45);
            this.findPiTrackBar.TabIndex = 0;
            this.findPiTrackBar.Scroll += new System.EventHandler(this.findPiTrackBar_Scroll);
            // 
            // findETabPage
            // 
            this.findETabPage.Controls.Add(this.fineEResultLabel);
            this.findETabPage.Controls.Add(this.findEAutoenerateCheckBox);
            this.findETabPage.Controls.Add(this.findEGenerateButton);
            this.findETabPage.Controls.Add(this.findEValueLabel);
            this.findETabPage.Controls.Add(this.findEDescriptionLabel);
            this.findETabPage.Controls.Add(this.findETrackBar);
            this.findETabPage.Location = new System.Drawing.Point(4, 22);
            this.findETabPage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.findETabPage.Name = "findETabPage";
            this.findETabPage.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.findETabPage.Size = new System.Drawing.Size(682, 253);
            this.findETabPage.TabIndex = 1;
            this.findETabPage.Text = "Find e to the Nth Digit";
            this.findETabPage.UseVisualStyleBackColor = true;
            // 
            // fineEResultLabel
            // 
            this.fineEResultLabel.AutoSize = true;
            this.fineEResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fineEResultLabel.Location = new System.Drawing.Point(5, 196);
            this.fineEResultLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fineEResultLabel.Name = "fineEResultLabel";
            this.fineEResultLabel.Size = new System.Drawing.Size(234, 54);
            this.fineEResultLabel.TabIndex = 11;
            this.fineEResultLabel.Text = "Result: e=";
            // 
            // findEAutoenerateCheckBox
            // 
            this.findEAutoenerateCheckBox.AutoSize = true;
            this.findEAutoenerateCheckBox.Location = new System.Drawing.Point(468, 149);
            this.findEAutoenerateCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.findEAutoenerateCheckBox.Name = "findEAutoenerateCheckBox";
            this.findEAutoenerateCheckBox.Size = new System.Drawing.Size(175, 17);
            this.findEAutoenerateCheckBox.TabIndex = 10;
            this.findEAutoenerateCheckBox.Text = "auto-generate on value change";
            this.findEAutoenerateCheckBox.UseVisualStyleBackColor = true;
            // 
            // findEGenerateButton
            // 
            this.findEGenerateButton.Location = new System.Drawing.Point(5, 120);
            this.findEGenerateButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.findEGenerateButton.Name = "findEGenerateButton";
            this.findEGenerateButton.Size = new System.Drawing.Size(458, 72);
            this.findEGenerateButton.TabIndex = 9;
            this.findEGenerateButton.Text = "Generate";
            this.findEGenerateButton.UseVisualStyleBackColor = true;
            this.findEGenerateButton.Click += new System.EventHandler(this.fineEGenerateButton_Click);
            // 
            // findEValueLabel
            // 
            this.findEValueLabel.AutoSize = true;
            this.findEValueLabel.Location = new System.Drawing.Point(5, 51);
            this.findEValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.findEValueLabel.Name = "findEValueLabel";
            this.findEValueLabel.Size = new System.Drawing.Size(49, 13);
            this.findEValueLabel.TabIndex = 8;
            this.findEValueLabel.Text = "Value : 0";
            // 
            // findEDescriptionLabel
            // 
            this.findEDescriptionLabel.AutoSize = true;
            this.findEDescriptionLabel.Location = new System.Drawing.Point(5, 3);
            this.findEDescriptionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.findEDescriptionLabel.Name = "findEDescriptionLabel";
            this.findEDescriptionLabel.Size = new System.Drawing.Size(592, 13);
            this.findEDescriptionLabel.TabIndex = 7;
            this.findEDescriptionLabel.Text = "Select a value and have the program generate e  up to that many decimal places. K" +
    "eep a limit to how far the program will go.";
            // 
            // findETrackBar
            // 
            this.findETrackBar.BackColor = System.Drawing.SystemColors.Window;
            this.findETrackBar.Location = new System.Drawing.Point(5, 67);
            this.findETrackBar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.findETrackBar.Maximum = 14;
            this.findETrackBar.Name = "findETrackBar";
            this.findETrackBar.Size = new System.Drawing.Size(670, 45);
            this.findETrackBar.TabIndex = 6;
            this.findETrackBar.Scroll += new System.EventHandler(this.findETrackBar_Scroll);
            // 
            // findFibonachiSequenceTabPage
            // 
            this.findFibonachiSequenceTabPage.Controls.Add(this.findFibonachiSequenceResultlabel);
            this.findFibonachiSequenceTabPage.Controls.Add(this.findFibonachiSequenceAutogenerateCheckBox);
            this.findFibonachiSequenceTabPage.Controls.Add(this.findFibonachiSequenceGenerateButton);
            this.findFibonachiSequenceTabPage.Controls.Add(this.findFibonachiSequenceValueLabel);
            this.findFibonachiSequenceTabPage.Controls.Add(this.findFibonachiSequenceDescriptionLabel);
            this.findFibonachiSequenceTabPage.Controls.Add(this.findFibonachiSequenceTrackBar);
            this.findFibonachiSequenceTabPage.Location = new System.Drawing.Point(4, 22);
            this.findFibonachiSequenceTabPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.findFibonachiSequenceTabPage.Name = "findFibonachiSequenceTabPage";
            this.findFibonachiSequenceTabPage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.findFibonachiSequenceTabPage.Size = new System.Drawing.Size(682, 253);
            this.findFibonachiSequenceTabPage.TabIndex = 2;
            this.findFibonachiSequenceTabPage.Text = "Find Fibonachi sequence";
            this.findFibonachiSequenceTabPage.UseVisualStyleBackColor = true;
            // 
            // findFibonachiSequenceResultlabel
            // 
            this.findFibonachiSequenceResultlabel.AutoSize = true;
            this.findFibonachiSequenceResultlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.findFibonachiSequenceResultlabel.Location = new System.Drawing.Point(4, 217);
            this.findFibonachiSequenceResultlabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.findFibonachiSequenceResultlabel.Name = "findFibonachiSequenceResultlabel";
            this.findFibonachiSequenceResultlabel.Size = new System.Drawing.Size(63, 20);
            this.findFibonachiSequenceResultlabel.TabIndex = 17;
            this.findFibonachiSequenceResultlabel.Text = "Result: ";
            // 
            // findFibonachiSequenceAutogenerateCheckBox
            // 
            this.findFibonachiSequenceAutogenerateCheckBox.AutoSize = true;
            this.findFibonachiSequenceAutogenerateCheckBox.Location = new System.Drawing.Point(468, 149);
            this.findFibonachiSequenceAutogenerateCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.findFibonachiSequenceAutogenerateCheckBox.Name = "findFibonachiSequenceAutogenerateCheckBox";
            this.findFibonachiSequenceAutogenerateCheckBox.Size = new System.Drawing.Size(175, 17);
            this.findFibonachiSequenceAutogenerateCheckBox.TabIndex = 16;
            this.findFibonachiSequenceAutogenerateCheckBox.Text = "auto-generate on value change";
            this.findFibonachiSequenceAutogenerateCheckBox.UseVisualStyleBackColor = true;
            // 
            // findFibonachiSequenceGenerateButton
            // 
            this.findFibonachiSequenceGenerateButton.Location = new System.Drawing.Point(5, 120);
            this.findFibonachiSequenceGenerateButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.findFibonachiSequenceGenerateButton.Name = "findFibonachiSequenceGenerateButton";
            this.findFibonachiSequenceGenerateButton.Size = new System.Drawing.Size(458, 72);
            this.findFibonachiSequenceGenerateButton.TabIndex = 15;
            this.findFibonachiSequenceGenerateButton.Text = "Generate";
            this.findFibonachiSequenceGenerateButton.UseVisualStyleBackColor = true;
            this.findFibonachiSequenceGenerateButton.Click += new System.EventHandler(this.findFibonachiSequenceGenerateButton_Click);
            // 
            // findFibonachiSequenceValueLabel
            // 
            this.findFibonachiSequenceValueLabel.AutoSize = true;
            this.findFibonachiSequenceValueLabel.Location = new System.Drawing.Point(5, 51);
            this.findFibonachiSequenceValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.findFibonachiSequenceValueLabel.Name = "findFibonachiSequenceValueLabel";
            this.findFibonachiSequenceValueLabel.Size = new System.Drawing.Size(49, 13);
            this.findFibonachiSequenceValueLabel.TabIndex = 14;
            this.findFibonachiSequenceValueLabel.Text = "Value : 0";
            // 
            // findFibonachiSequenceDescriptionLabel
            // 
            this.findFibonachiSequenceDescriptionLabel.AutoSize = true;
            this.findFibonachiSequenceDescriptionLabel.Location = new System.Drawing.Point(5, 3);
            this.findFibonachiSequenceDescriptionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.findFibonachiSequenceDescriptionLabel.Name = "findFibonachiSequenceDescriptionLabel";
            this.findFibonachiSequenceDescriptionLabel.Size = new System.Drawing.Size(589, 13);
            this.findFibonachiSequenceDescriptionLabel.TabIndex = 13;
            this.findFibonachiSequenceDescriptionLabel.Text = "Select a value and have the program generate e up to that many decimal places. Ke" +
    "ep a limit to how far the program will go.";
            // 
            // findFibonachiSequenceTrackBar
            // 
            this.findFibonachiSequenceTrackBar.BackColor = System.Drawing.SystemColors.Window;
            this.findFibonachiSequenceTrackBar.Location = new System.Drawing.Point(5, 67);
            this.findFibonachiSequenceTrackBar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.findFibonachiSequenceTrackBar.Maximum = 100;
            this.findFibonachiSequenceTrackBar.Name = "findFibonachiSequenceTrackBar";
            this.findFibonachiSequenceTrackBar.Size = new System.Drawing.Size(670, 45);
            this.findFibonachiSequenceTrackBar.TabIndex = 12;
            this.findFibonachiSequenceTrackBar.Scroll += new System.EventHandler(this.findFibonachiSequenceTrackBar_Scroll);
            // 
            // findPrimeFactorTabPage
            // 
            this.findPrimeFactorTabPage.Controls.Add(this.findPrimeFactorResultLabel);
            this.findPrimeFactorTabPage.Controls.Add(this.findPrimeFactorAutogenerateCheckBox);
            this.findPrimeFactorTabPage.Controls.Add(this.findPrimeFactorGenerateButton);
            this.findPrimeFactorTabPage.Controls.Add(this.findPrimeFactorValueLabel);
            this.findPrimeFactorTabPage.Controls.Add(this.findPrimeFactorDescriptionLabel);
            this.findPrimeFactorTabPage.Controls.Add(this.findPrimeFactorTrackBar);
            this.findPrimeFactorTabPage.Location = new System.Drawing.Point(4, 22);
            this.findPrimeFactorTabPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.findPrimeFactorTabPage.Name = "findPrimeFactorTabPage";
            this.findPrimeFactorTabPage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.findPrimeFactorTabPage.Size = new System.Drawing.Size(682, 253);
            this.findPrimeFactorTabPage.TabIndex = 3;
            this.findPrimeFactorTabPage.Text = "Find Prime Factor";
            this.findPrimeFactorTabPage.UseVisualStyleBackColor = true;
            // 
            // findPrimeFactorResultLabel
            // 
            this.findPrimeFactorResultLabel.AutoSize = true;
            this.findPrimeFactorResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.findPrimeFactorResultLabel.Location = new System.Drawing.Point(6, 225);
            this.findPrimeFactorResultLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.findPrimeFactorResultLabel.Name = "findPrimeFactorResultLabel";
            this.findPrimeFactorResultLabel.Size = new System.Drawing.Size(63, 20);
            this.findPrimeFactorResultLabel.TabIndex = 23;
            this.findPrimeFactorResultLabel.Text = "Result: ";
            // 
            // findPrimeFactorAutogenerateCheckBox
            // 
            this.findPrimeFactorAutogenerateCheckBox.AutoSize = true;
            this.findPrimeFactorAutogenerateCheckBox.Location = new System.Drawing.Point(468, 157);
            this.findPrimeFactorAutogenerateCheckBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.findPrimeFactorAutogenerateCheckBox.Name = "findPrimeFactorAutogenerateCheckBox";
            this.findPrimeFactorAutogenerateCheckBox.Size = new System.Drawing.Size(175, 17);
            this.findPrimeFactorAutogenerateCheckBox.TabIndex = 22;
            this.findPrimeFactorAutogenerateCheckBox.Text = "auto-generate on value change";
            this.findPrimeFactorAutogenerateCheckBox.UseVisualStyleBackColor = true;
            // 
            // findPrimeFactorGenerateButton
            // 
            this.findPrimeFactorGenerateButton.Location = new System.Drawing.Point(6, 127);
            this.findPrimeFactorGenerateButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.findPrimeFactorGenerateButton.Name = "findPrimeFactorGenerateButton";
            this.findPrimeFactorGenerateButton.Size = new System.Drawing.Size(458, 72);
            this.findPrimeFactorGenerateButton.TabIndex = 21;
            this.findPrimeFactorGenerateButton.Text = "Generate";
            this.findPrimeFactorGenerateButton.UseVisualStyleBackColor = true;
            this.findPrimeFactorGenerateButton.Click += new System.EventHandler(this.findPrimeFactorGenerateButton_Click);
            // 
            // findPrimeFactorValueLabel
            // 
            this.findPrimeFactorValueLabel.AutoSize = true;
            this.findPrimeFactorValueLabel.Location = new System.Drawing.Point(6, 58);
            this.findPrimeFactorValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.findPrimeFactorValueLabel.Name = "findPrimeFactorValueLabel";
            this.findPrimeFactorValueLabel.Size = new System.Drawing.Size(49, 13);
            this.findPrimeFactorValueLabel.TabIndex = 20;
            this.findPrimeFactorValueLabel.Text = "Value : 0";
            // 
            // findPrimeFactorDescriptionLabel
            // 
            this.findPrimeFactorDescriptionLabel.AutoSize = true;
            this.findPrimeFactorDescriptionLabel.Location = new System.Drawing.Point(6, 10);
            this.findPrimeFactorDescriptionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.findPrimeFactorDescriptionLabel.Name = "findPrimeFactorDescriptionLabel";
            this.findPrimeFactorDescriptionLabel.Size = new System.Drawing.Size(589, 13);
            this.findPrimeFactorDescriptionLabel.TabIndex = 19;
            this.findPrimeFactorDescriptionLabel.Text = "Select a value and have the program generate e up to that many decimal places. Ke" +
    "ep a limit to how far the program will go.";
            // 
            // findPrimeFactorTrackBar
            // 
            this.findPrimeFactorTrackBar.BackColor = System.Drawing.SystemColors.Window;
            this.findPrimeFactorTrackBar.Location = new System.Drawing.Point(6, 74);
            this.findPrimeFactorTrackBar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.findPrimeFactorTrackBar.Maximum = 1000;
            this.findPrimeFactorTrackBar.Name = "findPrimeFactorTrackBar";
            this.findPrimeFactorTrackBar.Size = new System.Drawing.Size(670, 45);
            this.findPrimeFactorTrackBar.TabIndex = 18;
            this.findPrimeFactorTrackBar.Scroll += new System.EventHandler(this.findPrimeFactorTrackBar_Scroll);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage2.Size = new System.Drawing.Size(702, 291);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TBD";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(6, 7);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(688, 278);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage5.Size = new System.Drawing.Size(680, 252);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage6.Size = new System.Drawing.Size(680, 252);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // debugRichTextBox
            // 
            this.debugRichTextBox.Location = new System.Drawing.Point(16, 353);
            this.debugRichTextBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.debugRichTextBox.Name = "debugRichTextBox";
            this.debugRichTextBox.Size = new System.Drawing.Size(702, 110);
            this.debugRichTextBox.TabIndex = 1;
            this.debugRichTextBox.Text = "";
            // 
            // debugLabel
            // 
            this.debugLabel.AutoSize = true;
            this.debugLabel.Location = new System.Drawing.Point(16, 336);
            this.debugLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.debugLabel.Name = "debugLabel";
            this.debugLabel.Size = new System.Drawing.Size(39, 13);
            this.debugLabel.TabIndex = 2;
            this.debugLabel.Text = "Debug";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 478);
            this.Controls.Add(this.debugLabel);
            this.Controls.Add(this.debugRichTextBox);
            this.Controls.Add(this.projectTabControl);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainForm";
            this.Text = "Mega Project";
            this.projectTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.numbersSubprojectTabControl.ResumeLayout(false);
            this.findPiTabPage.ResumeLayout(false);
            this.findPiTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findPiTrackBar)).EndInit();
            this.findETabPage.ResumeLayout(false);
            this.findETabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findETrackBar)).EndInit();
            this.findFibonachiSequenceTabPage.ResumeLayout(false);
            this.findFibonachiSequenceTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findFibonachiSequenceTrackBar)).EndInit();
            this.findPrimeFactorTabPage.ResumeLayout(false);
            this.findPrimeFactorTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findPrimeFactorTrackBar)).EndInit();
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
        private System.Windows.Forms.TabPage findPiTabPage;
        private System.Windows.Forms.Label findPiValueLabel;
        private System.Windows.Forms.Label findPiSubprojectDesriptionLabel;
        private System.Windows.Forms.TrackBar findPiTrackBar;
        private System.Windows.Forms.TabPage findETabPage;
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
        private System.Windows.Forms.TabPage findFibonachiSequenceTabPage;
        private System.Windows.Forms.Label findFibonachiSequenceResultlabel;
        private System.Windows.Forms.CheckBox findFibonachiSequenceAutogenerateCheckBox;
        private System.Windows.Forms.Button findFibonachiSequenceGenerateButton;
        private System.Windows.Forms.Label findFibonachiSequenceValueLabel;
        private System.Windows.Forms.Label findFibonachiSequenceDescriptionLabel;
        private System.Windows.Forms.TrackBar findFibonachiSequenceTrackBar;
        private System.Windows.Forms.TabPage findPrimeFactorTabPage;
        private System.Windows.Forms.Label findPrimeFactorResultLabel;
        private System.Windows.Forms.CheckBox findPrimeFactorAutogenerateCheckBox;
        private System.Windows.Forms.Button findPrimeFactorGenerateButton;
        private System.Windows.Forms.Label findPrimeFactorValueLabel;
        private System.Windows.Forms.Label findPrimeFactorDescriptionLabel;
        private System.Windows.Forms.TrackBar findPrimeFactorTrackBar;
    }
}


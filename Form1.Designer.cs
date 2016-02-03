namespace JPGRawFotoSelector
{
    partial class FotoSelectorMainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FotoSelectorMainWindow));
            this.checkBaseOnJPG = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FileCleanList = new System.Windows.Forms.ListBox();
            this.textBoxJPG = new System.Windows.Forms.TextBox();
            this.textPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblFileList = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxRAW = new System.Windows.Forms.TextBox();
            this.cobCamera = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // checkBaseOnJPG
            // 
            this.checkBaseOnJPG.AutoSize = true;
            this.checkBaseOnJPG.Checked = true;
            this.checkBaseOnJPG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBaseOnJPG.Location = new System.Drawing.Point(653, 36);
            this.checkBaseOnJPG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBaseOnJPG.Name = "checkBaseOnJPG";
            this.checkBaseOnJPG.Size = new System.Drawing.Size(157, 19);
            this.checkBaseOnJPG.TabIndex = 0;
            this.checkBaseOnJPG.Text = "Base on JPG File";
            this.checkBaseOnJPG.UseVisualStyleBackColor = true;
            this.checkBaseOnJPG.CheckedChanged += new System.EventHandler(this.checkBaseOnJPG_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "JPG File Type";
            // 
            // FileCleanList
            // 
            this.FileCleanList.FormattingEnabled = true;
            this.FileCleanList.ItemHeight = 15;
            this.FileCleanList.Location = new System.Drawing.Point(36, 183);
            this.FileCleanList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FileCleanList.Name = "FileCleanList";
            this.FileCleanList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.FileCleanList.Size = new System.Drawing.Size(764, 649);
            this.FileCleanList.TabIndex = 3;
            // 
            // textBoxJPG
            // 
            this.textBoxJPG.Location = new System.Drawing.Point(311, 32);
            this.textBoxJPG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxJPG.Name = "textBoxJPG";
            this.textBoxJPG.Size = new System.Drawing.Size(105, 25);
            this.textBoxJPG.TabIndex = 4;
            this.textBoxJPG.Text = "JPG";
            // 
            // textPath
            // 
            this.textPath.Location = new System.Drawing.Point(36, 107);
            this.textPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(640, 25);
            this.textPath.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(685, 92);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Detect File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(685, 137);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(116, 38);
            this.button2.TabIndex = 7;
            this.button2.Text = "Clean File";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblFileList
            // 
            this.lblFileList.AutoSize = true;
            this.lblFileList.Location = new System.Drawing.Point(33, 149);
            this.lblFileList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileList.Name = "lblFileList";
            this.lblFileList.Size = new System.Drawing.Size(183, 15);
            this.lblFileList.TabIndex = 8;
            this.lblFileList.Text = "Select Files To Delete";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(425, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "RAW File Type";
            // 
            // textBoxRAW
            // 
            this.textBoxRAW.Location = new System.Drawing.Point(539, 32);
            this.textBoxRAW.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxRAW.Name = "textBoxRAW";
            this.textBoxRAW.Size = new System.Drawing.Size(105, 25);
            this.textBoxRAW.TabIndex = 5;
            this.textBoxRAW.Text = "ARW";
            // 
            // cobCamera
            // 
            this.cobCamera.AllowDrop = true;
            this.cobCamera.FormattingEnabled = true;
            this.cobCamera.Location = new System.Drawing.Point(36, 33);
            this.cobCamera.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cobCamera.Name = "cobCamera";
            this.cobCamera.Size = new System.Drawing.Size(160, 23);
            this.cobCamera.TabIndex = 9;
            this.cobCamera.SelectedIndexChanged += new System.EventHandler(this.cobCamera_SelectedIndexChanged_1);
            // 
            // FotoSelectorMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 858);
            this.Controls.Add(this.cobCamera);
            this.Controls.Add(this.lblFileList);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxRAW);
            this.Controls.Add(this.textPath);
            this.Controls.Add(this.textBoxJPG);
            this.Controls.Add(this.FileCleanList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBaseOnJPG);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FotoSelectorMainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "JPGRawFotoSelector";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBaseOnJPG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox FileCleanList;
        private System.Windows.Forms.TextBox textBoxJPG;
        private System.Windows.Forms.TextBox textPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblFileList;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxRAW;
        private System.Windows.Forms.ComboBox cobCamera;
    }
}


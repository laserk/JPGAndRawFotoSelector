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
            this.baseOnJpgCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FileCleanList = new System.Windows.Forms.ListView();
            this.textBoxJPG = new System.Windows.Forms.TextBox();
            this.textPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cleanButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxRAW = new System.Windows.Forms.TextBox();
            this.cobCamera = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.jpgModeCheckBox = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.selectAllCheckBox = new System.Windows.Forms.CheckBox();
            this.viewButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseOnJpgCheckBox
            // 
            this.baseOnJpgCheckBox.AutoSize = true;
            this.baseOnJpgCheckBox.Checked = true;
            this.baseOnJpgCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.baseOnJpgCheckBox.Location = new System.Drawing.Point(57, 78);
            this.baseOnJpgCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.baseOnJpgCheckBox.Name = "baseOnJpgCheckBox";
            this.baseOnJpgCheckBox.Size = new System.Drawing.Size(139, 21);
            this.baseOnJpgCheckBox.TabIndex = 0;
            this.baseOnJpgCheckBox.Text = "Base on JPG File";
            this.baseOnJpgCheckBox.UseVisualStyleBackColor = true;
            this.baseOnJpgCheckBox.CheckedChanged += new System.EventHandler(this.checkBaseOnJPG_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(205, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "JPG File Type";
            // 
            // FileCleanList
            // 
 

            this.FileCleanList.Location = new System.Drawing.Point(36, 195);
            this.FileCleanList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FileCleanList.Name = "FileCleanList";
            this.FileCleanList.MultiSelect = true;
            this.FileCleanList.Size = new System.Drawing.Size(764, 692);
            this.FileCleanList.TabIndex = 3;
            this.FileCleanList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FileCleanList_MouseDoubleClick);
            // 
            // textBoxJPG
            // 
            this.textBoxJPG.Location = new System.Drawing.Point(311, 34);
            this.textBoxJPG.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxJPG.Name = "textBoxJPG";
            this.textBoxJPG.Size = new System.Drawing.Size(105, 22);
            this.textBoxJPG.TabIndex = 4;
            this.textBoxJPG.Text = "JPG";
            // 
            // textPath
            // 
            this.textPath.Location = new System.Drawing.Point(36, 114);
            this.textPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(764, 22);
            this.textPath.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(684, 58);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "Detect File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.detectButton_Click);
            // 
            // cleanButton
            // 
            this.cleanButton.Location = new System.Drawing.Point(684, 142);
            this.cleanButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(116, 41);
            this.cleanButton.TabIndex = 7;
            this.cleanButton.Text = "Clean File";
            this.cleanButton.UseVisualStyleBackColor = true;
            this.cleanButton.Click += new System.EventHandler(this.cleanButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(425, 38);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "RAW File Type";
            // 
            // textBoxRAW
            // 
            this.textBoxRAW.Location = new System.Drawing.Point(539, 34);
            this.textBoxRAW.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxRAW.Name = "textBoxRAW";
            this.textBoxRAW.Size = new System.Drawing.Size(105, 22);
            this.textBoxRAW.TabIndex = 5;
            this.textBoxRAW.Text = "ARW";
            // 
            // cobCamera
            // 
            this.cobCamera.AllowDrop = true;
            this.cobCamera.FormattingEnabled = true;
            this.cobCamera.Location = new System.Drawing.Point(36, 35);
            this.cobCamera.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cobCamera.Name = "cobCamera";
            this.cobCamera.Size = new System.Drawing.Size(160, 24);
            this.cobCamera.TabIndex = 9;
            this.cobCamera.SelectedIndexChanged += new System.EventHandler(this.cobCamera_SelectedIndexChanged_1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 890);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(817, 25);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // jpgModeCheckBox
            // 
            this.jpgModeCheckBox.AutoSize = true;
            this.jpgModeCheckBox.Location = new System.Drawing.Point(48, 154);
            this.jpgModeCheckBox.Name = "jpgModeCheckBox";
            this.jpgModeCheckBox.Size = new System.Drawing.Size(129, 21);
            this.jpgModeCheckBox.TabIndex = 11;
            this.jpgModeCheckBox.Text = "JPG View Mode";
            this.jpgModeCheckBox.UseVisualStyleBackColor = true;
            this.jpgModeCheckBox.CheckedChanged += new System.EventHandler(this.modeCheckBox_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(208, 78);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(103, 21);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Auto Group";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // selectAllCheckBox
            // 
            this.selectAllCheckBox.AutoSize = true;
            this.selectAllCheckBox.Location = new System.Drawing.Point(573, 153);
            this.selectAllCheckBox.Name = "selectAllCheckBox";
            this.selectAllCheckBox.Size = new System.Drawing.Size(88, 21);
            this.selectAllCheckBox.TabIndex = 13;
            this.selectAllCheckBox.Text = "Select All";
            this.selectAllCheckBox.UseVisualStyleBackColor = true;
            this.selectAllCheckBox.CheckedChanged += new System.EventHandler(this.selectAllCheckBox_CheckedChanged);
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(224, 142);
            this.viewButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(116, 41);
            this.viewButton.TabIndex = 15;
            this.viewButton.Text = "View JPG";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // FotoSelectorMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 915);
            this.Controls.Add(this.viewButton);
            this.Controls.Add(this.selectAllCheckBox);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.jpgModeCheckBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cobCamera);
            this.Controls.Add(this.cleanButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxRAW);
            this.Controls.Add(this.textPath);
            this.Controls.Add(this.textBoxJPG);
            this.Controls.Add(this.FileCleanList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.baseOnJpgCheckBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "FotoSelectorMainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "JPGRawFotoSelector";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox baseOnJpgCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView FileCleanList;
        private System.Windows.Forms.TextBox textBoxJPG;
        private System.Windows.Forms.TextBox textPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cleanButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxRAW;
        private System.Windows.Forms.ComboBox cobCamera;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.CheckBox jpgModeCheckBox;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox selectAllCheckBox;
        private System.Windows.Forms.Button viewButton;
    }
}


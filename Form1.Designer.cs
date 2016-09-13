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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblModelLabel = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseOnJpgCheckBox
            // 
            this.baseOnJpgCheckBox.AutoSize = true;
            this.baseOnJpgCheckBox.Checked = true;
            this.baseOnJpgCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.baseOnJpgCheckBox.Location = new System.Drawing.Point(57, 73);
            this.baseOnJpgCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.baseOnJpgCheckBox.Name = "baseOnJpgCheckBox";
            this.baseOnJpgCheckBox.Size = new System.Drawing.Size(157, 19);
            this.baseOnJpgCheckBox.TabIndex = 0;
            this.baseOnJpgCheckBox.Text = "Base on JPG File";
            this.baseOnJpgCheckBox.UseVisualStyleBackColor = true;
            this.baseOnJpgCheckBox.CheckedChanged += new System.EventHandler(this.checkBaseOnJPG_CheckedChanged);
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
            this.FileCleanList.AllowDrop = true;
            this.FileCleanList.FullRowSelect = true;
            this.FileCleanList.ImeMode = System.Windows.Forms.ImeMode.On;
            this.FileCleanList.LabelWrap = false;
            this.FileCleanList.Location = new System.Drawing.Point(36, 183);
            this.FileCleanList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FileCleanList.Name = "FileCleanList";
            this.FileCleanList.Size = new System.Drawing.Size(764, 649);
            this.FileCleanList.TabIndex = 3;
            this.FileCleanList.UseCompatibleStateImageBehavior = false;
            this.FileCleanList.View = System.Windows.Forms.View.Details;
            this.FileCleanList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FileCleanList_MouseDoubleClick);
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
            this.textPath.Size = new System.Drawing.Size(764, 25);
            this.textPath.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(684, 62);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Detect File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.detectButton_Click);
            // 
            // cleanButton
            // 
            this.cleanButton.Location = new System.Drawing.Point(684, 139);
            this.cleanButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(116, 38);
            this.cleanButton.TabIndex = 7;
            this.cleanButton.Text = "Clean File";
            this.cleanButton.UseVisualStyleBackColor = true;
            this.cleanButton.Click += new System.EventHandler(this.cleanButton_Click);
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
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 694);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(817, 25);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(167, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // jpgModeCheckBox
            // 
            this.jpgModeCheckBox.AutoSize = true;
            this.jpgModeCheckBox.Location = new System.Drawing.Point(283, 149);
            this.jpgModeCheckBox.Name = "jpgModeCheckBox";
            this.jpgModeCheckBox.Size = new System.Drawing.Size(133, 19);
            this.jpgModeCheckBox.TabIndex = 11;
            this.jpgModeCheckBox.Text = "JPG View Mode";
            this.jpgModeCheckBox.UseVisualStyleBackColor = true;
            this.jpgModeCheckBox.CheckedChanged += new System.EventHandler(this.modeCheckBox_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(237, 73);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(109, 19);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Auto Group";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // selectAllCheckBox
            // 
            this.selectAllCheckBox.AutoSize = true;
            this.selectAllCheckBox.Location = new System.Drawing.Point(551, 150);
            this.selectAllCheckBox.Name = "selectAllCheckBox";
            this.selectAllCheckBox.Size = new System.Drawing.Size(109, 19);
            this.selectAllCheckBox.TabIndex = 13;
            this.selectAllCheckBox.Text = "Select All";
            this.selectAllCheckBox.UseVisualStyleBackColor = true;
            this.selectAllCheckBox.CheckedChanged += new System.EventHandler(this.selectAllCheckBox_CheckedChanged);
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(428, 139);
            this.viewButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(116, 38);
            this.viewButton.TabIndex = 15;
            this.viewButton.Text = "View JPG";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(352, 73);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(192, 23);
            this.progressBar1.TabIndex = 16;
            // 
            // lblModelLabel
            // 
            this.lblModelLabel.AutoSize = true;
            this.lblModelLabel.Font = new System.Drawing.Font("Magneto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblModelLabel.Location = new System.Drawing.Point(31, 144);
            this.lblModelLabel.Name = "lblModelLabel";
            this.lblModelLabel.Size = new System.Drawing.Size(192, 25);
            this.lblModelLabel.TabIndex = 17;
            this.lblModelLabel.Text = "Photo view mode";
            // 
            // FotoSelectorMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 719);
            this.Controls.Add(this.lblModelLabel);
            this.Controls.Add(this.progressBar1);
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
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblModelLabel;
    }
}


namespace Copy_Files
{
    partial class Form1
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
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtBoxFolderPath = new System.Windows.Forms.TextBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.btnDeleteEverything = new System.Windows.Forms.Button();
            this.btnChooseFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxFolderPath
            // 
            this.txtBoxFolderPath.Location = new System.Drawing.Point(189, 21);
            this.txtBoxFolderPath.Name = "txtBoxFolderPath";
            this.txtBoxFolderPath.ReadOnly = true;
            this.txtBoxFolderPath.Size = new System.Drawing.Size(336, 20);
            this.txtBoxFolderPath.TabIndex = 0;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Location = new System.Drawing.Point(21, 51);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(504, 24);
            this.btnOpenFolder.TabIndex = 2;
            this.btnOpenFolder.Text = "Otwórz folder";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            this.btnOpenFolder.Click += new System.EventHandler(this.BtnOpenFolder_Click);
            // 
            // btnDeleteEverything
            // 
            this.btnDeleteEverything.Location = new System.Drawing.Point(21, 81);
            this.btnDeleteEverything.Name = "btnDeleteEverything";
            this.btnDeleteEverything.Size = new System.Drawing.Size(504, 24);
            this.btnDeleteEverything.TabIndex = 3;
            this.btnDeleteEverything.Text = "Usuń wszystko z folderu";
            this.btnDeleteEverything.UseVisualStyleBackColor = true;
            this.btnDeleteEverything.Click += new System.EventHandler(this.BtnDeleteEverything_Click);
            // 
            // btnChooseFolder
            // 
            this.btnChooseFolder.Location = new System.Drawing.Point(21, 18);
            this.btnChooseFolder.Name = "btnChooseFolder";
            this.btnChooseFolder.Size = new System.Drawing.Size(162, 24);
            this.btnChooseFolder.TabIndex = 4;
            this.btnChooseFolder.Text = "Wybierz folder docelowy";
            this.btnChooseFolder.UseVisualStyleBackColor = true;
            this.btnChooseFolder.Click += new System.EventHandler(this.BtnChooseFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 118);
            this.Controls.Add(this.btnChooseFolder);
            this.Controls.Add(this.btnDeleteEverything);
            this.Controls.Add(this.btnOpenFolder);
            this.Controls.Add(this.txtBoxFolderPath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox txtBoxFolderPath;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.Button btnDeleteEverything;
        private System.Windows.Forms.Button btnChooseFolder;
    }
}


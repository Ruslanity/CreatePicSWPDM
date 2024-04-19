namespace StandaloneApplicationCSharp
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCreatePic = new System.Windows.Forms.Button();
            this.labelFolder = new System.Windows.Forms.Label();
            this.textBoxFolderPath = new System.Windows.Forms.TextBox();
            this.buttonFolder = new System.Windows.Forms.Button();
            this.buttonBrowsePDM = new System.Windows.Forms.Button();
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonCreateOnePic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Поиск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(321, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя файла:   ";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(11, 148);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(457, 472);
            this.listBox1.TabIndex = 3;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(12, 626);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(457, 23);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonCreatePic
            // 
            this.buttonCreatePic.Location = new System.Drawing.Point(93, 610);
            this.buttonCreatePic.Name = "buttonCreatePic";
            this.buttonCreatePic.Size = new System.Drawing.Size(75, 23);
            this.buttonCreatePic.TabIndex = 5;
            this.buttonCreatePic.Text = "CreatePic";
            this.buttonCreatePic.UseVisualStyleBackColor = true;
            this.buttonCreatePic.Visible = false;
            this.buttonCreatePic.Click += new System.EventHandler(this.buttonCreatePic_Click);
            // 
            // labelFolder
            // 
            this.labelFolder.AutoSize = true;
            this.labelFolder.Location = new System.Drawing.Point(13, 42);
            this.labelFolder.Name = "labelFolder";
            this.labelFolder.Size = new System.Drawing.Size(101, 13);
            this.labelFolder.TabIndex = 6;
            this.labelFolder.Text = "Папка сохранения";
            // 
            // textBoxFolderPath
            // 
            this.textBoxFolderPath.Location = new System.Drawing.Point(120, 39);
            this.textBoxFolderPath.Name = "textBoxFolderPath";
            this.textBoxFolderPath.Size = new System.Drawing.Size(349, 20);
            this.textBoxFolderPath.TabIndex = 7;
            // 
            // buttonFolder
            // 
            this.buttonFolder.Location = new System.Drawing.Point(243, 65);
            this.buttonFolder.Name = "buttonFolder";
            this.buttonFolder.Size = new System.Drawing.Size(225, 23);
            this.buttonFolder.TabIndex = 8;
            this.buttonFolder.Text = "Обзор";
            this.buttonFolder.UseVisualStyleBackColor = true;
            this.buttonFolder.Click += new System.EventHandler(this.buttonFolder_Click);
            // 
            // buttonBrowsePDM
            // 
            this.buttonBrowsePDM.Location = new System.Drawing.Point(12, 65);
            this.buttonBrowsePDM.Name = "buttonBrowsePDM";
            this.buttonBrowsePDM.Size = new System.Drawing.Size(225, 23);
            this.buttonBrowsePDM.TabIndex = 10;
            this.buttonBrowsePDM.Text = "BrowsePDM";
            this.buttonBrowsePDM.UseVisualStyleBackColor = true;
            this.buttonBrowsePDM.Click += new System.EventHandler(this.buttonBrowsePDM_Click);
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(11, 94);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(457, 23);
            this.buttonTest.TabIndex = 11;
            this.buttonTest.Text = "Create pictures for everything";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonCreateOnePic
            // 
            this.buttonCreateOnePic.Location = new System.Drawing.Point(11, 119);
            this.buttonCreateOnePic.Name = "buttonCreateOnePic";
            this.buttonCreateOnePic.Size = new System.Drawing.Size(457, 23);
            this.buttonCreateOnePic.TabIndex = 12;
            this.buttonCreateOnePic.Text = "Create an image only";
            this.buttonCreateOnePic.UseVisualStyleBackColor = true;
            this.buttonCreateOnePic.Click += new System.EventHandler(this.buttonCreateOnePic_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 661);
            this.Controls.Add(this.buttonCreateOnePic);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.buttonBrowsePDM);
            this.Controls.Add(this.buttonFolder);
            this.Controls.Add(this.textBoxFolderPath);
            this.Controls.Add(this.labelFolder);
            this.Controls.Add(this.buttonCreatePic);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(500, 700);
            this.MinimumSize = new System.Drawing.Size(500, 700);
            this.Name = "Form1";
            this.Text = "PictureFromPDM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonCreatePic;
        private System.Windows.Forms.Label labelFolder;
        private System.Windows.Forms.TextBox textBoxFolderPath;
        private System.Windows.Forms.Button buttonFolder;
        private System.Windows.Forms.Button buttonBrowsePDM;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonCreateOnePic;
        public System.Windows.Forms.ListBox listBox1;
    }
}


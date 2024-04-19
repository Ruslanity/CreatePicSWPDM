namespace CreatePicPDM
{
    partial class Form2
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxSearchItem = new System.Windows.Forms.ListBox();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.listBoxSearchItem, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddItem, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 261);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // listBoxSearchItem
            // 
            this.listBoxSearchItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSearchItem.FormattingEnabled = true;
            this.listBoxSearchItem.Location = new System.Drawing.Point(3, 3);
            this.listBoxSearchItem.Name = "listBoxSearchItem";
            this.listBoxSearchItem.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxSearchItem.Size = new System.Drawing.Size(978, 225);
            this.listBoxSearchItem.TabIndex = 0;
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddItem.Location = new System.Drawing.Point(3, 234);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(978, 24);
            this.buttonAddItem.TabIndex = 1;
            this.buttonAddItem.Text = "Добавить";
            this.buttonAddItem.UseVisualStyleBackColor = true;
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(1000, 300);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "Form2";
            this.Text = "Добавление файлов";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonAddItem;
        public System.Windows.Forms.ListBox listBoxSearchItem;
    }
}
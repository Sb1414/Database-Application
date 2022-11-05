namespace PassApp
{
    partial class Form3
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelUp = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelBorder = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelUp.SuspendLayout();
            this.panelBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.panel1.Controls.Add(this.panelUp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 607);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelUp_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelUp_MouseMove);
            // 
            // panelUp
            // 
            this.panelUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(31)))), ((int)(((byte)(37)))));
            this.panelUp.Controls.Add(this.labelName);
            this.panelUp.Controls.Add(this.buttonClose);
            this.panelUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUp.Location = new System.Drawing.Point(0, 0);
            this.panelUp.Name = "panelUp";
            this.panelUp.Size = new System.Drawing.Size(925, 28);
            this.panelUp.TabIndex = 0;
            this.panelUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelUp_MouseDown);
            this.panelUp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelUp_MouseMove);
            // 
            // labelName
            // 
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.Font = new System.Drawing.Font("Rockwell", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(128)))), ((int)(((byte)(132)))));
            this.labelName.Location = new System.Drawing.Point(186, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(527, 25);
            this.labelName.TabIndex = 2;
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelUp_MouseDown);
            this.labelName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelUp_MouseMove);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.BackgroundImage = global::PassApp.Properties.Resources.icons8_macos_закрыть_20__1_;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(0, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(28, 28);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panelBorder
            // 
            this.panelBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelBorder.Controls.Add(this.panel1);
            this.panelBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorder.Location = new System.Drawing.Point(0, 0);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Size = new System.Drawing.Size(925, 607);
            this.panelBorder.TabIndex = 3;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 607);
            this.Controls.Add(this.panelBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.panel1.ResumeLayout(false);
            this.panelUp.ResumeLayout(false);
            this.panelBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Panel panelUp;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panelBorder;
    }
}
namespace BaseBuilder
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_base = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_info_text = new System.Windows.Forms.Label();
            this.label_info_title = new System.Windows.Forms.Label();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.label_person = new System.Windows.Forms.Label();
            this.panel_right = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel_base.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.panel_right.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_base
            // 
            this.panel_base.Controls.Add(this.panel1);
            this.panel_base.Controls.Add(this.canvas);
            this.panel_base.Controls.Add(this.label_person);
            this.panel_base.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_base.Location = new System.Drawing.Point(0, 0);
            this.panel_base.Name = "panel_base";
            this.panel_base.Size = new System.Drawing.Size(629, 701);
            this.panel_base.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_info_text);
            this.panel1.Controls.Add(this.label_info_title);
            this.panel1.Location = new System.Drawing.Point(12, 429);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 176);
            this.panel1.TabIndex = 2;
            // 
            // label_info_text
            // 
            this.label_info_text.Font = new System.Drawing.Font("Quicksand Book", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_info_text.Location = new System.Drawing.Point(3, 34);
            this.label_info_text.Name = "label_info_text";
            this.label_info_text.Size = new System.Drawing.Size(605, 124);
            this.label_info_text.TabIndex = 1;
            this.label_info_text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label_info_title
            // 
            this.label_info_title.Font = new System.Drawing.Font("Quicksand Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_info_title.Location = new System.Drawing.Point(3, 1);
            this.label_info_title.Name = "label_info_title";
            this.label_info_title.Size = new System.Drawing.Size(605, 33);
            this.label_info_title.TabIndex = 0;
            this.label_info_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // canvas
            // 
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(26, 22);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(580, 401);
            this.canvas.TabIndex = 1;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            // 
            // label_person
            // 
            this.label_person.BackColor = System.Drawing.Color.White;
            this.label_person.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_person.Font = new System.Drawing.Font("Quicksand Book", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_person.Location = new System.Drawing.Point(12, 608);
            this.label_person.Name = "label_person";
            this.label_person.Size = new System.Drawing.Size(611, 84);
            this.label_person.TabIndex = 0;
            this.label_person.Text = "HI!";
            this.label_person.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_person.TextChanged += new System.EventHandler(this.label_person_TextChanged);
            this.label_person.Click += new System.EventHandler(this.label_person_Click);
            // 
            // panel_right
            // 
            this.panel_right.Controls.Add(this.textBox1);
            this.panel_right.Controls.Add(this.button2);
            this.panel_right.Controls.Add(this.button1);
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_right.Location = new System.Drawing.Point(629, 0);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(651, 701);
            this.panel_right.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 25);
            this.button2.TabIndex = 1;
            this.button2.Text = ">> 1 >>";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 666);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(156, 133);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(353, 454);
            this.textBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 701);
            this.Controls.Add(this.panel_right);
            this.Controls.Add(this.panel_base);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_base.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.panel_right.ResumeLayout(false);
            this.panel_right.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_base;
        private System.Windows.Forms.Panel panel_right;
        private System.Windows.Forms.Label label_person;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_info_title;
        private System.Windows.Forms.Label label_info_text;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
    }
}


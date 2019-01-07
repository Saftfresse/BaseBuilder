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
            this.panel_right = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel_base
            // 
            this.panel_base.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_base.Location = new System.Drawing.Point(0, 0);
            this.panel_base.Name = "panel_base";
            this.panel_base.Size = new System.Drawing.Size(629, 701);
            this.panel_base.TabIndex = 0;
            // 
            // panel_right
            // 
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_right.Location = new System.Drawing.Point(629, 0);
            this.panel_right.Name = "panel_right";
            this.panel_right.Size = new System.Drawing.Size(651, 701);
            this.panel_right.TabIndex = 1;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_base;
        private System.Windows.Forms.Panel panel_right;
    }
}



namespace Presentacion
{
    partial class Captcha
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
            this.pb_confirmado = new System.Windows.Forms.PictureBox();
            this.pb_noconfirmado = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_confirmado = new System.Windows.Forms.TextBox();
            this.txt_noconfirmado = new System.Windows.Forms.TextBox();
            this.btn_comprobar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_confirmado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_noconfirmado)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_confirmado
            // 
            this.pb_confirmado.Location = new System.Drawing.Point(268, 63);
            this.pb_confirmado.Name = "pb_confirmado";
            this.pb_confirmado.Size = new System.Drawing.Size(200, 100);
            this.pb_confirmado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_confirmado.TabIndex = 0;
            this.pb_confirmado.TabStop = false;
            // 
            // pb_noconfirmado
            // 
            this.pb_noconfirmado.Location = new System.Drawing.Point(62, 63);
            this.pb_noconfirmado.Name = "pb_noconfirmado";
            this.pb_noconfirmado.Size = new System.Drawing.Size(200, 100);
            this.pb_noconfirmado.TabIndex = 1;
            this.pb_noconfirmado.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Confirmado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "No confirmado";
            // 
            // txt_confirmado
            // 
            this.txt_confirmado.CausesValidation = false;
            this.txt_confirmado.Location = new System.Drawing.Point(268, 169);
            this.txt_confirmado.Name = "txt_confirmado";
            this.txt_confirmado.Size = new System.Drawing.Size(200, 20);
            this.txt_confirmado.TabIndex = 5;
            // 
            // txt_noconfirmado
            // 
            this.txt_noconfirmado.Location = new System.Drawing.Point(62, 169);
            this.txt_noconfirmado.Name = "txt_noconfirmado";
            this.txt_noconfirmado.Size = new System.Drawing.Size(200, 20);
            this.txt_noconfirmado.TabIndex = 4;
            // 
            // btn_comprobar
            // 
            this.btn_comprobar.CausesValidation = false;
            this.btn_comprobar.Location = new System.Drawing.Point(228, 215);
            this.btn_comprobar.Name = "btn_comprobar";
            this.btn_comprobar.Size = new System.Drawing.Size(75, 23);
            this.btn_comprobar.TabIndex = 6;
            this.btn_comprobar.Text = "Comprobar";
            this.btn_comprobar.UseVisualStyleBackColor = true;
            this.btn_comprobar.Click += new System.EventHandler(this.btn_comprobar_Click);
            // 
            // Captcha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 250);
            this.Controls.Add(this.btn_comprobar);
            this.Controls.Add(this.txt_noconfirmado);
            this.Controls.Add(this.txt_confirmado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_noconfirmado);
            this.Controls.Add(this.pb_confirmado);
            this.Name = "Captcha";
            this.Text = "Captcha";
            ((System.ComponentModel.ISupportInitialize)(this.pb_confirmado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_noconfirmado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_confirmado;
        private System.Windows.Forms.PictureBox pb_noconfirmado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_confirmado;
        private System.Windows.Forms.TextBox txt_noconfirmado;
        private System.Windows.Forms.Button btn_comprobar;
    }
}
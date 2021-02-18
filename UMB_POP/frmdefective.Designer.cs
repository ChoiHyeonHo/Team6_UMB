
namespace UMB_POP
{
    partial class frmdefective
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblper = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDef = new System.Windows.Forms.ComboBox();
            this.btnCreat = new System.Windows.Forms.Button();
            this.txtngcount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(27, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "생산 실적 번호";
            // 
            // lblper
            // 
            this.lblper.AutoSize = true;
            this.lblper.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblper.ForeColor = System.Drawing.Color.White;
            this.lblper.Location = new System.Drawing.Point(27, 79);
            this.lblper.Name = "lblper";
            this.lblper.Size = new System.Drawing.Size(153, 29);
            this.lblper.TabIndex = 0;
            this.lblper.Text = "2021022023";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(27, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "불량유형";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(27, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "불량갯수";
            // 
            // cboDef
            // 
            this.cboDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.cboDef.ForeColor = System.Drawing.Color.Black;
            this.cboDef.FormattingEnabled = true;
            this.cboDef.Location = new System.Drawing.Point(27, 190);
            this.cboDef.Name = "cboDef";
            this.cboDef.Size = new System.Drawing.Size(210, 37);
            this.cboDef.TabIndex = 1;
            // 
            // btnCreat
            // 
            this.btnCreat.BackColor = System.Drawing.Color.DimGray;
            this.btnCreat.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.btnCreat.ForeColor = System.Drawing.Color.White;
            this.btnCreat.Location = new System.Drawing.Point(27, 373);
            this.btnCreat.Name = "btnCreat";
            this.btnCreat.Size = new System.Drawing.Size(210, 65);
            this.btnCreat.TabIndex = 2;
            this.btnCreat.Text = "불량 등록";
            this.btnCreat.UseVisualStyleBackColor = false;
            this.btnCreat.Click += new System.EventHandler(this.btnCreat_Click);
            // 
            // txtngcount
            // 
            this.txtngcount.BackColor = System.Drawing.Color.Gainsboro;
            this.txtngcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtngcount.Location = new System.Drawing.Point(27, 301);
            this.txtngcount.Name = "txtngcount";
            this.txtngcount.Size = new System.Drawing.Size(210, 40);
            this.txtngcount.TabIndex = 8;
            // 
            // frmdefective
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(267, 450);
            this.Controls.Add(this.txtngcount);
            this.Controls.Add(this.btnCreat);
            this.Controls.Add(this.cboDef);
            this.Controls.Add(this.lblper);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "frmdefective";
            this.Text = "불랑등록";
            this.Load += new System.EventHandler(this.frmdefective_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblper;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDef;
        private System.Windows.Forms.Button btnCreat;
        private System.Windows.Forms.TextBox txtngcount;
    }
}
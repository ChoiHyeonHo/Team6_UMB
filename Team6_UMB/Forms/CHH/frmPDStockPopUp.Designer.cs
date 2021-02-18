
namespace Team6_UMB.Forms
{
    partial class frmPDStockPopUp
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button3 = new System.Windows.Forms.Button();
            this.dgvPDStockPop = new Team6_UMB.DGV_Custom();
            this.newBtns1 = new Team6_UMB.Controls.NewBtns();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPDStockPop)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.newBtns1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Size = new System.Drawing.Size(867, 35);
            this.panel1.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.Controls.SetChildIndex(this.newBtns1, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(86, 24);
            this.label1.Text = "재고현황";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::Team6_UMB.Properties.Resources.Close;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(3, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(29, 23);
            this.button3.TabIndex = 22;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dgvPDStockPop
            // 
            this.dgvPDStockPop.BackgroundColor = System.Drawing.Color.White;
            this.dgvPDStockPop.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("나눔바른고딕", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPDStockPop.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPDStockPop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPDStockPop.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgvPDStockPop.GridColor = System.Drawing.Color.LightGray;
            this.dgvPDStockPop.Location = new System.Drawing.Point(12, 55);
            this.dgvPDStockPop.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.dgvPDStockPop.MinimumSize = new System.Drawing.Size(150, 150);
            this.dgvPDStockPop.Name = "dgvPDStockPop";
            this.dgvPDStockPop.RowTemplate.Height = 23;
            this.dgvPDStockPop.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPDStockPop.Size = new System.Drawing.Size(867, 431);
            this.dgvPDStockPop.TabIndex = 16;
            this.dgvPDStockPop.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPDStockPop_CellDoubleClick);
            // 
            // newBtns1
            // 
            this.newBtns1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(79)))));
            this.newBtns1.Dock = System.Windows.Forms.DockStyle.Right;
            this.newBtns1.Location = new System.Drawing.Point(61, 0);
            this.newBtns1.Name = "newBtns1";
            this.newBtns1.Size = new System.Drawing.Size(770, 35);
            this.newBtns1.TabIndex = 23;
            this.newBtns1.btnUpdate_Event += new System.EventHandler(this.newBtns1_btnUpdate_Event);
            this.newBtns1.btnDelete_Event += new System.EventHandler(this.newBtns1_btnDelete_Event);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(831, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(36, 35);
            this.panel2.TabIndex = 23;
            // 
            // frmPDStockPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(889, 496);
            this.Controls.Add(this.dgvPDStockPop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPDStockPopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dgvPDStockPop, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPDStockPop)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DGV_Custom dgvPDStockPop;
        private System.Windows.Forms.Button button3;
        private Controls.NewBtns newBtns1;
        private System.Windows.Forms.Panel panel2;
    }
}

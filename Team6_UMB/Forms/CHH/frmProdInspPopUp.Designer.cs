
namespace Team6_UMB.Forms.CHH
{
    partial class frmProdInspPopUp
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_CheckList = new Team6_UMB.DGV_Custom();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.구성품ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.양품ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.불량ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.포장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.양품ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.불량ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.비고ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.newBtns1 = new Team6_UMB.Controls.NewBtns();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CheckList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.newBtns1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Size = new System.Drawing.Size(770, 35);
            this.panel1.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.Controls.SetChildIndex(this.newBtns1, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(86, 24);
            this.label1.Text = "제품검사";
            // 
            // dgv_CheckList
            // 
            this.dgv_CheckList.BackgroundColor = System.Drawing.Color.White;
            this.dgv_CheckList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("나눔바른고딕", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_CheckList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_CheckList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CheckList.ContextMenuStrip = this.contextMenuStrip1;
            this.dgv_CheckList.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgv_CheckList.GridColor = System.Drawing.Color.LightGray;
            this.dgv_CheckList.Location = new System.Drawing.Point(12, 55);
            this.dgv_CheckList.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.dgv_CheckList.MinimumSize = new System.Drawing.Size(150, 150);
            this.dgv_CheckList.Name = "dgv_CheckList";
            this.dgv_CheckList.RowTemplate.Height = 23;
            this.dgv_CheckList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_CheckList.Size = new System.Drawing.Size(770, 366);
            this.dgv_CheckList.TabIndex = 17;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.구성품ToolStripMenuItem,
            this.포장ToolStripMenuItem,
            this.비고ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 70);
            // 
            // 구성품ToolStripMenuItem
            // 
            this.구성품ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.양품ToolStripMenuItem,
            this.불량ToolStripMenuItem});
            this.구성품ToolStripMenuItem.Name = "구성품ToolStripMenuItem";
            this.구성품ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.구성품ToolStripMenuItem.Text = "구성품";
            // 
            // 양품ToolStripMenuItem
            // 
            this.양품ToolStripMenuItem.Name = "양품ToolStripMenuItem";
            this.양품ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.양품ToolStripMenuItem.Text = "양품";
            this.양품ToolStripMenuItem.Click += new System.EventHandler(this.양품ToolStripMenuItem_Click);
            // 
            // 불량ToolStripMenuItem
            // 
            this.불량ToolStripMenuItem.Name = "불량ToolStripMenuItem";
            this.불량ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.불량ToolStripMenuItem.Text = "불량";
            this.불량ToolStripMenuItem.Click += new System.EventHandler(this.불량ToolStripMenuItem_Click);
            // 
            // 포장ToolStripMenuItem
            // 
            this.포장ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.양품ToolStripMenuItem1,
            this.불량ToolStripMenuItem1});
            this.포장ToolStripMenuItem.Name = "포장ToolStripMenuItem";
            this.포장ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.포장ToolStripMenuItem.Text = "포장";
            // 
            // 양품ToolStripMenuItem1
            // 
            this.양품ToolStripMenuItem1.Name = "양품ToolStripMenuItem1";
            this.양품ToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.양품ToolStripMenuItem1.Text = "양품";
            this.양품ToolStripMenuItem1.Click += new System.EventHandler(this.양품ToolStripMenuItem1_Click);
            // 
            // 불량ToolStripMenuItem1
            // 
            this.불량ToolStripMenuItem1.Name = "불량ToolStripMenuItem1";
            this.불량ToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.불량ToolStripMenuItem1.Text = "불량";
            this.불량ToolStripMenuItem1.Click += new System.EventHandler(this.불량ToolStripMenuItem1_Click);
            // 
            // 비고ToolStripMenuItem
            // 
            this.비고ToolStripMenuItem.Name = "비고ToolStripMenuItem";
            this.비고ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.비고ToolStripMenuItem.Text = "비고";
            this.비고ToolStripMenuItem.Click += new System.EventHandler(this.비고ToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancle);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Location = new System.Drawing.Point(329, 429);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 40);
            this.panel2.TabIndex = 25;
            // 
            // btnCancle
            // 
            this.btnCancle.BackColor = System.Drawing.Color.Gray;
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancle.ForeColor = System.Drawing.Color.White;
            this.btnCancle.Location = new System.Drawing.Point(84, 4);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 34);
            this.btnCancle.TabIndex = 18;
            this.btnCancle.Text = "취소";
            this.btnCancle.UseVisualStyleBackColor = false;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(79)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 34);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "저장";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(735, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(35, 35);
            this.panel3.TabIndex = 27;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::Team6_UMB.Properties.Resources.Close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(3, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(29, 23);
            this.btnClose.TabIndex = 22;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // newBtns1
            // 
            this.newBtns1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(79)))));
            this.newBtns1.Dock = System.Windows.Forms.DockStyle.Right;
            this.newBtns1.Location = new System.Drawing.Point(-35, 0);
            this.newBtns1.Name = "newBtns1";
            this.newBtns1.Size = new System.Drawing.Size(770, 35);
            this.newBtns1.TabIndex = 28;
            this.newBtns1.btnShipment_Event += new System.EventHandler(this.newBtns1_btnShipment_Event);
            this.newBtns1.btnDocument_Event += new System.EventHandler(this.newBtns1_btnDocument_Event);
            this.newBtns1.btnRefresh_Event += new System.EventHandler(this.newBtns1_btnRefresh_Event);
            // 
            // frmProdInspPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(794, 477);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv_CheckList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProdInspPopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmProdInspPopUp_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dgv_CheckList, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CheckList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DGV_Custom dgv_CheckList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnEdit;
        private Controls.NewBtns newBtns1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 구성품ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 양품ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 불량ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 포장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 양품ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 불량ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 비고ToolStripMenuItem;
    }
}

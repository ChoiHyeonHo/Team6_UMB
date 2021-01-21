
namespace Team6_UMB.Forms.ASB
{
    partial class frmWarehouse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAllButtons1 = new Team6_UMB.Controls.btnAllButtons();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPrice = new Team6_UMB.DGV_Custom();
            this.company_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company_ceo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company_cnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company_btype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company_gtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company_email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company_fax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company_bnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company_uadmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company_udate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1511, 50);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::Team6_UMB.Properties.Resources.Search;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1083, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 30);
            this.button1.TabIndex = 21;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.Location = new System.Drawing.Point(63, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 24);
            this.textBox1.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(10, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "부서명";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(79)))));
            this.panel1.Controls.Add(this.btnAllButtons1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1511, 35);
            this.panel1.TabIndex = 28;
            // 
            // btnAllButtons1
            // 
            this.btnAllButtons1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(79)))));
            this.btnAllButtons1.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnAllButtons1.Location = new System.Drawing.Point(1134, 0);
            this.btnAllButtons1.Name = "btnAllButtons1";
            this.btnAllButtons1.Size = new System.Drawing.Size(377, 35);
            this.btnAllButtons1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "창고관리";
            // 
            // dgvPrice
            // 
            this.dgvPrice.BackgroundColor = System.Drawing.Color.White;
            this.dgvPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.company_id,
            this.company_name,
            this.company_type,
            this.company_ceo,
            this.company_cnum,
            this.company_btype,
            this.company_gtype,
            this.company_email,
            this.company_phone,
            this.company_fax,
            this.company_bnum,
            this.company_address,
            this.company_uadmin,
            this.company_udate});
            this.dgvPrice.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dgvPrice.GridColor = System.Drawing.Color.LightGray;
            this.dgvPrice.Location = new System.Drawing.Point(11, 107);
            this.dgvPrice.Margin = new System.Windows.Forms.Padding(4, 1, 4, 1);
            this.dgvPrice.MinimumSize = new System.Drawing.Size(150, 150);
            this.dgvPrice.Name = "dgvPrice";
            this.dgvPrice.RowTemplate.Height = 23;
            this.dgvPrice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPrice.Size = new System.Drawing.Size(1511, 829);
            this.dgvPrice.TabIndex = 30;
            // 
            // company_id
            // 
            this.company_id.HeaderText = "업체ID";
            this.company_id.Name = "company_id";
            // 
            // company_name
            // 
            this.company_name.HeaderText = "업체명";
            this.company_name.Name = "company_name";
            // 
            // company_type
            // 
            this.company_type.HeaderText = "업체구분";
            this.company_type.Name = "company_type";
            // 
            // company_ceo
            // 
            this.company_ceo.HeaderText = "대표자명";
            this.company_ceo.Name = "company_ceo";
            // 
            // company_cnum
            // 
            this.company_cnum.HeaderText = "사업자등록번호";
            this.company_cnum.Name = "company_cnum";
            // 
            // company_btype
            // 
            this.company_btype.HeaderText = "업종";
            this.company_btype.Name = "company_btype";
            // 
            // company_gtype
            // 
            this.company_gtype.HeaderText = "업태";
            this.company_gtype.Name = "company_gtype";
            // 
            // company_email
            // 
            this.company_email.HeaderText = "이메일";
            this.company_email.Name = "company_email";
            // 
            // company_phone
            // 
            this.company_phone.HeaderText = "전화번호";
            this.company_phone.Name = "company_phone";
            // 
            // company_fax
            // 
            this.company_fax.HeaderText = "팩스";
            this.company_fax.Name = "company_fax";
            // 
            // company_bnum
            // 
            this.company_bnum.HeaderText = "법인등록번호";
            this.company_bnum.Name = "company_bnum";
            // 
            // company_address
            // 
            this.company_address.HeaderText = "업체 주소";
            this.company_address.Name = "company_address";
            // 
            // company_uadmin
            // 
            this.company_uadmin.HeaderText = "수정자";
            this.company_uadmin.Name = "company_uadmin";
            // 
            // company_udate
            // 
            this.company_udate.HeaderText = "수정일";
            this.company_udate.Name = "company_udate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(278, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 18);
            this.label4.TabIndex = 24;
            this.label4.Text = "사업자등록번호";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox2.Location = new System.Drawing.Point(383, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(164, 24);
            this.textBox2.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(584, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 18);
            this.label5.TabIndex = 26;
            this.label5.Text = "업체코드";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox3.Location = new System.Drawing.Point(650, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(164, 24);
            this.textBox3.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(841, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 28;
            this.label2.Text = "업체코드";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(907, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 29;
            // 
            // frmWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1503, 872);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvPrice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmWarehouse";
            this.Text = "frmWarehouse";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrice)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Panel panel1;
        private Controls.btnAllButtons btnAllButtons1;
        protected System.Windows.Forms.Label label1;
        private DGV_Custom dgvPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_type;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_ceo;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_cnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_btype;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_gtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_email;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_fax;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_bnum;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_address;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_uadmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn company_udate;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
    }
}
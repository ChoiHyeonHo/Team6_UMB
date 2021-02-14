
namespace UMB_POP
{
    partial class frmPOP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPOP));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lbl1 = new System.Windows.Forms.Label();
            this.dtpstart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpend = new System.Windows.Forms.DateTimePicker();
            this.TabDGV = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvWaitWork = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvWorking = new System.Windows.Forms.DataGridView();
            this.Column20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvEndWork = new System.Windows.Forms.DataGridView();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.txtcount = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cboProcessname = new System.Windows.Forms.ComboBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lb_time = new System.Windows.Forms.Label();
            this.SystemTimer = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.TabDGV.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaitWork)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorking)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEndWork)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "cancel.png");
            this.imageList1.Images.SetKeyName(1, "ChangeUser.png");
            this.imageList1.Images.SetKeyName(2, "checked.png");
            this.imageList1.Images.SetKeyName(3, "Close.png");
            this.imageList1.Images.SetKeyName(4, "Create.png");
            this.imageList1.Images.SetKeyName(5, "delete.png");
            this.imageList1.Images.SetKeyName(6, "erase.png");
            this.imageList1.Images.SetKeyName(7, "Excel.png");
            this.imageList1.Images.SetKeyName(8, "Gear.png");
            this.imageList1.Images.SetKeyName(9, "Logo_Black.png");
            this.imageList1.Images.SetKeyName(10, "Logo_White.png");
            this.imageList1.Images.SetKeyName(11, "Maximize.png");
            this.imageList1.Images.SetKeyName(12, "Minimize.png");
            this.imageList1.Images.SetKeyName(13, "Password.png");
            this.imageList1.Images.SetKeyName(14, "Print.png");
            this.imageList1.Images.SetKeyName(15, "question.png");
            this.imageList1.Images.SetKeyName(16, "Search.png");
            this.imageList1.Images.SetKeyName(17, "SearchWhite.png");
            this.imageList1.Images.SetKeyName(18, "umbrella.png");
            this.imageList1.Images.SetKeyName(19, "UserIcon.png");
            this.imageList1.Images.SetKeyName(20, "Search.png");
            this.imageList1.Images.SetKeyName(21, "Printer_32x32.png");
            this.imageList1.Images.SetKeyName(22, "SaveTo_32x32.png");
            this.imageList1.Images.SetKeyName(23, "Zoom_32x32.png");
            this.imageList1.Images.SetKeyName(24, "화면 캡처 2021-01-21 142102.jpg");
            this.imageList1.Images.SetKeyName(25, "화면 캡처 2021-01-21 142111.jpg");
            this.imageList1.Images.SetKeyName(26, "화면 캡처 2021-01-21 142355.jpg");
            this.imageList1.Images.SetKeyName(27, "화면 캡처 2021-01-21 150003.jpg");
            this.imageList1.Images.SetKeyName(28, "화면 캡처 2021-01-21 150013.jpg");
            this.imageList1.Images.SetKeyName(29, "green-size.png");
            this.imageList1.Images.SetKeyName(30, "red-size.png");
            // 
            // lbl1
            // 
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl1.ForeColor = System.Drawing.Color.White;
            this.lbl1.Location = new System.Drawing.Point(12, 9);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(184, 23);
            this.lbl1.TabIndex = 3;
            this.lbl1.Text = "구디우산 완제품공장";
            // 
            // dtpstart
            // 
            this.dtpstart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpstart.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpstart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpstart.Location = new System.Drawing.Point(227, 62);
            this.dtpstart.Name = "dtpstart";
            this.dtpstart.Size = new System.Drawing.Size(167, 38);
            this.dtpstart.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(54, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "조회일자";
            // 
            // dtpend
            // 
            this.dtpend.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpend.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpend.Location = new System.Drawing.Point(409, 62);
            this.dtpend.Name = "dtpend";
            this.dtpend.Size = new System.Drawing.Size(167, 38);
            this.dtpend.TabIndex = 4;
            // 
            // TabDGV
            // 
            this.TabDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabDGV.Controls.Add(this.tabPage1);
            this.TabDGV.Controls.Add(this.tabPage2);
            this.TabDGV.Controls.Add(this.tabPage3);
            this.TabDGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.TabDGV.Location = new System.Drawing.Point(10, 136);
            this.TabDGV.Name = "TabDGV";
            this.TabDGV.SelectedIndex = 0;
            this.TabDGV.Size = new System.Drawing.Size(1871, 582);
            this.TabDGV.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvWaitWork);
            this.tabPage1.Location = new System.Drawing.Point(4, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1863, 538);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "작업대기";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvWaitWork
            // 
            this.dgvWaitWork.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWaitWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWaitWork.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dgvWaitWork.Location = new System.Drawing.Point(3, 3);
            this.dgvWaitWork.Name = "dgvWaitWork";
            this.dgvWaitWork.RowTemplate.Height = 23;
            this.dgvWaitWork.Size = new System.Drawing.Size(1857, 532);
            this.dgvWaitWork.TabIndex = 32;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "작업지시번호";
            this.Column5.Name = "Column5";
            this.Column5.Width = 200;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "거래처명";
            this.Column6.Name = "Column6";
            this.Column6.Width = 200;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "품번";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "품명";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "지시수량";
            this.Column9.Name = "Column9";
            this.Column9.Width = 200;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvWorking);
            this.tabPage2.Location = new System.Drawing.Point(4, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1863, 538);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "작업진행중";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvWorking
            // 
            this.dgvWorking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column20,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column10,
            this.Column11,
            this.Column12});
            this.dgvWorking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorking.Location = new System.Drawing.Point(3, 3);
            this.dgvWorking.Name = "dgvWorking";
            this.dgvWorking.RowTemplate.Height = 23;
            this.dgvWorking.Size = new System.Drawing.Size(1857, 532);
            this.dgvWorking.TabIndex = 0;
            // 
            // Column20
            // 
            this.Column20.HeaderText = "작업지시번호";
            this.Column20.Name = "Column20";
            this.Column20.Width = 200;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "거래처명";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "품번";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "품명";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "지시수량";
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "생산수량";
            this.Column10.Name = "Column10";
            this.Column10.Width = 150;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "양품수량";
            this.Column11.Name = "Column11";
            this.Column11.Width = 150;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "불량수량";
            this.Column12.Name = "Column12";
            this.Column12.Width = 150;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvEndWork);
            this.tabPage3.Location = new System.Drawing.Point(4, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1863, 538);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "작업종료";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvEndWork
            // 
            this.dgvEndWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEndWork.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column21,
            this.Column13,
            this.Column14,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Column18,
            this.Column19});
            this.dgvEndWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEndWork.Location = new System.Drawing.Point(3, 3);
            this.dgvEndWork.Name = "dgvEndWork";
            this.dgvEndWork.RowTemplate.Height = 23;
            this.dgvEndWork.Size = new System.Drawing.Size(1857, 532);
            this.dgvEndWork.TabIndex = 0;
            // 
            // Column21
            // 
            this.Column21.HeaderText = "작업지시번호";
            this.Column21.Name = "Column21";
            this.Column21.Width = 200;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "거래처명";
            this.Column13.Name = "Column13";
            this.Column13.Width = 150;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "품번";
            this.Column14.Name = "Column14";
            // 
            // Column15
            // 
            this.Column15.HeaderText = "품명";
            this.Column15.Name = "Column15";
            // 
            // Column16
            // 
            this.Column16.HeaderText = "양품수량";
            this.Column16.Name = "Column16";
            this.Column16.Width = 150;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "불량수량";
            this.Column17.Name = "Column17";
            this.Column17.Width = 150;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "시작시간";
            this.Column18.Name = "Column18";
            this.Column18.Width = 150;
            // 
            // Column19
            // 
            this.Column19.HeaderText = "종료시간";
            this.Column19.Name = "Column19";
            this.Column19.Width = 150;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1365, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 43);
            this.label3.TabIndex = 6;
            this.label3.Text = "양품수량";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.MidnightBlue;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(425, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 43);
            this.label4.TabIndex = 6;
            this.label4.Text = "설비명";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.MidnightBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(425, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 43);
            this.label5.TabIndex = 6;
            this.label5.Text = "공정명";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.MidnightBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(17, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 43);
            this.label6.TabIndex = 6;
            this.label6.Text = "품번";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.MidnightBlue;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(17, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 43);
            this.label7.TabIndex = 6;
            this.label7.Text = "품명";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(1365, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 43);
            this.label8.TabIndex = 6;
            this.label8.Text = "불량수량";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(857, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(149, 43);
            this.label9.TabIndex = 6;
            this.label9.Text = "지시수량";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtProductName.Enabled = false;
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProductName.Location = new System.Drawing.Point(141, 91);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(260, 40);
            this.txtProductName.TabIndex = 7;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox3.Location = new System.Drawing.Point(1537, 35);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(293, 40);
            this.textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox4.Location = new System.Drawing.Point(1537, 92);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(293, 40);
            this.textBox4.TabIndex = 7;
            // 
            // txtMachineName
            // 
            this.txtMachineName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtMachineName.Enabled = false;
            this.txtMachineName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMachineName.Location = new System.Drawing.Point(547, 36);
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Size = new System.Drawing.Size(290, 40);
            this.txtMachineName.TabIndex = 7;
            // 
            // txtProcessName
            // 
            this.txtProcessName.BackColor = System.Drawing.Color.Gainsboro;
            this.txtProcessName.Enabled = false;
            this.txtProcessName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProcessName.Location = new System.Drawing.Point(547, 93);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(290, 40);
            this.txtProcessName.TabIndex = 7;
            // 
            // txtcount
            // 
            this.txtcount.BackColor = System.Drawing.Color.Gainsboro;
            this.txtcount.Enabled = false;
            this.txtcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtcount.Location = new System.Drawing.Point(1012, 36);
            this.txtcount.Name = "txtcount";
            this.txtcount.Size = new System.Drawing.Size(335, 40);
            this.txtcount.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtProcessName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox10);
            this.groupBox1.Controls.Add(this.txtcount);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMachineName);
            this.groupBox1.Controls.Add(this.txtProductID);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(6, 724);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1875, 166);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.Gainsboro;
            this.textBox10.Enabled = false;
            this.textBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox10.Location = new System.Drawing.Point(1012, 93);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(335, 40);
            this.textBox10.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(857, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(149, 43);
            this.label10.TabIndex = 6;
            this.label10.Text = "생산수량";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtProductID
            // 
            this.txtProductID.BackColor = System.Drawing.Color.Gainsboro;
            this.txtProductID.Enabled = false;
            this.txtProductID.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProductID.Location = new System.Drawing.Point(141, 34);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(260, 40);
            this.txtProductID.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageKey = "화면 캡처 2021-01-21 142355.jpg";
            this.button1.ImageList = this.imageList1;
            this.button1.Location = new System.Drawing.Point(623, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 48);
            this.button1.TabIndex = 2;
            this.button1.Text = "조회";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "green-size.png");
            this.imageList2.Images.SetKeyName(1, "red-size11.png");
            this.imageList2.Images.SetKeyName(2, "불량.png");
            this.imageList2.Images.SetKeyName(3, "ZZZZZZZZZ.png");
            this.imageList2.Images.SetKeyName(4, "green-sizeFINAL.png");
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.ImageKey = "green-sizeFINAL.png";
            this.button2.ImageList = this.imageList2;
            this.button2.Location = new System.Drawing.Point(6, 896);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(621, 94);
            this.button2.TabIndex = 10;
            this.button2.Text = "작업시작";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.ImageKey = "red-size11.png";
            this.button3.ImageList = this.imageList2;
            this.button3.Location = new System.Drawing.Point(633, 896);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(621, 94);
            this.button3.TabIndex = 10;
            this.button3.Text = "작업종료";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold);
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.ImageKey = "ZZZZZZZZZ.png";
            this.button7.ImageList = this.imageList2;
            this.button7.Location = new System.Drawing.Point(1260, 896);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(621, 94);
            this.button7.TabIndex = 10;
            this.button7.Text = "불량처리";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(935, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 42);
            this.label11.TabIndex = 0;
            this.label11.Text = "공 정";
            // 
            // cboProcessname
            // 
            this.cboProcessname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProcessname.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold);
            this.cboProcessname.FormattingEnabled = true;
            this.cboProcessname.Location = new System.Drawing.Point(1030, 59);
            this.cboProcessname.Name = "cboProcessname";
            this.cboProcessname.Size = new System.Drawing.Size(205, 41);
            this.cboProcessname.TabIndex = 8;
            // 
            // lblUser
            // 
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(212, 9);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(184, 23);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "작업자 : 안성빈";
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lb_time.ForeColor = System.Drawing.Color.White;
            this.lb_time.Location = new System.Drawing.Point(1629, 9);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(224, 24);
            this.lb_time.TabIndex = 11;
            this.lb_time.Text = "yyyy-MM-dd  hh:mm:ss";
            // 
            // SystemTimer
            // 
            this.SystemTimer.Tick += new System.EventHandler(this.SystemTimer_Tick);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.ImageKey = "화면 캡처 2021-01-21 142355.jpg";
            this.button4.ImageList = this.imageList1;
            this.button4.Location = new System.Drawing.Point(1271, 57);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(132, 48);
            this.button4.TabIndex = 12;
            this.button4.Text = "조회";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // frmPOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(1888, 1002);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lb_time);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.cboProcessname);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TabDGV);
            this.Controls.Add(this.dtpend);
            this.Controls.Add(this.dtpstart);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPOP";
            this.Text = "pop";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TabDGV.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaitWork)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorking)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEndWork)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.DateTimePicker dtpstart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpend;
        private System.Windows.Forms.TabControl TabDGV;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvWorking;
        private System.Windows.Forms.DataGridView dgvEndWork;
        private System.Windows.Forms.DataGridView dgvWaitWork;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txtMachineName;
        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.TextBox txtcount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboProcessname;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lb_time;
        private System.Windows.Forms.Timer SystemTimer;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column20;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.Button button4;
    }
}


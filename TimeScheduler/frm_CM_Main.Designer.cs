namespace TimeScheduler
{
    partial class frm_CM_Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.ScheduleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScheduleCycle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScheduleDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScheduleDayOfWeek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScheduleTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScheduleMinute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScheduleCompleted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.gbInform = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tbScheduleDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSchedule_Minute = new System.Windows.Forms.Label();
            this.lblMinutes_Chng = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbScheduleName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHours_Chng = new System.Windows.Forms.Label();
            this.lblSchedule_Time = new System.Windows.Forms.Label();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.rbSchedule_Every = new System.Windows.Forms.RadioButton();
            this.rbSchedule_Once = new System.Windows.Forms.RadioButton();
            this.cbSchedule_Completed = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.cbSchedule_Sun = new System.Windows.Forms.CheckBox();
            this.cbSchedule_Wed = new System.Windows.Forms.CheckBox();
            this.cbSchedule_Tue = new System.Windows.Forms.CheckBox();
            this.cbSchedule_Mon = new System.Windows.Forms.CheckBox();
            this.cbSchedule_Sat = new System.Windows.Forms.CheckBox();
            this.cbSchedule_Fri = new System.Windows.Forms.CheckBox();
            this.cbSchedule_Thu = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnToggleDaemon = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblWorkDate = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbWaitLatency = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblRecogCnt = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeleteCompleted = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.gbInform.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.dgvList, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1232, 622);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("맑은 고딕", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScheduleName,
            this.ScheduleCycle,
            this.ScheduleDate,
            this.ScheduleDayOfWeek,
            this.ScheduleTime,
            this.ScheduleMinute,
            this.ScheduleCompleted});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Location = new System.Drawing.Point(66, 4);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.ReadOnly = true;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(792, 614);
            this.dgvList.TabIndex = 0;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // ScheduleName
            // 
            this.ScheduleName.FillWeight = 99.49239F;
            this.ScheduleName.HeaderText = "일정명";
            this.ScheduleName.Name = "ScheduleName";
            this.ScheduleName.ReadOnly = true;
            // 
            // ScheduleCycle
            // 
            this.ScheduleCycle.FillWeight = 101.5228F;
            this.ScheduleCycle.HeaderText = "주기";
            this.ScheduleCycle.Name = "ScheduleCycle";
            this.ScheduleCycle.ReadOnly = true;
            // 
            // ScheduleDate
            // 
            this.ScheduleDate.HeaderText = "날짜";
            this.ScheduleDate.Name = "ScheduleDate";
            this.ScheduleDate.ReadOnly = true;
            // 
            // ScheduleDayOfWeek
            // 
            this.ScheduleDayOfWeek.FillWeight = 99.49239F;
            this.ScheduleDayOfWeek.HeaderText = "요일";
            this.ScheduleDayOfWeek.Name = "ScheduleDayOfWeek";
            this.ScheduleDayOfWeek.ReadOnly = true;
            // 
            // ScheduleTime
            // 
            this.ScheduleTime.HeaderText = "시간";
            this.ScheduleTime.Name = "ScheduleTime";
            this.ScheduleTime.ReadOnly = true;
            // 
            // ScheduleMinute
            // 
            this.ScheduleMinute.HeaderText = "분";
            this.ScheduleMinute.Name = "ScheduleMinute";
            this.ScheduleMinute.ReadOnly = true;
            // 
            // ScheduleCompleted
            // 
            this.ScheduleCompleted.FillWeight = 99.49239F;
            this.ScheduleCompleted.HeaderText = "완료 여부";
            this.ScheduleCompleted.Name = "ScheduleCompleted";
            this.ScheduleCompleted.ReadOnly = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.gbInform, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(865, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(363, 614);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // gbInform
            // 
            this.gbInform.Controls.Add(this.tableLayoutPanel3);
            this.gbInform.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInform.Location = new System.Drawing.Point(4, 4);
            this.gbInform.Name = "gbInform";
            this.gbInform.Size = new System.Drawing.Size(355, 360);
            this.gbInform.TabIndex = 0;
            this.gbInform.TabStop = false;
            this.gbInform.Text = "정보";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.Controls.Add(this.tbScheduleDate, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.label11, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tbScheduleName, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel7, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.cbSchedule_Completed, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel8, 1, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.10154F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.10154F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.48939F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.18616F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.48939F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.48939F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.14258F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(349, 336);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tbScheduleDate
            // 
            this.tbScheduleDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbScheduleDate.Location = new System.Drawing.Point(108, 44);
            this.tbScheduleDate.Multiline = true;
            this.tbScheduleDate.Name = "tbScheduleDate";
            this.tbScheduleDate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbScheduleDate.Size = new System.Drawing.Size(237, 33);
            this.tbScheduleDate.TabIndex = 2;
            this.tbScheduleDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(4, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "날짜";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.Controls.Add(this.lblSchedule_Minute, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblMinutes_Chng, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(108, 253);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(237, 41);
            this.tableLayoutPanel5.TabIndex = 19;
            // 
            // lblSchedule_Minute
            // 
            this.lblSchedule_Minute.AutoSize = true;
            this.lblSchedule_Minute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSchedule_Minute.Location = new System.Drawing.Point(4, 1);
            this.lblSchedule_Minute.Name = "lblSchedule_Minute";
            this.lblSchedule_Minute.Size = new System.Drawing.Size(157, 39);
            this.lblSchedule_Minute.TabIndex = 6;
            this.lblSchedule_Minute.Text = "00";
            this.lblSchedule_Minute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinutes_Chng
            // 
            this.lblMinutes_Chng.AutoSize = true;
            this.lblMinutes_Chng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinutes_Chng.Location = new System.Drawing.Point(168, 1);
            this.lblMinutes_Chng.Name = "lblMinutes_Chng";
            this.lblMinutes_Chng.Size = new System.Drawing.Size(65, 39);
            this.lblMinutes_Chng.TabIndex = 8;
            this.lblMinutes_Chng.Text = "변경";
            this.lblMinutes_Chng.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMinutes_Chng.Click += new System.EventHandler(this.lblMinutes_Chng_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(4, 298);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 37);
            this.label11.TabIndex = 11;
            this.label11.Text = "완료여부";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(4, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 47);
            this.label9.TabIndex = 9;
            this.label9.Text = "분";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(4, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 47);
            this.label7.TabIndex = 7;
            this.label7.Text = "시간";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(4, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 72);
            this.label5.TabIndex = 5;
            this.label5.Text = "요일";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(4, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 47);
            this.label3.TabIndex = 2;
            this.label3.Text = "주기";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "일정명";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbScheduleName
            // 
            this.tbScheduleName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbScheduleName.Location = new System.Drawing.Point(108, 4);
            this.tbScheduleName.Multiline = true;
            this.tbScheduleName.Name = "tbScheduleName";
            this.tbScheduleName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbScheduleName.Size = new System.Drawing.Size(237, 33);
            this.tbScheduleName.TabIndex = 1;
            this.tbScheduleName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.Controls.Add(this.lblHours_Chng, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblSchedule_Time, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(108, 205);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(237, 41);
            this.tableLayoutPanel4.TabIndex = 18;
            // 
            // lblHours_Chng
            // 
            this.lblHours_Chng.AutoSize = true;
            this.lblHours_Chng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHours_Chng.Location = new System.Drawing.Point(168, 1);
            this.lblHours_Chng.Name = "lblHours_Chng";
            this.lblHours_Chng.Size = new System.Drawing.Size(65, 39);
            this.lblHours_Chng.TabIndex = 8;
            this.lblHours_Chng.Text = "변경";
            this.lblHours_Chng.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHours_Chng.Click += new System.EventHandler(this.lblHours_Chng_Click);
            // 
            // lblSchedule_Time
            // 
            this.lblSchedule_Time.AutoSize = true;
            this.lblSchedule_Time.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSchedule_Time.Location = new System.Drawing.Point(4, 1);
            this.lblSchedule_Time.Name = "lblSchedule_Time";
            this.lblSchedule_Time.Size = new System.Drawing.Size(157, 39);
            this.lblSchedule_Time.TabIndex = 5;
            this.lblSchedule_Time.Text = "00";
            this.lblSchedule_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.rbSchedule_Every, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.rbSchedule_Once, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(108, 84);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(237, 41);
            this.tableLayoutPanel7.TabIndex = 20;
            // 
            // rbSchedule_Every
            // 
            this.rbSchedule_Every.AutoSize = true;
            this.rbSchedule_Every.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbSchedule_Every.Location = new System.Drawing.Point(122, 4);
            this.rbSchedule_Every.Name = "rbSchedule_Every";
            this.rbSchedule_Every.Size = new System.Drawing.Size(111, 33);
            this.rbSchedule_Every.TabIndex = 4;
            this.rbSchedule_Every.TabStop = true;
            this.rbSchedule_Every.Text = "매주";
            this.rbSchedule_Every.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbSchedule_Every.UseVisualStyleBackColor = true;
            this.rbSchedule_Every.CheckedChanged += new System.EventHandler(this.rbSchedule_Every_CheckedChanged);
            // 
            // rbSchedule_Once
            // 
            this.rbSchedule_Once.AutoSize = true;
            this.rbSchedule_Once.Checked = true;
            this.rbSchedule_Once.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbSchedule_Once.Location = new System.Drawing.Point(4, 4);
            this.rbSchedule_Once.Name = "rbSchedule_Once";
            this.rbSchedule_Once.Size = new System.Drawing.Size(111, 33);
            this.rbSchedule_Once.TabIndex = 3;
            this.rbSchedule_Once.TabStop = true;
            this.rbSchedule_Once.Text = "한번만";
            this.rbSchedule_Once.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbSchedule_Once.UseVisualStyleBackColor = true;
            this.rbSchedule_Once.CheckedChanged += new System.EventHandler(this.rbSchedule_Once_CheckedChanged);
            // 
            // cbSchedule_Completed
            // 
            this.cbSchedule_Completed.AutoSize = true;
            this.cbSchedule_Completed.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSchedule_Completed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSchedule_Completed.Location = new System.Drawing.Point(108, 301);
            this.cbSchedule_Completed.Name = "cbSchedule_Completed";
            this.cbSchedule_Completed.Size = new System.Drawing.Size(237, 31);
            this.cbSchedule_Completed.TabIndex = 22;
            this.cbSchedule_Completed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSchedule_Completed.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel8.ColumnCount = 7;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel8.Controls.Add(this.cbSchedule_Sun, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.cbSchedule_Wed, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.cbSchedule_Tue, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.cbSchedule_Mon, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.cbSchedule_Sat, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.cbSchedule_Fri, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.cbSchedule_Thu, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.label8, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.label10, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.label12, 4, 0);
            this.tableLayoutPanel8.Controls.Add(this.label13, 3, 0);
            this.tableLayoutPanel8.Controls.Add(this.label15, 6, 0);
            this.tableLayoutPanel8.Controls.Add(this.label14, 5, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(108, 132);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(237, 66);
            this.tableLayoutPanel8.TabIndex = 23;
            // 
            // cbSchedule_Sun
            // 
            this.cbSchedule_Sun.AutoSize = true;
            this.cbSchedule_Sun.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSchedule_Sun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSchedule_Sun.Location = new System.Drawing.Point(4, 36);
            this.cbSchedule_Sun.Name = "cbSchedule_Sun";
            this.cbSchedule_Sun.Size = new System.Drawing.Size(26, 26);
            this.cbSchedule_Sun.TabIndex = 29;
            this.cbSchedule_Sun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSchedule_Sun.UseVisualStyleBackColor = true;
            // 
            // cbSchedule_Wed
            // 
            this.cbSchedule_Wed.AutoSize = true;
            this.cbSchedule_Wed.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSchedule_Wed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSchedule_Wed.Location = new System.Drawing.Point(103, 36);
            this.cbSchedule_Wed.Name = "cbSchedule_Wed";
            this.cbSchedule_Wed.Size = new System.Drawing.Size(26, 26);
            this.cbSchedule_Wed.TabIndex = 28;
            this.cbSchedule_Wed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSchedule_Wed.UseVisualStyleBackColor = true;
            // 
            // cbSchedule_Tue
            // 
            this.cbSchedule_Tue.AutoSize = true;
            this.cbSchedule_Tue.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSchedule_Tue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSchedule_Tue.Location = new System.Drawing.Point(70, 36);
            this.cbSchedule_Tue.Name = "cbSchedule_Tue";
            this.cbSchedule_Tue.Size = new System.Drawing.Size(26, 26);
            this.cbSchedule_Tue.TabIndex = 27;
            this.cbSchedule_Tue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSchedule_Tue.UseVisualStyleBackColor = true;
            // 
            // cbSchedule_Mon
            // 
            this.cbSchedule_Mon.AutoSize = true;
            this.cbSchedule_Mon.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSchedule_Mon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSchedule_Mon.Location = new System.Drawing.Point(37, 36);
            this.cbSchedule_Mon.Name = "cbSchedule_Mon";
            this.cbSchedule_Mon.Size = new System.Drawing.Size(26, 26);
            this.cbSchedule_Mon.TabIndex = 26;
            this.cbSchedule_Mon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSchedule_Mon.UseVisualStyleBackColor = true;
            // 
            // cbSchedule_Sat
            // 
            this.cbSchedule_Sat.AutoSize = true;
            this.cbSchedule_Sat.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSchedule_Sat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSchedule_Sat.Location = new System.Drawing.Point(202, 36);
            this.cbSchedule_Sat.Name = "cbSchedule_Sat";
            this.cbSchedule_Sat.Size = new System.Drawing.Size(31, 26);
            this.cbSchedule_Sat.TabIndex = 25;
            this.cbSchedule_Sat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSchedule_Sat.UseVisualStyleBackColor = true;
            // 
            // cbSchedule_Fri
            // 
            this.cbSchedule_Fri.AutoSize = true;
            this.cbSchedule_Fri.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSchedule_Fri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSchedule_Fri.Location = new System.Drawing.Point(169, 36);
            this.cbSchedule_Fri.Name = "cbSchedule_Fri";
            this.cbSchedule_Fri.Size = new System.Drawing.Size(26, 26);
            this.cbSchedule_Fri.TabIndex = 24;
            this.cbSchedule_Fri.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSchedule_Fri.UseVisualStyleBackColor = true;
            // 
            // cbSchedule_Thu
            // 
            this.cbSchedule_Thu.AutoSize = true;
            this.cbSchedule_Thu.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSchedule_Thu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSchedule_Thu.Location = new System.Drawing.Point(136, 36);
            this.cbSchedule_Thu.Name = "cbSchedule_Thu";
            this.cbSchedule_Thu.Size = new System.Drawing.Size(26, 26);
            this.cbSchedule_Thu.TabIndex = 23;
            this.cbSchedule_Thu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbSchedule_Thu.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(4, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 31);
            this.label6.TabIndex = 8;
            this.label6.Text = "일";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(37, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 31);
            this.label8.TabIndex = 9;
            this.label8.Text = "월";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(70, 1);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 31);
            this.label10.TabIndex = 10;
            this.label10.Text = "화";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(136, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(26, 31);
            this.label12.TabIndex = 11;
            this.label12.Text = "목";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(103, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 31);
            this.label13.TabIndex = 12;
            this.label13.Text = "수";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.ForeColor = System.Drawing.Color.Blue;
            this.label15.Location = new System.Drawing.Point(202, 1);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 31);
            this.label15.TabIndex = 14;
            this.label15.Text = "토";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(169, 1);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 31);
            this.label14.TabIndex = 13;
            this.label14.Text = "금";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel6.ColumnCount = 5;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.Controls.Add(this.btnAdd, 3, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnDelete, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnModify, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnReset, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnToggleDaemon, 4, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(4, 555);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(355, 55);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(214, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(63, 47);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "등록";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(74, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(63, 47);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnModify
            // 
            this.btnModify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModify.Location = new System.Drawing.Point(144, 4);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(63, 47);
            this.btnModify.TabIndex = 1;
            this.btnModify.Text = "수정";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnReset
            // 
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(4, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(63, 47);
            this.btnReset.TabIndex = 0;
            this.btnReset.Text = "초기화";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnToggleDaemon
            // 
            this.btnToggleDaemon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnToggleDaemon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleDaemon.Location = new System.Drawing.Point(284, 4);
            this.btnToggleDaemon.Name = "btnToggleDaemon";
            this.btnToggleDaemon.Size = new System.Drawing.Size(67, 47);
            this.btnToggleDaemon.TabIndex = 5;
            this.btnToggleDaemon.Text = "실행";
            this.btnToggleDaemon.UseVisualStyleBackColor = true;
            this.btnToggleDaemon.Click += new System.EventHandler(this.btnToggleDaemon_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel9);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 371);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 177);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "실행 설정";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel9.Controls.Add(this.lblStatus, 1, 3);
            this.tableLayoutPanel9.Controls.Add(this.label18, 0, 3);
            this.tableLayoutPanel9.Controls.Add(this.lblWorkDate, 1, 2);
            this.tableLayoutPanel9.Controls.Add(this.label17, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.tbWaitLatency, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.label16, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.lblRecogCnt, 1, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 4;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(349, 153);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Location = new System.Drawing.Point(108, 122);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(237, 30);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "0";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(4, 122);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 30);
            this.label18.TabIndex = 18;
            this.label18.Text = "Status";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWorkDate
            // 
            this.lblWorkDate.AutoSize = true;
            this.lblWorkDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkDate.Location = new System.Drawing.Point(108, 84);
            this.lblWorkDate.Name = "lblWorkDate";
            this.lblWorkDate.Size = new System.Drawing.Size(237, 37);
            this.lblWorkDate.TabIndex = 17;
            this.lblWorkDate.Text = "0";
            this.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(4, 84);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(97, 37);
            this.label17.TabIndex = 16;
            this.label17.Text = "최근\r\n작동시간";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(4, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 44);
            this.label4.TabIndex = 12;
            this.label4.Text = "조회 주기\r\n(ms)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbWaitLatency
            // 
            this.tbWaitLatency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbWaitLatency.Location = new System.Drawing.Point(108, 4);
            this.tbWaitLatency.Multiline = true;
            this.tbWaitLatency.Name = "tbWaitLatency";
            this.tbWaitLatency.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbWaitLatency.Size = new System.Drawing.Size(237, 38);
            this.tbWaitLatency.TabIndex = 7;
            this.tbWaitLatency.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(4, 46);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(97, 37);
            this.label16.TabIndex = 14;
            this.label16.Text = "인식된\r\n항목 수";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRecogCnt
            // 
            this.lblRecogCnt.AutoSize = true;
            this.lblRecogCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecogCnt.Location = new System.Drawing.Point(108, 46);
            this.lblRecogCnt.Name = "lblRecogCnt";
            this.lblRecogCnt.Size = new System.Drawing.Size(237, 37);
            this.lblRecogCnt.TabIndex = 15;
            this.lblRecogCnt.Text = "0";
            this.lblRecogCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel10);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(55, 614);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "도구";
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.btnDeleteCompleted, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.btnSave, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.btnLoad, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.btnDeleteAll, 0, 3);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 4;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(49, 590);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // btnDeleteCompleted
            // 
            this.btnDeleteCompleted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteCompleted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCompleted.Location = new System.Drawing.Point(4, 4);
            this.btnDeleteCompleted.Name = "btnDeleteCompleted";
            this.btnDeleteCompleted.Size = new System.Drawing.Size(41, 140);
            this.btnDeleteCompleted.TabIndex = 6;
            this.btnDeleteCompleted.Text = "완료삭제";
            this.btnDeleteCompleted.UseVisualStyleBackColor = true;
            this.btnDeleteCompleted.Click += new System.EventHandler(this.btnDeleteCompleted_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(4, 151);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(41, 140);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Location = new System.Drawing.Point(4, 298);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(41, 140);
            this.btnLoad.TabIndex = 8;
            this.btnLoad.Text = "불러오기";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAll.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDeleteAll.ForeColor = System.Drawing.Color.Red;
            this.btnDeleteAll.Location = new System.Drawing.Point(4, 445);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(41, 141);
            this.btnDeleteAll.TabIndex = 9;
            this.btnDeleteAll.Text = "모두삭제";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // frm_CM_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1232, 622);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_CM_Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Scheduler";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_CM_Main_FormClosed);
            this.Load += new System.EventHandler(this.frm_CM_Main_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.gbInform.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox gbInform;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbScheduleName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.RadioButton rbSchedule_Every;
        private System.Windows.Forms.RadioButton rbSchedule_Once;
        private System.Windows.Forms.CheckBox cbSchedule_Completed;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbSchedule_Sun;
        private System.Windows.Forms.CheckBox cbSchedule_Wed;
        private System.Windows.Forms.CheckBox cbSchedule_Tue;
        private System.Windows.Forms.CheckBox cbSchedule_Mon;
        private System.Windows.Forms.CheckBox cbSchedule_Sat;
        private System.Windows.Forms.CheckBox cbSchedule_Fri;
        private System.Windows.Forms.CheckBox cbSchedule_Thu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblSchedule_Minute;
        private System.Windows.Forms.Label lblSchedule_Time;
        private System.Windows.Forms.Label lblMinutes_Chng;
        private System.Windows.Forms.Label lblHours_Chng;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScheduleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScheduleCycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScheduleDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScheduleDayOfWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScheduleTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScheduleMinute;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ScheduleCompleted;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox tbScheduleDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnToggleDaemon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblWorkDate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbWaitLatency;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblRecogCnt;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Button btnDeleteCompleted;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnDeleteAll;
    }
}


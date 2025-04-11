namespace TestPower
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualInputVoltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualOutputVoltage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualOutputCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualOutputPower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualInputPower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualEfficiency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestWaitTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoadCurrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Standard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputVoltageUpperLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputVoltageLowerLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutputVoltageUpperLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutputVoltageLowerLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutputCurrentUpperLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutputCurrentLowerLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutputPowerUpperLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutputPowerLowerLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputPowerUpperLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputPowerLowerLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EfficiencyUpperLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EfficiencyLowerLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputVoltageRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutputVoltageRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutputCurrentRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutputPowerRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputPowerRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EfficiencyRange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new HslControls.HslProgressColorful();
            this.button1 = new HslControls.HslButton();
            this.Button2 = new HslControls.HslButton();
            this.Button3 = new HslControls.HslButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.TestItem,
            this.ActualInputVoltage,
            this.ActualOutputVoltage,
            this.ActualOutputCurrent,
            this.ActualOutputPower,
            this.ActualInputPower,
            this.ActualEfficiency,
            this.TestWaitTime,
            this.LoadCurrent,
            this.Standard,
            this.Status,
            this.InputVoltageUpperLimit,
            this.InputVoltageLowerLimit,
            this.OutputVoltageUpperLimit,
            this.OutputVoltageLowerLimit,
            this.OutputCurrentUpperLimit,
            this.OutputCurrentLowerLimit,
            this.OutputPowerUpperLimit,
            this.OutputPowerLowerLimit,
            this.InputPowerUpperLimit,
            this.InputPowerLowerLimit,
            this.EfficiencyUpperLimit,
            this.EfficiencyLowerLimit,
            this.InputVoltageRange,
            this.OutputVoltageRange,
            this.OutputCurrentRange,
            this.OutputPowerRange,
            this.InputPowerRange,
            this.EfficiencyRange});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(784, 426);
            this.dataGridView1.TabIndex = 3;
            // 
            // Id
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Id.DefaultCellStyle = dataGridViewCellStyle3;
            this.Id.HeaderText = "序列";
            this.Id.MinimumWidth = 20;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 20;
            // 
            // TestItem
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.TestItem.DefaultCellStyle = dataGridViewCellStyle4;
            this.TestItem.HeaderText = "测试项目";
            this.TestItem.MinimumWidth = 6;
            this.TestItem.Name = "TestItem";
            this.TestItem.ReadOnly = true;
            this.TestItem.Width = 120;
            // 
            // ActualInputVoltage
            // 
            this.ActualInputVoltage.HeaderText = "实际输入电压";
            this.ActualInputVoltage.Name = "ActualInputVoltage";
            this.ActualInputVoltage.ReadOnly = true;
            this.ActualInputVoltage.Width = 70;
            // 
            // ActualOutputVoltage
            // 
            this.ActualOutputVoltage.HeaderText = "实际输出电压";
            this.ActualOutputVoltage.Name = "ActualOutputVoltage";
            this.ActualOutputVoltage.ReadOnly = true;
            this.ActualOutputVoltage.Width = 70;
            // 
            // ActualOutputCurrent
            // 
            this.ActualOutputCurrent.HeaderText = "实际输出电流";
            this.ActualOutputCurrent.Name = "ActualOutputCurrent";
            this.ActualOutputCurrent.ReadOnly = true;
            this.ActualOutputCurrent.Width = 70;
            // 
            // ActualOutputPower
            // 
            this.ActualOutputPower.HeaderText = "实际输出功率";
            this.ActualOutputPower.Name = "ActualOutputPower";
            this.ActualOutputPower.ReadOnly = true;
            this.ActualOutputPower.Width = 70;
            // 
            // ActualInputPower
            // 
            this.ActualInputPower.HeaderText = "实际输入功率";
            this.ActualInputPower.Name = "ActualInputPower";
            this.ActualInputPower.ReadOnly = true;
            this.ActualInputPower.Width = 70;
            // 
            // ActualEfficiency
            // 
            this.ActualEfficiency.HeaderText = "实际效率";
            this.ActualEfficiency.Name = "ActualEfficiency";
            this.ActualEfficiency.ReadOnly = true;
            this.ActualEfficiency.Width = 70;
            // 
            // TestWaitTime
            // 
            this.TestWaitTime.HeaderText = "测试等待时间";
            this.TestWaitTime.MinimumWidth = 6;
            this.TestWaitTime.Name = "TestWaitTime";
            this.TestWaitTime.ReadOnly = true;
            this.TestWaitTime.Visible = false;
            this.TestWaitTime.Width = 72;
            // 
            // LoadCurrent
            // 
            this.LoadCurrent.HeaderText = "负载电流";
            this.LoadCurrent.MinimumWidth = 6;
            this.LoadCurrent.Name = "LoadCurrent";
            this.LoadCurrent.ReadOnly = true;
            this.LoadCurrent.Width = 70;
            // 
            // Standard
            // 
            this.Standard.HeaderText = "合格标准";
            this.Standard.MinimumWidth = 6;
            this.Standard.Name = "Standard";
            this.Standard.ReadOnly = true;
            this.Standard.Width = 120;
            // 
            // Status
            // 
            this.Status.HeaderText = "状态";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 80;
            // 
            // InputVoltageUpperLimit
            // 
            this.InputVoltageUpperLimit.HeaderText = "输入电压上限";
            this.InputVoltageUpperLimit.MinimumWidth = 6;
            this.InputVoltageUpperLimit.Name = "InputVoltageUpperLimit";
            this.InputVoltageUpperLimit.ReadOnly = true;
            this.InputVoltageUpperLimit.Visible = false;
            this.InputVoltageUpperLimit.Width = 72;
            // 
            // InputVoltageLowerLimit
            // 
            this.InputVoltageLowerLimit.HeaderText = "输入电压下限";
            this.InputVoltageLowerLimit.MinimumWidth = 6;
            this.InputVoltageLowerLimit.Name = "InputVoltageLowerLimit";
            this.InputVoltageLowerLimit.ReadOnly = true;
            this.InputVoltageLowerLimit.Visible = false;
            this.InputVoltageLowerLimit.Width = 72;
            // 
            // OutputVoltageUpperLimit
            // 
            this.OutputVoltageUpperLimit.HeaderText = "输出电压上限";
            this.OutputVoltageUpperLimit.MinimumWidth = 6;
            this.OutputVoltageUpperLimit.Name = "OutputVoltageUpperLimit";
            this.OutputVoltageUpperLimit.ReadOnly = true;
            this.OutputVoltageUpperLimit.Visible = false;
            this.OutputVoltageUpperLimit.Width = 72;
            // 
            // OutputVoltageLowerLimit
            // 
            this.OutputVoltageLowerLimit.HeaderText = "输出电压下限";
            this.OutputVoltageLowerLimit.MinimumWidth = 6;
            this.OutputVoltageLowerLimit.Name = "OutputVoltageLowerLimit";
            this.OutputVoltageLowerLimit.ReadOnly = true;
            this.OutputVoltageLowerLimit.Visible = false;
            this.OutputVoltageLowerLimit.Width = 72;
            // 
            // OutputCurrentUpperLimit
            // 
            this.OutputCurrentUpperLimit.HeaderText = "输出电流上限";
            this.OutputCurrentUpperLimit.MinimumWidth = 6;
            this.OutputCurrentUpperLimit.Name = "OutputCurrentUpperLimit";
            this.OutputCurrentUpperLimit.ReadOnly = true;
            this.OutputCurrentUpperLimit.Visible = false;
            this.OutputCurrentUpperLimit.Width = 72;
            // 
            // OutputCurrentLowerLimit
            // 
            this.OutputCurrentLowerLimit.HeaderText = "输出电流下限";
            this.OutputCurrentLowerLimit.MinimumWidth = 6;
            this.OutputCurrentLowerLimit.Name = "OutputCurrentLowerLimit";
            this.OutputCurrentLowerLimit.ReadOnly = true;
            this.OutputCurrentLowerLimit.Visible = false;
            this.OutputCurrentLowerLimit.Width = 72;
            // 
            // OutputPowerUpperLimit
            // 
            this.OutputPowerUpperLimit.HeaderText = "输出功率上限";
            this.OutputPowerUpperLimit.MinimumWidth = 6;
            this.OutputPowerUpperLimit.Name = "OutputPowerUpperLimit";
            this.OutputPowerUpperLimit.ReadOnly = true;
            this.OutputPowerUpperLimit.Visible = false;
            this.OutputPowerUpperLimit.Width = 72;
            // 
            // OutputPowerLowerLimit
            // 
            this.OutputPowerLowerLimit.HeaderText = "输出功率下限";
            this.OutputPowerLowerLimit.MinimumWidth = 6;
            this.OutputPowerLowerLimit.Name = "OutputPowerLowerLimit";
            this.OutputPowerLowerLimit.ReadOnly = true;
            this.OutputPowerLowerLimit.Visible = false;
            this.OutputPowerLowerLimit.Width = 72;
            // 
            // InputPowerUpperLimit
            // 
            this.InputPowerUpperLimit.HeaderText = "输入功率上限";
            this.InputPowerUpperLimit.MinimumWidth = 6;
            this.InputPowerUpperLimit.Name = "InputPowerUpperLimit";
            this.InputPowerUpperLimit.ReadOnly = true;
            this.InputPowerUpperLimit.Visible = false;
            this.InputPowerUpperLimit.Width = 72;
            // 
            // InputPowerLowerLimit
            // 
            this.InputPowerLowerLimit.HeaderText = "输入功率下限";
            this.InputPowerLowerLimit.MinimumWidth = 6;
            this.InputPowerLowerLimit.Name = "InputPowerLowerLimit";
            this.InputPowerLowerLimit.ReadOnly = true;
            this.InputPowerLowerLimit.Visible = false;
            this.InputPowerLowerLimit.Width = 72;
            // 
            // EfficiencyUpperLimit
            // 
            this.EfficiencyUpperLimit.HeaderText = "效率上限";
            this.EfficiencyUpperLimit.MinimumWidth = 6;
            this.EfficiencyUpperLimit.Name = "EfficiencyUpperLimit";
            this.EfficiencyUpperLimit.ReadOnly = true;
            this.EfficiencyUpperLimit.Visible = false;
            this.EfficiencyUpperLimit.Width = 70;
            // 
            // EfficiencyLowerLimit
            // 
            this.EfficiencyLowerLimit.HeaderText = "效率下限";
            this.EfficiencyLowerLimit.MinimumWidth = 6;
            this.EfficiencyLowerLimit.Name = "EfficiencyLowerLimit";
            this.EfficiencyLowerLimit.ReadOnly = true;
            this.EfficiencyLowerLimit.Visible = false;
            this.EfficiencyLowerLimit.Width = 70;
            // 
            // InputVoltageRange
            // 
            this.InputVoltageRange.DataPropertyName = "InputVoltageRange";
            this.InputVoltageRange.HeaderText = "输入电压限";
            this.InputVoltageRange.Name = "InputVoltageRange";
            this.InputVoltageRange.ReadOnly = true;
            this.InputVoltageRange.Width = 70;
            // 
            // OutputVoltageRange
            // 
            this.OutputVoltageRange.DataPropertyName = "OutputVoltageRange";
            this.OutputVoltageRange.HeaderText = "输出电压限";
            this.OutputVoltageRange.Name = "OutputVoltageRange";
            this.OutputVoltageRange.ReadOnly = true;
            this.OutputVoltageRange.Width = 70;
            // 
            // OutputCurrentRange
            // 
            this.OutputCurrentRange.DataPropertyName = "OutputCurrentRange";
            this.OutputCurrentRange.HeaderText = "输出电流限";
            this.OutputCurrentRange.Name = "OutputCurrentRange";
            this.OutputCurrentRange.ReadOnly = true;
            this.OutputCurrentRange.Width = 70;
            // 
            // OutputPowerRange
            // 
            this.OutputPowerRange.DataPropertyName = "OutputPowerRange";
            this.OutputPowerRange.HeaderText = "输出功率限";
            this.OutputPowerRange.Name = "OutputPowerRange";
            this.OutputPowerRange.ReadOnly = true;
            this.OutputPowerRange.Width = 70;
            // 
            // InputPowerRange
            // 
            this.InputPowerRange.DataPropertyName = "InputPowerRange";
            this.InputPowerRange.HeaderText = "输入功率限";
            this.InputPowerRange.Name = "InputPowerRange";
            this.InputPowerRange.ReadOnly = true;
            this.InputPowerRange.Width = 70;
            // 
            // EfficiencyRange
            // 
            this.EfficiencyRange.DataPropertyName = "EfficiencyRange";
            this.EfficiencyRange.HeaderText = "效率限";
            this.EfficiencyRange.Name = "EfficiencyRange";
            this.EfficiencyRange.ReadOnly = true;
            this.EfficiencyRange.Width = 70;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Transparent;
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.ForeColor = System.Drawing.Color.Blue;
            this.progressBar1.Location = new System.Drawing.Point(0, 544);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBar1.ProgressStyle = HslControls.HslProgressStyle.Horizontal;
            this.progressBar1.Size = new System.Drawing.Size(784, 17);
            this.progressBar1.TabIndex = 9;
            this.progressBar1.Value = 0;
            // 
            // button1
            // 
            this.button1.CustomerInformation = null;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(10, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 46);
            this.button1.TabIndex = 11;
            this.button1.Text = "开始";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Button2
            // 
            this.Button2.CustomerInformation = null;
            this.Button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button2.Location = new System.Drawing.Point(266, 466);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(250, 46);
            this.Button2.TabIndex = 12;
            this.Button2.Text = "配置界面";
            this.Button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Button3
            // 
            this.Button3.CustomerInformation = null;
            this.Button3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button3.Location = new System.Drawing.Point(523, 466);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(250, 46);
            this.Button3.TabIndex = 13;
            this.Button3.Text = "导出excel";
            this.Button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private HslControls.HslProgressColorful progressBar1;
        private HslControls.HslButton button1;
        private HslControls.HslButton Button2;
        private HslControls.HslButton Button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualInputVoltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualOutputVoltage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualOutputCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualOutputPower;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualInputPower;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualEfficiency;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestWaitTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoadCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Standard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputVoltageUpperLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputVoltageLowerLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutputVoltageUpperLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutputVoltageLowerLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutputCurrentUpperLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutputCurrentLowerLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutputPowerUpperLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutputPowerLowerLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputPowerUpperLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputPowerLowerLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn EfficiencyUpperLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn EfficiencyLowerLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputVoltageRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutputVoltageRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutputCurrentRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutputPowerRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputPowerRange;
        private System.Windows.Forms.DataGridViewTextBoxColumn EfficiencyRange;
    }
}


namespace TestPower
{
    partial class Form2
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
            this.cmbParamPort = new System.Windows.Forms.ComboBox();
            this.lblParamPort = new System.Windows.Forms.Label();
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
            this.cmbKpPort = new System.Windows.Forms.ComboBox();
            this.lblKpPort = new System.Windows.Forms.Label();
            this.Button1 = new HslControls.HslButton();
            this.Button3 = new HslControls.HslButton();
            this.Button4 = new HslControls.HslButton();
            this.Button2 = new HslControls.HslButton();
            this.btnConnect = new HslControls.HslButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbParamPort
            // 
            this.cmbParamPort.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbParamPort.FormattingEnabled = true;
            this.cmbParamPort.Location = new System.Drawing.Point(472, 95);
            this.cmbParamPort.Name = "cmbParamPort";
            this.cmbParamPort.Size = new System.Drawing.Size(74, 29);
            this.cmbParamPort.TabIndex = 15;
            // 
            // lblParamPort
            // 
            this.lblParamPort.AutoSize = true;
            this.lblParamPort.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblParamPort.Location = new System.Drawing.Point(344, 98);
            this.lblParamPort.Name = "lblParamPort";
            this.lblParamPort.Size = new System.Drawing.Size(90, 21);
            this.lblParamPort.TabIndex = 14;
            this.lblParamPort.Text = "参数串口：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
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
            this.EfficiencyLowerLimit});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 161);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(784, 400);
            this.dataGridView1.TabIndex = 9;
            // 
            // Id
            // 
            this.Id.HeaderText = "序列";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 20;
            // 
            // TestItem
            // 
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
            this.TestWaitTime.Width = 70;
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
            this.InputVoltageUpperLimit.Width = 70;
            // 
            // InputVoltageLowerLimit
            // 
            this.InputVoltageLowerLimit.HeaderText = "输入电压下限";
            this.InputVoltageLowerLimit.MinimumWidth = 6;
            this.InputVoltageLowerLimit.Name = "InputVoltageLowerLimit";
            this.InputVoltageLowerLimit.ReadOnly = true;
            this.InputVoltageLowerLimit.Width = 70;
            // 
            // OutputVoltageUpperLimit
            // 
            this.OutputVoltageUpperLimit.HeaderText = "输出电压上限";
            this.OutputVoltageUpperLimit.MinimumWidth = 6;
            this.OutputVoltageUpperLimit.Name = "OutputVoltageUpperLimit";
            this.OutputVoltageUpperLimit.ReadOnly = true;
            this.OutputVoltageUpperLimit.Width = 70;
            // 
            // OutputVoltageLowerLimit
            // 
            this.OutputVoltageLowerLimit.HeaderText = "输出电压下限";
            this.OutputVoltageLowerLimit.MinimumWidth = 6;
            this.OutputVoltageLowerLimit.Name = "OutputVoltageLowerLimit";
            this.OutputVoltageLowerLimit.ReadOnly = true;
            this.OutputVoltageLowerLimit.Width = 70;
            // 
            // OutputCurrentUpperLimit
            // 
            this.OutputCurrentUpperLimit.HeaderText = "输出电流上限";
            this.OutputCurrentUpperLimit.MinimumWidth = 6;
            this.OutputCurrentUpperLimit.Name = "OutputCurrentUpperLimit";
            this.OutputCurrentUpperLimit.ReadOnly = true;
            this.OutputCurrentUpperLimit.Width = 70;
            // 
            // OutputCurrentLowerLimit
            // 
            this.OutputCurrentLowerLimit.HeaderText = "输出电流下限";
            this.OutputCurrentLowerLimit.MinimumWidth = 6;
            this.OutputCurrentLowerLimit.Name = "OutputCurrentLowerLimit";
            this.OutputCurrentLowerLimit.ReadOnly = true;
            this.OutputCurrentLowerLimit.Width = 70;
            // 
            // OutputPowerUpperLimit
            // 
            this.OutputPowerUpperLimit.HeaderText = "输出功率上限";
            this.OutputPowerUpperLimit.MinimumWidth = 6;
            this.OutputPowerUpperLimit.Name = "OutputPowerUpperLimit";
            this.OutputPowerUpperLimit.ReadOnly = true;
            this.OutputPowerUpperLimit.Width = 70;
            // 
            // OutputPowerLowerLimit
            // 
            this.OutputPowerLowerLimit.HeaderText = "输出功率下限";
            this.OutputPowerLowerLimit.MinimumWidth = 6;
            this.OutputPowerLowerLimit.Name = "OutputPowerLowerLimit";
            this.OutputPowerLowerLimit.ReadOnly = true;
            this.OutputPowerLowerLimit.Width = 70;
            // 
            // InputPowerUpperLimit
            // 
            this.InputPowerUpperLimit.HeaderText = "输入功率上限";
            this.InputPowerUpperLimit.MinimumWidth = 6;
            this.InputPowerUpperLimit.Name = "InputPowerUpperLimit";
            this.InputPowerUpperLimit.ReadOnly = true;
            this.InputPowerUpperLimit.Width = 70;
            // 
            // InputPowerLowerLimit
            // 
            this.InputPowerLowerLimit.HeaderText = "输入功率下限";
            this.InputPowerLowerLimit.MinimumWidth = 6;
            this.InputPowerLowerLimit.Name = "InputPowerLowerLimit";
            this.InputPowerLowerLimit.ReadOnly = true;
            this.InputPowerLowerLimit.Width = 70;
            // 
            // EfficiencyUpperLimit
            // 
            this.EfficiencyUpperLimit.HeaderText = "效率上限";
            this.EfficiencyUpperLimit.MinimumWidth = 6;
            this.EfficiencyUpperLimit.Name = "EfficiencyUpperLimit";
            this.EfficiencyUpperLimit.ReadOnly = true;
            this.EfficiencyUpperLimit.Width = 70;
            // 
            // EfficiencyLowerLimit
            // 
            this.EfficiencyLowerLimit.HeaderText = "效率下限";
            this.EfficiencyLowerLimit.MinimumWidth = 6;
            this.EfficiencyLowerLimit.Name = "EfficiencyLowerLimit";
            this.EfficiencyLowerLimit.ReadOnly = true;
            this.EfficiencyLowerLimit.Width = 70;
            // 
            // cmbKpPort
            // 
            this.cmbKpPort.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbKpPort.FormattingEnabled = true;
            this.cmbKpPort.Location = new System.Drawing.Point(472, 25);
            this.cmbKpPort.Name = "cmbKpPort";
            this.cmbKpPort.Size = new System.Drawing.Size(74, 29);
            this.cmbKpPort.TabIndex = 19;
            // 
            // lblKpPort
            // 
            this.lblKpPort.AutoSize = true;
            this.lblKpPort.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblKpPort.Location = new System.Drawing.Point(344, 25);
            this.lblKpPort.Name = "lblKpPort";
            this.lblKpPort.Size = new System.Drawing.Size(122, 21);
            this.lblKpPort.TabIndex = 18;
            this.lblKpPort.Text = "电子负载串口：";
            // 
            // Button1
            // 
            this.Button1.CustomerInformation = null;
            this.Button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button1.Location = new System.Drawing.Point(6, 13);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(114, 46);
            this.Button1.TabIndex = 21;
            this.Button1.Text = "添加";
            this.Button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Button3
            // 
            this.Button3.CustomerInformation = null;
            this.Button3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button3.Location = new System.Drawing.Point(6, 89);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(114, 46);
            this.Button3.TabIndex = 22;
            this.Button3.Text = "保存";
            this.Button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Button4
            // 
            this.Button4.CustomerInformation = null;
            this.Button4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button4.Location = new System.Drawing.Point(144, 89);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(114, 46);
            this.Button4.TabIndex = 23;
            this.Button4.Text = "返回主界面";
            this.Button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Button2
            // 
            this.Button2.CustomerInformation = null;
            this.Button2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Button2.Location = new System.Drawing.Point(144, 13);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(114, 46);
            this.Button2.TabIndex = 24;
            this.Button2.Text = "删除";
            this.Button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.CustomerInformation = null;
            this.btnConnect.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConnect.Location = new System.Drawing.Point(602, 51);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(114, 46);
            this.btnConnect.TabIndex = 25;
            this.btnConnect.Text = "连接";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Button2);
            this.groupBox1.Controls.Add(this.Button1);
            this.groupBox1.Controls.Add(this.Button4);
            this.groupBox1.Controls.Add(this.Button3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 141);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.cmbKpPort);
            this.Controls.Add(this.lblKpPort);
            this.Controls.Add(this.cmbParamPort);
            this.Controls.Add(this.lblParamPort);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbParamPort;
        private System.Windows.Forms.Label lblParamPort;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbKpPort;
        private System.Windows.Forms.Label lblKpPort;
        private HslControls.HslButton Button1;
        private HslControls.HslButton Button3;
        private HslControls.HslButton Button4;
        private HslControls.HslButton Button2;
        private HslControls.HslButton btnConnect;
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
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
using Sunisoft.IrisSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestPower
{
    public partial class Form2: Form
    {
        private DatabaseHelper dbHelper;
        public Form2(DatabaseHelper dbHelper)
        {
            InitializeComponent();
            this.dbHelper = dbHelper;
            LoadDataFromDatabase();
            // 初始化 COM 端口列表
            InitializeComPorts();
            RefreshSerialPorts();
        }

        private void InitializeComPorts()
        {
            // 假设系统支持的 COM 端口为 COM1-COM16
            for (int i = 1; i <= 16; i++)
            {
                cmbKpPort.Items.Add($"COM{i}");
                cmbParamPort.Items.Add($"COM{i}");
            }
            // 加载上次保存的端口设置
            string kp184Port = dbHelper.GetSetting("KP184Port") ?? "COM3";
            string parameterPort = dbHelper.GetSetting("ParameterPort") ?? "COM4";
            cmbKpPort.Text = kp184Port;
            cmbParamPort.Text = parameterPort;
        }
        #region 串口扫描和连接
        private void RefreshSerialPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            cmbKpPort.Items.Clear();
            cmbParamPort.Items.Clear();
            cmbKpPort.Items.AddRange(ports);
            cmbParamPort.Items.AddRange(ports);
            if (ports.Length > 0)
            {
                cmbKpPort.SelectedIndex = 0;
                cmbParamPort.SelectedIndex = 0;
            }

        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取配置
                string kpPort = cmbKpPort.Text;
                string paramPort = cmbParamPort.Text;

                // 验证输入
                if (string.IsNullOrEmpty(kpPort) || string.IsNullOrEmpty(paramPort))
                {
                    MessageBox.Show("请选择有效的串口！");
                    return;
                }

                // 测试电子负载连接（无需修改 KP184 类）
                KP184 testKp = new KP184(3, 9600);// 使用默认参数测试连接
                
                    int[] testData = testKp.GetALL(1); // 假设测试成功返回有效数据
                    if (testData[0] == -999)
                    {
                        MessageBox.Show("电子负载连接失败！");
                        return;
                    }


                // 测试参数表连接（无需修改 Parameter 类）
                Parameter testParam = new Parameter(4, 9600);
                
                    int volt = testParam.GetVolt(1);
                    if (volt == -999)
                    {
                        MessageBox.Show("参数表连接失败！");
                        return;
                    }
                
                // 保存配置到数据库
                SaveConfigToDatabase(kpPort, 9600, "KP184");
                SaveConfigToDatabase(paramPort, 9600, "Parameter");

                MessageBox.Show("配置保存成功！");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"连接失败：{ex.Message}");
            }
        }

        // 保存配置到数据库
        private void SaveConfigToDatabase(string port, int baudRate, string deviceType)
        {
            using (SQLiteConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT OR REPLACE INTO DeviceConfig (DeviceType, Port, BaudRate) VALUES (@Type, @Port, @Baud)";
                using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Type", deviceType);
                    cmd.Parameters.AddWithValue("@Port", port);
                    cmd.Parameters.AddWithValue("@Baud", baudRate);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion


        private void Form2_Load(object sender, EventArgs e)
        {
            // 扫描可用串口
            RefreshSerialPorts();
        }

        #region 事件处理
        // 点击“添加”按钮
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 addForm = new Form3(dbHelper);
            addForm.ShowDialog();
            LoadDataFromDatabase();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveDataToDatabase();
            this.Close(); // 保存成功后关闭窗口，触发 Form1 的刷新
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 数据操作
        // 加载数据到 DataGridView
        private void LoadDataFromDatabase()
        {
            using (SQLiteConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM TestResults", conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    dataGridView1.Rows.Clear();
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(
                            reader["Id"],
                            reader["TestItem"],
                            reader["ActualInputVoltage"],
                            reader["ActualOutputVoltage"],
                            reader["ActualOutputCurrent"],
                            reader["ActualOutputPower"],
                            reader["ActualInputPower"],
                            reader["ActualEfficiency"],
                            reader["TestWaitTime"],
                            reader["LoadCurrent"],
                            reader["Standard"],
                            reader["Status"],
                            reader["InputVoltageUpperLimit"],
                            reader["InputVoltageLowerLimit"],
                            reader["OutputVoltageUpperLimit"],
                            reader["OutputVoltageLowerLimit"],
                            reader["OutputCurrentUpperLimit"],
                            reader["OutputCurrentLowerLimit"],
                            reader["OutputPowerUpperLimit"],
                            reader["OutputPowerLowerLimit"],
                            reader["InputPowerUpperLimit"],
                            reader["InputPowerLowerLimit"],
                            reader["EfficiencyUpperLimit"],
                            reader["EfficiencyLowerLimit"]
                        );
                    }
                }
                conn.Close();
            }
        }

        // 删除数据库记录（传入连接对象）
        private void DeleteFromDatabase(int id, SQLiteConnection conn)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(
                "DELETE FROM TestResults WHERE Id = @Id",
                conn
            ))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        // 保存所有数据到数据库
        private void SaveDataToDatabase()
        {
            using (SQLiteConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                // 获取当前 DataGridView 中的 Id 列表
                var currentIds = dataGridView1.Rows//包含了所有的数据
                    .Cast<DataGridViewRow>()
                    .Where(row => !row.IsNewRow)
                    .Select(row => Convert.ToInt32(row.Cells["Id"].Value))
                    .ToList();

                // 获取数据库中的所有 Id
                var dbIds = new List<int>();
                using (SQLiteCommand cmd = new SQLiteCommand("SELECT Id FROM TestResults", conn))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dbIds.Add(Convert.ToInt32(reader["Id"]));
                    }
                }

                // 删除数据库中存在但不在当前 DataGridView 的记录
                foreach (var id in dbIds)
                {
                    if (!currentIds.Contains(id))
                    {
                        DeleteFromDatabase(id, conn);
                    }
                }

                // 处理当前 DataGridView 中的每一行
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    int id = Convert.ToInt32(row.Cells["Id"].Value);
                    if (id == 0 || id == -1)
                    {
                        // 插入新记录
                        InsertRowToDatabase(row, conn);
                    }
                    else
                    {
                        // 更新现有记录
                        UpdateRowInDatabase(row, conn);
                    }
                }

                conn.Close();
                // 保存端口设置
                dbHelper.SaveSetting("KP184Port", cmbKpPort.Text);
                dbHelper.SaveSetting("ParameterPort", cmbParamPort.Text);
                MessageBox.Show("保存成功！");
                this.Close(); // 保存成功后关闭窗口
            }
        }
        // 插入新记录到数据库
        private void InsertRowToDatabase(DataGridViewRow row, SQLiteConnection conn)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "INSERT INTO TestResults (" +
                "TestItem,ActualInputVoltage, ActualOutputVoltage, ActualOutputCurrent, ActualOutputPower, ActualInputPower, ActualEfficiency ,TestWaitTime, LoadCurrent, Standard, Status, InputVoltageUpperLimit, " +
                "InputVoltageLowerLimit, OutputVoltageUpperLimit, OutputVoltageLowerLimit, " +
                "OutputCurrentUpperLimit, OutputCurrentLowerLimit, OutputPowerUpperLimit, " +
                "OutputPowerLowerLimit, InputPowerUpperLimit, InputPowerLowerLimit, " +
                "EfficiencyUpperLimit, EfficiencyLowerLimit) " +
                "VALUES (@TestItem, @ActualInputVoltage, @ActualOutputVoltage, @ActualOutputCurrent,@ActualOutputPower, @ActualInputPower, @ActualEfficiency,@TestWaitTime, @LoadCurrent, @Standard, @Status, " +
                "@InputVoltageUpperLimit, @InputVoltageLowerLimit, " +
                "@OutputVoltageUpperLimit, @OutputVoltageLowerLimit, " +
                "@OutputCurrentUpperLimit, @OutputCurrentLowerLimit, " +
                "@OutputPowerUpperLimit, @OutputPowerLowerLimit, " +
                "@InputPowerUpperLimit, @InputPowerLowerLimit, " +
                "@EfficiencyUpperLimit, @EfficiencyLowerLimit)",
                conn
            );

            // 设置所有参数值
            cmd.Parameters.AddWithValue("@TestItem", row.Cells["TestItem"].Value?.ToString());

            // 设置新参数值
            cmd.Parameters.AddWithValue(
                "@ActualInputVoltage",
                row.Cells["ActualInputVoltage"].Value ?? DBNull.Value
            );
            cmd.Parameters.AddWithValue(
                "@ActualOutputVoltage",
                row.Cells["ActualOutputVoltage"].Value ?? DBNull.Value
            );
            cmd.Parameters.AddWithValue(
                "@ActualOutputCurrent",
                row.Cells["ActualOutputCurrent"].Value ?? DBNull.Value
            );
            cmd.Parameters.AddWithValue(
                "@ActualOutputPower",
                row.Cells["ActualOutputPower"].Value ?? DBNull.Value
            );
            cmd.Parameters.AddWithValue(
                "@ActualInputPower",
                row.Cells["ActualInputPower"].Value ?? DBNull.Value
            );
            cmd.Parameters.AddWithValue(
                "@ActualEfficiency",
                row.Cells["ActualEfficiency"].Value ?? DBNull.Value
            );

            cmd.Parameters.AddWithValue("@TestWaitTime", Convert.ToInt32(row.Cells["TestWaitTime"].Value));
            cmd.Parameters.AddWithValue("@LoadCurrent", Convert.ToDouble(row.Cells["LoadCurrent"].Value));
            cmd.Parameters.AddWithValue("@Standard", row.Cells["Standard"].Value?.ToString());
            cmd.Parameters.AddWithValue("@Status", row.Cells["Status"].Value?.ToString());
            cmd.Parameters.AddWithValue("@InputVoltageUpperLimit", Convert.ToDouble(row.Cells["InputVoltageUpperLimit"].Value));
            cmd.Parameters.AddWithValue("@InputVoltageLowerLimit", Convert.ToDouble(row.Cells["InputVoltageLowerLimit"].Value));
            cmd.Parameters.AddWithValue("@OutputVoltageUpperLimit", Convert.ToDouble(row.Cells["OutputVoltageUpperLimit"].Value));
            cmd.Parameters.AddWithValue("@OutputVoltageLowerLimit", Convert.ToDouble(row.Cells["OutputVoltageLowerLimit"].Value));
            cmd.Parameters.AddWithValue("@OutputCurrentUpperLimit", Convert.ToDouble(row.Cells["OutputCurrentUpperLimit"].Value));
            cmd.Parameters.AddWithValue("@OutputCurrentLowerLimit", Convert.ToDouble(row.Cells["OutputCurrentLowerLimit"].Value));
            cmd.Parameters.AddWithValue("@OutputPowerUpperLimit", Convert.ToDouble(row.Cells["OutputPowerUpperLimit"].Value));
            cmd.Parameters.AddWithValue("@OutputPowerLowerLimit", Convert.ToDouble(row.Cells["OutputPowerLowerLimit"].Value));
            cmd.Parameters.AddWithValue("@InputPowerUpperLimit", Convert.ToDouble(row.Cells["InputPowerUpperLimit"].Value));
            cmd.Parameters.AddWithValue("@InputPowerLowerLimit", Convert.ToDouble(row.Cells["InputPowerLowerLimit"].Value));
            cmd.Parameters.AddWithValue("@EfficiencyUpperLimit", Convert.ToDouble(row.Cells["EfficiencyUpperLimit"].Value));
            cmd.Parameters.AddWithValue("@EfficiencyLowerLimit", Convert.ToDouble(row.Cells["EfficiencyLowerLimit"].Value));
           
            cmd.ExecuteNonQuery();
        }

        // 更新现有记录到数据库
        private void UpdateRowInDatabase(DataGridViewRow row, SQLiteConnection conn)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "UPDATE TestResults SET " +
                "TestItem = @TestItem, " +
                "ActualInputVoltage = @ActualInputVoltage, " +
                "ActualOutputVoltage = @ActualOutputVoltage, " +
                "ActualOutputCurrent = @ActualOutputCurrent, " +
                "ActualOutputPower = @ActualOutputPower, " +
                "ActualInputPower = @ActualInputPower, " +
                "ActualEfficiency = @ActualEfficiency, " +
                "TestWaitTime = @TestWaitTime, " +
                "LoadCurrent = @LoadCurrent, " +
                "Standard = @Standard, " +
                "Status = @Status, " +
                "InputVoltageUpperLimit = @InputVoltageUpperLimit, " +
                "InputVoltageLowerLimit = @InputVoltageLowerLimit, " +
                "OutputVoltageUpperLimit = @OutputVoltageUpperLimit, " +
                "OutputVoltageLowerLimit = @OutputVoltageLowerLimit, " +
                "OutputCurrentUpperLimit = @OutputCurrentUpperLimit, " +
                "OutputCurrentLowerLimit = @OutputCurrentLowerLimit, " +
                "OutputPowerUpperLimit = @OutputPowerUpperLimit, " +
                "OutputPowerLowerLimit = @OutputPowerLowerLimit, " +
                "InputPowerUpperLimit = @InputPowerUpperLimit, " +
                "InputPowerLowerLimit = @InputPowerLowerLimit, " +
                "EfficiencyUpperLimit = @EfficiencyUpperLimit, " +
                "EfficiencyLowerLimit = @EfficiencyLowerLimit " +
               
                "WHERE Id = @Id",
                conn
            );

            // 设置所有参数值
            cmd.Parameters.AddWithValue("@TestItem", row.Cells["TestItem"].Value?.ToString());

            // 设置新参数值
            cmd.Parameters.AddWithValue(
                "@ActualInputVoltage",
                row.Cells["ActualInputVoltage"].Value ?? DBNull.Value
            );
            cmd.Parameters.AddWithValue(
                "@ActualOutputVoltage",
                row.Cells["ActualOutputVoltage"].Value ?? DBNull.Value
            );
            cmd.Parameters.AddWithValue(
                "@ActualOutputCurrent",
                row.Cells["ActualOutputCurrent"].Value ?? DBNull.Value
            );
            cmd.Parameters.AddWithValue(
                "@ActualOutputPower",
                row.Cells["ActualOutputPower"].Value ?? DBNull.Value
            );
            cmd.Parameters.AddWithValue(
                "@ActualInputPower",
                row.Cells["ActualInputPower"].Value ?? DBNull.Value
            );
            cmd.Parameters.AddWithValue(
                "@ActualEfficiency",
                row.Cells["ActualEfficiency"].Value ?? DBNull.Value
            );

            cmd.Parameters.AddWithValue("@TestWaitTime", Convert.ToInt32(row.Cells["TestWaitTime"].Value));
            cmd.Parameters.AddWithValue("@LoadCurrent", Convert.ToDouble(row.Cells["LoadCurrent"].Value));
            cmd.Parameters.AddWithValue("@Standard", row.Cells["Standard"].Value?.ToString());
            cmd.Parameters.AddWithValue("@Status", row.Cells["Status"].Value?.ToString());
            cmd.Parameters.AddWithValue("@InputVoltageUpperLimit", Convert.ToDouble(row.Cells["InputVoltageUpperLimit"].Value));
            cmd.Parameters.AddWithValue("@InputVoltageLowerLimit", Convert.ToDouble(row.Cells["InputVoltageLowerLimit"].Value));
            cmd.Parameters.AddWithValue("@OutputVoltageUpperLimit", Convert.ToDouble(row.Cells["OutputVoltageUpperLimit"].Value));
            cmd.Parameters.AddWithValue("@OutputVoltageLowerLimit", Convert.ToDouble(row.Cells["OutputVoltageLowerLimit"].Value));
            cmd.Parameters.AddWithValue("@OutputCurrentUpperLimit", Convert.ToDouble(row.Cells["OutputCurrentUpperLimit"].Value));
            cmd.Parameters.AddWithValue("@OutputCurrentLowerLimit", Convert.ToDouble(row.Cells["OutputCurrentLowerLimit"].Value));
            cmd.Parameters.AddWithValue("@OutputPowerUpperLimit", Convert.ToDouble(row.Cells["OutputPowerUpperLimit"].Value));
            cmd.Parameters.AddWithValue("@OutputPowerLowerLimit", Convert.ToDouble(row.Cells["OutputPowerLowerLimit"].Value));
            cmd.Parameters.AddWithValue("@InputPowerUpperLimit", Convert.ToDouble(row.Cells["InputPowerUpperLimit"].Value));
            cmd.Parameters.AddWithValue("@InputPowerLowerLimit", Convert.ToDouble(row.Cells["InputPowerLowerLimit"].Value));
            cmd.Parameters.AddWithValue("@EfficiencyUpperLimit", Convert.ToDouble(row.Cells["EfficiencyUpperLimit"].Value));
            cmd.Parameters.AddWithValue("@EfficiencyLowerLimit", Convert.ToDouble(row.Cells["EfficiencyLowerLimit"].Value));
        
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(row.Cells["Id"].Value));

            cmd.ExecuteNonQuery();
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的测试项！");
                return;
            }

            if (MessageBox.Show(
                "确定删除选中的测试项？",
                "删除确认",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            ) != DialogResult.OK)
            {
                return;
            }

            // 移除选中行
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            dataGridView1.Rows.Remove(selectedRow);
            MessageBox.Show("删除成功！");
        }
    }
 }


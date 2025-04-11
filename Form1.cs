using HslControls;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace TestPower
{
    public partial class Form1 : Form
    {
        private DatabaseHelper dbHelper;//数据库操作类
        private KP184 kp184;            // 电子负载通信类
        private Parameter parameter;     // 参数表通信类
        private bool isTesting = false;
        public Form1()
        {
            InitializeComponent();
        }

        #region   端口处理
        // 将 COMx 转换为数字端口号（如 COM3 → 3）
        private int GetPortNumber(string comPort)
        {
            if (string.IsNullOrEmpty(comPort))
            {
                throw new ArgumentException("COM 端口不能为空", nameof(comPort));
            }
            // 确保以 "COM" 开头
            if (!comPort.StartsWith("COM", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("无效的 COM 端口格式", nameof(comPort));
            }

            string portNumberStr = comPort.Replace("COM", "");
            if (!int.TryParse(portNumberStr, out int portNumber))
            {
                throw new FormatException($"无法解析端口号：{portNumberStr}");
            }
            return portNumber;
        }
        #endregion

        #region 界面初始化
        private void InitializeDataGridView()
        {
            // 添加序号列（如果不存在）
            if (!dataGridView1.Columns.Contains("RowNumber"))
            {
                dataGridView1.Columns.Insert(0, new DataGridViewTextBoxColumn
                {
                    Name = "RowNumber",
                    HeaderText = "序号",
                    Width = 40,
                    ReadOnly = true
                });
            }
        }
        #endregion

        #region 开始直接运行
        private void Form1_Load(object sender, EventArgs e)
        {
            // 初始化数据库路径
            string dbPath = @"D:\sqlite\testdb";
            dbHelper = new DatabaseHelper(dbPath);
            InitializeDataGridView(); //初始化列（确保手动列与代码一致）
            LoadDataFromDatabase();      // 启动时加载数据   
                                         // 检查是否已配置端口
            if (string.IsNullOrEmpty(dbHelper.GetSetting("KP184Port")) ||
                string.IsNullOrEmpty(dbHelper.GetSetting("ParameterPort")))
            {
                // 强制用户配置端口
                using (PasswordForm pwdForm = new PasswordForm())
                {
                    if (pwdForm.ShowDialog() == DialogResult.OK && pwdForm.IsAuthorized)
                    {
                        Form2 configForm = new Form2(dbHelper);
                        configForm.ShowDialog();
                    }
                }
            }

            string kp184Port = dbHelper.GetSetting("KP184Port") ?? "COM3";//??"COM3" 是空合并运算符，如果返回的结果是null或者空字符串，则使用默认值-COM3
            string parameterPort = dbHelper.GetSetting("ParameterPort") ?? "COM4";

            // 创建设备实例
            kp184 = new KP184(GetPortNumber(kp184Port), 9600);
            parameter = new Parameter(GetPortNumber(parameterPort), 9600);
        }
        #endregion

        #region   事件处理（按钮功能）
        private void button1_Click(object sender, EventArgs e)
        {
            if (isTesting)
            {
                MessageBox.Show("测试正在进行，请稍后再试！");
                return;
            }

            isTesting = true; // 标记测试开始
            StartTest();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (PasswordForm pwdForm = new PasswordForm())
            {
                if (pwdForm.ShowDialog() == DialogResult.OK && pwdForm.IsAuthorized)
                {
                    Form2 configForm = new Form2(dbHelper);
                    // 监听Form2的关闭事件，触发Form1的刷新
                    configForm.FormClosed += (s, ev) =>
                    {
                        LoadDataFromDatabase(); // 关闭后重新加载数据
                    };
                    configForm.ShowDialog();//模态显示
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        #endregion

        #region 核心逻辑StartTest()
        // 执行测试
        private async void StartTest()
        {
            //整个窗口不能点击
            this.Enabled = false;
            // 强制刷新数据（重新加载数据库）
            LoadDataFromDatabase();
            int boardID = 1; // Modbus 从站地址
            int waitTime = 500; // 通信超时时间（毫秒）
            int totalRows = dataGridView1.Rows.Count; // 总行数
            try
            {
                progressBar1.Max = totalRows;
                progressBar1.Value = 0;
                //lblProgress.Text = $"正在测试第 1 行/共 {totalRows} 行";

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    var row = dataGridView1.Rows[i];
                    int rowIndex = i;
                    await Task.Run(() => ProcessTestRow(rowIndex, boardID, waitTime)); // 异步处理每一行
                    await Task.Yield(); // 切换到 UI 线程更新界面
                                        // 更新进度条和标签（在 UI 线程）
                    UpdateProgress(i + 1, totalRows);
                }

                // 测试完成
                progressBar1.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"测试失败：{ex.Message}");
            }
            finally
            {
                //启动整个窗口的点击
                this.Enabled = true;
                isTesting = false; // 标记测试结束
            }
        }

        // 逐行测试的逻辑（在后台线程执行）
        private void ProcessTestRow(int rowIndex, int boardID, int waitTime)
        {

            //// 方法级变量（确保所有代码块可访问）
            //int id = -1; // 默认值
            string testItem = string.Empty;
            //double actualInputVoltage = -999;
            //double actualOutputVoltage = -999;
            //double actualOutputCurrent = -999;
            //double actualOutputPower = -999;
            //double actualInputPower = -999;
            //double actualEfficiency = -999;
            //int testWaitTime = 0;
            //double loadCurrent = 0.0;
            //string standard = string.Empty;
            //double inputVoltageUpper = 0.0;
            //double inputVoltageLower = 0.0;
            //double outputVoltageUpper = 0.0;
            //double outputVoltageLower = 0.0;
            //double outputCurrentUpper = 0.0;
            //double outputCurrentLower = 0.0;
            //double outputPowerUpper = 0.0;
            //double outputPowerLower = 0.0;
            //double inputPowerUpper = 0.0;
            //double inputPowerLower = 0.0;
            //double efficiencyUpper = 0.0;
            //double efficiencyLower = 0.0;

            try
            {
                // 读取当前行的所有字段
                var row = dataGridView1.Rows[rowIndex];
                int id = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["Id"].Value);
                testItem = dataGridView1.Rows[rowIndex].Cells["TestItem"].Value?.ToString() ?? "";

                int testWaitTime = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["TestWaitTime"].Value);
                double loadCurrent = Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["LoadCurrent"].Value);
                string standard = dataGridView1.Rows[rowIndex].Cells["Standard"].Value?.ToString() ?? "";
                //string status = dataGridView1.Rows[rowIndex].Cells["Status"].Value?.ToString() ?? "未测试";

                double inputVoltageUpper = Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["InputVoltageUpperLimit"].Value);
                double inputVoltageLower = Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["InputVoltageLowerLimit"].Value);

                double outputVoltageUpper = Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["OutputVoltageUpperLimit"].Value);
                double outputVoltageLower = Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["OutputVoltageLowerLimit"].Value);

                double outputCurrentUpper = Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["OutputCurrentUpperLimit"].Value);
                double outputCurrentLower = Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["OutputCurrentLowerLimit"].Value);

                double outputPowerUpper = Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["OutputPowerUpperLimit"].Value);
                double outputPowerLower = Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["OutputPowerLowerLimit"].Value);

                double inputPowerUpper = Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["InputPowerUpperLimit"].Value);
                double inputPowerLower = Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["InputPowerLowerLimit"].Value);

                double efficiencyUpper = Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["EfficiencyUpperLimit"].Value);
                double efficiencyLower = Convert.ToDouble(dataGridView1.Rows[rowIndex].Cells["EfficiencyLowerLimit"].Value);

                //// 从设备读取实际值
                //actualInputVoltage = parameter.GetVolt(boardID, waitTime); // 输入电压
                //actualOutputVoltage = kp184.GetALL(boardID, waitTime)[0]; // 输出电压
                //actualOutputCurrent = kp184.GetALL(boardID, waitTime)[1]; // 输出电流
                //actualOutputPower = actualOutputVoltage * actualOutputCurrent; // 输出功率
                //actualInputPower = actualInputVoltage * actualInputCurrent; // 输入功率
                //actualEfficiency = (actualOutputPower / actualInputPower) * 100; // 效率
                // 应用测试等待时间
                Thread.Sleep(testWaitTime);

                // 设置为CC模式（模式1）
                bool setModeResult = kp184.SetMode(boardID, 1, waitTime); // 1代表CC模式
                if (!setModeResult)
                {
                    UpdateErrorRow(rowIndex, testItem, "模式通信失败");
                    return;
                }
                // 设置加载电流值（假设参数单位转换为整数毫安）
                int settingValue = (int)(loadCurrent * 1000); // 将安培转换为毫安
                bool setSettingResult = kp184.SetSetting(boardID, settingValue, waitTime);
                if (!setSettingResult)
                {
                    UpdateErrorRow(rowIndex, testItem, "电流设置失败");
                    return;
                }

                // 设置电子负载参数
                //  打开负载开关（ON=1）
                bool setOnResult = kp184.Seton(boardID, 1, waitTime);
                if (!setOnResult)
                {
                    UpdateErrorRow(rowIndex, testItem, "开关设置失败");
                    return;
                }

                // 读取电子负载的实时数据
                string kp184Port = dbHelper.GetSetting("KP184Port") ?? "3";
                // 修改后（转换为字符串）
                int[] data = kp184.GetALL(GetPortNumber(kp184Port), waitTime);
                string s = string.Join(" ", data); // 例如：将数组转为 "123 456 789" 格式
                //string s = kp184.GetALL(GetPortNumber(kp184Port),  waitTime); /*"01 03 03 00 00 00 45 8E",*/
                // 读取电子负载数据

                double actualOutputVoltage = data[0]; //Convert.ToDouble(s); // 输出电压
                double actualOutputCurrent = data[1]; //Convert.ToDouble(s); // 当前电流

                // 处理电子负载通信失败
                if (actualOutputVoltage == -999 || actualOutputCurrent == -999)
                {
                    UpdateErrorRow(rowIndex, testItem, "通信失败");

                    return;
                }


                //double actualInputVoltage = 199;  // 输入电压(V)
                                                  //// 读取输入侧数据（来自 Parameter）
                int actualInputVoltage = parameter.GetVolt(boardID, waitTime); // 输入电压(V)
                int autualInputCurrent = parameter.GetCurr(boardID, waitTime); // 输入电流(A)                                   // 输入电流(A)


                // 处理参数表通信失败
                if (actualInputVoltage == -999 || autualInputCurrent == -999)
                {
                    UpdateErrorRow(rowIndex, testItem, "参数表读取失败");
                    return;
                }

                // 计算功率和效率
                double actualOutputPower = actualOutputVoltage * actualOutputCurrent;
                double actualInputPower = actualInputVoltage * autualInputCurrent;
                double actualEfficiency = (actualOutputPower / actualInputPower) * 100;

                // 判断是否合格
                string status = "Pass";
                // 1. 输入电压判断
                if (!IsInRange(actualInputVoltage, inputVoltageUpper, inputVoltageLower))
                    status = "False";
                // 3. 输出电流判断（允许±2%误差）
                else if (Math.Abs(actualOutputCurrent - loadCurrent) / loadCurrent > 0.02)
                    status = "False";
                // 3. 输出电流判断
                else if (!IsInRange(actualOutputCurrent, outputCurrentUpper, outputCurrentLower))
                    status = "False";
                // 4. 输出功率判断
                else if (!IsInRange(actualOutputPower, outputPowerUpper, outputPowerLower))
                    status = "False";
                // 5. 输入功率判断
                else if (!IsInRange(actualInputPower, inputPowerUpper, inputPowerLower))
                    status = "False";
                // 6. 效率判断
                else if (!IsInRange(actualEfficiency, efficiencyUpper, efficiencyLower))
                    status = "False";

                // 更新界面（通过 Invoke 确保在 UI 线程）
                // 在 ProcessTestRow 的末尾：
                object[] values = {
                        id, // Id
                        testItem, // TestItem
                        actualInputVoltage,
                        actualOutputVoltage,
                        actualOutputCurrent,
                        actualOutputPower,
                        actualInputPower,
                        actualEfficiency,
                        testWaitTime,
                        loadCurrent,
                        standard,
                        status // Status → 共 12 个元素
                    };
                // 构造包含 RowNumber 的参数数组
                object[] paramsWithRowNumber = new object[13] // 列数为 13（包括 RowNumber）
                   {
                        rowIndex + 1, // RowNumber
                        values[0],    // Id
                        values[1],    // TestItem
                        values[2],    // ActualInputVoltage
                        values[3],    // ActualOutputVoltage
                        values[4],    // ActualOutputCurrent
                        values[5],    // ActualOutputPower
                        values[6],    // ActualInputPower
                        values[7],    // ActualEfficiency
                        values[8],    // TestWaitTime
                        values[9],    // LoadCurrent
                        values[10],   // Standard
                        values[11]    // Status
               };
                UpdateDataGridView(rowIndex, paramsWithRowNumber); // 传递 13 个参数
            }

            catch (Exception ex)
            {
                UpdateErrorRow(rowIndex, testItem, "未知通信失败");
            }
            finally
            {
                // 确保关闭负载开关
                kp184.Seton(boardID, 0, waitTime);
            }
        }
        /// <summary>
        /// 通信失败的代码
        /// </summary>
        /// <param name="currentRow"></param>
        /// <param name="totalRows"></param>
        private void UpdateErrorRow(int rowIndex, string testItem,
          string errorMessage)
        {
            object[] errorValues = new object[12]
            {
                        rowIndex + 1, // RowNumber
                        testItem,     // TestItem（保留原值）
                        "N/A",        // ActualInputVoltage
                        "N/A",        // ActualOutputVoltage
                        "N/A",        // ActualOutputCurrent
                        "N/A",        // ActualOutputPower
                        "N/A",        // ActualInputPower
                        "N/A",        // ActualEfficiency
                        "N/A", // TestWaitTime
                        "N/A",  // LoadCurrent
                        "N/A",     // Standard
                        errorMessage  // Status → 具体错误信息
            };
            UpdateDataGridView(rowIndex, errorValues);
        }

        private void UpdateProgress(int currentRow, int totalRows)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action(() => UpdateProgress(currentRow, totalRows)));
                return;
            }

            progressBar1.Value = currentRow;
            //lblProgress.Text = $"正在测试第 {currentRow} 行/共 {totalRows} 行";
        }

        // 判断数值是否在范围内
        private bool IsInRange(double value, double upper, double lower)
        {
            return value >= lower && value <= upper;
        }

        // 更新 DataGridView
        private void UpdateDataGridView(int rowIndex, params object[] values)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new Action(() => UpdateDataGridView(rowIndex, values)));
                return;
            }
            if (values.Length < 12)
            {
                throw new ArgumentException("values 数组长度不足，无法更新 DataGridView。");
            }
            // 参数顺序：输出电压、输出电流、输出功率、输入功率、效率、状态
            dataGridView1.Rows[rowIndex].SetValues(
                rowIndex + 1, // 序号
                values[0],    // Id（隐藏列）
                values[1],    // TestItem
                values[2],    // ActualInputVoltage
                values[3],    // ActualOutputVoltage
                values[4],    // ActualOutputCurrent
                values[5],    // ActualOutputPower
                values[6],    // ActualInputPower
                values[7],    // ActualEfficiency
                values[8],    // TestWaitTime
                values[9],    // LoadCurrent
                values[10],   // Standard
                values[11]    // Status
            );
            // 更新合并列（示例）
            //输入电压
            dataGridView1.Rows[rowIndex].Cells["InputVoltageRange"].Value =
                $"{dataGridView1.Rows[rowIndex].Cells["InputVoltageLowerLimit"].Value}-" +
                $"{dataGridView1.Rows[rowIndex].Cells["InputVoltageUpperLimit"].Value}";
            //输出电压
            dataGridView1.Rows[rowIndex].Cells["OutputVoltageRange"].Value =
               $"{dataGridView1.Rows[rowIndex].Cells["OutputVoltageLowerLimit"].Value}-" +
               $"{dataGridView1.Rows[rowIndex].Cells["OutputVoltageUpperLimit"].Value}";
            //输出电流 
            dataGridView1.Rows[rowIndex].Cells["OutputCurrentRange"].Value =
               $"{dataGridView1.Rows[rowIndex].Cells["OutputCurrentLowerLimit"].Value}-" +
               $"{dataGridView1.Rows[rowIndex].Cells["OutputCurrentUpperLimit"].Value}";
            //输出功率
            dataGridView1.Rows[rowIndex].Cells["OutputPowerRange"].Value =
             $"{dataGridView1.Rows[rowIndex].Cells["OutputPowerLowerLimit"].Value}-" +
             $"{dataGridView1.Rows[rowIndex].Cells["OutputPowerUpperLimit"].Value}";
            //输入功率
            dataGridView1.Rows[rowIndex].Cells["InputPowerRange"].Value =
             $"{dataGridView1.Rows[rowIndex].Cells["InputPowerLowerLimit"].Value}-" +
             $"{dataGridView1.Rows[rowIndex].Cells["InputPowerUpperLimit"].Value}";
            //效率
            dataGridView1.Rows[rowIndex].Cells["EfficiencyRange"].Value =
             $"{dataGridView1.Rows[rowIndex].Cells["EfficiencyLowerLimit"].Value}-" +
             $"{dataGridView1.Rows[rowIndex].Cells["EfficiencyUpperLimit"].Value}";
        }

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
                    int rowIndex = 0;
                    while (reader.Read())
                    {
                        // 添加行并动态设置序号
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[rowIndex].Cells["RowNumber"].Value = rowIndex + 1;

                        // 填充其他列（确保顺序与数据库字段一致）
                        dataGridView1.Rows[rowIndex].Cells["Id"].Value = reader["Id"];
                        dataGridView1.Rows[rowIndex].Cells["TestItem"].Value = reader["TestItem"];
                        //实际数据
                        dataGridView1.Rows[rowIndex].Cells["ActualInputVoltage"].Value = reader["ActualInputVoltage"];
                        dataGridView1.Rows[rowIndex].Cells["ActualOutputVoltage"].Value = reader["ActualOutputVoltage"];
                        dataGridView1.Rows[rowIndex].Cells["ActualOutputCurrent"].Value = reader["ActualOutputCurrent"];
                        dataGridView1.Rows[rowIndex].Cells["ActualOutputPower"].Value = reader["ActualOutputPower"];
                        dataGridView1.Rows[rowIndex].Cells["ActualInputPower"].Value = reader["ActualInputPower"];
                        dataGridView1.Rows[rowIndex].Cells["ActualEfficiency"].Value = reader["ActualEfficiency"];

                        dataGridView1.Rows[rowIndex].Cells["TestWaitTime"].Value = reader["TestWaitTime"];

                        dataGridView1.Rows[rowIndex].Cells["LoadCurrent"].Value = reader["LoadCurrent"];
                        dataGridView1.Rows[rowIndex].Cells["Standard"].Value = reader["Standard"];
                        dataGridView1.Rows[rowIndex].Cells["Status"].Value = reader["Status"];
                        dataGridView1.Rows[rowIndex].Cells["InputVoltageUpperLimit"].Value = reader["InputVoltageUpperLimit"];
                        dataGridView1.Rows[rowIndex].Cells["InputVoltageLowerLimit"].Value = reader["InputVoltageLowerLimit"];
                        dataGridView1.Rows[rowIndex].Cells["OutputVoltageUpperLimit"].Value = reader["OutputVoltageUpperLimit"];
                        dataGridView1.Rows[rowIndex].Cells["OutputVoltageLowerLimit"].Value = reader["OutputVoltageLowerLimit"];
                        dataGridView1.Rows[rowIndex].Cells["OutputCurrentUpperLimit"].Value = reader["OutputCurrentUpperLimit"];
                        dataGridView1.Rows[rowIndex].Cells["OutputCurrentLowerLimit"].Value = reader["OutputCurrentLowerLimit"];
                        dataGridView1.Rows[rowIndex].Cells["OutputPowerUpperLimit"].Value = reader["OutputPowerUpperLimit"];
                        dataGridView1.Rows[rowIndex].Cells["OutputPowerLowerLimit"].Value = reader["OutputPowerLowerLimit"];
                        dataGridView1.Rows[rowIndex].Cells["InputPowerUpperLimit"].Value = reader["InputPowerUpperLimit"];
                        dataGridView1.Rows[rowIndex].Cells["InputPowerLowerLimit"].Value = reader["InputPowerLowerLimit"];
                        dataGridView1.Rows[rowIndex].Cells["EfficiencyUpperLimit"].Value = reader["EfficiencyUpperLimit"];
                        dataGridView1.Rows[rowIndex].Cells["EfficiencyLowerLimit"].Value = reader["EfficiencyLowerLimit"];

                        // 合并输入电压限
                        dataGridView1.Rows[rowIndex].Cells["InputVoltageRange"].Value =
                            $"{reader["InputVoltageLowerLimit"]}-{reader["InputVoltageUpperLimit"]}";
                        // 合并输出电压限
                        dataGridView1.Rows[rowIndex].Cells["OutputVoltageRange"].Value =
                            $"{reader["OutputVoltageLowerLimit"]}-{reader["OutputVoltageUpperLimit"]}";
                        // 合并输出电流限
                        dataGridView1.Rows[rowIndex].Cells["OutputCurrentRange"].Value =
                            $"{reader["OutputCurrentLowerLimit"]}-{reader["OutputCurrentUpperLimit"]}";
                        // 合并输出功率限
                        dataGridView1.Rows[rowIndex].Cells["OutputPowerRange"].Value =
                            $"{reader["OutputPowerLowerLimit"]}-{reader["OutputPowerUpperLimit"]}";
                        // 合并输入功率限
                        dataGridView1.Rows[rowIndex].Cells["InputPowerRange"].Value =
                            $"{reader["InputPowerLowerLimit"]}-{reader["InputPowerUpperLimit"]}";
                        // 合并效率限
                        dataGridView1.Rows[rowIndex].Cells["EfficiencyRange"].Value =
                            $"{reader["EfficiencyLowerLimit"]}-{reader["EfficiencyUpperLimit"]}";
                        rowIndex++;
                    }
                }
                conn.Close();
            }
            RefreshRowNumbers(); // 确保序号从1开始
        }

        #endregion

        // 刷新序号（确保每次操作后重新生成）
        private void RefreshRowNumbers()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["RowNumber"].Value = i + 1;
            }
        }
        #endregion

        // 导出 Excel
        private void ExportToExcel()
        {

            // 创建保存对话框
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel 文件|*.xlsx",
                Title = "保存为 Excel 文件"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    // 设置 EPPlus 许可（非商业用途）
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    // 创建 Excel 文件
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        // 创建工作表
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("测试结果");

                        // 写入表头和数据时，仅处理可见列
                        int currentColumn = 1; // 轨迹当前列号

                        // 写入表头
                        for (int col = 0; col < dataGridView1.Columns.Count; col++)
                        {
                            if (!dataGridView1.Columns[col].Visible) continue; // 跳过隐藏列
                            worksheet.Cells[1, currentColumn].Value = dataGridView1.Columns[col].HeaderText;
                            currentColumn++;
                        }

                        // 写入数据
                        for (int row = 0; row < dataGridView1.Rows.Count; row++)
                        {
                            currentColumn = 1; // 每行重置列号
                            for (int col = 0; col < dataGridView1.Columns.Count; col++)
                            {
                                if (!dataGridView1.Columns[col].Visible) continue; // 跳过隐藏列
                                worksheet.Cells[row + 2, currentColumn].Value = dataGridView1.Rows[row].Cells[col].Value?.ToString();
                                currentColumn++;
                            }
                        }

                        // 自动调整列宽（仅调整可见列的数量）
                        int maxColumn = currentColumn - 1; // 最后一列的列号
                        for (int i = 1; i <= maxColumn; i++)
                        {
                            worksheet.Column(i).AutoFit();
                        }

                        // 保存文件
                        File.WriteAllBytes(saveFileDialog.FileName, package.GetAsByteArray());
                        MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"导出失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}






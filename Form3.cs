using Sunisoft.IrisSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestPower
{
    public partial class Form3: Form
    {
        private DatabaseHelper dbHelper;
        //private SkinEngine skinEngine1;

        public Form3(DatabaseHelper dbHelper)
        {
            InitializeComponent();

            //this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            //this.skinEngine1.SkinFile = Application.StartupPath + "\\DeepCyan.ssk"; // 注意：这里的文件名需要与debug文件夹中的皮肤文件名一致
            this.dbHelper = dbHelper;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        #region 事件处理
        // 点击“保存”按钮
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection conn = dbHelper.GetConnection())//ActualInputVoltage, ActualOutputVoltage, ActualOutputCurrent, ActualOutputPower, ActualInputPower, ActualEfficiency ,
                {                                       // @ActualInputVoltage, @ActualOutputVoltage, @ActualOutputCurrent,@ActualOutputPower, @ActualInputPower, @ActualEfficiency,
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(
               "INSERT INTO TestResults (" +
               "TestItem,TestWaitTime, LoadCurrent, Standard, Status, InputVoltageUpperLimit, " +
               "InputVoltageLowerLimit, OutputVoltageUpperLimit, OutputVoltageLowerLimit, " +
               "OutputCurrentUpperLimit, OutputCurrentLowerLimit, OutputPowerUpperLimit, " +
               "OutputPowerLowerLimit, InputPowerUpperLimit, InputPowerLowerLimit, " +
               "EfficiencyUpperLimit, EfficiencyLowerLimit) " +
               "VALUES (@TestItem,@TestWaitTime, @LoadCurrent, @Standard, @Status, " +
               "@InputVoltageUpperLimit, @InputVoltageLowerLimit, " +
               "@OutputVoltageUpperLimit, @OutputVoltageLowerLimit, " +
               "@OutputCurrentUpperLimit, @OutputCurrentLowerLimit, " +
               "@OutputPowerUpperLimit, @OutputPowerLowerLimit, " +
               "@InputPowerUpperLimit, @InputPowerLowerLimit, " +
               "@EfficiencyUpperLimit, @EfficiencyLowerLimit)",
               conn
                   );
                    // 设置所有参数值
                    cmd.Parameters.AddWithValue("@TestItem", textBox1.Text);

                    //cmd.Parameters.AddWithValue("@ActualInputVoltage", "未测试");
                    //cmd.Parameters.AddWithValue("@ActualOutputVoltage", "未测试");
                    //cmd.Parameters.AddWithValue("@ActualOutputCurrent", "未测试");
                    //cmd.Parameters.AddWithValue("@ActualOutputPower", "未测试");
                    //cmd.Parameters.AddWithValue("@ActualInputPower", "未测试");
                    //cmd.Parameters.AddWithValue("@ActualEfficiency", "未测试");


                    cmd.Parameters.AddWithValue("@TestWaitTime", Convert.ToInt32(textBox2.Text));
                    cmd.Parameters.AddWithValue("@LoadCurrent", Convert.ToDouble(textBox3.Text));
                    cmd.Parameters.AddWithValue("@Standard", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Status", "未测试"); // 初始状态为“未测试”
                    cmd.Parameters.AddWithValue("@InputVoltageUpperLimit", Convert.ToDouble(textBox5.Text));
                    cmd.Parameters.AddWithValue("@InputVoltageLowerLimit", Convert.ToDouble(textBox6.Text));
                    cmd.Parameters.AddWithValue("@OutputVoltageUpperLimit", Convert.ToDouble(textBox7.Text));
                    cmd.Parameters.AddWithValue("@OutputVoltageLowerLimit", Convert.ToDouble(textBox8.Text));
                    cmd.Parameters.AddWithValue("@OutputCurrentUpperLimit", Convert.ToDouble(textBox9.Text));
                    cmd.Parameters.AddWithValue("@OutputCurrentLowerLimit", Convert.ToDouble(textBox10.Text));
                    cmd.Parameters.AddWithValue("@OutputPowerUpperLimit", Convert.ToDouble(textBox11.Text));
                    cmd.Parameters.AddWithValue("@OutputPowerLowerLimit", Convert.ToDouble(textBox12.Text));
                    cmd.Parameters.AddWithValue("@InputPowerUpperLimit", Convert.ToDouble(textBox13.Text));
                    cmd.Parameters.AddWithValue("@InputPowerLowerLimit", Convert.ToDouble(textBox14.Text));
                    cmd.Parameters.AddWithValue("@EfficiencyUpperLimit", Convert.ToDouble(textBox15.Text));
                    cmd.Parameters.AddWithValue("@EfficiencyLowerLimit", Convert.ToDouble(textBox16.Text));
                   
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("保存成功！");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败：" + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
        #endregion
    }
}


using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPower
{
    /// <summary>
    /// 数据库操作类，负责创建和管理 SQLite 数据库。
    /// </summary>
    public class DatabaseHelper
    {
        private string dbPath;
     

        /// <summary>
        /// 初始化数据库连接。
        /// </summary>
        /// <param name="dbPath">数据库文件路径</param>
        public DatabaseHelper(string dbPath)
        {
            this.dbPath = dbPath;
            InitializeDatabase(); // 每次初始化都创建表
        }


        public string GetSetting(string key)
        {
            using (SQLiteConnection conn = GetConnection())
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(
                    "SELECT Value FROM Settings WHERE Key = @Key",
                    conn))
                {
                    cmd.Parameters.AddWithValue("@Key", key);
                    object result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "";
                }
            }
        }

        public void SaveSetting(string key, string value)
        {
            using (SQLiteConnection conn = GetConnection())
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(
                    "INSERT OR REPLACE INTO Settings (Key, Value) VALUES (@Key, @Value)",
                    conn))
                {
                    cmd.Parameters.AddWithValue("@Key", key);
                    cmd.Parameters.AddWithValue("@Value", value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// 初始化数据库
        /// </summary>
        /// <param name="dbPath"></param>
        private void InitializeDatabase()
        {
            if (!File.Exists(dbPath))
            {
                using (SQLiteConnection conn = GetConnection())
                {
                    conn.Open();
                    CreateTables(conn);
                    conn.Close();
                }
            }
            else
            {
                // 如果表已存在，尝试添加缺失的列
                using (SQLiteConnection conn = GetConnection())
                {
                    conn.Open();
                    AddMissingColumns(conn); // 添加可能缺失的列
                    conn.Close();
                }
            }
        }

        // 创建表结构
        private void CreateTables(SQLiteConnection conn)
        {
            string sql = @"
                CREATE TABLE TestResults (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    TestItem TEXT,
                    ActualInputVoltage REAL; 
                    ActualOutputVoltage REAL;  
                    ActualOutputCurrent REAL; 
                    ActualOutputPower REAL; 
                    ActualInputPower REAL;  
                    ActualEfficiency REAL;
                    TestWaitTime INT,           -- 新增：测试等待时间（毫秒）
                    LoadCurrent REAL,
                    Standard TEXT,
                    Status TEXT,
                    InputVoltageUpperLimit REAL,   -- 输入电压上限
                    InputVoltageLowerLimit REAL,   -- 输入电压下限
                    OutputVoltageUpperLimit REAL,  -- 输出电压上限
                    OutputVoltageLowerLimit REAL,  -- 输出电压下限
                    OutputCurrentUpperLimit REAL,  -- 输出电流上限
                    OutputCurrentLowerLimit REAL,  -- 输出电流下限
                    OutputPowerUpperLimit REAL,    -- 输出功率上限
                    OutputPowerLowerLimit REAL,    -- 输出功率下限
                    InputPowerUpperLimit REAL,     -- 输入功率上限
                    InputPowerLowerLimit REAL,     -- 输入功率下限
                    EfficiencyUpperLimit REAL,      -- 效率上限
                    EfficiencyLowerLimit REAL       -- 效率下限
                   
                );";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        // 添加缺失的列（如 TestWaitTime）
        private void AddMissingColumns(SQLiteConnection conn)
        {
            string[] columnsToAdd = new string[]
            {
                "ALTER TABLE TestResults ADD COLUMN TestWaitTime INT;", // 添加 TestWaitTime 列
                "ALTER TABLE TestResults ADD COLUMN Status TEXT;"       // 添加 Status 列
            };

            foreach (var column in columnsToAdd)
            {
                try
                {
                    new SQLiteCommand(column, conn).ExecuteNonQuery();
                }
                catch { /* 忽略已存在的列 */ }
            }
        }
        // 获取数据库连接
        // 获取新连接
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection($"Data Source={dbPath};Version=3;");
        }
    }
}
    


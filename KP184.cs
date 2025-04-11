    using HslCommunication.ModBus;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace TestPower
    {
            public   class KP184 
        {
            private Int32 PortNumber = 0;
            private Int32 baudRate = 0;

            public KP184(Int32 Port, Int32 BaudRate)
            {
         
                PortNumber = Port;
                this.baudRate = BaudRate; // 修正字段名（原代码是小写的 baudRate）
            }
            /// <summary>
            /// 读取当前电压电流功率值
            /// </summary>
            /// <returns></returns>
            public int[] GetALL(Int32 BoardID, Int32 WaitTime = 500)
            {
                int[] v = new int[] { -999, -999 };
                ModbusRtu modus = new ModbusRtu((byte)BoardID);
                try
                {
                    modus.SerialPortInni("COM" + PortNumber, baudRate);
                    modus.Open();
                    modus.ReceiveTimeOut = WaitTime;
                    modus.DataFormat = HslCommunication.Core.DataFormat.ABCD;
                    HslCommunication.OperateResult<Int32[]> read = modus.ReadInt32("290", 2);
                    modus.Close();
                    if (read.IsSuccess)
                    {
                        v[0] = (int)(read.Content[0] / 1000.0);
                        v[1] = (int)(read.Content[1] / 1000.0);
                        //v[2] = read.Content[2];
                    }

                    return v;
                }
                catch (Exception ex)
                {
                    // 记录错误日志
                    System.Diagnostics.Debug.WriteLine($"KP184 GetALL 错误: {ex.Message}");    
                    if (modus.IsOpen())
                        modus.Close();
                    return v;
                }
            }


            /// <summary>
            /// 写入开关状态
            /// </summary>
            /// <returns></returns>
            public bool Seton(Int32 BoardID, int onoff, Int32 WaitTime = 500)
            {
                ModbusRtu modus = new ModbusRtu((byte)BoardID);
                try
                {
                    modus.SerialPortInni("COM" + PortNumber, baudRate);
                    modus.Open();
                    modus.ReceiveTimeOut = WaitTime;
                    modus.DataFormat = HslCommunication.Core.DataFormat.ABCD;
                    HslCommunication.OperateResult writeResult = modus.Write("270", onoff);

                    modus.Close();
                    if (writeResult.IsSuccess)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    // 记录错误日志
                    System.Diagnostics.Debug.WriteLine($"KP184 Seton 错误: {ex.Message}");
                    if (modus.IsOpen())
                        modus.Close();
                    return false;
                }
            }
            /// <summary>
            /// 写入加载模式
            /// </summary>
            /// <returns></returns>
            public bool SetMode(Int32 BoardID, int mode, Int32 WaitTime = 500)
            {
                ModbusRtu modus = new ModbusRtu((byte)BoardID);
                try
                {
                    modus.SerialPortInni("COM" + PortNumber, baudRate);
                    modus.Open();
                    modus.ReceiveTimeOut = WaitTime;
                    modus.DataFormat = HslCommunication.Core.DataFormat.ABCD;
                    HslCommunication.OperateResult writeResult = modus.Write("272", mode);
                    modus.Close();
                    if (writeResult.IsSuccess)
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    // 记录错误日志
                    System.Diagnostics.Debug.WriteLine($"KP184 SetMode 错误: {ex.Message}");
                    if (modus.IsOpen())
                        modus.Close();
                    return false;
                }

            }
            /// <summary>
            /// 写入电流加载值
            /// </summary>
            /// <returns></returns>
            public bool SetSetting(Int32 BoardID, int setting, Int32 WaitTime = 500)
            {
            
                ModbusRtu modus = new ModbusRtu((byte)BoardID);

                try
                {
                    modus.SerialPortInni("COM" + PortNumber, baudRate);
                    modus.Open();
                    modus.ReceiveTimeOut = WaitTime;
                    modus.DataFormat = HslCommunication.Core.DataFormat.ABCD;
                    HslCommunication.OperateResult writeResult = modus.Write("278", setting);

                    modus.Close();
                    if (writeResult.IsSuccess)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    // 记录错误日志
                    System.Diagnostics.Debug.WriteLine($"KP184 SetMode 错误: {ex.Message}");
                    if (modus.IsOpen())
                        modus.Close();
                    return false;
                }

            }

        }
    }


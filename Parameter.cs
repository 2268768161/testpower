using HslCommunication.ModBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPower
{
    class Parameter 
    {
       
        private Int32 PortNumber;
        private Int32 baudRate;

        public Parameter(Int32 Port, Int32 BaudRate)
        {
           
            PortNumber = Port;
            baudRate = BaudRate;
        }
        /// <summary>
        /// 读取当前电压值
        /// </summary>
        /// <param name="Port"></param>
        /// <returns></returns>
        public int GetVolt(Int32 BoardID, Int32 WaitTime = 500)
        {
            int rpm = -999;
            ModbusRtu modus = new ModbusRtu((byte)BoardID);

            try
            {
                modus.SerialPortInni("COM" + PortNumber, baudRate);
                modus.Open();
                modus.ReceiveTimeOut = WaitTime;
                modus.DataFormat = HslCommunication.Core.DataFormat.ABCD;
                HslCommunication.OperateResult<int> read = modus.ReadInt32("290");

                modus.Close();
                if (read.IsSuccess)
                {
                    rpm = read.Content;
                }

                return rpm;
            }
            catch (Exception ex)
            {
                // 记录错误日志
                System.Diagnostics.Debug.WriteLine($"KP184 GetVolt 错误: {ex.Message}");
                if (modus.IsOpen())
                    modus.Close();
                return rpm;
            }
        }

        /// <summary>
        /// 读取当前电流值
        /// </summary>
        /// <returns></returns>
        public int GetCurr(Int32 BoardID, Int32 WaitTime = 500)
        {
            int rpm = -999;
            ModbusRtu modus = new ModbusRtu((byte)BoardID);
            try
            {
                modus.SerialPortInni("COM" + PortNumber, baudRate);
                modus.Open();
                modus.ReceiveTimeOut = WaitTime;
                modus.DataFormat = HslCommunication.Core.DataFormat.ABCD;
                HslCommunication.OperateResult<int> read = modus.ReadInt32("294");

                modus.Close();

                if (read.IsSuccess)
                {
                    rpm = read.Content;
                }

                return rpm;
            }
            catch (Exception ex)
            {
                // 记录错误日志
                System.Diagnostics.Debug.WriteLine($"KP184 GetCurr 错误: {ex.Message}");
                if (modus.IsOpen())
                    modus.Close();
                return rpm;
            }
        }

        /// <summary>
        /// 读取当前功率值
        /// </summary>
        /// <returns></returns>
        public int GetPower(Int32 BoardID, Int32 WaitTime = 500)
        {
            int rpm = -999;
            ModbusRtu modus = new ModbusRtu((byte)BoardID);

            try
            {

                modus.SerialPortInni("COM" + PortNumber, baudRate);
                modus.Open();
                modus.ReceiveTimeOut = WaitTime;
                modus.DataFormat = HslCommunication.Core.DataFormat.ABCD;
                HslCommunication.OperateResult<int> read = modus.ReadInt32("286");

               
                modus.Close();

                if (read.IsSuccess)
                {
                    rpm = read.Content;
                }

                return rpm;
            }
            catch (Exception)
            {
                if (modus.IsOpen())
                    modus.Close();
                return rpm;
            }

        }

        /// <summary>
        /// 读取当前电压电流功率值
        /// </summary>
        /// <returns></returns>
        public int[] GetALL(Int32 BoardID, Int32 WaitTime = 500)
        {
            int[] v = new int[] { -999, -999, -999 };
            ModbusRtu modus = new ModbusRtu((byte)BoardID);

            try
            {

                modus.SerialPortInni("COM" + PortNumber, baudRate);
                modus.Open();
                modus.ReceiveTimeOut = WaitTime;
                modus.DataFormat = HslCommunication.Core.DataFormat.ABCD;
                HslCommunication.OperateResult<float[]> read = modus.ReadFloat("290", 2);

                if (read.IsSuccess)
                {
                    v[0] = (int)read.Content[0];
                    v[1] = (int)read.Content[1];
                    v[2] = (int)read.Content[2];
                }

                modus.Close();

                return v;
            }
            catch (Exception)
            {
                if (modus.IsOpen())
                    modus.Close();
                return v;
            }
        }

        /// <summary>
        /// 读取当前电压电流功率值
        /// </summary>
        /// <returns></returns>
        public Double[] GetALL2(Int32 BoardID, Int32 WaitTime = 500)
        {
            Double[] v = new Double[] { -999, -999, -999, -999, -999 };
            ModbusRtu modus = new ModbusRtu((byte)BoardID);

            try
            {

                modus.SerialPortInni("COM" + PortNumber, baudRate);
                modus.Open();
                modus.ReceiveTimeOut = WaitTime;
                modus.DataFormat = HslCommunication.Core.DataFormat.ABCD;
                HslCommunication.OperateResult<float[]> read = modus.ReadFloat("4096", 5);

                if (read.IsSuccess)
                {
                    v[0] = read.Content[0];
                    v[1] = read.Content[1];
                    v[2] = read.Content[2];
                    v[3] = read.Content[3];
                    v[4] = read.Content[4];
                }

                modus.Close();

                return v;
            }
            catch (Exception)
            {
                if (modus.IsOpen())
                    modus.Close();
                return v;
            }
        }


        /// <summary>
        /// 设备自检
        /// </summary>
        /// <returns></returns>
        public Boolean SelfTest(Int32 BoardID)
        {
            try
            {
                if (GetVolt(BoardID) == -999)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
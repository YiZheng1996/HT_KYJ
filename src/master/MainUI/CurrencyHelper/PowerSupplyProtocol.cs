using System.IO.Ports;
using static MainUI.CurrencyHelper.PowerSupplyProtocol;

namespace MainUI.CurrencyHelper
{
    // <summary>
    /// 调频电源RS485通讯协议类
    /// </summary>
    public class PowerSupplyProtocol : IDisposable
    {
        private readonly SerialPort _serialPort;
        private readonly object lockObject = new();

        /// <summary>
        /// 电源故障类型枚举
        /// </summary>
        public enum FaultType
        {
            Normal = 0,         // 智能电源正常
            OverTemperature = 1, // 过温保护
            Overload = 2,       // 过载保护  
            OverVoltage = 3,    // 过压保护
            PowerFailure = 4,   // 输入掉电保护
            ShortCircuit = 5    // 短路保护/器件故障保护
        }

        /// <summary>
        /// 输出档位枚举
        /// </summary>
        public enum OutputRange
        {
            High = 0,   // 高档输出 0-300V/21A
            Low = 1     // 低档输出 0-150V/42A
        }

        /// <summary>
        /// 控制模式枚举
        /// </summary>
        public enum ControlMode
        {
            Local = 0,      // 本机控制
            Remote = 1      // 电脑控制
        }

        /// <summary>
        /// 相别枚举
        /// </summary>
        public enum Phase
        {
            U = 1,
            V = 2,
            W = 3
        }

        /// <summary>
        /// 数据类型枚举
        /// </summary>
        public enum DataType
        {
            Current = 1,    // 电流 (数据4: 1-3)
            Voltage = 4,    // 电压 (数据4: 4-6)  
            Power = 7,      // 功率 (数据4: 7-9)
            Frequency = 0   // 频率 (数据4: 0)
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="portName">串口名称</param>
        /// <param name="baudRate">波特率，默认9600</param>
        public PowerSupplyProtocol(string portName, int baudRate = 9600)
        {
            _serialPort = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
            _serialPort.ReadTimeout = 1000;
            _serialPort.WriteTimeout = 1000;
        }

        /// <summary>
        /// 打开串口连接
        /// </summary>
        public void Open()
        {
            if (!_serialPort.IsOpen)
            {
                _serialPort.Open();
            }
        }

        /// <summary>
        /// 关闭串口连接
        /// </summary>
        public void Close()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }

        /// <summary>
        /// 计算异或校验值
        /// </summary>
        private byte CalculateChecksum(byte[] data)
        {
            byte checksum = 0;
            for (int i = 0; i < 6; i++) // 前6个字节参与校验
            {
                checksum ^= data[i];
            }
            return checksum;
        }

        /// <summary>
        /// 发送命令并接收响应
        /// </summary>
        private byte[] SendCommand(byte address, byte command, byte data1, byte data2, byte data3, byte data4)
        {
            lock (lockObject)
            {
                try
                {
                    if (!_serialPort.IsOpen)
                    {
                        throw new InvalidOperationException("串口未打开");
                    }

                    // 构建命令帧
                    byte[] frame = new byte[7];
                    frame[0] = address;
                    frame[1] = command;
                    frame[2] = data1;
                    frame[3] = data2;
                    frame[4] = data3;
                    frame[5] = data4;
                    frame[6] = CalculateChecksum(frame);

                    // 清空缓冲区
                    _serialPort.DiscardInBuffer();
                    _serialPort.DiscardOutBuffer();

                    // 发送命令
                    _serialPort.Write(frame, 0, frame.Length);

                    // 接收响应 - 使用更短的超时和非阻塞方式
                    byte[] response = new byte[7];
                    int totalBytes = 0;
                    DateTime startTime = DateTime.Now;
                    const int timeoutMs = 200; // 缩短超时时间到200ms

                    while (totalBytes < 7 && (DateTime.Now - startTime).TotalMilliseconds < timeoutMs)
                    {
                        if (_serialPort.BytesToRead > 0)
                        {
                            try
                            {
                                int bytesRead = _serialPort.Read(response, totalBytes, 7 - totalBytes);
                                totalBytes += bytesRead;
                            }
                            catch (TimeoutException)
                            {
                                // 读取超时，继续等待
                                continue;
                            }
                        }
                        Thread.Sleep(1); // 短暂休眠避免CPU占用过高
                    }

                    if (totalBytes == 7)
                    {
                        // 验证校验和
                        byte calculatedChecksum = 0;
                        for (int i = 0; i < 6; i++)
                        {
                            calculatedChecksum ^= response[i];
                        }

                        if (calculatedChecksum == response[6])
                        {
                            return response;
                        }
                        else
                        {
                            throw new InvalidOperationException("校验和错误");
                        }
                    }
                    else
                    {
                        throw new TimeoutException($"接收响应超时，实际接收{totalBytes}字节");
                    }
                }
                catch (Exception ex)
                {
                    // 记录详细错误信息
                    Console.WriteLine($"通讯失败: {ex.Message}");
                    throw;
                }
            }
        }

        /// <summary>
        /// 设置控制模式
        /// </summary>
        public bool SetControlMode(ControlMode mode)
        {
            byte[] response = SendCommand(0x08, 0x00, (byte)mode, 0x00, 0x00, 0x00);
            return response != null && response[2] == (byte)mode;
        }

        /// <summary>
        /// 设置输出档位
        /// </summary>
        public bool SetOutputRange(OutputRange range)
        {
            byte[] response = SendCommand(0x08, 0x01, (byte)range, 0x00, 0x00, 0x00);
            return response != null && response[2] == (byte)range;
        }

        /// <summary>
        /// 设置电压给定值
        /// </summary>
        /// <param name="voltage">电压值</param>
        /// <param name="range">档位</param>
        public bool SetVoltage(double voltage, OutputRange range)
        {
            byte command = (byte)(range == OutputRange.Low ? 0x02 : 0x03);

            // 电压值转换为数据格式 (例: 150.0V -> 数据1=01, 数据2=05)
            int voltageInt = (int)(voltage * 10);
            byte data1 = (byte)(voltageInt / 1000);
            byte data2 = (byte)((voltageInt % 1000) / 100);

            byte[] response = SendCommand(0x08, command, data1, data2, 0x00, 0x00);
            return response != null && response[2] == data1 && response[3] == data2;
        }

        /// <summary>
        /// 设置频率给定值
        /// </summary>
        /// <param name="frequency">频率值 (40-70HZ)</param>
        public bool SetFrequency(double frequency)
        {
            // 限制频率范围
            if (frequency < 40) frequency = 40;
            if (frequency > 70) frequency = 70;

            int frequencyInt = (int)(frequency * 10);
            byte data2 = (byte)(frequencyInt / 100);

            byte[] response = SendCommand(0x08, 0x05, 0x00, data2, 0x00, 0x00);
            return response != null;
        }

        /// <summary>
        /// 电源复位
        /// </summary>
        public bool PowerReset()
        {
            byte[] response = SendCommand(0x08, 0x04, 0x00, 0x00, 0x00, 0x00);
            return response != null;
        }

        /// <summary>
        /// 查询故障状态
        /// </summary>
        public FaultType QueryFaultStatus()
        {
            byte[] response = SendCommand(0x08, 0x06, 0x00, 0x00, 0x00, 0x00);
            if (response != null && response.Length >= 6)
            {
                return (FaultType)response[5];
            }
            return FaultType.Normal;
        }

        /// <summary>
        /// 读取电流值
        /// </summary>
        /// <param name="phase">相别</param>
        /// <returns>电流值(A)</returns>
        public double ReadCurrent(Phase phase)
        {
            byte[] response = SendCommand(0x07, 0x00, 0x00, 0x00, 0x00, (byte)phase);
            if (response != null && response.Length >= 6)
            {
                // 解析电流值: 数据3和数据4组成电流值
                double current = response[4] + response[5] * 0.1;
                return current;
            }
            return 0;
        }

        /// <summary>
        /// 读取电压值
        /// </summary>
        /// <param name="phase">相别</param>
        /// <returns>电压值(V)</returns>
        public double ReadVoltage(Phase phase)
        {
            byte dataType = (byte)((int)DataType.Voltage + (int)phase - 1);
            byte[] response = SendCommand(0x07, 0x00, 0x00, 0x00, 0x00, dataType);
            if (response != null && response.Length >= 6)
            {
                // 解析电压值: 数据1和数据2组成电压值 (例: 01 05 -> 150.0V)
                double voltage = response[2] * 100 + response[3] * 10;
                return voltage;
            }
            return 0;
        }

        /// <summary>
        /// 读取功率值
        /// </summary>
        /// <param name="phase">相别</param>
        /// <returns>功率值(W)</returns>
        public double ReadPower(Phase phase)
        {
            byte dataType = (byte)((int)DataType.Power + (int)phase - 1);
            byte[] response = SendCommand(0x07, 0x00, 0x00, 0x00, 0x00, dataType);
            if (response != null && response.Length >= 6)
            {
                // 解析功率值: 数据2和数据3组成功率值 (例: 09 01 -> 910W)
                double power = response[3] * 100 + response[4] * 10;
                return power;
            }
            return 0;
        }

        /// <summary>
        /// 读取输出频率
        /// </summary>
        /// <returns>频率值(HZ)</returns>
        public double ReadFrequency()
        {
            byte[] response = SendCommand(0x07, 0x00, 0x00, 0x00, 0x00, 0x00);
            if (response != null && response.Length >= 6)
            {
                // 解析频率值: 数据2组成频率值 (例: 05 -> 50.0HZ)
                double frequency = response[3] * 10;
                return frequency;
            }
            return 0;
        }

        /// <summary>
        /// 读取所有三相电流
        /// </summary>
        public (double U, double V, double W) ReadAllCurrents()
        {
            return (ReadCurrent(Phase.U), ReadCurrent(Phase.V), ReadCurrent(Phase.W));
        }

        /// <summary>
        /// 读取所有三相电压
        /// </summary>
        public (double U, double V, double W) ReadAllVoltages()
        {
            return (ReadVoltage(Phase.U), ReadVoltage(Phase.V), ReadVoltage(Phase.W));
        }

        /// <summary>
        /// 读取所有三相功率
        /// </summary>
        public (double U, double V, double W) ReadAllPowers()
        {
            return (ReadPower(Phase.U), ReadPower(Phase.V), ReadPower(Phase.W));
        }

        /// <summary>
        /// 异步读取所有三相电压（带超时控制）
        /// </summary>
        public async Task<(double U, double V, double W)> ReadAllVoltagesAsync(CancellationToken cancellationToken = default)
        {
            var tasks = new[]
            {
            Task.Run(() => ReadVoltage(Phase.U), cancellationToken),
            Task.Run(() => ReadVoltage(Phase.V), cancellationToken),
            Task.Run(() => ReadVoltage(Phase.W), cancellationToken)
        };

            try
            {
                var results = await Task.WhenAll(tasks);
                return (results[0], results[1], results[2]);
            }
            catch (OperationCanceledException)
            {
                return (0.0, 0.0, 0.0);
            }
        }

        /// <summary>
        /// 异步读取所有三相电流（带超时控制）
        /// </summary>
        public async Task<(double U, double V, double W)> ReadAllCurrentsAsync(CancellationToken cancellationToken = default)
        {
            var tasks = new[]
            {
            Task.Run(() => ReadCurrent(Phase.U), cancellationToken),
            Task.Run(() => ReadCurrent(Phase.V), cancellationToken),
            Task.Run(() => ReadCurrent(Phase.W), cancellationToken)
        };

            try
            {
                var results = await Task.WhenAll(tasks);
                return (results[0], results[1], results[2]);
            }
            catch (OperationCanceledException)
            {
                return (0.0, 0.0, 0.0);
            }
        }

        /// <summary>
        /// 异步读取所有三相功率（带超时控制）
        /// </summary>
        public async Task<(double U, double V, double W)> ReadAllPowersAsync(CancellationToken cancellationToken = default)
        {
            var tasks = new[]
            {
            Task.Run(() => ReadPower(Phase.U), cancellationToken),
            Task.Run(() => ReadPower(Phase.V), cancellationToken),
            Task.Run(() => ReadPower(Phase.W), cancellationToken)
        };

            try
            {
                var results = await Task.WhenAll(tasks);
                return (results[0], results[1], results[2]);
            }
            catch (OperationCanceledException)
            {
                return (0.0, 0.0, 0.0);
            }
        }

        /// <summary>
        /// 异步读取频率（带超时控制）
        /// </summary>
        public async Task<double> ReadFrequencyAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => ReadFrequency(), cancellationToken);
        }

        /// <summary>
        /// 异步查询故障状态（带超时控制）
        /// </summary>
        public async Task<FaultType> QueryFaultStatusAsync(CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => QueryFaultStatus(), cancellationToken);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            Close();
            _serialPort?.Dispose();
        }
    }

    /// <summary>
    /// 电源数据结构
    /// </summary>
    public class PowerSupplyData
    {
        public double VoltageU { get; set; }
        public double VoltageV { get; set; }
        public double VoltageW { get; set; }
        public double CurrentU { get; set; }
        public double CurrentV { get; set; }
        public double CurrentW { get; set; }
        public double PowerU { get; set; }
        public double PowerV { get; set; }
        public double PowerW { get; set; }
        public double Frequency { get; set; }
        public FaultType FaultStatus { get; set; }
        public DateTime UpdateTime { get; set; }

        public double TotalPower => PowerU + PowerV + PowerW;
        public bool IsConnected { get; set; }
    }
}

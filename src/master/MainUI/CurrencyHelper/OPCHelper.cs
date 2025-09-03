using RW.Driver;

namespace MainUI.CurrencyHelper
{
    public class OPCHelper
    {
        #region OPCDriver
        public static OPCDriver opcAIGroup = new();
        public static OPCDriver opcAOGroup = new();
        public static OPCDriver opcDIGroup = new();
        public static OPCDriver opcDOGroup = new();
        public static OPCDriver opcStatusGroup = new();
        public static OPCDriver opcTestConGroup = new();
        // 串口通讯使用
        public static OPCDriver opcWSD = new();
        public static OPCDriver opcHJYL = new();
        public static OPCDriver opcYL01 = new();
        public static OPCDriver opcYL02 = new();
        public static OPCDriver opcYL03 = new();
        public static OPCDriver opcTemperature = new();
        #endregion

        #region opcGroup
        public static OpcStatusGrp opcStatus;
        public static AIGrp AIgrp;
        public static AOGrp AOgrp;
        public static DIGrp DIgrp;
        public static DOGrp DOgrp;
        public static TestConGrp TestCongrp;
        public static PLCCalibration plcc;

        public static WSDGrp WSDgrp;
        public static HJYLGrp HJYLGrpgrp;
        public static YL01Grp YL01grp;
        public static YL02Grp YL02grp;
        public static YL03Grp YL03grp;
        public static TemperatureGrp Temperaturegrp;
        #endregion

        static OPCHelper()
        {
            string kepServerName = "KEPware.KEPServerEx.V4";
            //opcDOGroup.ServerName = kepServerName;
            //opcDOGroup.Prefix = "SMART.PLC.";
            //opcDIGroup.ServerName = kepServerName;
            //opcDIGroup.Prefix = "SMART.PLC.";
            //opcAIGroup.ServerName = kepServerName;
            //opcAIGroup.Prefix = "SMART.PLC.";
            //opcAOGroup.ServerName = kepServerName;
            //opcAOGroup.Prefix = "SMART.PLC.";
            //opcStatusGroup.ServerName = kepServerName;
            //opcStatusGroup.Prefix = "SMART.PLC.";
            //opcTestConGroup.ServerName = kepServerName;
            //opcTestConGroup.Prefix = "SMART.PLC.";
            //opcCurrent.ServerName = kepServerName;
            //opcCurrent.Prefix = "Current.Current.";
            //opcWaterPump.ServerName = kepServerName;
            //opcWaterPump.Prefix = "WaterPump.WaterPump.";

            opcWSD.ServerName = kepServerName;
            opcWSD.Prefix = "Humiture.WSD.";
            opcHJYL.ServerName = kepServerName;
            opcHJYL.Prefix = "Humiture.HJYL.";
            opcYL01.ServerName = kepServerName;
            opcYL01.Prefix = "Pressure.YL01.";
            opcYL02.ServerName = kepServerName;
            opcYL02.Prefix = "Pressure.YL02.";
            opcYL03.ServerName = kepServerName;
            opcYL03.Prefix = "Pressure.YL03.";
            opcTemperature.ServerName = kepServerName;
            opcTemperature.Prefix = "Pressure.Temperature.";
        }

        /// <summary>
        /// OPC打开
        /// </summary>
        public static void Connect()
        {
            //opcDOGroup.Connect();
            //opcDIGroup.Connect();
            //opcAIGroup.Connect();
            //opcAOGroup.Connect();
            //opcTestConGroup.Connect();
            //opcStatusGroup.Connect();

            opcWSD.Connect();
            opcHJYL.Connect();
            opcYL01.Connect();
            opcYL02.Connect();
            opcYL03.Connect();
            opcTemperature.Connect();
        }

        /// <summary>
        /// OPC关闭
        /// </summary>
        public static void Close()
        {
            opcDOGroup.Close();
            opcDIGroup.Close();
            opcAIGroup.Close();
            opcAOGroup.Close();
            //opcTestConGroup.Close();
            //opcStatusGroup.Close();

            opcWSD.Close();
            opcHJYL.Close();
            opcYL01.Close();
            opcYL02.Close();
            opcYL03.Close();
            opcTemperature.Close();
        }


        public static void Init()
        {
            AIgrp = new AIGrp();
            AOgrp = new AOGrp();
            DIgrp = new DIGrp();
            DOgrp = new DOGrp();
            //TestCongrp = new TestConGrp();
            //plcc = new PLCCalibration();
            //opcStatus = new OpcStatusGrp();
            WSDgrp = new WSDGrp();
            HJYLGrpgrp = new HJYLGrp();
            YL01grp = new YL01Grp();
            YL02grp = new YL02Grp();
            YL03grp = new YL03Grp();
            Temperaturegrp = new TemperatureGrp();

            WSDgrp.Init();
            HJYLGrpgrp.Init();
            YL01grp.Init();
            YL02grp.Init();
            YL03grp.Init();
            Temperaturegrp.Init();

            //opcStatus.Init();
            //AIgrp.Init();
            //AOgrp.Init();
            //DIgrp.Init();
            //DOgrp.Init();
            //TestCongrp.Init();
            //plcc.Init();
        }

    }
}

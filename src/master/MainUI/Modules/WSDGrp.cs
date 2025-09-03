using RW.Modules;
using System.ComponentModel;

namespace MainUI.Modules
{
    public partial class WSDGrp : BaseModule
    {
        private const int Count = 2;
        public event ValueGroupHandler<double> ValueGrpChaned;
        public WSDGrp()
        {
            Driver = OPCHelper.opcWSD;
            InitializeComponent();
        }

        public WSDGrp(IContainer container)
            : base(container)
        {
            Driver = OPCHelper.opcWSD;
        }
        private double[] _TestList = new double[Count];
        public double[] TestList
        {
            get { return _TestList; }
        }
        public void Fresh()
        {
            for (int i = 0; i < _TestList.Length; i++)
            {
                ValueGrpChaned?.Invoke(this, i, _TestList[i]);
            }
        }
        /// <summary>
        /// 0:温度; 1:湿度;
        /// </summary>
        public double this[int index]
        {
            get { return TestList[index]; }
            set { Write("CH" + index.ToString().PadLeft(2, '0'), value); }
        }

        public override void Init()
        {
            for (int i = 0; i < Count; i++)
            {
                int idx = i; // 循环中的i需要用临时变量存储。
                string opcTag = "CH" + i.ToString().PadLeft(2, '0');
                AddListening(opcTag, delegate (double value)
                {
                    _TestList[idx] = value;
                    ValueGrpChaned?.Invoke(this, idx, value);
                });
            }
            base.Init();
        }
    }
}

using MainUI.CurrencyHelper;
using RW.Modules;
using System.ComponentModel;

namespace MainUI.Modules
{
    public partial class HJYLGrp : BaseModule
    {
        private const int Count = 1;
        public event ValueGroupHandler<double> ValueGrpChaned;
        public HJYLGrp()
        {
            Driver = OPCHelper.opcHJYL;
            InitializeComponent();
        }

        public HJYLGrp(IContainer container)
            : base(container)
        {
            Driver = OPCHelper.opcHJYL;
        }
        private double[] _HJYLList = new double[Count];
        public double[] HJYLList
        {
            get { return _HJYLList; }
        }
        public void Fresh()
        {
            for (int i = 0; i < _HJYLList.Length; i++)
            {
                ValueGrpChaned?.Invoke(this, i, _HJYLList[i]);
            }
        }
        /// <summary>
        /// 环境压力
        /// </summary>
        public double this[int index]
        {
            get { return HJYLList[index]; }
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
                    _HJYLList[idx] = value;
                    ValueGrpChaned?.Invoke(this, idx, value);
                });
            }
            base.Init();
        }
    }
}

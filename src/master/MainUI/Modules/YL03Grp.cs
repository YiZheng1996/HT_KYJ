using RW.Modules;
using System.ComponentModel;

namespace MainUI.Modules
{
    public partial class YL03Grp : BaseModule
    {
        private const int Count = 1;
        public event ValueGroupHandler<double> ValueGrpChaned;
        public YL03Grp()
        {
            Driver = OPCHelper.opcYL03;
            InitializeComponent();
        }

        public YL03Grp(IContainer container)
            : base(container)
        {
            Driver = OPCHelper.opcYL03;
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

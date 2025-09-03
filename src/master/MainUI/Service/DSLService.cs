using RW.DSL;
using RW.DSL.Procedures;

namespace MainUI.Service
{
    /// <summary>
    /// DSL�����࣬���ڼ��غ͹���DSL�ļ�
    /// </summary>
    /// <param name="dslPath">DSL·��</param>
    public class DSLService(string dslPath)
    {
        private readonly Dictionary<string, DSLProcedure> _procedureModules = [];

        /// <summary>
        /// ����DSL�ļ�
        /// </summary>
        /// <param name="modelId">�ͺ�ID</param>
        /// <param name="paraConfig">ϵͳ������</param>
        public void LoadDSL(int modelId, ParaConfig paraConfig)
        {
            if (modelId <= 0)
            {
                throw new ArgumentException("ģ��ID�������0", nameof(modelId));
            }

            try
            {
                _procedureModules.Clear();
                LoadAndInitializeProcedures(modelId, paraConfig);
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error("����DSL�ļ�����", ex);
                MessageHelper.MessageOK($"����DSL�ļ�����{ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// ���غͳ�ʼ������
        /// </summary>
        /// <param name="modelId">�ͺ�ID</param>
        /// <param name="paraConfig">ϵͳ������</param>
        private void LoadAndInitializeProcedures(int modelId, ParaConfig paraConfig)
        {
            var testStep = new TestStepBLL();
            var testItems = testStep.GetTestItems(modelId);

            if (testItems.Count == 0)
            {
                MessageHelper.MessageOK("δ�ҵ�������Ŀ");
                return;
            }

            var visitor = DSLFactory.CreateVisitor();
            var moduleParameters = new Dictionary<string, object>
            {
                ["����"] = paraConfig
            };

            string modelType = VarHelper.TestViewModel.ModelTypeName;
            string modelName = VarHelper.TestViewModel.ModelName;
            foreach (var testItem in testItems)
            {
                LoadSingleProcedure(testItem, modelType, modelName, moduleParameters, visitor);
            }
        }

        /// <summary>
        /// ���ص�������
        /// </summary>
        /// <param name="testItem">�����ͺ�ID���úõĲ����[TestStep]</param>
        /// <param name="modelName">DSL����</param>
        /// <param name="moduleParameters">�Զ���ģ�鼯��</param>
        /// <param name="visitor"></param>
        private void LoadSingleProcedure(TestStepNewModel testItem, string modelType, string modelName,
            Dictionary<string, object> moduleParameters, object visitor = null)
        {
            string processName = testItem.ProcessName;
            string dslFilePath = Application.StartupPath + Path.Combine(dslPath, modelType, modelName, $"{processName}.rw1");

            if (!File.Exists(dslFilePath))
            {
                MessageHelper.MessageOK($"������㣺{processName},�Ҳ����Զ������ļ���");
                return;
            }

            var procedure = DSLFactory.CreateProcedure(dslFilePath);
            procedure.AddModules(moduleParameters);
            procedure.AddModules(ModuleComponent.Instance.GetList());
            procedure.DomainEventInvoked += (sender, name, output) =>
            {
                try
                {
                    if (name == "������ʾ")
                    {
                        // ����������ʾ
                    }
                    Debug.WriteLine($"�����¼���{name}  ֵ������{output.Count}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�¼���������" + ex.Message);
                }
            };

            _procedureModules.Add(processName, procedure);
        }

        /// <summary>
        /// ��ȡָ�����Ƶĳ���
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DSLProcedure GetProcedure(string name)
        {
            return _procedureModules.TryGetValue(name, out var procedure) ? procedure : null;
        }

        /// <summary>
        /// ȷ���������Ƿ���ھ���ָ�����ƵĹ���
        /// </summary>
        /// <param name="name">����Ƿ���ڵĳ��������</param>
        public bool HasProcedure(string name) => _procedureModules.ContainsKey(name);
    }
}
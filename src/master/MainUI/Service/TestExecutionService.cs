using RW.DSL;

namespace MainUI.Service
{
    /// <summary>
    /// ִ�в��Է����࣬����ִ��DSL�ű��еĲ�����Ŀ
    /// </summary>
    /// <param name="dslService">DSL������</param>
    /// <param name="updateTableColor">�����������ɫ</param>
    public class TestExecutionService(DSLService dslService, Action<ItemPointModel, int> updateTableColor)
    {
        private CancellationTokenSource _cancellationTokenSource = new();

        /// <summary>
        /// ��ʼִ�в���
        /// </summary>
        /// <param name="testPoints"></param>
        /// <returns></returns>
        public async Task StartTest(List<ItemPointModel> testPoints)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            await Task.Factory.StartNew(() => ExecuteTests(testPoints),
                _cancellationTokenSource.Token,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Default);
        }

        /// <summary>
        /// ���ṩ�Ĳ��Ե㼯��ִ��һϵ�в��ԡ�
        /// </summary>
        /// <param name="testPoints">����������״̬�༯��</param>
        private void ExecuteTests(List<ItemPointModel> testPoints)
        {
            // �������в��Ե����ɫ״̬Ϊ0��δ��ʼ״̬��
            testPoints.ForEach(i => i.ColorState = 0);

            foreach (var point in testPoints)
            {
                if (!point.Check) continue;

                if (dslService.HasProcedure(point.ItemName))
                {
                    ExecuteSingleTest(point);
                }
                else
                {
                    throw new Exception("δ�ҵ��Զ������ļ������鿪ʼʧ�ܣ�");
                }
            }
        }

        /// <summary>
        /// ִ�е��β���
        /// </summary>
        /// <param name="point">��������������״̬��</param>
        private void ExecuteSingleTest(ItemPointModel point)
        {
            updateTableColor(point, 1);
            try
            {
                var procedure = dslService.GetProcedure(point.ItemName);
                procedure?.Execute();
            }
            catch (Exception ex)
            {
                HandleTestException(ex);
            }
            finally
            {
                updateTableColor(point, 2);
            }
        }

        /// <summary>
        /// ��¼������ϸ��Ϣ
        /// </summary>
        /// <param name="ex"></param>
        private static void HandleTestException(Exception ex)
        {
            switch (ex)
            {
                case RWDSLException dslex:
                    NlogHelper.Default.Debug($"ִ��DSL����RW.DSL.RWDSLException{dslex.Message}");
                    break;
                case NullReferenceException nullex:
                    NlogHelper.Default.Debug($"ִ��DSL����NullReferenceException{nullex.Message}");
                    break;
                default:
                    NlogHelper.Default.Error($"ִ��DSL����Exception{ex.Message}");
                    MessageHelper.MessageOK(ex.Message);
                    break;
            }
        }

        /// <summary>
        /// ֹͣ����
        /// </summary>
        public void StopTest()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}
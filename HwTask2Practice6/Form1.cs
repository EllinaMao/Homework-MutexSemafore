namespace HwTask2Practice6
{
    public partial class Form1 : Form
    {
        private Mutex mutex = new Mutex();

        public Form1()
        {
            InitializeComponent();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {

            textBox1.Clear();
            textBox2.Clear();

            // Запускаем два потока через Task
            Task.Run(() => ShowAscending())
                 .ContinueWith(t => ShowDescending(), TaskScheduler.FromCurrentSynchronizationContext());

        }
        private void ShowAscending(int min = 0, int max = 20)
        {
            mutex.WaitOne(); // первый поток захватывает первый мьютекс
            for (int i = min; i <= max; i++)
            {
                Invoke(new Action(() =>
                {
                    textBox1.AppendText($"{i} ");
                }));
                Thread.Sleep(100);
            }
            mutex.ReleaseMutex();
        }

        private void ShowDescending(int min = 0, int max = 10)
        {
            mutex.WaitOne();
            for (int i = max; i >= min; i--)
            {
                Invoke(new Action(() =>
                {
                    textBox2.AppendText($"{i} ");
                }));
                Thread.Sleep(100);

            }
            mutex.ReleaseMutex();

        }

    }
}

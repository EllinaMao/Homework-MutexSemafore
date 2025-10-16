using SemaphoreRandomNumberRunner;

namespace Practice_Task_7__Homework_task_1
{

    public partial class Form1 : Form
    {
        private RunSemaphore? runner;

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            runner = new RunSemaphore(LogMessage, 3, 3); // максимум 3 потока одновременно
            Task[] tasks = runner.Run(10); // 10 потоков

            Task.WhenAll(tasks).ContinueWith(_ =>
            {
                MessageBox.Show("Все потоки завершили работу!");
            });
        }


        private void LogMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogMessage), message);
                return;
            }
            textBox1.AppendText(message + Environment.NewLine);
        }
    }
}


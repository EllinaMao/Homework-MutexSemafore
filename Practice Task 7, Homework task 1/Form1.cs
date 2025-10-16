namespace Practice_Task_7__Homework_task_1
{

    public partial class Form1 : Form
    {
        static SemaphoreSlim slim = new SemaphoreSlim(3, 3);//3 максимальное количество потоков
        static Random rd = new Random();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(var list in flowLayoutPanel1.Controls)
            {
                var thread = new Thread(DoWork);
                //thread.Name = $"Поток {flowLayoutPanel1.Controls.}";
                thread.Start();

            }
            DoWork();
        }

        private void DoWork()
        {
            
        }
    }
}

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        private static readonly string[] mutexes =
            {
            "659EAAFF-B096-4978-999F-EEF0AAADE39B",
            "30466A5C-A06D-4CFC-9024-1BE3AA2F4B2A",
            "0AA5419B-7DA7-44FB-B44B-560AB9676386"
        };
        private static Mutex? app = null;
        public Form1()
        {
            bool flag = false;
            try
            {
                foreach (var mutex in mutexes)
                {
                    app = new Mutex(false, mutex, out bool createdNew);
                    if (createdNew)
                    {
                        flag = true;
                        break;
                    }
                    else
                    {
                        app.Dispose();
                    }
                }
                if (flag)
                {
                    InitializeComponent();
                }
                else
                {
                    MessageBox.Show("You already have three copies!");
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}

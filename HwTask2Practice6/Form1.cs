namespace HwTask2Practice6
{
    public partial class Form1 : Form
    {
        SynchronizationContext? uicontext;
        public Form1()
        {
            InitializeComponent();
            uicontext = SynchronizationContext.Current;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            uicontext.Send(d => label1.Text = "Start Generation", null);

        }
        void LoadFile(string path)
        {
            string pathfile;
            using var dialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Multiselect = true
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pathfile = dialog.FileName;
                FileStream file = new FileStream(pathfile, FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(file);
                int range = rnd.Next
            }

           

        }

    }
}

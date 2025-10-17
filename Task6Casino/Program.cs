namespace Task6Casino
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting day");
            CasinoSettings settings = CasinoSettings.LoadFromConfig();
            Casino casino = new Casino(settings);
            Report.SubscribeAll(casino);
            casino.StartDay();
        }
    }
}

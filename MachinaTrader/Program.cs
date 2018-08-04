namespace MachinaTrader
{
    class Program
    {
        static void Main(string[] args)
        {
            MachinaTrader.Globals.Global.InitGlobals();
            RuntimeSettings.LoadSettings();
            WebApplication.ProcessInit();
        }
    }

    public static class WebApplication
    {
        public static void ProcessInit()
        {
            Startup.RunWebHost();
        }
    }
}

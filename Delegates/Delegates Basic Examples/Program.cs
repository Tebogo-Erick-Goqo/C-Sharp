using System.IO;

namespace DelegateExample
{
    public class Program
    {
        delegate void LogDel(string text);

        static void Main(string[] args)
        {
            Log log = new();
            //LogDel logDel = new(log.LogTextToScreen);

            LogDel logTextToScreenDel = new(log.LogTextToScreen);

            LogDel logTextToFileDel = new(log.LogTextToFile);

            LogDel multicastDel = logTextToScreenDel + logTextToFileDel;

            Console.WriteLine("Please Enter Your Name and Surname");
            string? saveNameSurname = Console.ReadLine();
            multicastDel($"Your name is {saveNameSurname}!");
        }
    }

    public class Log
    {
        public void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        public void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }
    }
}

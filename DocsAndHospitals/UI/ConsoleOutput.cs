using System;

namespace DocsAndHospitals.UI
{
    public class ConsoleOutput : IOutput
    {
        public void Write(string text) => Console.Write(text);
        public void WriteLine(string text) => Console.WriteLine(text);
        public void Clear() => Console.Clear();

        public void PressKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

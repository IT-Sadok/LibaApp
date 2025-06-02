using System;

namespace DocsAndHospitals.UI
{
    public class ConsoleInput : IInput
    {
        public string ReadLine() => Console.ReadLine();

        public int ReadInt()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value < 0)
                Console.Write("Enter a valid positive number: ");
            return value;
        }
    }
}

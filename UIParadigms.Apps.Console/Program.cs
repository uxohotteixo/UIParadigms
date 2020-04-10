using System;
using System.IO;
using UIParadigms.Modules.Interpretator;

namespace UIParadigms.Apps.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            var interpreter = new CommandInterpreter();

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..");

            System.Console.WriteLine("Console app started!");

            while (true)
            {
                System.Console.WriteLine("EnterCommand: ");

                var strCommand = System.Console.ReadLine();
                System.Console.WriteLine(interpreter.Interpret(strCommand));
            }
        }
    }
}

using Capitalism.Classes;
using Capitalism.Engine.Commands;
using System;
using System.Collections.Generic;

namespace Capitalism.Engine
{
    public class Application
    {
        

        private static Application instance;

        private Application() { }

        public static Application Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Application();
                }

                return instance;
            }
        }
        
        public void Run()
        {
            var commandLine = Console.ReadLine();
            var commandProcessor = new CommandProcessor();
            while (commandLine != "end")
            {
                var commandParts = commandLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var command = commandParts[0];

                commandProcessor.ProcessCommand(command, commandParts);
                commandLine = Console.ReadLine();
            }
        }
    }
}

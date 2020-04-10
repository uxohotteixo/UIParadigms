using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UIParadigms.Modules.Parser.Enums;

namespace UIParadigms.Modules.Parser.Commands
{
    public class MoveCommand : CommandBase
    {
        public MoveCommand(IList<string> arguments, IList<CommandOptions> options) :
            base("cd", arguments, options, new List<CommandOptions>())
        {
            if (arguments == null || !arguments.Any())
                throw new ArgumentException(nameof(arguments));

            CurrentPath = Path.GetFullPath(Path.IsPathRooted(arguments[0]) 
                ? arguments[0] 
                : Path.Combine(CurrentPath, arguments[0]));
        }

        public static string CurrentPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;
    }
}

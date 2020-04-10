using System.Collections.Generic;
using UIParadigms.Modules.Parser.Enums;

namespace UIParadigms.Modules.Parser.Commands
{
    public class ShowContentCommand : CommandBase
    {
        public ShowContentCommand(IList<string> arguments, IList<CommandOptions> options) : 
            base("dir", arguments, options, new[] { CommandOptions.Recursive })
        {
            CommandType = CommandType.ShowСontent;
        }
    }
}

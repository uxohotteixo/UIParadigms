using System.Collections.Generic;
using UIParadigms.Modules.Parser.Enums;

namespace UIParadigms.Modules.Parser.Commands
{
    public class OpenFileCommand : CommandBase
    {
        public OpenFileCommand(IList<string> arguments, IList<CommandOptions> options) :
            base("type", arguments, options, new List<CommandOptions>())
        {
        }
    }
}
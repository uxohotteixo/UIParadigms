using System.Collections.Generic;
using UIParadigms.Modules.Parser.Enums;

namespace UIParadigms.Modules.Parser.Commands
{
    public class CreateFileCommand : CommandBase
    {
        public CreateFileCommand(IList<string> arguments, IList<CommandOptions> options) : 
            base("cd. >", arguments, options, new List<CommandOptions>()) { }
    }
}

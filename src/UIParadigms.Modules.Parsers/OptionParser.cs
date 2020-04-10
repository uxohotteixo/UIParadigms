using System;
using System.Collections.Generic;
using UIParadigms.Modules.Parser.Enums;

namespace UIParadigms.Modules.Parser
{
    public class OptionParser
    {
        private readonly Dictionary<CommandOptions, string> _matchTable = new Dictionary<CommandOptions, string>()
        {
            {CommandOptions.Recursive, "/s"}
        };

        public string Parse(CommandOptions option)
        {
            if (_matchTable.TryGetValue(option, out var parsedOption)) return parsedOption;
            throw new ArgumentException(nameof(option));
        }
    }
}
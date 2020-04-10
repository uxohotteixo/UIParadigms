using System;
using System.Collections.Generic;
using System.Linq;
using UIParadigms.Modules.Parser.Enums;

namespace UIParadigms.Modules.Parser.Commands
{
    public abstract class CommandBase
    {
        protected CommandBase(
            string commandPrefix,
            IList<string> arguments,
            IList<CommandOptions> options,
            IList<CommandOptions> availableOptions)
        {
            CommandPrefix = commandPrefix;
            Arguments = arguments;
            Options = options;
            AvailableOptions = availableOptions;
            if (!ValidateOption(options)) throw new ArgumentException();
        }

        public string CommandPrefix { get; protected set; }

        public IList<string> Arguments { get; protected set; }

        public IList<CommandOptions> Options { get; protected set; }

        public IList<CommandOptions> AvailableOptions { get; protected set; }

        public CommandType CommandType { get; protected set; } = CommandType.Create;

        public virtual string GetCommandText() => CommandPrefix +
                                                  (Arguments.Any() ? " " : "") + string.Join(" ", Arguments) +
                                                  (Options.Any() ? " " : "") +
                                                  string.Join(" ", Options.Select(new OptionParser().Parse));

        protected bool ValidateOption(IEnumerable<CommandOptions> options) => options.All(AvailableOptions.Contains);
    }

    public class RemoveFileCommand : CommandBase
    {
        public RemoveFileCommand(IList<string> arguments, IList<CommandOptions> options) :
            base("del /f", arguments, options, new List<CommandOptions>())
        {
        }
    }
}
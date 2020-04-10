using System;
using System.Collections.Generic;
using System.Linq;
using UIParadigms.Modules.Parser.Commands;
using UIParadigms.Modules.Parser.Enums;

namespace UIParadigms.Modules.Parser
{
    public class CommandParser
    {
        private readonly Dictionary<string, CommandType> _cmdTypes = new Dictionary<string, CommandType>()
        {
            { "show", CommandType.ShowСontent },
            { "create", CommandType.Create },
            { "move", CommandType.Move },
            { "open", CommandType.Open },
            { "remove", CommandType.Remove }
        };

        private Dictionary<string, CommandOptions> _cmdOptions = new Dictionary<string, CommandOptions>()
        {
            {"-r", CommandOptions.Recursive}
        };

        public CommandBase Parse(string commandText)
        {
            if (string.IsNullOrEmpty(commandText) || string.IsNullOrWhiteSpace(commandText)) 
                throw new ArgumentException(nameof(commandText));

            var commandParts = commandText.Trim().Split(' ');

            if (!_cmdTypes.TryGetValue(commandParts[0], out var cmdType))
                throw new ArgumentException(nameof(commandText), $"Command {commandText} is not supported.");

            var arguments = GetCommandArguments(commandParts.Skip(1).ToArray());

            var options = GetOptions(commandParts.Skip(1 + arguments.Count).ToArray());

            switch (cmdType)
            {
                case CommandType.ShowСontent:
                    return new ShowContentCommand(arguments, options);
                case CommandType.Move:
                    return new MoveCommand(arguments, options);
                case CommandType.Create:
                    return new CreateFileCommand(arguments, options);
                case CommandType.Open:
                    return new OpenFileCommand(arguments, options);
                case CommandType.Remove:
                    return new RemoveFileCommand(arguments, options);
                default:
                    throw new ArgumentException(nameof(commandText), $"Command {commandText} is not supported.");
            }
        }

        private IList<CommandOptions> GetOptions(IEnumerable<string> optionParts)
        {
            var parsedOptions = new List<CommandOptions>();

            foreach (var part in optionParts)
            {
                if (!_cmdOptions.TryGetValue(part, out var option)) throw new ArgumentException();
                parsedOptions.Add(option);
            }

            return parsedOptions;
        }

        private IList<string> GetCommandArguments(IEnumerable<string> commandParts)
            => commandParts.TakeWhile(cp => !_cmdOptions.ContainsKey(cp)).ToList();
    }
}

using UIParadigms.Modules.Parser;
using UIParadigms.Modules.Parser.Commands;
using UIParadigms.Modules.Proxy;

namespace UIParadigms.Modules.Interpretator
{
    public class CommandInterpreter
    {
        private readonly WindowsCmdProxy _windowsCmdProxy;

        private readonly CommandParser _commandParser;

        public CommandInterpreter()
        {
            _windowsCmdProxy = new WindowsCmdProxy();
            _commandParser = new CommandParser();
        }

        public string Interpret(string commandText)
        {
            var command = _commandParser.Parse(commandText);
            return _windowsCmdProxy.ExecuteCommand(
                command.GetCommandText(), 
                MoveCommand.CurrentPath);
        }
    }
}

using System.IO;
using Microsoft.AspNetCore.Mvc;
using UIParadigms.Modules.Interpretator;

namespace UIParadigms.Apps.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class CommandsController : ControllerBase
    {
        private readonly CommandInterpreter _interpreter;

        public CommandsController(CommandInterpreter interpreter)
        {
            _interpreter = interpreter;
        }

        [HttpGet]
        public IActionResult Show(string parameters = "")
        {
            return Ok(_interpreter.Interpret(parameters));
        }

        [HttpGet]
        public IActionResult Open(string parameters)
        {
            return Ok(_interpreter.Interpret(parameters));
        }

        [HttpPost]
        public IActionResult Move([FromBody]InputParams parameters)
        {
            return Ok(_interpreter.Interpret(parameters.Parameters));
        }

        [HttpPost]
        public IActionResult Create([FromBody] InputParams parameters)
        {
            return Ok(_interpreter.Interpret(parameters.Parameters));
        }

        [HttpPost]
        public IActionResult Remove([FromBody]InputParams parameters)
        {
            return Ok(_interpreter.Interpret(parameters.Parameters));
        }
    }

    public class InputParams
    {
        public string Parameters { get; set; }
    }
}
using COMMANDER.Data;
using COMMANDER.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMMANDER.Controllers
{
    //
    [Route("api/controller")]
    [ApiController]
    public class CommandsController : ControllerBase    
    {
        private readonly MockCommanderRepo _repository = new MockCommanderRepo();

        // get api/Command
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommander()
        {
            var commandItem = _repository.GetAppCommands();

            return Ok(commandItem);
        }


        // get api/command/{id}
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);

            return Ok(commandItem);
        }
    }
}
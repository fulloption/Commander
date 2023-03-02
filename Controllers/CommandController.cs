using AutoMapper;
using COMMANDER.Data;
using COMMANDER.Dtos;
using COMMANDER.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMMANDER.Controllers
{
    //
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase    
    {
        
        // private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, AutoMapper.IMapper mapper){
            _repository = repository;
            _mapper = mapper;
        }

        
        // get api/Command
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommander()
        {
            var commandItem = _repository.GetAllCommands();

            return Ok(commandItem);
        }


        // get api/command/{id}
        [HttpGet("{id}")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
        }
    }
}
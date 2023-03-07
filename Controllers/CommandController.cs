using AutoMapper;
using COMMANDER.Data;
using COMMANDER.Dtos;
using COMMANDER.Models;
using Microsoft.AspNetCore.JsonPatch;
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
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommander()
        {
            var commandItem = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItem));
        }


        // get api/command/{id}
        [HttpGet("{id}", Name="GetCommandById") ]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }
            return NotFound();
        }

        //POST api/command/
        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto cmdCreateDto)
        {
            var commandModel = _mapper.Map<Command>(cmdCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChange();
            var commanderReadDto = _mapper.Map<CommandReadDto>(commandModel);
            return CreatedAtRoute(nameof(GetCommandById), new {Id = commanderReadDto.id}, commanderReadDto);       
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChange();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChange();

            return NoContent();
        }
        
    }
}
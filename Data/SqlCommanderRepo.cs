using COMMANDER.Models;

namespace COMMANDER.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _commanderContext;

        public SqlCommanderRepo(CommanderContext commanderContext)
        {
            _commanderContext = commanderContext;
        }
        public IEnumerable<Command> GetAllCommands()
        {
            return _commanderContext.Commands.ToList();
        }


        public Command GetCommandById(int id)
        {
            return _commanderContext.Commands.FirstOrDefault(p => p.id == id);
        }

        public bool SaveChange()
        {
            return (_commanderContext.SaveChanges() >= 0);
        }

        public void CreateCommand(Command command)
        {
            if(command == null){
                throw new ArgumentException(nameof(command));
            }
            _commanderContext.Commands.Add(command);
        }

        public void UpdateCommand(Command cmd)
        {
            //Nothing
        }

        public void DeleteCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            _commanderContext.Commands.Remove(cmd);
        }
    }

}
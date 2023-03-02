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

        public IEnumerable<Command> GetAppCommands()
        {
            throw new NotImplementedException();
        }

        public Command GetCommandById(int id)
        {
            return _commanderContext.Commands.FirstOrDefault(p => p.id == id);
        }
    }

}
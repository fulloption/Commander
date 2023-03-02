using COMMANDER.Models;

namespace COMMANDER.Data
{
    public interface ICommanderRepo
    {
        bool SaveChange();
        IEnumerable<Command> GetAppCommands();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);

        void CreateCommand(Command command);
    }
}  

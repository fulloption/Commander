using COMMANDER.Models;

namespace COMMANDER.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAppCommands();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
    }
}  

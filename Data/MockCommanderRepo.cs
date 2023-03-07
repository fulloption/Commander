using COMMANDER.Models;

namespace COMMANDER.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAppCommands()
        {
            var command = new List<Command>
            {
                new Command{id=0 ,HowTo="Boil an 1",Line="Boil 1",Platform="Kettle & 1"},
                new Command{id=1 ,HowTo="Boil an 2",Line="Boil 2",Platform="Kettle & 2"},
                new Command{id=2 ,HowTo="Boil an 3",Line="Boil 3",Platform="Kettle & 3"},
                new Command{id=3 ,HowTo="Boil an 4",Line="Boil 4",Platform="Kettle & 4"}
            };
            return command;
        }

        public Command GetCommandById(int id)
        {
            return new Command{id=0 ,HowTo="Boil an egg",Line="Boil water",Platform="Kettle & Pan"};
        }

        public bool SaveChange()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}

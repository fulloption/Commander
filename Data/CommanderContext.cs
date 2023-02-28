using System.Reflection;
using COMMANDER.Models;
using Microsoft.EntityFrameworkCore;

namespace COMMANDER.Data
{
    public class CommanderContext : DbContext
    {
        
        public CommanderContext(DbContextOptions<CommanderContext> opt): base(opt)
        {

        }

        public DbSet<Command> Commands { get; set; }
        
    }
}
using System.ComponentModel.DataAnnotations;

namespace COMMANDER.Dtos
{
   public class CommandUpdateDto
   {
        [MaxLength(250)]
        public string HowTo { get; set; }
        
        public string Line { get; set; }
        
        public string Platform { get; set; }
   }
}
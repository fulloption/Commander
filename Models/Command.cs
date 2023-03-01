using System.ComponentModel.DataAnnotations;

namespace COMMANDER.Models
{
    // [System.ComponentModel.DataAnnotations.Schema.Table("Command")]
    public class Command
    {
        [Key]
        public int id{get;set;}

        [MaxLength(250)]
        public string HowTo{get;set;}

        public string Line { get; set; }

        public string Platform { get; set; }
    }

}
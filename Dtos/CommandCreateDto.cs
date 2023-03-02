using System.ComponentModel.DataAnnotations;

namespace COMMANDER.Dtos
{
    // [System.ComponentModel.DataAnnotations.Schema.Table("Command")]
    public class CommandCreateDto 
    {
        [MaxLength(250)]
        public string HowTo{get;set;}

        public string Line { get; set; }

        public string Platform { get; set; }

    }

}

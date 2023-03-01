namespace COMMANDER.Models
{
    // [System.ComponentModel.DataAnnotations.Schema.Table("Command")]
    public class Command
    {
        public int id{get;set;}
        public string HowTo{get;set;}

        public string Line { get; set; }

        public string Platform { get; set; }
    }

}
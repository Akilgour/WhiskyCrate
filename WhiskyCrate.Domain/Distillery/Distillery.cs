using System.ComponentModel.DataAnnotations;

namespace WhiskyCrate.Domain.Distillery
{
    public class Distillery : BaseModel
    {
        [Required]
        public string Name { get; set; }

        public bool CurrentlyOperating { get; set; }
        public string Region { get; set; }
    }
}
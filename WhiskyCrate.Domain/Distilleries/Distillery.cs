using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WhiskyCrate.Domain.WhiskyExpressions;

namespace WhiskyCrate.Domain.Distilleries
{
  
    public class Distillery : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public bool CurrentlyOperating { get; set; }
        public string Region { get; set; }

        public List<WhiskyExpression> WhiskyExpressions { get; set; } = new List<WhiskyExpression>();
    }
}
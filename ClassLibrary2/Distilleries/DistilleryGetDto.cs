using System.Collections.Generic;

namespace WhiskyCrate.Application.Contracts.Distilleries
{
    public class DistilleryGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CurrentlyOperating { get; set; }
        public string Region { get; set; }
        public List<DistilleryGetWhiskyExpressionDto> WhiskyExpressions { get; set; } = new List<DistilleryGetWhiskyExpressionDto>();
    }

    public class DistilleryGetWhiskyExpressionDto
    {
        public int Id { get; set; }
        public string AgeDisplay { get; set; }
    }
}
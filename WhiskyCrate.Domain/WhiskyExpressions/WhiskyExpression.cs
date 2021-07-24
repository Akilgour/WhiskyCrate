using WhiskyCrate.Domain.Distilleries;

namespace WhiskyCrate.Domain.WhiskyExpressions
{
    public class WhiskyExpression : BaseModel
    {
        public int AgeInMonths { get; set; }
        public string TastingNotes { get; set; }
        public string DistillingNotes { get; set; }
        public Distillery Distillery { get; set; }
    }
}
namespace WhiskyCrate.Application.Contracts.Distilleries
{
    public class DistilleryPostRequest
    {
        public string Name { get; set; }
        public bool CurrentlyOperating { get; set; }
        public string Region { get; set; }
    }
}
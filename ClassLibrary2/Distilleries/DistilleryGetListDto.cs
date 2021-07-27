namespace WhiskyCrate.Application.Contracts.Distilleries
{
    public class DistilleryGetListDto
    {
        public string Name { get; set; }
        public bool CurrentlyOperating { get; set; }
        public string Region { get; set; }
    }
}
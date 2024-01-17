namespace EnterpriseMaster.DbServices.Models.Database
{
    public class AboutPage : Bases
    {
        public byte[] OurMission { get; set; }
        public byte[] OurVision { get; set; }
        public byte[] AboutUs { get; set; }
        public string? Title { get; set; }
        public string? OurMissionTitle { get; set; }
        public string? OurMissionTitleLess { get; set; }
        public string? OurMissionTitleText { get; set; }
        public string? OurVisionTitle { get; set; }
        public string? OurVisionTitleLess { get; set; }
        public string? OurVisionTitleText { get; set; }
        public string? AboutUsTitle { get; set; }
        public string? AboutUsTitleLess { get; set; }
        public string? AboutUsTitleText { get; set; }
    }
}

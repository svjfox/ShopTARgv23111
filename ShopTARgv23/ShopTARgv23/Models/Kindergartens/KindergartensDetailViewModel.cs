namespace ShopTARgv23.Models.Kindergartens
{
    public class KindergartensDetailViewModel
    {
        public Guid? Id { get; set; }

        public string? GroupName { get; set; }

        public int? ChildrenCount { get; set; }

        public string? KindergartenName { get; set; }

        public string? Teacher { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public List<KindergartensImageViewModel> Image { get; set; }
            = new List<KindergartensImageViewModel>();

    }
}
using ShopTARgv23.Models.Spaceships;

namespace ShopTARgv23.Models.RealEstates
{
    public class RealEstateCreateUpdateViewModel
    {
        public Guid? Id { get; set; }
        public string Location { get; set; }
        public int Size { get; set; }
        public int RoomNumber { get; set; }
        public string BuildingType { get; set; }

        public List<IFormFile> Files { get; set; }
        public List<FileToApiViewModel> FileToApiViewModels { get; set; }
            = new List<FileToApiViewModel>();

        //only in db
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }



    }
}
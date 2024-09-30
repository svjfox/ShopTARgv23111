namespace ShopTARgv23.Models.Spaceships
{
    public class SpaceshipCreateUpdateViewModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime BuiltDate { get; set; }
        public int CargoWeight { get; set; }
        public int Crew { get; set; }
        public int EnginePower { get; set; }

        public List<IFormFile> Files { get; set; }
        public List<FileToApiViewModels> FileToApiViewModels { get; set; }
            =  new List<FileToApiViewModels>();

        //only in db
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}

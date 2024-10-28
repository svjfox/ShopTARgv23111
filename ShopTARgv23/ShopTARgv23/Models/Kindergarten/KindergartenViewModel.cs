// Models/Kindergarten/KindergartenViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace ShopTARgv23.Models.Kindergarten
{
    public class KindergartenViewModel
    {

        public int? Id { get; set; }

        [Required(ErrorMessage = "Название группы обязательно.")]
        public string GroupName { get; set; }

        [Required(ErrorMessage = "Количество детей обязательно.")]
        [Range(1, 100, ErrorMessage = "Количество детей должно быть от 1 до 100.")]
        public int ChildrenCount { get; set; }

        [Required(ErrorMessage = "Название детского сада обязательно.")]
        public string KindergartenName { get; set; }

        [Required(ErrorMessage = "Имя учителя обязательно.")]
        public string Teacher { get; set; }
    }
}

// Models/Kindergarten/Kindergarten.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace ShopTARgv23.Models.Kindergarten
{
    public class Kindergarten
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название группы обязательно.")]
        public string GroupName { get; set; }

        [Required(ErrorMessage = "Количество детей обязательно.")]
        [Range(1, 100, ErrorMessage = "Количество детей должно быть от 1 до 100.")]
        public int ChildrenCount { get; set; }

        [Required(ErrorMessage = "Название детского сада обязательно.")]
        public string KindergartenName { get; set; }

        [Required(ErrorMessage = "Имя учителя обязательно.")]
        public string Teacher { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}

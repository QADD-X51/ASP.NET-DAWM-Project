using System.ComponentModel.DataAnnotations;

namespace DAWM_Project.Services.Dtos
{
    public class CarAddDto
    {
        [Required]
        public string Maker { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        [Range(1800,9999)]
        public int ModelYear { get; set; }
        [Required]
        [Range(0,100000)]
        public int Power { get; set; }
        public int? EngineCapacity { get; set; }
        public string? EngineType { get; set; }
        [Required]
        public string Drivetrain { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        [Range(0,Int32.MaxValue)]
        public int Mileage { get; set; }
        [Required]
        [Range(0,Single.MaxValue)]
        public float Price { get; set; }
        [Required]
        public bool Negotiable { get; set; }
        [Required]
        public string Description { get; set; }
    }
}

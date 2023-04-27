using System.Diagnostics.Metrics;

namespace DAWM_Project.Data.Entity
{
    public class Car : BaseEntity
    {
        public string Maker { get; set; }
        public string ModelName { get; set; }
        public int ModelYear { get; set; }
        public int Power { get; set; }
        public int EngineCapacity { get; set; }
        public string EngineType { get; set; }
        public string Drivetrain { get; set; }
        public int Weight { get; set; }
        public int Mileage { get; set; }
        public float Price { get; set; }
        public bool Negotiable { get; set; }
        public string Description { get; set; }
        public bool Sold { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}

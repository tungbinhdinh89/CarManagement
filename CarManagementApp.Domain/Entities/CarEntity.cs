namespace CarManagementApp.Domain.Entities
{
    public class CarEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Make { get; set; } = null!;
        public DateTime Year { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}

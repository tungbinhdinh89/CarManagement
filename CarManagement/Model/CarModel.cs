namespace CarManagement.Model
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Make { get; set; } = null!;
        public int Year { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

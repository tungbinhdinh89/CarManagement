namespace CarManagementApp.Domain.Entities
{
    public class CarEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public DateTime Year { get; set; }
        public DateTime CreatedAtAS { get; set; }

    }
}

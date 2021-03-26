namespace Courir.Entities
{
    public class ModelEntity : BaseEntity
    {
        public Brand Brand { get; set; }

        public int Id { get; set; }

        public string IdentificationNumber { get; set; }

        public string Name { get; set; }
    }
}

public enum Brand : int
{
    Nike = 0,
    Adidas = 1,
    Jordan = 2,
    Converse = 3,
}
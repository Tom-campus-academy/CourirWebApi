namespace Courir.Entities
{
    public class StockEntity : BaseEntity
    {
        public int Id { get; set; }

        public int IdModel { get; set; }

        public ModelEntity Model { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

        public ShoeSize ShoeSize { get; set; }
    }
}

public enum ShoeSize : int
{
    S39_5 = 0,
    S40 = 1,
    S40_5 = 2,
    S41 = 3,
    S41_5 = 4,
}
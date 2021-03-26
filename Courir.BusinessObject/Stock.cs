namespace Courir.BusinessObject
{
    using Courir.BusinessObject.Validation;
    using Courir.Entities;

    public class Stock : BaseBusinessObject<StockEntity>
    {
        public Stock()
        {
            this.ValidationService = new StockValidation();
        }

        public Stock(StockEntity entity) : base(entity)
        {
            this.ValidationService = new StockValidation();
            this.Id = entity.Id;
            this.IdModel = entity.IdModel;
            this.Price = entity.Price;
            this.Quantity = entity.Quantity;
            this.ShoeSize = entity.ShoeSize;
        }

        public int Id { get; set; }

        public int IdModel { get; set; }

        public Model Model { get; set; }

        public float Price { get; set; }

        public int Quantity { get; set; }

        public ShoeSize ShoeSize { get; set; }

        public override StockEntity CreateEntity()
        {
            return new StockEntity
            {
                Id = this.Id,
                IdModel = this.IdModel,
                Price = this.Price,
                Quantity = this.Quantity,
                ShoeSize = this.ShoeSize,
                CreatedDate = this.CreatedDate,
                UpdatedDate = this.UpdatedDate,
            };
        }
    }
}
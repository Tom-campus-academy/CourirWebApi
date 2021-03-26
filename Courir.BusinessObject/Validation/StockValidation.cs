namespace Courir.BusinessObject.Validation
{
    using Courir.BusinessObject.Validation.Service;
    using Courir.Entities;

    public class StockValidation : ValidationService<StockEntity>
    {
        public override bool Validate(StockEntity itemToValidate)
        {
            this.Clear();

            return this.IsValid;
        }
    }
}
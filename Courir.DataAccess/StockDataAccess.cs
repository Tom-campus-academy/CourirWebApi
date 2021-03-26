namespace Courir.DataAccess
{
    using Courir.Entities;
    using Courir.IDataAccess;

    public class StockDataAccess : BaseDataAccess<StockEntity>, IStockDataAccess
    {
        public StockDataAccess(CourirContext context)
            : base(context)
        {
        }
    }
}
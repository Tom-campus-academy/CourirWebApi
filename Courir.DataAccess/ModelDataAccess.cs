namespace Courir.DataAccess
{
    using Courir.Entities;
    using Courir.IDataAccess;

    public class ModelDataAccess : BaseDataAccess<ModelEntity>, IModelDataAccess
    {
        public ModelDataAccess(CourirContext context)
            : base(context)
        {
        }
    }
}
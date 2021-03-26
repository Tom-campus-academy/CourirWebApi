namespace Courir.BusinessObject
{
    using Courir.BusinessObject.Validation;
    using Courir.Entities;

    public class Model : BaseBusinessObject<ModelEntity>
    {
        public Model()
        {
            this.ValidationService = new ModelValidation();
        }

        public Model(ModelEntity entity) : base(entity)
        {
            this.ValidationService = new ModelValidation();
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.Brand = entity.Brand;
            this.IdentificationNumber = entity.IdentificationNumber;
        }

        public Brand Brand { get; set; }

        public int Id { get; set; }

        public string IdentificationNumber { get; set; }

        public string Name { get; set; }

        public override ModelEntity CreateEntity()
        {
            return new ModelEntity
            {
                Id = this.Id,
                Name = this.Name,
                IdentificationNumber = this.IdentificationNumber,
                Brand = this.Brand,
                CreatedDate = this.CreatedDate,
                UpdatedDate = this.UpdatedDate,
            };
        }
    }
}
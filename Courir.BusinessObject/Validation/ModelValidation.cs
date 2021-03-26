namespace Courir.BusinessObject.Validation
{
    using Courir.BusinessObject.Validation.Resource;
    using Courir.BusinessObject.Validation.Service;
    using Courir.Entities;

    public class ModelValidation : ValidationService<ModelEntity>
    {
        public override bool Validate(ModelEntity itemToValidate)
        {
            this.Clear();
            this.ValidationIdentificationNumber(itemToValidate.IdentificationNumber);
            this.ValidationName(itemToValidate.Name);

            return this.IsValid;
        }

        private void ValidationIdentificationNumber(string value)
        {
            this.ValidateStringRequired(value, nameof(ModelValidationResource.Model_IdentificationNumber_Required), ModelValidationResource.Model_IdentificationNumber_Required);
            this.ValidateStringLength(value, 1000, nameof(ModelValidationResource.Model_IdentificationNumber_Max_Length), ModelValidationResource.Model_IdentificationNumber_Max_Length);
        }

        private void ValidationName(string value)
        {
            this.ValidateStringRequired(value, nameof(ModelValidationResource.Model_Name_Required), ModelValidationResource.Model_Name_Required);
            this.ValidateStringLength(value, 1000, nameof(ModelValidationResource.Model_Name_Max_Length), ModelValidationResource.Model_Name_Max_Length);
        }
    }
}
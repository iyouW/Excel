namespace Excel.Validator.Abstraction
{
    public interface IValidator
    {
        IValidateResult Validate(object value);
    }
}
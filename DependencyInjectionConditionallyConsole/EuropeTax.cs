namespace DependencyInjectionConditionallyConsole
{
    public class EuropeTax : ITax
    {
        public int GetTaxValue()
        {
            return 30;
        }
    }
}
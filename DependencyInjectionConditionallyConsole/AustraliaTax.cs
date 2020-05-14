namespace DependencyInjectionConditionallyConsole
{
    public class AustraliaTax : ITax
    {
        public int GetTaxValue()
        {
            return 10;
        }
    }
}
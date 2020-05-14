using System;
namespace DependencyInjectionConditionallyConsole
{
    public class TaxCalculator
    {
        private readonly Func<Location, ITax> _accessor;

        public TaxCalculator(Func<Location, ITax> accessor)
        {
            _accessor = accessor;
        }
        public int CalculateTax(Location location, int earning)
        {

            int result = earning + _accessor(location).GetTaxValue();
            //_accessor.
            return result;
        }
    }
}
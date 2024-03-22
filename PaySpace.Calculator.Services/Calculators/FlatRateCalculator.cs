using Microsoft.EntityFrameworkCore;
using PaySpace.Calculator.Data;
using PaySpace.Calculator.Data.Models;
using PaySpace.Calculator.Services.Abstractions;
using PaySpace.Calculator.Services.Models;

namespace PaySpace.Calculator.Services.Calculators
{
    public class FlatRateCalculator : IFlatRateCalculator
    {
        private readonly CalculatorContext _dbContext;
        public FlatRateCalculator(CalculatorContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CalculateResult> CalculateAsync(decimal income)
        {
            var settings = await _dbContext.CalculatorSettings.Where(x => x.Calculator == CalculatorType.FlatRate).ToListAsync();

            decimal tax = 0;
            decimal previousBracket = 0;
            var result = new CalculateResult();
            for (int i = 0; i < settings.Count; i++)
            {
                if (income > settings[i].To)
                {
                    tax += (settings[i].To - previousBracket) * settings[i].Rate;
                    previousBracket = settings[i].To;
                }
                else
                {
                    tax += (income - previousBracket) * settings[i].Rate;
                    result.Calculator = settings[i].Calculator;

                    break;
                }
            }

            result.Tax = tax;
            return result;
        }
    }
}
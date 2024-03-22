using PaySpace.Calculator.Web.Services.Models;

namespace PaySpace.Calculator.Web.Services.Abstractions
{
    public interface ICalculatorHttpService
    {
        Task<List<PostalCodeDto>> GetPostalCodesAsync();

        Task<List<CalculatorHistoryDto>> GetHistoryAsync();

        Task<CalculateResultDto> CalculateTaxAsync(CalculateRequest calculationRequest);
    }
}
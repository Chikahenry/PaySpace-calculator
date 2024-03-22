using System.Net.Http.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PaySpace.Calculator.Data;
using PaySpace.Calculator.Data.Models;
using PaySpace.Calculator.Web.Services.Abstractions;
using PaySpace.Calculator.Web.Services.Models;

namespace PaySpace.Calculator.Web.Services
{
    public class CalculatorHttpService : ICalculatorHttpService
    {
        private readonly HttpClient _httpClient;
        public CalculatorHttpService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("CalculatorHttpService"); 
        }
        public async Task<List<PostalCodeDto>> GetPostalCodesAsync()
        {
            var response = await _httpClient.GetAsync("api/calculator/postalcode");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Cannot fetch postal codes, status code: {response.StatusCode}");
            }

            var postalCodes = await response.Content.ReadFromJsonAsync<List<PostalCodeDto>>() ?? [];
            return postalCodes;
        }

        public async Task<List<CalculatorHistoryDto>> GetHistoryAsync()
        {
            var response = await _httpClient.GetAsync("api/Calculator/history");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Cannot fetch history, status code: {response.StatusCode}");
            }

            var histories = await response.Content.ReadFromJsonAsync<List<CalculatorHistoryDto>>() ?? [];
            return histories;
        }

        public async Task<CalculateResultDto> CalculateTaxAsync(CalculateRequest calculationRequest)
        {
            var response = await _httpClient.GetAsync("api/Calculator/calculate-tax");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Cannot Calculate tax now, status code: {response.StatusCode}");
            }

            var result = await response.Content.ReadFromJsonAsync<CalculateResultDto>();
            return result;
        }
    }
}
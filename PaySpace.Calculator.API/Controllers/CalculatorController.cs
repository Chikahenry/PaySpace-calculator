using MapsterMapper;

using Microsoft.AspNetCore.Mvc;

using PaySpace.Calculator.API.Models;
using PaySpace.Calculator.Data.Models;
using PaySpace.Calculator.Services.Abstractions;
using PaySpace.Calculator.Services.Exceptions;
using PaySpace.Calculator.Services.Models;

namespace PaySpace.Calculator.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly IHistoryService _historyService;
        private readonly IPostalCodeService _postalcodeService;
        private readonly IProgressiveCalculator _progressiveService;
        private readonly IFlatValueCalculator _flatValueService;
        private readonly IFlatRateCalculator _flatRateService;
        private readonly IMapper _mapper;
        public CalculatorController(
        ILogger<CalculatorController> logger, IProgressiveCalculator progressiveService,
        IHistoryService historyService, IFlatValueCalculator flatValueService,
        IMapper mapper, IFlatRateCalculator flatRateService, IPostalCodeService postalcodeService)
        {
            _flatRateService = flatRateService;
            _logger = logger;
            _historyService = historyService;
            _progressiveService = progressiveService;
            _mapper = mapper;
            _flatValueService = flatValueService;
            _postalcodeService = postalcodeService;

        }

        [HttpPost("calculate-tax")]
        public async Task<ActionResult<CalculateResultDto>> Calculate(CalculateRequest request)
        {
            try
            {
                var result = new CalculateResult(); 
                switch (request.PostalCode)
                {
                    case "7441":
                        result = await _progressiveService.CalculateAsync(request.Income);
                        break;
                    case "1000":
                        result = await _progressiveService.CalculateAsync(request.Income);
                        break;
                    case "A100":
                        result = await _flatValueService.CalculateAsync(request.Income);
                        break;
                    case "7000":
                        result = await _flatRateService.CalculateAsync(request.Income);
                        break;
                    default:
                        throw new ArgumentException("Invalid postal code.");
                }

                await _historyService.AddAsync(new CalculatorHistory
                {
                    Tax = result.Tax,
                    Calculator = result.Calculator,
                    PostalCode = request.PostalCode ?? "Unknown",
                    Income = request.Income
                });

                return this.Ok(_mapper.Map<CalculateResultDto>(result));
            }
            catch (CalculatorException e)
            {
                _logger.LogError(e, e.Message);

                return this.BadRequest(e.Message);
            }
        }

        [HttpGet("history")]
        public async Task<ActionResult<List<CalculatorHistoryDto>>> History()
        {
            var history = await _historyService.GetHistoryAsync();

            return this.Ok(_mapper.Map<List<CalculatorHistoryDto>>(history));
        }

        [HttpGet("postalcode")]
        public async Task<ActionResult<List<PostalCodeDto>>> PostalCodes()
        {
            var result = await _postalcodeService.GetPostalCodesAsync();

            return this.Ok(_mapper.Map<List<PostalCodeDto>>(result));
        }
    }
}
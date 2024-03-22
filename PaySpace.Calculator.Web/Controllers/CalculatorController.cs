using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PaySpace.Calculator.Web.Models;
using PaySpace.Calculator.Web.Services.Abstractions;
using PaySpace.Calculator.Web.Services.Models;

namespace PaySpace.Calculator.Web.Controllers
{
    public class CalculatorController(ICalculatorHttpService calculatorHttpService) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var vm = this.GetCalculatorViewModelAsync();

            return this.View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> History()
        {
            return this.View(new CalculatorHistoryViewModel
            {
                CalculatorHistory = await calculatorHttpService.GetHistoryAsync()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Index(CalculateRequestViewModel request)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    await calculatorHttpService.CalculateTaxAsync(new CalculateRequest
                    {
                        PostalCode = request.PostalCode,
                        Income = request.Income
                    });

                    return this.RedirectToAction(nameof(this.History));
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError(string.Empty, e.Message);
                }
            }

            var vm = GetCalculatorViewModelAsync(request);

            return this.View(vm);
        }

        private CalculatorViewModel GetCalculatorViewModelAsync(CalculateRequestViewModel? request = null)
        {
            var postalCodes = calculatorHttpService.GetPostalCodesAsync();
            var selectListItems = postalCodes.Result
                            .Select(h => new SelectListItem { Value = h.Calculator, Text = h.Calculator })
                            .ToList();
            return new CalculatorViewModel
            {
                PostalCodes = new SelectList(selectListItems, "Value", "Text"),
                Income = request.Income,
                PostalCode = request.PostalCode ?? string.Empty
            };
        }
    }
}
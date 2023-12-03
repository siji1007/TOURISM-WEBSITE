using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TOURISM_WEBSITE.Pages
{
    public class ExploreModel : PageModel
    {
        private readonly ILogger<ExploreModel> _logger;

        public ExploreModel(ILogger<ExploreModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}

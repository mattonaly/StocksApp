using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StocksApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        //if logged in redirect to dashboard
        if (User.Identity.IsAuthenticated)
        {
            Response.Redirect("/Stocks");
            return;
        }

        Response.Redirect("/Identity/Account/Login");
    }
}

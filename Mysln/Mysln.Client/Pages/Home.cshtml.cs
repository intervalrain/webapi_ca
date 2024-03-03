using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mysln.Client.Pages;

public class HomeModel : PageModel
{
    private readonly ILogger<HomeModel> _logger;

    public HomeModel(ILogger<HomeModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        if (User.Identity.IsAuthenticated)
        {
            // 使用者已驗證
            // 您可以在這裡執行相應的操作
        }
        else
        {
            // 使用者未驗證
            // 您可以在這裡顯示登入按鈕或其他處理方式
        }
    }
}


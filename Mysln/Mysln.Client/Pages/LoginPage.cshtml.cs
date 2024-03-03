using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mysln.Client.Models;
using Newtonsoft.Json;

namespace Mysln.Client.Pages;

public class LoginModel : PageModel
{
    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        using (var client = new HttpClient())
        {
            var url = "http://localhost:5034/auth/login";
            var data = new
            {
                Email,
                Password
            };
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<User>();
                var identity = new ClaimsIdentity("custom");
                var expires = new JwtSecurityTokenHandler().ReadJwtToken(user.Token).Claims.SingleOrDefault(c => c.Type.Equals("exp")).Value;
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddSeconds(int.Parse(expires))
                };
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                    new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                HttpContext.User = new ClaimsPrincipal(identity);
                Response.Cookies.Append("UserId", user.Id.ToString(), cookieOptions);

                return RedirectToPage("Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "密碼錯誤");
                return Page();
            }
        }
    }

    private readonly ILogger<IndexModel> _logger;

    public LoginModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}
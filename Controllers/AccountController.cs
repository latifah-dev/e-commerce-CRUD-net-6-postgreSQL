using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using PALUGADA.Datas;


namespace PALUGADA.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly palugadaDBContext _dbContext;

        public AccountController(ILogger<AccountController> logger, palugadaDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Login()
        {
            return View(new LoginRequest());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest req)
        {
            if (!ModelState.IsValid)
            {
                return View(req);
            }
            var user = _dbContext.Users.FirstOrDefault(x=>x.Username == req.Username && x.Password == req.Password);
            if (user == null) {
                ViewBag.ErrorMessage = "Invalid Username or Password";
                return View(req);
            }
            if (user.TipeUser == "Pembeli")
            {
                ViewBag.ErrorMessage = "You'r not admin or seller";
                return View(req);
            }
            //authorisasi data ke cookie
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim("FullName", user.Username),
            new Claim(ClaimTypes.Role, user.TipeUser),
        };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
        };

            await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme, 
            new ClaimsPrincipal(claimsIdentity), 
            authProperties);
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Logout(){
        await HttpContext.SignOutAsync();

        return RedirectToAction("Login");
        }

    }
}
using Infrastructure.Email;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using System.IO.Pipelines;
using System.Security.Claims;
using FileWriter = System.IO.File;
namespace OnBoarding.Pages
{
    public class UserLoginModel : PageModel
    {
        private readonly Serilog.ILogger logger;
        private readonly IOnBordingFormRepository onBordingFormRepository;
        public static string? CurrentURI { get; set; }
        public UserLoginModel(Serilog.ILogger logger, IOnBordingFormRepository onBordingFormRepository)
        {
            this.logger = logger;
            this.onBordingFormRepository = onBordingFormRepository;
        }

        [BindProperty]
        public string? UserId { get; set; }

        [BindProperty]
        public string? Password { get; set; }

        public static string? UserError { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(UserId) || string.IsNullOrEmpty(Password))
                    return Page();

                var isValid = await onBordingFormRepository.ValidateEmployeeCredential(new { UserId, Password });

                if (!isValid)
                {
                    UserError = "The credentials provided are not valid!";
                    return Page();
                }

                var user = await onBordingFormRepository.GetEmployeeById(new { UserId });

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new AuthenticationProperties { ExpiresUtc = DateTimeOffset.UtcNow.AddDays(-1) });

                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                   new Claim(ClaimTypes.NameIdentifier, user?.Id),
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
                    new AuthenticationProperties { ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8), IsPersistent = true });

                var currentURI = string.IsNullOrEmpty(CurrentURI) ? "~/forms/newhire" : $"~/{CurrentURI}";
                return LocalRedirect(Url.Content(currentURI));
            }
            catch (Exception exception)
            {
                var type = exception.GetType();
                var message = exception.Message;
                var trace = exception.StackTrace;

                UserError = "Oops, we're sorry. Something has gone wrong. Please contact IT Department.";
                logger.Error("\n Type: {type} \n Message: {message} \n Stack Trace: {trace} \n", type, message, trace);

                Log.CloseAndFlush();

                return LocalRedirect(Url.Content("~/login"));
            }
        }
    }
}

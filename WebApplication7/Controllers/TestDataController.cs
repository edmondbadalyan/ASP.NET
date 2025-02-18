using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication7.Data;

namespace WebApplication7.Controllers
{
    public class TestDataController : Controller
    {
           private readonly UserManager<IdentityUser> _userManager;

        public TestDataController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> AddGameCreationClaim(string email)
        {
            // Получаем пользователя по email
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                // Проверяем, есть ли у пользователя уже такой claim
                var existingClaims = await _userManager.GetClaimsAsync(user);
                if (!existingClaims.Any(c => c.Type == "CanCreateGame" && c.Value == "true"))
                {
                    // Добавляем claim
                    await _userManager.AddClaimAsync(user, new Claim("CanCreateGame", "true"));
                    return Ok($"Claim 'CanCreateGame' добавлен пользователю {email}.");
                    
                }
                else
                {
                    return Ok($"У пользователя {email} уже есть claim 'CanCreateGame'.");
                }
            }
            else
            {
                return NotFound($"Пользователь с email {email} не найден.");
            }
        }
    }
}

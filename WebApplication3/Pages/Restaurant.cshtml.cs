using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication3.Pages
{
    public class RestaurantModel : PageModel
    {
        public List<Restaurant> Restaurants { get; set; } = new();
        public void OnGet()
        {
            Restaurants = new List<Restaurant>
            {
                new Restaurant("Итальянский уголок", "🍝", "Паста, пицца, тирамису", 4.5f),
                new Restaurant("Суши-мастер", "🍣", "Суши, роллы, сашими", 4.7f),
                new Restaurant("Бургерная №1", "🍔", "Бургеры, картофель фри", 4.3f),
                new Restaurant("Вегетариано", "🥑", "Постные и веганские блюда", 4.6f)
            };
        }
    }
    public record Restaurant(
            string Name,
            string Emoji,
            string Specialization,
            float Rating);
}


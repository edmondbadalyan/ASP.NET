using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Metrics;

namespace WebApplication3.Pages
{
    public class CountriesModel : PageModel
    {
        public List<Country> Countries { get; set; } = new();
        public void OnGet()
        {
            Countries = new List<Country>
            {
                new Country(
                    "������",
                    "https://flagcdn.com/ru.svg",
                    "������",
                    144_400_000,
                    17_098_246),

                new Country(
                    "�������",
                    "https://flagcdn.com/fr.svg",
                    "�����",
                    67_400_000,
                    640_679),

                new Country(
                    "��������",
                    "https://flagcdn.com/br.svg",
                    "��������",
                    213_900_000,
                    8_515_767),

                new Country(
                    "������",
                    "https://flagcdn.com/jp.svg",
                    "�����",
                    125_700_000,
                    377_975)
            };
        }
    }
    public record Country(
            string Name,
            string Flag,
            string Capital,
            long Population,
            int Area);
}


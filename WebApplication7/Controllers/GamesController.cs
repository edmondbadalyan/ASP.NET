using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Data;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }


        // Поиск игр по названию
        [Authorize(Policy = "SearchPolicy")]
        public async Task<IActionResult> SearchByTitle(string title)
        {
            var games = await _context.Games
                .Where(g => g.Title.Contains(title))
                .ToListAsync();
            return View(games);
        }

        // Поиск игр по названию студии
        [Authorize(Policy = "SearchPolicy")]
        public async Task<IActionResult> SearchByStudio(string studio)
        {
            var games = await _context.Games
                .Where(g => g.Studio.Contains(studio))
                .ToListAsync();
            return View(games);
        }

        // Поиск игр по названию студии и игры
        [Authorize(Policy = "SearchPolicy")]
        public async Task<IActionResult> SearchByStudioAndTitle(string studio, string title)
        {
            var games = await _context.Games
                .Where(g => g.Studio.Contains(studio) && g.Title.Contains(title))
                .ToListAsync();
            return View(games);
        }

        // Поиск игр по стилю
        [Authorize(Policy = "SearchPolicy")]
        public async Task<IActionResult> SearchByGenre(string genre)
        {
            var games = await _context.Games
                .Where(g => g.Genre.Contains(genre))
                .ToListAsync();
            return View(games);
        }

        // Поиск игр по году релиза
        [Authorize(Policy = "SearchPolicy")]
        public async Task<IActionResult> SearchByYear(int year)
        {
            var games = await _context.Games
                .Where(g => g.ReleaseDate.Year == year)
                .ToListAsync();
            return View(games);
        }

        // Отображение всех однопользовательских игр
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SinglePlayerGames()
        {
            var games = await _context.Games
                .Where(g => g.GameMode == GameMode.SinglePlayer)
                .ToListAsync();
            return View(games);
        }

        // Отображение всех многопользовательских игр
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MultiPlayerGames()
        {
            var games = await _context.Games
                .Where(g => g.GameMode == GameMode.MultiPlayer)
                .ToListAsync();
            return View(games);
        }

        // Показать игру с максимальным количеством проданных копий
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MaxSoldGame()
        {
            var game = await _context.Games
                .OrderByDescending(g => g.SoldCopies)
                .FirstOrDefaultAsync();
            return View(game);
        }

        // Показать игру с минимальным количеством проданных копий
        [Authorize(Roles = "Admin")]
        public IActionResult MinSoldGame()
        {
            var game = _context.Games.OrderBy(g => g.SoldCopies).FirstOrDefault();
            return View("Details", game);
        }

        // Отображение топ-3 самых продаваемых игр
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Top3BestSelling()
        {
            var games = await _context.Games
                .OrderByDescending(g => g.SoldCopies)
                .Take(3)
                .ToListAsync();
            return View(games);
        }

        // Отображение топ-3 самых непродаваемых игр
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Top3WorstSelling()
        {
            var games = await _context.Games
                .OrderBy(g => g.SoldCopies)
                .Take(3)
                .ToListAsync();
            return View(games);
        }

        public async Task<IActionResult> Index()
        {
            var games = await _context.Games.ToListAsync();
            return View(games);
        }

        // GET: Создание новой игры.
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Создание новой игры.
        // Для создания используется политика "GameCreationPolicy", реализующая кастомный AuthorizationHandler.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "GameCreationPolicy")]
        public async Task<IActionResult> Create(Game game)
        {
            game.CreatedBy = User.Identity.Name;
            Console.WriteLine("Начало метода Create");

            if (ModelState.IsValid)
            {
                Console.WriteLine("ModelState корректен");

                bool exists = await _context.Games
                    .AnyAsync(g => g.Title == game.Title && g.Studio == game.Studio);

                if (exists)
                {
                    Console.WriteLine("Игра уже существует в БД");
                    ModelState.AddModelError("", "Игра с таким названием и студией уже существует.");
                    return View(game);
                }

                Console.WriteLine($"Добавление игры: {game.Title}, {game.Studio}");

                game.CreatedBy = User.Identity.Name;
                _context.Games.Add(game);
                await _context.SaveChangesAsync();

                Console.WriteLine("Игра успешно сохранена в БД");

                return RedirectToAction(nameof(Index));
            }

            Console.WriteLine("ModelState НЕ корректен");
            return View(game);
        }


        // GET: Редактирование игры.
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var game = await _context.Games.FindAsync(id);
            if (game == null)
                return NotFound();

            // Если текущий пользователь не является создателем, запрет редактирования.
            if (game.CreatedBy != User.Identity.Name)
                return Forbid();

            return View(game);
        }

        // POST: Редактирование игры.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Game game)
        {
            if (id != game.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(game);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GameExists(game.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(game);
        }

        // GET: Удаление игры (запрос подтверждения).
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var game = await _context.Games.FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
                return NotFound();

            return View(game);
        }

        // POST: Подтверждение удаления игры.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // метод для проверки существования игры.
        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}

namespace WebApplication4
{
    public interface IMovieScheduleService
    {
        Task<IEnumerable<MovieScheduleDto>> GetAllSchedulesAsync();
    }


    public class MovieScheduleService : IMovieScheduleService
    {
        private readonly List<MovieSchedule> _schedules = new()
    {
        new MovieSchedule
        {
            Id = 1,
            Name = "Крестный отец",
            Director = "Фрэнсис Форд Коппола",
            Genre = "Криминал, Драма",
            Description = "Эпическая сага о семье мафиози...",
            Sessions = new List<DateTime>
            {
                new(2024, 03, 20, 18, 0, 0),
                new(2024, 03, 20, 21, 0, 0)
            }
        }
    };

        public async Task<IEnumerable<MovieScheduleDto>> GetAllSchedulesAsync()
        {
            return await Task.FromResult(_schedules.Select(s => new MovieScheduleDto
            {
                Name = s.Name,
                Sessions = s.Sessions
            }));
        }
    }
}

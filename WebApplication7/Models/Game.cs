using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
        public enum GameMode
        {
            SinglePlayer,
            MultiPlayer   
        }

    public class Game
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название игры")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Студия/Фирма")]
        public string Studio { get; set; }

        [Required]
        [Display(Name = "Стиль игры")]
        public string Genre { get; set; }

        [Required]
        [Display(Name = "Дата релиза")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Количество проданных копий")]
        public int SoldCopies { get; set; }

        [Display(Name = "Режим игры")]
        public GameMode GameMode { get; set; }

        // Свойство для хранения логина пользователя, создавшего игру (используется для проверки прав редактирования)
        public string? CreatedBy { get; set; }
    }

}

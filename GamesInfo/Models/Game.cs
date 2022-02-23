using System.ComponentModel.DataAnnotations;

namespace GamesInfo.Models
{
    public class Game
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string GameName { get; set; } = string.Empty;
        [StringLength(200)]
        public string GameDescription { get; set; } = string.Empty;
        public int GameCategoryId { get; set; }
        public GameСategory? GameCategory { get; set; }
        public int GameStudioId { get; set; }
        public GameStudio? GameStudio { get; set; }
    }
}


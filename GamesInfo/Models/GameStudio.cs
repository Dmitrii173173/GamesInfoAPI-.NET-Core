using System.ComponentModel.DataAnnotations;

namespace GamesInfo.Models
{
    public class GameStudio
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string StudioName { get; set; } = string.Empty;
    }
}

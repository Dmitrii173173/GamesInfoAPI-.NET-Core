using System.ComponentModel.DataAnnotations;

namespace GamesInfo
{
    public class GameСategory
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string CategoryName { get; set; } = string.Empty;
    }
}

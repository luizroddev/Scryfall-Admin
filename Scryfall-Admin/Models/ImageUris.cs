using System.ComponentModel.DataAnnotations;

namespace Scryfall_Admin.Models
{
    public class ImageUris
    {
        [Key]
        public int Id { get; set; }
        public string Small { get; set; }
        public string Normal { get; set; }
        public string Large { get; set; }
    }
}

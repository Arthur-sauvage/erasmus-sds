using System.ComponentModel.DataAnnotations;

namespace SDS.Models
{
    public class Basket
    {
        [Key]
        public string? idBasket { get; set; }

        public string? idStudent { get; set; }
        public string? idCourse { get; set; }

    }
}

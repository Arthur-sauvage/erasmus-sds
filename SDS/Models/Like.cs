using System.ComponentModel.DataAnnotations;

namespace SDS.Models
{
    public class Like
    {
        [Key]
        public string likeId { get; set; }

        public string studentId { get; set; }
        public string courseId { get; set; }
    }
}

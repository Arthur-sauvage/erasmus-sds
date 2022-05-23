using System.ComponentModel.DataAnnotations;


namespace SDS.Models
{
    public class Comment
    {
        [Key]
        public string CommentId { get; set; }
        public string? IdStudent { get; set; }

        public int IDCourse { get; set; }
        public string? CommentStudent { get; set; }

        public int QualityC { get; set; }
        public int DifficultyC { get; set; }

    }
}

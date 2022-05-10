using System.ComponentModel.DataAnnotations;


namespace SDS.Models
{
    public class Comment
    {
        [Key]
        //public String? IdStudent { get; set; }

        public string? CommentStudent { get; set; }

        public int QualityC { get; set; }

        public int DifficultyC { get; set; }

    }
}

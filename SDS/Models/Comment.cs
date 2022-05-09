using System.ComponentModel.DataAnnotations;


namespace SDS.Models
{
    public class Comment
    {
        [Key]
        //public int? IdStudent { get; set; }

        public string? CommentStudent { get; set; }
    }
}

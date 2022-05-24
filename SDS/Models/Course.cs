using System.ComponentModel.DataAnnotations;

namespace SDS.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Speciality { get; set; }
        public int Ects { get; set; }
        public int Likes { get; set; }
        public int? Difficulty { get; set; }

        public string? LastComment { get; set; }

        //public Comment? CommTest { get; set; }

        public List<Comment>? AllComments { get; set; }

        public int? Quality { get; set; }

        //public string? LastComment { get; set; }    
        //public string? LastComment { get; set; }

        //class Comment

        /*public class Comment
        {
            private string IdStudent { get; set; }

            private string CommentStudent { get; set; }
        }*/
    }
}
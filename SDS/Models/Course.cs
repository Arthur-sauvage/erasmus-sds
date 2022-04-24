using System.ComponentModel.DataAnnotations;

namespace SDS.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Likes { get; set; }
        public int Difficulty { get; set; }
    }
}
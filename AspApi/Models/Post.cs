using System.ComponentModel.DataAnnotations;

namespace AspApi.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter a Title")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Write a description")]
        public string Description { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}

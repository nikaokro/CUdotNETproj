using System.ComponentModel.DataAnnotations;

namespace dotNETproject.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        public int YearOfPublication { get; set; }

        [Required]
        [MaxLength(255)]
        public string AuthorName { get; set; }
    }

}

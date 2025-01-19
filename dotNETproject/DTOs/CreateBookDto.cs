using System.ComponentModel.DataAnnotations;

namespace dotNETproject.DTOs
{
    public class CreateBookDto
    {
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

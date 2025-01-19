using System.ComponentModel.DataAnnotations;

namespace dotNETproject.DTOs
{
    public class UpdateBookDto
    {
        [MaxLength(255)]
        public string Title { get; set; }

        public int? YearOfPublication { get; set; }

        [MaxLength(255)]
        public string AuthorName { get; set; }
    }
}

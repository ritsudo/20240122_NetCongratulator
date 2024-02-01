using System.ComponentModel.DataAnnotations;

namespace NetCongratulator.API.Dto
{
    public class UserCardReceive
    {
        public int id { get; set; }

        public DateTime? createdAt { get; set; }

        public DateTime? updatedAt { get; set; }

        [Required]
        [MaxLength(100)]
        public string? firstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? lastName { get; set; }

        [Required]
        public DateTime? birthdayDate { get; set; }

        public string? imageName { get; set; }
    }
}

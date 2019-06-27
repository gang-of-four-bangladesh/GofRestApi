using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gof.Api.Core.Enums;

namespace Gof.Api.Domain
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            this.CreatedAt = DateTime.UtcNow;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(20)]
        public string Password { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public UserStatus UserStatus { get; set; }
    }
}
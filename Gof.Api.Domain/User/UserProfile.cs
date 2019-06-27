using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gof.Api.Core.Enums;

namespace Gof.Api.Domain
{
    [Table("UsersProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(500)]
        public string ImagePath { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        [MaxLength(20)]
        public string NationalIdNumber { get; set; }

        [MaxLength(10)]
        public string ReferralCode { get; set; }
        
        public decimal Balance { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
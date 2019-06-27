using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gof.Api.Core.Enums;

namespace Gof.Api.Domain
{
    [Table("Products")]
    public class Product
    {
        public Product()
        {
            this.CreatedAt = DateTime.UtcNow;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public ProductCategory CategoryId { get; set; }

        [Required]
        public ProductUnit ProductUnit { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public string Brand { get; set; }

        [Required]
        public decimal Price { get; set; }

        public decimal Weight { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
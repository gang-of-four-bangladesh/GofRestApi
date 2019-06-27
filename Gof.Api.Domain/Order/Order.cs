using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gof.Api.Core.Enums;

namespace Gof.Api.Domain
{
    [Table("Orders")]
    public class Order
    {
        public Order()
        {
            this.CreatedAt = DateTime.UtcNow;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string OrderNumber { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime ProbableDeliveryAt { get; set; }

        [MaxLength(500)]
        [Required]
        public string DeliveryAddress { get; set; }

        [Required]
        [Column("Status")]
        public OrderStatus Status { get; set; }

        [MaxLength(1000)]
        public string Comment { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}
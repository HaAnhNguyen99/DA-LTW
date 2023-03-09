using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DA_LTW.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;

        // khoa ngoai 
        [ForeignKey("Customer")]
        public int? sdt { get; set; }
        public virtual Customer Customer { get; set; }

        // khoa ngoai tour
        [ForeignKey("Tour")]
        public int? IdTour { get; set; }

        [Required]
        public virtual Tour Tour { get; set; }
    }
}

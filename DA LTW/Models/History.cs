using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DA_LTW.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;

        // Foreign key CUSTOMER to history
        [ForeignKey("Customer")]
        public int? sdt { get; set; }
        public virtual Customer Customer { get; set; }

        // Foreign key TOUR to history
        [ForeignKey("Tour")]
        public int? IdTour { get; set; }

        [Required]
        public virtual Tour Tour { get; set; }
    }
}

using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DA_LTW.Models
{
    public class OrderDetail
    {
        // khoa ngoai Order
        [Key]
        [Column (Order = 1)]
        public int OrderId { get; set; }
        public virtual Order Order{ get; set; }

        //Khoa ngoai Tour
        [Key]
        [Column(Order = 2)]
        public int TourId { get; set; }
        public virtual Tour Tour { get; set; }

        public decimal Price { get; set; }

    }
}

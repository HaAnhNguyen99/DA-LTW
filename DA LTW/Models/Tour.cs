using System.ComponentModel.DataAnnotations;

namespace DA_LTW.Models
{
    public class Tour
    {
        [Key]
        public int IdTour { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên tour!!!")]
        public string Name_tour { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số người!!!")]
        [Range(15,30 , ErrorMessage = "Vui lòng nhập số người trong khoảng ( 15 - 30 người )!!!")]
        public int People { get; set; }

        [Required]
        [Display(Name = "Tour guide")]
        public string Tour_guide { get; set; }

        [Required]
        public string Detail { get; set; }

        [Required]
        public string stay { get; set; }

        [Required]
        public string Difficult { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;

        [Required]
        public DateTime Started_date { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int TotalDay { get; set; }

        public string? ImgURL{ get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SphinxTask.Models
{
    public class Product
    { 
        public int PId { get; set; }
        [Required (ErrorMessage ="This Field Is Required")]
        [MaxLength(50 ,ErrorMessage ="The Max Length is 50" )]
        public string PName { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        [MaxLength(150, ErrorMessage = "The Max Length is 150")]
        public string Discription { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        public bool IsActive { get; set; }
        [NotMapped]
        public ICollection<ClientProducts>? ClientProducts { get; set; }
    }
}
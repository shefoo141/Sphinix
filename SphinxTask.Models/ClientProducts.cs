using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SphinxTask.Models
{
    public class ClientProducts
    {
        public int ClientproductsId { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        [MaxLength(255, ErrorMessage = "The Max Length is 255")]
        public string Lisence { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [NotMapped]
        public Client client { get; set; }
        public int ClientId { get; set; }
        [NotMapped]
        public Product product { get; set; }
        public int ProductId { get; set; }
    }
}

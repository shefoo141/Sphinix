using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SphinxTask.Models
{
    public enum ClientClass
    {
        A, B, C
    }

    public enum ClientState
    {
        Active, Inactive, Pending
    }
    public class Client
    {
        public int CId { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        [MaxLength(50, ErrorMessage = "The Max Length is 50")]
        public string CName { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        public int Code { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        public ClientClass Class { get; set; }
        [Required(ErrorMessage = "This Field Is Required")]
        public ClientState State { get; set; }
        [NotMapped]
        public ICollection<ClientProducts>? ClientProducts { get; set; }
    }
}



using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SphinxTask.NewFolder
{
    public class ClientProductVM
    {
        public int? Id { get; set; }
        public int CId { get; set; }
        public int PId { get; set; }
        public string Lisence { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? ClientName { get; set; }
    }
}

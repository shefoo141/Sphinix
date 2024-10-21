using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SphinxTask.DataAccess.Repository;

namespace SphinxTask.Pages.Client
{
    public class DetailsModel : PageModel
    {
        private readonly IClientRepo clientRepo;
        public DetailsModel(IClientRepo _clientRepo)
        {
            clientRepo = _clientRepo;      
        }
        public Models.Client client { get; set; }
        public IActionResult OnGet(int itemid)
        {
            client = clientRepo.Getone(itemid, "Load");
            return Page();
        }
    }
}

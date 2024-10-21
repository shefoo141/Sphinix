using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SphinxTask.DataAccess.Repository;

namespace SphinxTask.Pages.ClientProduct
{
    public class DetailsModel : PageModel
    {
        private readonly IClientProductRepo clientProductRepo;
        public DetailsModel(IClientProductRepo _clientProductRepo)
        {
           clientProductRepo = _clientProductRepo;   
        }
        public Models.ClientProducts cltproud { get; set; }
        public IActionResult OnGet(int itemid)
        {
            cltproud = clientProductRepo.GetOne(itemid);
            return Page();
        }
    }
}

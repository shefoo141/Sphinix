using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SphinxTask.DataAccess.DataBase;
using SphinxTask.DataAccess.Repository;

namespace SphinxTask.Pages.Client
{
    public class IndexModel : PageModel
    { 
        private readonly IClientRepo ClientRepo;
        public IndexModel( IClientRepo _ClientRepo)
        {
            ClientRepo= _ClientRepo;
        }
        [BindProperty]
        public Models.Client Client { get; set; }
        public List<Models.Client> clients { get; set; }

        public void OnGet()
        {
            clients = ClientRepo.GetAll();
        }
        public IActionResult OnPost(int itemid)
        {
            ClientRepo.delete(itemid);
            return RedirectToPage("Index");   

        }

    }
}


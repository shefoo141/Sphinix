using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SphinxTask.DataAccess.Repository;

namespace SphinxTask.Pages.ClientProduct
{
    public class IndexModel : PageModel
    {
        private readonly IClientProductRepo clientProductsRepo;

        public IndexModel(IClientProductRepo _clientProductsRepo)
        {
           clientProductsRepo = _clientProductsRepo;
        }
        public List<Models.ClientProducts> clientProducts { get; set; }
        public IActionResult OnGet()
        {
            clientProducts = clientProductsRepo.GetAll();
            return Page();
        }
        public IActionResult OnPost(int clientproductsId)
        {
            clientProductsRepo.delete(clientproductsId);
            return RedirectToPage("Index");

        }
    }
    
}

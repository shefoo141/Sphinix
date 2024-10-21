using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SphinxTask.DataAccess.DataBase;
using SphinxTask.DataAccess.Repository;
using SphinxTask.Models;

namespace SphinxTask.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepo productRepo;
        private readonly IClientProductRepo clientProductRepo;

        public IndexModel(IProductRepo _productRepo , IClientProductRepo clientProductRepo)
        {
            productRepo = _productRepo;
            this.clientProductRepo = clientProductRepo;
        }
        [BindProperty]
        public Models.Product Product { get; set; }
        public List<Models.Product>? Products { get; set; }
        public IActionResult OnGet()
        {
            Products = productRepo.GetAll();
            return Page();
        }
        public IActionResult OnPost(int itemid)
        {
            var isThereProduct = clientProductRepo.GetRelatedProdcut(itemid);
            if (!isThereProduct)
            {
                productRepo.delete(itemid);
            }
            return RedirectToPage("Index");

        }
    }
}

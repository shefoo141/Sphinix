using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SphinxTask.DataAccess.Repository;

namespace SphinxTask.Pages.Product
{
    public class DetailsModel : PageModel
    {
        private readonly IProductRepo productRepo;
        public DetailsModel(IProductRepo _productRepo)
        {
            productRepo = _productRepo;
        }
        public Models.Product product { get; set; }
        public IActionResult OnGet(int itemid)
        {
            product = productRepo.GetOne(itemid);
            return Page();
        }
    }
}

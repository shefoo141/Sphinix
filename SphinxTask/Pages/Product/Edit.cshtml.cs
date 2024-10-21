using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SphinxTask.DataAccess.Repository;

namespace SphinxTask.Pages.Product
{
    public class EditModel : PageModel
    {
        private readonly IProductRepo proudctRepo;

        public EditModel(IProductRepo _proudctRepo)
        {
            proudctRepo = _proudctRepo;
        }
        [BindProperty]
        public Models.Product products { get; set; }
        public IActionResult OnGet(int itemid)
        {
            var product = proudctRepo.GetOne(itemid);
            products = product;
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                proudctRepo.Edit(products);
                return RedirectToPage(nameof(Index));
            }

            return Page();
        }
    }
}

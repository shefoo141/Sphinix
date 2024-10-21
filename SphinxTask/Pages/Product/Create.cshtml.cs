using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SphinxTask.DataAccess.Repository;

namespace SphinxTask.Pages.Product
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepo proudctRepo;

        public CreateModel( IProductRepo _proudctRepo)
        {
            proudctRepo = _proudctRepo;
        }

        [BindProperty]
        public Models.Product product { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
    
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                proudctRepo.Insert(product);
                return RedirectToPage("Index");
            }
          return Page();
        }
    }
    }

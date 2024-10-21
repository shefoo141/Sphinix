using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SphinxTask.DataAccess.DataBase;
using SphinxTask.DataAccess.Repository;
using SphinxTask.Models;
using SphinxTask.NewFolder;

namespace SphinxTask.Pages.ClientProduct
{
    public class CreateModel : PageModel
    {
        private readonly IClientProductRepo clientProductRepo;
        private readonly IProductRepo productRepo;
        private readonly IClientRepo clientRepo;

        public CreateModel( IClientProductRepo _clientProductRepo, IProductRepo _productRepo , IClientRepo _clientRepo)
        {
            clientProductRepo = _clientProductRepo;
            productRepo = _productRepo;
            clientRepo = _clientRepo;
        }

        [BindProperty]
        public ClientProductVM ClientProducts { get; set; }

        public SelectList? clientsList { get; set; }
        public SelectList? productsList { get; set; }
        public IActionResult OnGet()
        {
            var clients = clientRepo.GetAll();
            var products = productRepo.GetAll(p => p.IsActive == true);
            clientsList = new SelectList(clients, "CId", "CName");
            productsList = new SelectList(products, "PId", "PName");
            return Page();
        }
        
        public IActionResult OnPost()
        {
           
            if (ModelState.IsValid)
            {
                var ClientProduct = new ClientProducts()
                {
                    ProductId = ClientProducts.PId,
                    ClientId = ClientProducts.CId,
                    StartDate = ClientProducts.StartDate,
                    EndDate = ClientProducts.EndDate,
                    Lisence = ClientProducts.Lisence,
                };
                clientProductRepo.insert(ClientProduct);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

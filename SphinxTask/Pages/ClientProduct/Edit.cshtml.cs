using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SphinxTask.DataAccess.Repository;
using SphinxTask.Models;
using SphinxTask.NewFolder;

namespace SphinxTask.Pages.ClientProduct
{
    public class EditModel : PageModel
    {
        private readonly IClientProductRepo clientProductRepo;
        private readonly IProductRepo productRepo;
        private readonly IClientRepo clientRepo;

        public EditModel(IClientProductRepo _clientProductRepo , IProductRepo _productRepo , IClientRepo _clientRepo)
        {
            clientProductRepo = _clientProductRepo;
            productRepo = _productRepo;
            clientRepo = _clientRepo;
        }
        [BindProperty]
        public ClientProductVM ClientProducts { get; set; }

        public SelectList? clientsList { get; set; }
        public SelectList? productsList { get; set; }
        public IActionResult OnGet(int itemid)
        {
            var CP = clientProductRepo.GetOne(itemid);
            ClientProducts = new ClientProductVM()
            {
                StartDate = CP.StartDate,
                EndDate = CP.EndDate,
                CId = CP.ClientId,
                PId = CP.ProductId,
                Lisence = CP.Lisence,
                Id = CP.ClientproductsId,
                ClientName = clientRepo.Getone(CP.ClientId).CName
            };
            
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
                    ClientId = ClientProducts.CId,
                    ProductId = ClientProducts.PId,
                    StartDate = ClientProducts.StartDate,
                    EndDate = ClientProducts.EndDate,
                    Lisence = ClientProducts.Lisence,
                    ClientproductsId = ClientProducts.Id.Value
                };
                clientProductRepo.Edit(ClientProduct);
                return RedirectToPage(nameof(Index));
            }

            return Page();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SphinxTask.DataAccess.DataBase;
using SphinxTask.DataAccess.Repository;

namespace SphinxTask.Pages.Client
{
    public class EditModel : PageModel
    {
        private readonly IClientRepo clientRepo;

        public EditModel(IClientRepo _clientRepo)
        {
            clientRepo = _clientRepo;   
        }
        [BindProperty]
        public Models.Client clients { get; set; }
        public SelectList? ClientStates { get; set; }
        public SelectList? ClientClass { get; set; }


        public IActionResult OnGet(int itemid)
        {
            var clientStates = Enum.GetValues(typeof(Models.ClientState))
        .Cast<Models.ClientState>()
        .Select(e => new
        {
            Value = (int)e,
            Text = e.ToString()
        });
            var clientclass = Enum.GetValues(typeof(Models.ClientClass))
          .Cast<Models.ClientClass>()
          .Select(y => new
          {
              Value = (int)y,
              Text = y.ToString()
          });
            ClientStates = new SelectList(clientStates, "Value", "Text");
            ClientClass = new SelectList(clientclass, "Value", "Text");

            var client = clientRepo.Getone(itemid);
            clients = client;
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            clientRepo.Edit(clients);
            return RedirectToPage("Index");
      
        }
    }
}

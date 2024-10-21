using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SphinxTask.DataAccess.Repository;


namespace SphinxTask.Pages.Client
{
    public class CreateModel : PageModel
    {
        private readonly IClientRepo clientRepo;

        public CreateModel(IClientRepo _clientRepo )
        {
            clientRepo = _clientRepo;
        }

        [BindProperty]
        public Models.Client? client { get; set; }
        public SelectList? ClientStates { get; set; }
        public SelectList? ClientClass { get; set; }
       
        public IActionResult OnGet()
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
           
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid )
            {
                clientRepo.Insert(client);
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

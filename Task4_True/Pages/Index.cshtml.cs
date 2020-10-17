using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Task4_True.Control;
using Task4_True.Pages.Models;

namespace Task4_True.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;


        public IndexModel(ILogger<IndexModel> logger,
            UserControl userControl)
        {
            _logger = logger;
            Usercontrol = userControl;
        }

        public UserControl Usercontrol{ get; }
        public IEnumerable<User> users { get; private set; }

        public void OnGet()
        {
            users = Usercontrol.GetUsers();
        }
    }
}

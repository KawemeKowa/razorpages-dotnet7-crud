using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesDemo.Models;

namespace RazorPagesDemo.Pages
{
    public class PeopleModel : PageModel
    {
        private readonly MyDbContext _myDbContext;

        public List<Person> People { get; set;} = new List<Person>();

        [BindProperty]
        public Person NewPerson { get; set; }

        public PeopleModel(MyDbContext myDbContext)
        {
            _myDbContext= myDbContext;  
        }
        public void OnGet()
        {
           People = _myDbContext.People.ToList();
        }

        public IActionResult OnPost()
        {
            _myDbContext.People.Add(NewPerson);
            _myDbContext.SaveChanges();
            return RedirectToPage();
        }
    }
}

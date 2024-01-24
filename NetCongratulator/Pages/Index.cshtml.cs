using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetCongratulator.Models;
using NetCongratulator.Services;

namespace NetCongratulator.Pages
{
    public class IndexModel(UserCardService service) : PageModel
    {
        private readonly CultureInfo russianCulture = new CultureInfo("ru-RU");
        private readonly UserCardService _service = service;
        public IList<UserCard> UserCardList { get; set; } = default!;

        [BindProperty]
        public UserCard NewUserCard { get; set; } = default!;

        public void OnGet()
        {
            UserCardList = _service.GetAll().ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewUserCard == null)
            {
                return Page();
            }
            _service.Create(NewUserCard);
            return Redirect("/");
        }

        public IActionResult OnPostDelete(int id)
        {
            _service.DeleteById(id);

            return Redirect("/");
        }

        public IActionResult OnPostEdit(int id)
        {
            return Redirect("/EditPage?id=" + id);
        }
    }
}
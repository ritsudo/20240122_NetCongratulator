using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetCongratulator.Interfaces;
using NetCongratulator.Domain;
using NetCongratulator.Services;

namespace NetCongratulator.Pages
{
    public class IndexModel(IUserCardService service) : PageModel
    {
        private readonly CultureInfo russianCulture = new("ru-RU");
        private readonly IUserCardService _service = service;
        public IList<UserCard> UserCardList { get; set; } = default!;

        [BindProperty]
        public UserCard NewUserCard { get; set; } = default!;

        public void OnGet()
        {
            UserCardList = _service.GetAllWithinMonth().ToList();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid || NewUserCard == null)
            {
                return Page();
            }
            await _service.Create(NewUserCard);
            return Redirect("/");
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _service.DeleteById(id);

            return Redirect("/");
        }

        public IActionResult OnPostEdit(int id)
        {
            return Redirect("/EditPage?id=" + id);
        }

        public IActionResult OnPostEditAvatar(int id)
        {
            return Redirect("/EditAvatar?id=" + id);
        }
    }
}
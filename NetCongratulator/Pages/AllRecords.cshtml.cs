using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetCongratulator.Models;
using NetCongratulator.Services;

namespace NetCongratulator.Pages
{
    public class AllRecordsModel(UserCardService service) : PageModel
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

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid || NewUserCard == null)
            {
                return Page();
            }
            await _service.Create(NewUserCard);
            return Redirect("/AllRecords");
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            await _service.DeleteById(id);

            return Redirect("/AllRecords");
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
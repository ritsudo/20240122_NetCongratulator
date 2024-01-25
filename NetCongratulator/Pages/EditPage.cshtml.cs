using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetCongratulator.Models;
using NetCongratulator.Services;

namespace NetCongratulator.Pages
{
    public class EditPageModel(UserCardService service) : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public UserCard? UserCardToEdit { get; set;} = default!;

        [BindProperty]
        public UserCard EditedUserCard { get; set;} = default!;

        private readonly UserCardService _service = service;

        public void OnGet()
        {
            if (Id != 0) {
                UserCardToEdit = _service.GetById(Id);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid  || EditedUserCard == null)
            {
                return Page();
            }

            EditedUserCard.Id = Id;

            await _service.UpdateDataByCard(EditedUserCard);
            return Redirect("/");
        }
    }
}

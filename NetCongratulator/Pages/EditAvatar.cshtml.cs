using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetCongratulator.Interfaces;
using NetCongratulator.Domain;
using NetCongratulator.Services;

namespace NetCongratulator.Pages
{
    public class EditAvatarModel(IUserCardService service) : PageModel
    {
        private readonly IUserCardService _service = service;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public UserCard? UserCardToEdit { get; set; } = default!;

        [BindProperty]
        public EditImage UserImageEditDto { get; set; } = default!;

        public void OnGet()
        {
            if (Id != 0)
            {
                UserCardToEdit = _service.GetById(Id);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid || UserImageEditDto.Id == 0)
            {
                return Page();
            }

            if (UserImageEditDto.File == null || UserImageEditDto.File.Length <= 0)
            {
                return Page();
            }

            await _service.UpdateUserImage(UserImageEditDto.Id, UserImageEditDto.File);
            return Redirect("/");

        }

    }
}

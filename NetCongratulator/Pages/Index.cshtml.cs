using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NetCongratulator.Interfaces;
using NetCongratulator.Domain;
using NetCongratulator.Services;
using System.Text.Json;
using System.Collections.Generic;
using NetCongratulator.API.Dto;
using Microsoft.AspNetCore.Http.Extensions;

namespace NetCongratulator.Pages
{
    public class IndexModel(IUserCardService service, IHttpClientFactory httpClientFactory) : PageModel
    {
        private readonly CultureInfo russianCulture = new("ru-RU");
        private readonly IUserCardService _service = service;

        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;


        public IList<UserCardReceive> UserCardList { get; set; }

        [BindProperty]
        public UserCard NewUserCard { get; set; } = default!;


        //public void OnGet()
        //{
        //    UserCardList = _service.GetAllWithinMonth().ToList();
        //}

        public async Task OnGet()
        {
            var httpClient = _httpClientFactory.CreateClient("NetCongratulatorAPI");

            using HttpResponseMessage response = await httpClient.GetAsync(HttpContext.Request.GetDisplayUrl() + "Nearest");

            if (response.IsSuccessStatusCode)
            {
                using var contentStream = await response.Content.ReadAsStreamAsync();
                UserCardList = await JsonSerializer.DeserializeAsync<IList<UserCardReceive>>(contentStream);
            }
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
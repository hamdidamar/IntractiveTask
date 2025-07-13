using IntractiveTask.Entity.Dtos.UserDtos;
using IntractiveTask.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntractiveTask.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly ApiClient _apiClient;

        public UserController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _apiClient.GetAsync<List<UserDto>>("/api/User");
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto model)
        {
            await _apiClient.PostAsync<UserCreateDto, object>("/api/User", model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _apiClient.GetAsync<UserDto>($"/api/User/{id}");
            var updateDto = new UserUpdateDto
            {
                Id = user.Id,
                Username = user.Username,
                PasswordHash = user.PasswordHash 
            };
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateDto model)
        {
            await _apiClient.PutAsync("/api/User", model);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _apiClient.DeleteAsync($"/api/User/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}

using IntractiveTask.Entity.Dtos.TaskDtos;
using IntractiveTask.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntractiveTask.UI.Controllers
{
    public class ProjectTaskController : Controller
    {
        private readonly ApiClient _apiClient;

        public ProjectTaskController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _apiClient.GetAsync<List<ProjectTaskDto>>($"/api/ProjectTask");
            return View(tasks);
        }

        public IActionResult Create(int projectId)
        {
            var model = new ProjectTaskCreateDto { ProjectId = projectId };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectTaskCreateDto model)
        {
            await _apiClient.PostAsync<ProjectTaskCreateDto, object>("/api/ProjectTask", model);
            return RedirectToAction(nameof(Index), new { projectId = model.ProjectId });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await _apiClient.GetAsync<ProjectTaskDto>($"/api/ProjectTask/Detail/{id}");
            var updateDto = new ProjectTaskUpdateDto
            {
                Id = task.Id,
                ProjectId = task.ProjectId,
                Title = task.Title,
                Description = task.Description,
                EndDate = task.EndDate,
                Status = task.Status
            };
            return View(updateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProjectTaskUpdateDto model)
        {
            await _apiClient.PutAsync("/api/ProjectTask", model);
            return RedirectToAction(nameof(Index), new { projectId = model.ProjectId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int projectId)
        {
            await _apiClient.DeleteAsync($"/api/ProjectTask/{id}");
            return RedirectToAction(nameof(Index), new { projectId });
        }
    }
}

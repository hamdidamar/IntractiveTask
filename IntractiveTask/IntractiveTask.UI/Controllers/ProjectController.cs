using IntractiveTask.Entity.Dtos.ProjectDtos;
using IntractiveTask.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntractiveTask.UI.Controllers;

public class ProjectController : Controller
{
    private readonly ApiClient _apiClient;

    public ProjectController(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<IActionResult> Index()
    {
        var projects = await _apiClient.GetAsync<List<ProjectDto>>("/api/Project");
        return View(projects);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProjectCreateDto model)
    {
        await _apiClient.PostAsync<ProjectCreateDto, object>("/api/Project", model);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var project = await _apiClient.GetAsync<ProjectDto>($"/api/Project/{id}");
        var updateDto = new ProjectUpdateDto
        {
            Id = project.Id,
            Title = project.Title,
            Description = project.Description
        };
        return View(updateDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProjectUpdateDto model)
    {
        await _apiClient.PutAsync("/api/Project", model);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _apiClient.DeleteAsync($"/api/Project/{id}");
        return RedirectToAction(nameof(Index));
    }
}


﻿using IntractiveTask.UI.Models.Auth;
using IntractiveTask.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntractiveTask.UI.Controllers;

public class AuthController : Controller
{
    private readonly ApiClient _apiClient;

    public AuthController(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    [HttpGet]
    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest model)
    {
        var token = await _apiClient.PostForTokenAsync("/api/Auth/login", model);
        if (!string.IsNullOrEmpty(token))
        {
            HttpContext.Session.SetString("JwtToken", token);
            return RedirectToAction("Index", "Project");
        }

        ModelState.AddModelError("", "Login failed");
        return View(model);
    }
}


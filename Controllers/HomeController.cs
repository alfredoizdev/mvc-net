using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using portafolio.Models;
using portafolio.Services;

namespace portafolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
	private readonly IRepositoryProjects repositoryProjects;
	private readonly IServiceEmail serviceEmail;

    public HomeController(
		ILogger<HomeController> logger,
		IRepositoryProjects repositoryProjects,
		IServiceEmail serviceEmail
		)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
		var projects = repositoryProjects?.GetProjects()
			.Take(3)
			.ToList();
		var model = new HomeIndexViewModel() {Projects = projects};
        return View(model);
    }

	public IActionResult Projects()
	{
		var projects = new RepositoryProjects().GetProjects();
		return View(projects);
	} 


    public IActionResult Privacy()
    {
        return View();
    }

	[HttpGet]
	public IActionResult Contact()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Contact(ContactViewModel contactViewModel)
	{
		await serviceEmail.Sending(contactViewModel);
		return RedirectToAction("Thanks");
	}

	public IActionResult Thanks() {
		return View();
	}

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

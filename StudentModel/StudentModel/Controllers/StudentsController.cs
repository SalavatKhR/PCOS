using Microsoft.AspNetCore.Mvc;

namespace PCOS.Controllers;

public class StudentsController: Controller
{
    public IActionResult Index()
    {
        return View(Data.Students);
    }
}
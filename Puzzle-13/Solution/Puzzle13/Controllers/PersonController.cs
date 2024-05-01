using Microsoft.AspNetCore.Mvc;
using Puzzle13.Data;

namespace Puzzle13.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : Controller
{

    [HttpGet]
    public List<dtoPerson> GetAll()
    {
        var people = PersonManager.GetAllPeople();
        return people;
    }
}
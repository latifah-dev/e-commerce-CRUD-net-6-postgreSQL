using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PALUGADA.Datas.Entities;
using PALUGADA.Datas;
using Microsoft.AspNetCore.Authorization;

namespace PALUGADA.Controllers;
public class HomeController : Controller
{
    private readonly palugadaDBContext _dbContext;

    public HomeController( palugadaDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        IEnumerable<Barang> objCatlist = _dbContext.Barangs;
            return View(objCatlist);
    }

    public IActionResult Forbidden() {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PALUGADA.Datas;
using PALUGADA.Datas.Entities;
using PALUGADA.Models;
using Microsoft.AspNetCore.Authorization;

namespace PALUGADA.Controllers;
public class PembeliController : Controller
{
    private readonly palugadaDBContext _dbContext;

    public PembeliController( palugadaDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
            IEnumerable<Pembeli> objCatlist = _dbContext.Pembelis;
            return View(objCatlist);
    }

    public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pembeli empobj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Pembelis.Add(empobj);
                _dbContext.SaveChanges();
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }

            return View(empobj);
        }

public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var empfromdb = _dbContext.Pembelis.Find(Id);

            if (empfromdb == null)
            {
                return NotFound(); 
            }
            return View(empfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pembeli empobj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Pembelis.Update(empobj);
                _dbContext.SaveChanges();
                TempData["ResultOk"] = "Data Updated Successfully !";
                return RedirectToAction("Index");
            }
            return View(empobj);
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var empfromdb = _dbContext.Pembelis.Find(id);
         
            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(empfromdb);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var empfromdb = _dbContext.Pembelis.Find(id);
         
            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(empfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBr(int? IdPembeli)
        {
            var deleterecord = _dbContext.Pembelis.Find(IdPembeli);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _dbContext.Pembelis.Remove(deleterecord);
            _dbContext.SaveChanges();
            TempData["ResultOk"] = "Data Deleted Successfully !";
            return RedirectToAction("Index");
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

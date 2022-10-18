using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PALUGADA.Datas;
using PALUGADA.Datas.Entities;
using PALUGADA.Models;


namespace PALUGADA.Controllers;

public class BarangController : Controller
{
    private readonly DBPALUGADAContext _dbContext;

    public BarangController( DBPALUGADAContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
            IEnumerable<Barang> objCatlist = _dbContext.Barangs;
            return View(objCatlist);
    }

    public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Barang empobj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Barangs.Add(empobj);
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
            var empfromdb = _dbContext.Barangs.Find(Id);

            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(empfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Barang empobj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Barangs.Update(empobj);
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
            var empfromdb = _dbContext.Barangs.Find(id);
         
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
            var empfromdb = _dbContext.Barangs.Find(id);
         
            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(empfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBr(int? IdBarang)
        {
            var deleterecord = _dbContext.Barangs.Find(IdBarang);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _dbContext.Barangs.Remove(deleterecord);
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

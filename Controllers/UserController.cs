using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PALUGADA.Datas;
using PALUGADA.Datas.Entities;
using PALUGADA.Models;
using Microsoft.AspNetCore.Authorization;

namespace PALUGADA.Controllers;
public class UserController : Controller
{
    private readonly palugadaDBContext _dbContext;

    public UserController( palugadaDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
            IEnumerable<User> objCatlist = _dbContext.Users;
            return View(objCatlist);
    }

    public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User empobj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Users.Add(empobj);
                _dbContext.SaveChanges();
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }

            return View(empobj);
        }

public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var empfromdb = _dbContext.Users.Find(id);

            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(empfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User empobj)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Users.Update(empobj);
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
            var empfromdb = _dbContext.Users.Find(id);
         
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
            var empfromdb = _dbContext.Users.Find(id);
         
            if (empfromdb == null)
            {
                return NotFound();
            }
            return View(empfromdb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBr(int? IdUser)
        {
            var deleterecord = _dbContext.Users.Find(IdUser);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _dbContext.Users.Remove(deleterecord);
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

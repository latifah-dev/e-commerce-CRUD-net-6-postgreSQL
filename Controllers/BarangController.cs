using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PALUGADA.Datas;
using PALUGADA.Datas.Entities;
using PALUGADA.Models;
using Microsoft.AspNetCore.Authorization;

namespace PALUGADA.Controllers;
public class BarangController : Controller
{
    private readonly palugadaDBContext _dbContext;

    public BarangController( palugadaDBContext dbContext)
    {
        _dbContext = dbContext;
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
        public IActionResult Create(BarangRequest empobj)
        {
            if (ModelState.IsValid)
            {
                
                var UploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images");
                if (!Directory.Exists(UploadFolder))
                    Directory.CreateDirectory(UploadFolder);

                var filename = $"{empobj.KodeBarang}-{empobj.FileImage.FileName}";
                var filepath = Path.Combine(UploadFolder,filename);

                using var stream = System.IO.File.Create(filepath);
                if(empobj.FileImage != null)
                {
                    empobj.FileImage.CopyTo(stream);
                }

                var url = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/images/{filename}";
            _dbContext.Barangs.Add(new Barang {
            KodeBarang = empobj.KodeBarang,
            NamaBarang = empobj.NamaBarang,
            JenisBarang = empobj.JenisBarang,
            HargaBarang = empobj.HargaBarang,
            StokBarang = empobj.StokBarang,
            DeskripsiBarang = empobj.DeskripsiBarang,
            GambarBarang = filename,
            IdPenjual = empobj.IdPenjual,
            UrlGambar = url
            });
                _dbContext.SaveChanges();
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }

            return View();
        }


    
    public IActionResult Edit(int? Id) 
        {
        Barang empobj = _dbContext.Barangs.First(x=> x.IdBarang == Id);
        BarangRequest data = new BarangRequest {
            KodeBarang = empobj.KodeBarang,
            NamaBarang = empobj.NamaBarang,
            JenisBarang = empobj.JenisBarang,
            HargaBarang = empobj.HargaBarang,
            StokBarang = empobj.StokBarang,
            DeskripsiBarang = empobj.DeskripsiBarang,
            IdPenjual = empobj.IdPenjual,
            IdBarang = empobj.IdBarang
        };
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(BarangRequest empobj)
        {
                var UploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images");
                if (!Directory.Exists(UploadFolder))
                    Directory.CreateDirectory(UploadFolder);

                var filename = $"{empobj.KodeBarang}-{empobj.FileImage.FileName}";
                var filepath = Path.Combine(UploadFolder,filename);

                using var stream = System.IO.File.Create(filepath);
                if(empobj.FileImage != null)
                {
                    empobj.FileImage.CopyTo(stream);
                }

                var url = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/images/{filename}";
                
                Barang Updated = _dbContext.Barangs.First(x=> x.IdBarang == empobj.IdBarang);
                var Deletedfilepath = Path.Combine(UploadFolder,Updated.GambarBarang);
                System.IO.File.Delete(Deletedfilepath);

            Updated.KodeBarang = empobj.KodeBarang;
            Updated.NamaBarang = empobj.NamaBarang;
            Updated.JenisBarang = empobj.JenisBarang;
            Updated.HargaBarang = empobj.HargaBarang;
            Updated.StokBarang = empobj.StokBarang;
            Updated.DeskripsiBarang = empobj.DeskripsiBarang;
            Updated.GambarBarang = filename;
            Updated.IdPenjual = empobj.IdPenjual;
            Updated.UrlGambar = url;
            _dbContext.Barangs.Update(Updated);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
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

using BookingCruise.Data;
using Microsoft.AspNetCore.Mvc;
using BookingCruise.Models;

namespace BookingCruise.Controllers
{
    public class CruiseController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CruiseController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<CruiseBook> ObjCruiseList = _db.CruiseBooks;
            return View(ObjCruiseList);
        }

        //GET
        public IActionResult Create()
        {
            
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Create(CruiseBook obj)
        {
            //Ensure no duplication below if 

            if(obj.Name == obj.Arrival.ToString())
            {
                ModelState.AddModelError("Name", "Arrival and Name Cannot exactly match the same");
            }

            if(ModelState.IsValid)
            {
            _db.CruiseBooks.Add(obj);
            _db.SaveChanges();
                TempData["Success"] = "Bookings added successfully";
            return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? CruiseId )
        {
            if(CruiseId== null || CruiseId == 0)
            {
                return NotFound();
            }
            var dbvalues = _db.CruiseBooks.Find(CruiseId);

            if (dbvalues == null) {

                return NotFound();
            }


            //Another ways to fetch through Id

            //var dbvaluesfirst = _db.CruiseBooks.FirstOrDefault(u => u.CruiseId ==CruiseId);
            //var dbvaluesSingle = _db.CruiseBooks.SingleOrDefault(u => u.CruiseId.Equals(CruiseId));

            

            return View(dbvalues);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string CruiseId, CruiseBook obj)
        {
            //Ensure no duplication below if 
            //if(CruiseId != 0) {
            //    obj.CruiseId = CruiseId;
            //}
            if (obj.Name == obj.Arrival.ToString())
            {
                ModelState.AddModelError("Name", "Arrival and Name Cannot exactly match the same");
            }

            if (ModelState.IsValid)
            {
                _db.CruiseBooks.Update(obj);
                //_db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
              _db.SaveChanges();
                TempData["Success"] = "Bookings edited successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        public IActionResult Delete(int? CruiseId)
        {
            if (CruiseId == null || CruiseId == 0)
            {
                return NotFound();
            }
            var dbvalues = _db.CruiseBooks.Find(CruiseId);

            if (dbvalues == null)
            {

                return NotFound();
            }


            //Another ways to fetch through Id

            //var dbvaluesfirst = _db.CruiseBooks.FirstOrDefault(u => u.CruiseId ==CruiseId);
            //var dbvaluesSingle = _db.CruiseBooks.SingleOrDefault(u => u.CruiseId.Equals(CruiseId));



            return View(dbvalues);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int CruiseId)
        {

            var dbvalues = _db.CruiseBooks.Find(CruiseId);
            if (dbvalues == null)
            {
                return NotFound();
            }
            
            _db.CruiseBooks.Remove(dbvalues);
                _db.SaveChanges();
            TempData["Success"] = "Bookings deleted successfully";
            return RedirectToAction("Index");
        }

    }
}

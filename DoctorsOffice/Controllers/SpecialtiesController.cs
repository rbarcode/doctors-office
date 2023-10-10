using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DoctorsOffice.Models;
using System.Linq;
using System.Collections.Generic;

namespace DoctorsOffice.Controllers
{
  public class SpecialtiesController : Controller
  {
    private readonly DoctorsOfficeContext _db;


    public SpecialtiesController(DoctorsOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Specialties.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Specialty specialty)
    {
      if (!ModelState.IsValid)
      {
        return View(specialty);
      }
      else
      {
        _db.Specialties.Add(specialty);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }


    public ActionResult Details(int id)
    {
      Specialty thisSpecialty = _db.Specialties
              .Include(specialty => specialty.JoinEntities)
              .ThenInclude(join => join.Doctor)
              .FirstOrDefault(specialty => specialty.SpecialtyId == id);
      return View(thisSpecialty);
    }

    public ActionResult Edit(int id)
    {
      Specialty thisSpecialty = _db.Specialties.FirstOrDefault(specialties => specialties.SpecialtyId == id);
      return View(thisSpecialty);
    }

    [HttpPost]
    public ActionResult Edit(Specialty specialty)
    {
      _db.Specialties.Update(specialty);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Specialty thisSpecialty = _db.Specialties.FirstOrDefault(specialties => specialties.SpecialtyId == id);
      return View(thisSpecialty);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Specialty thisSpecialty = _db.Specialties.FirstOrDefault(specialties => specialties.SpecialtyId == id);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddDoctor(int id)
    {
      Specialty thisSpecialty = _db.Specialties.FirstOrDefault(specialties => specialties.SpecialtyId == id);
      ViewBag.DoctorId = new SelectList(_db.Doctors, "DoctorId", "Name");
      return View(thisSpecialty);
    }

    [HttpPost]
    public ActionResult AddDoctor(Specialty specialty, int doctorId)
    {
#nullable enable
      DoctorSpecialty? joinEntity = _db.DoctorSpecialties.FirstOrDefault(join => (join.DoctorId == doctorId && join.SpecialtyId == specialty.SpecialtyId));
#nullable disable
      if (joinEntity == null && doctorId != 0)
      {
        _db.DoctorSpecialties.Add(new DoctorSpecialty() { DoctorId = doctorId, SpecialtyId = specialty.SpecialtyId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = specialty.SpecialtyId });
    }

    [HttpPost]

    public ActionResult DeleteJoin(int joinId)
    {
      DoctorSpecialty joinEntry = _db.DoctorSpecialties.FirstOrDefault(join => join.DoctorSpecialtyId == joinId);
      _db.DoctorSpecialties.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TP1Module6EntityFrameworkBODojoPart2;
using TP1Module6EntityFrameworkDojoPart2.Data;
using TP1Module6EntityFrameworkDojoPart2.Models;

namespace TP1Module6EntityFrameworkDojoPart2.Controllers
{
    public class SamouraisController : Controller
    {
        private TP1Module6EntityFrameworkDojoContext db = new TP1Module6EntityFrameworkDojoContext();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            SamouraiViewModel samouraiVm = new SamouraiViewModel();
            samouraiVm.Armes = db.Armes.Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList();
            return View(samouraiVm);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiViewModel samouraiVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Samourai samourai = samouraiVM.Samourai;
                    if(samouraiVM.IdArme == null)
                    {
                        samourai.Arme = null;
                    }
                    else
                    {
                        samourai.Arme = db.Armes.FirstOrDefault(a => a.Id == samouraiVM.IdArme);
                    }
                    db.Samourais.Add(samourai);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    samouraiVM.Armes = db.Armes.Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList();
                    return View(samouraiVM);
                }
            }
            catch
            {
                samouraiVM.Armes = db.Armes.Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList();
                return View(samouraiVM);
            }
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SamouraiViewModel samouraiVM = new SamouraiViewModel();
            Samourai samourai = db.Samourais.Find(id);

            samouraiVM.Samourai = samourai;
            samouraiVM.Armes = db.Armes.Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList();

            if (samourai == null)
            {
                return HttpNotFound();
            }

            return View(samouraiVM);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiViewModel samouraiVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Samourai samourai = db.Samourais.Include(x => x.Arme).FirstOrDefault(x => x.Id == samouraiVM.Samourai.Id);
                    samourai.Nom = samouraiVM.Samourai.Nom;
                    samourai.Force = samouraiVM.Samourai.Force;
                    if (samouraiVM.IdArme != null)
                    {
                        samourai.Arme = db.Armes.FirstOrDefault(x => x.Id == samouraiVM.IdArme);
                        /*samouraisAvecMonArme = db.Samourais.Where(x => x.Arme.Id == samouraiVM.IdArme).ToList();

                        Arme arme = null;
                        foreach (var item in samouraisAvecMonArme)
                        {
                            arme = item.Arme;
                            item.Arme = null;
                            db.Entry(item).State = EntityState.Modified;
                        }

                        if (arme == null)
                        {
                            currentSamourai.Arme = db.Armes.FirstOrDefault(x => x.Id == samouraiVM.IdArme);
                        }
                        else
                        {
                            currentSamourai.Arme = arme;
                        }*/
                    }
                    else
                    {
                        samourai.Arme = null;
                    }

                    db.Entry(samourai).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(samouraiVM);
            }
            catch
            {

                return View(samouraiVM);
            }
            
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samouraiASupprimer = db.Samourais.Find(id);
            db.Samourais.Remove(samouraiASupprimer);
            db.SaveChanges();
                 
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

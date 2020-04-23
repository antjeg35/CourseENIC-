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
        private TP1Module6EntityFrameworkDojoPart2Context db = new TP1Module6EntityFrameworkDojoPart2Context();
       
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
            samourai.Potentiel = (samourai.Force + samourai.Arme.Degats) * samourai.ArtMartials.Count + 1;
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            SamouraiViewModel samouraiVM = new SamouraiViewModel();
            samouraiVM = HydratationListesArmesAvailableAndArtMartials(samouraiVM);
            return View(samouraiVM);
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
                    if (samouraiVM.IdsArtMartials.Count > 0) 
                    {
                        samourai.ArtMartials = db.ArtMartials.Where(a => samouraiVM.IdsArtMartials.Contains(a.Id)).ToList();
                    }

                    if(samouraiVM.IdArme == null)
                    {
                        samourai.Arme = null;
                    }
                    else
                    {
                        List<Samourai> samouraisWithThisArme = db.Samourais.Where(s => s.Arme.Id == samouraiVM.IdArme).ToList();
                        if (samouraisWithThisArme.Count() > 0)
                        {
                            ModelState.AddModelError("IdArme", "Cette arme appartient déjà à un autre samourai");
                        }
                        else
                        {
                            samourai.Arme = db.Armes.FirstOrDefault(a => a.Id == samouraiVM.IdArme);
                        }
                     }
                    db.Samourais.Add(samourai);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    samouraiVM = HydratationListesArmesAvailableAndArtMartials(samouraiVM);
                    return View(samouraiVM);
                }
            }
            catch
            {
                samouraiVM = HydratationListesArmesAvailableAndArtMartials(samouraiVM);
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
            if (samourai == null)
            {
                return HttpNotFound();
            }

            samouraiVM.Samourai = samourai;
            samouraiVM = HydratationListesArmesAvailableAndArtMartials(samouraiVM);
            samouraiVM.IdsArtMartials = samourai.ArtMartials.Select(a => a.Id).ToList();
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
                    Samourai samourai = db.Samourais.Find(samouraiVM.Samourai.Id);
                    /*Samourai samourai = db.Samourais.Include(x => x.Arme).Include(x=>x.ArtMartials).FirstOrDefault(x => x.Id == samouraiVM.Samourai.Id);*/
                    samourai.Nom = samouraiVM.Samourai.Nom;
                    samourai.Force = samouraiVM.Samourai.Force;
                    samourai.Arme = null;

                    if (samouraiVM.IdsArtMartials != null)
                    {
                        foreach (var item in samourai.ArtMartials)
                        {
                            db.Entry(item).State = EntityState.Modified;
                        }
                        samourai.ArtMartials = db.ArtMartials.Where(a => samouraiVM.IdsArtMartials.Contains(a.Id)).ToList();
                    }
                    else
                    {
                        samourai.ArtMartials = new List<ArtMartial>();
                    }


                    if (samouraiVM.IdArme != null)
                    {
                        List<Samourai> samouraisWithThisArme = db.Samourais.Where(s => s.Arme.Id == samouraiVM.IdArme).ToList();
                        if (samouraisWithThisArme.Count() > 0)
                        {
                            ModelState.AddModelError("IdArme", "Cette arme appartient déjà à un autre samourai");
                            samouraiVM = HydratationListesArmesAvailableAndArtMartials(samouraiVM);
                            return View(samouraiVM);
                        }
                        else
                        {
                            samourai.Arme = db.Armes.Find(samouraiVM.IdArme);
                        }
                    }
                    db.Entry(samourai).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(samouraiVM);
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
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
            samourai.Potentiel = (samourai.Force + samourai.Arme.Degats) * samourai.ArtMartials.Count + 1;
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


        private SamouraiViewModel HydratationListesArmesAvailableAndArtMartials(SamouraiViewModel samouraiVM)
        {
            samouraiVM.Armes = ListeArmesAvailable().Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList();
            samouraiVM.ArtMartials = db.ArtMartials.Select(a => new SelectListItem { Text = a.Nom, Value = a.Id.ToString() }).ToList();
            return samouraiVM;
        }
        public List<Arme> ListeArmesAvailable()
        {
            List<Arme> armesAvailable = new List<Arme>();
            foreach (var arme in db.Armes.ToList())
            {
                if (!db.Samourais.Any(s => s.Arme.Id == arme.Id))
                {
                    armesAvailable.Add(arme);
                }
            }
            return armesAvailable;
        }
    }
}

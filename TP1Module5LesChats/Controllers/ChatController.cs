using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP1Module5LesChats.Models;

namespace TP1Module5LesChats.Controllers
{
    public class ChatController : Controller
    {
        List<Chat> listeChats = Data.Instance.ListeChats;

        // GET: Chat
        public ActionResult Index()
        {
            return View(listeChats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            Chat chat = listeChats.Where(c => c.Id == id).Single();
            return View(chat);
        }

        // GET: Chat/Edit/5
        public ActionResult Edit(int id)
        {
            Chat chat = listeChats.FirstOrDefault(c => c.Id == id);
            if(chat != null)
            {
                return View(chat);
            }
            return RedirectToAction("Index");
        }

        // POST: Chat/Edit/5
        [HttpPost]
        public ActionResult Edit(Chat chat)
        {
            try
            {
                Chat chatEdit = listeChats.FirstOrDefault(c => c.Id == chat.Id);
                chatEdit.Nom = chat.Nom;
                chatEdit.Age = chat.Age;
                chatEdit.Couleur = chat.Couleur;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            List<Chat> listeChats = Data.Instance.ListeChats;
            Chat chat = listeChats.Where(c => c.Id == id).Single();
            return View(chat);
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                List<Chat> listeChats = Data.Instance.ListeChats;
                Chat chatRemoving = listeChats.Where(c => c.Id == id).Single();
                listeChats.Remove(chatRemoving);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

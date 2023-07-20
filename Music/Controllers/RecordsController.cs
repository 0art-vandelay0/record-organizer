using Microsoft.AspNetCore.Mvc;
using Music.Models;
using System.Collections.Generic;

namespace Music.Controllers
{
    public class RecordsController : Controller
    {

        [HttpGet("/records")]
        public ActionResult Index()
        {
            List<Record> allRecords = Record.GetAll();
            return View(allRecords);
        }

        [HttpGet("/records/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/records/delete")]
        public ActionResult DeleteAll()
        {
            Record.ClearAll();
            return View();
        }

        [HttpPost("/records")]
        public ActionResult Create(string title)
        {
            Record myRecord = new Record(title);
            return RedirectToAction("Index");
        }

        [HttpGet("/records/{id}")]
        public ActionResult Show(int id)
        {
            Record foundRecord = Record.Find(id);
            return View(foundRecord);
        }

    }
}
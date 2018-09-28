using NotesApplicationApi.Db;
using NotesApplicationApi.ModesApi;
using NotesApplicationApi.Services;
using NotesApplicationApi.VievModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace NotesApplicationApi.Controllers
{
    public class WeathersController : Controller
    {
        private WeatherContex db = new WeatherContex();
        private List<NotesVm> _notesVmList = new List<NotesVm>();
        private List<Weather> _notes;
        private LogicHandler _logic = new LogicHandler();
        private GenericHandler<RootObject> _genericLogic = new GenericHandler<RootObject>();
        private Weather _weather;
        private NotesVm _find;

        /// <summary>
        /// Search and sort functionality
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(string sortOrder, string query)
        {
            _notes = db.Weather.ToList();
            _genericLogic.GetserializeObject = _genericLogic.ReturnResultsFromApi(_logic.GetUrl().UrlApi).Result;
            foreach (var note in _notes)
            {
                var date = note.Date ?? DateTime.Now;
                _logic.MaxTemp = _logic.TempMaxvalue(_genericLogic.GetserializeObject, date);
                _notesVmList.Add(new NotesVm() {Id = note.Id,Date = date, Notes = note.Notes, Temp = _logic.MaxTemp });
            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var notes = from n in _notesVmList
                        select n;

            switch (sortOrder)
            {

                case "name_desc":
                    notes = notes.OrderByDescending(l => l.Notes);
                    break;
                case "Date":
                    notes = notes.OrderBy(l => l.Date);
                    break;
                case "date_desc":
                    notes = notes.OrderByDescending(l => l.Date);
                    break;
                default:
                    notes = notes.OrderBy(l => l.Notes);
                    break;
            }

            if (!string.IsNullOrEmpty(query))
            {
                notes = notes.Where(x => x.Notes.ToLower().Contains(query.ToLower()));
            }

            return View(notes);
        }


        // GET: Weathers and temp
        public ActionResult Index()
        {
            _notes = db.Weather.ToList();
            _genericLogic.GetserializeObject = _genericLogic.ReturnResultsFromApi(_logic.GetUrl().UrlApi).Result;
            foreach (var note in _notes)
            {
                var date = note.Date ?? DateTime.Now;
                _logic.MaxTemp = _logic.TempMaxvalue(_genericLogic.GetserializeObject, date);
                _notesVmList.Add(new NotesVm() {Id = note.Id ,Date = date, Notes = note.Notes, Temp = _logic.MaxTemp });
            }

            return View(_notesVmList);
        }

        // GET: Weathers/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Notes,Date")] Weather weather)
        {

            if (ModelState.IsValid)
            {
                db.Weather.Add(weather);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weather);
        }

        // GET: Weathers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Weather weather = db.Weather.Find(id);

            if (weather == null)
            {
                return HttpNotFound();
            }
            return View(weather);
        }

        // POST: Weathers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Notes,Date")] Weather weather)
        {

            if (ModelState.IsValid)
            {
                db.Entry(weather).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weather);
        }

        // GET: Weathers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _weather = db.Weather.Find(id);
            _weather.Id = (int)id;
            _notes = db.Weather.ToList();
            var notesid = _notes.Where(x => x.Id == _weather.Id);
            _genericLogic.GetserializeObject = _genericLogic.ReturnResultsFromApi(_logic.GetUrl().UrlApi).Result;
            foreach (var note in notesid)
            {
                var date = note.Date ?? DateTime.Now;
                _logic.MaxTemp = _logic.TempMaxvalue(_genericLogic.GetserializeObject, date);
                _notesVmList.Add(new NotesVm() {Id = note.Id,Date = date, Notes = note.Notes, Temp = _logic.MaxTemp });
            }

            _find = new NotesVm()
            {
                Id = _weather.Id,
                Date = _weather.Date ?? DateTime.Now,
                Notes = _weather.Notes,
                Temp = _logic.MaxTemp
            };

            if (_weather == null)
            {
                return HttpNotFound();
            }
            return View(_find);
        }

        // POST: Weathers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Weather weather = db.Weather.Find(id);
            db.Weather.Remove(weather);
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

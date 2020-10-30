using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TODOList.Entities;
using TODOList.Entities.Models;
using TODOList.Portal.Helpers;

namespace TODOList.Portal.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private TODOListEntities db = new TODOListEntities();

        // GET: Todo Index
        public ActionResult Index()
        {
            return View();
        }

        // get JSON data to bind in datatable
        public ActionResult GetData(JqueryDatatableParam param)
        {
            var userId = User.Identity.GetUserId();

            var todoList = db.Todo.Where(t => t.UserId == userId).ToList();

            if (!string.IsNullOrEmpty(param.sSearch))
            {
                todoList = todoList.Where(x => x.Id.ToString().ToLower().Contains(param.sSearch.ToLower())
                                              || x.TodoTitle.ToLower().Contains(param.sSearch.ToLower())
                                              || x.DueDate.ToString("dd'/'MM'/'yyyy").ToLower().Contains(param.sSearch.ToLower())).ToList();
            }


            var displayResult = todoList.Skip(param.iDisplayStart)
                .Take(param.iDisplayLength).ToList();
            var totalRecords = todoList.Count();

            return Json(new
            {
                param.sEcho,
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = totalRecords,
                aaData = displayResult
            }, JsonRequestBehavior.AllowGet);

        }

        // GET: Todo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Todo todo)
        {
            var userId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                todo.UserId = userId;
                db.Todo.Add(todo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        // GET: Todo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todo.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Todo todo)
        {
            var userId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                todo.UserId = userId;
                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // POST: Todo/Delete/5
        [HttpPost]
        public ActionResult ConfirmDelete(int? id)
        {
            Todo todo = db.Todo.Find(id);
            db.Todo.Remove(todo);
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

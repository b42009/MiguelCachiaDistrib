using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using MiguelCachiaDistrib.Models;

namespace MiguelCachiaDistrib.Controllers
{
    [System.Web.Http.RoutePrefix("api/Prefer")]
    public class PreferencmodelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // POST: Preferencmodels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [System.Web.Http.HttpPost]
        
        [System.Web.Http.Route("create")]
        public bool Create(String email,bool valueEmail,bool valueBirthDate,bool valuename)
        {
            try
            {
                var user = db.Users.FirstOrDefault(x => x.UserName == email);
                Preferencmodel pm = new Preferencmodel();
                pm.email = valueEmail;
                pm.birthday = valueBirthDate;
                pm.name = valuename;
                pm.praivecyuserid = user.Id;
                pm.praivecyuser = user;

                if (ModelState.IsValid)
                {

                    db.Preferencmodels.Add(pm);
                    db.SaveChanges();
                   
                }

              
                return true ;
            }
            catch (Exception e) {

                return false;
            }
        }
        public bool checkifexist(string email) {

            var user = db.Users.FirstOrDefault(x => x.UserName == email);
            var test = db.Preferencmodels.FirstOrDefault(x => x.praivecyuserid == user.Id);
            if (db.Preferencmodels.FirstOrDefault(x => x.praivecyuserid == user.Id) == null)
            {

                return true;
            }
            else { return false; }
                

        }

        public void UpdatenewFeeld(String email, bool valueEmail, bool valueBirthDate, bool valuename) {
            var user = db.Users.FirstOrDefault(x => x.UserName == email);
            var actualuser = db.Preferencmodels.FirstOrDefault(x => x.praivecyuserid == user.Id);
            actualuser.email = valueEmail;
            actualuser.name = valuename;
            actualuser.birthday = valueBirthDate;
            db.SaveChanges();

        }
        // GET: Preferencmodels/Edit/5


        // POST: Preferencmodels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[System.Web.Http.HttpPost]

        //[System.Web.Http.Route("edit")]
        //public ActionResult Edit()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(preferencmodel).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.praivecyuserid = new SelectList(db.ApplicationUsers, "Id", "Email", preferencmodel.praivecyuserid);
        //    return View(preferencmodel);
        //}

    
     
    }
}

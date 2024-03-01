using AutoMapper;
using IPBLL;
using IPDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TripTaskEFApp.Models;

namespace TripTaskEFApp.Controllers
{
    public class TripController : Controller
    {
        // GET: Trip
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetTrips()
        {
            TripService tripService = new TripService();
            var trips = tripService.GetTrips();
            List<TripVM> tripVMs = new List<TripVM>();

            foreach(Trip vm in trips)
            {
                tripVMs.Add(new TripVM
                {
                    TripId = vm.TripId,
                    Description = vm.Description,
                    Destination = vm.Destination,
                    StartDate = vm.StartDate,
                    EndDate = vm.EndDate
                });
            }

            //Mapper.Initialize(x => x.CreateMap<Trip, TripVM>());
            //Mapper.Map(trips, tripVMs);

            return Json(tripVMs, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteTrip(int tripId)
        {
            TripService tripService = new TripService();
            if(tripService.DeleteTrip(tripId))
            {
                return Json(JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}
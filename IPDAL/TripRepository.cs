using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPDAL
{
    public class TripRepository
    {
        public List<Trip> GetTripRepo()
        {
            ItineraryPlannerEntities ipe = new ItineraryPlannerEntities();
            return ipe.Trips.ToList();
        }

        public bool DeleteTripRepo(int tripId)
        {
            ItineraryPlannerEntities ipe = new ItineraryPlannerEntities();
            var trip = ipe.Trips.Where(x => x.TripId == tripId).FirstOrDefault();
            if (trip != null)
            {
                ipe.Trips.Remove(trip);
                ipe.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

using System;
using HandicappedDriver.Bridge;

namespace HandicappedDriver.CoreSystem
{
    public class Reservation
    {
        private int id;
        public DateTime startTime;
        public DateTime endTime;
        private ParkingSpace parkingSpace;
		private DriverData driverData;
        private Driver driver;

        public Reservation(Driver d, ParkingSpace ps, DateTime startTime, DateTime endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public string GetReservationInfo()
        {
            return "";
        }

        public void OccupyParkingSpace(int id)
        {
			parkingSpace.SetOccupied(true);
		}

        public void LeaveParkingSpace()
        {
			parkingSpace.SetOccupied(false);
        }

        public void CancelReservation()
        {
			
		}

        public void MakeReservation()
        {

        }

        private void LoadInfo()
        {

        }

        private void SaveInfo()
        {

        }
    }
}

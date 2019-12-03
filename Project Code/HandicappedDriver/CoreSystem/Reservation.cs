using System;
namespace HandicappedDriver.CoreSystem
{
    public class Reservation
    {
        private int id;
        public DateTime startTime;
        public DateTime endTime;
        private ParkingSpace parkingSpace;
        private Driver driver;

        public Reservation(Driver d, ParkingSpace ps, DateTime startTime, DateTime endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
        }

        public void GetReservationInfo()
        {

        }

        public void OccupyParkingSpace()
        {

        }

        public void LeaveParkingSpace()
        {

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

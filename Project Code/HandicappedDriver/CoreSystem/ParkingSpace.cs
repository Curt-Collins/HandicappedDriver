using System;
namespace HandicappedDriver.CoreSystem
{
    public class ParkingSpace
    {
        private string locationDescription;
        private bool occupied = false;
        private string locationCoordinates;
        private int id;
        private ParkingLot parkingLot;

        public ParkingSpace(int id)
        {
            this.id = id;
        }

        public string GetCoordinates()
        {
            return locationCoordinates;
        }

        public void SetOccupied(bool o)
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

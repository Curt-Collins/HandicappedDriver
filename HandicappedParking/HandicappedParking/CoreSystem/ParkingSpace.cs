using System;

// changed HandicappedDriver to HandicappedParking
namespace HandicappedParking.CoreSystem
{
    public class ParkingSpace
    {
        private string locationDescription;
        private bool occupied = false;
        private string locationCoordinates;
        public int id;
        public ParkingLot parkingLot;

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
            occupied = o;
        }

        public bool GetOccupied()
        {
            return occupied;
        }

        private void LoadInfo()
        {

        }

        private void SaveInfo()
        {

        }

    }
}

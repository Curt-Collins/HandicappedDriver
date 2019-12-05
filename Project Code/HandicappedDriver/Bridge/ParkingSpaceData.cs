using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandicappedDriver.Bridge
{
    public class ParkingSpaceData
    {
        private string NavInfo = "";

        public void SetNavInfo(string n)
        {
            NavInfo = n;
        }

        public string GetNavInfo()
        {
            return NavInfo;
        }

        public void LoadInfo()
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandicappedDriver.Bridge
{
    public class ReservationData
    {
        private string resvID = "";

        private void SetID(string r)
        {
            resvID = r;
        }

        public string GetID()
        {
            return resvID;
        }

        public void PullRes()
        {

        }

    }
}
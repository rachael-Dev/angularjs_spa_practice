using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIGFiance.Entities
{
    /// <summary>
    /// Ship by aircraft
    /// </summary>
    public class AircraftService : DeliveryServiceBase
    {
        public AircraftDeliverInfor DeliverInfor { get; set; }

        public AircraftService()
        {
            DeliveryService = "Aircraft";

            BaseCost = 20.0m;

            JuneToAugFactor = 0.8m;

            SepFactor = 2.0m;

            OtherMonthFactor = 1.0m;
        }

        public override string ToString()
        {           
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Flight No: {0},{4}Gate Of Arrival: {1},{4}Date Of Arrival: {2},{4}Cost: {3}", DeliverInfor.FlightNo, DeliverInfor.GateOfArrival, DeliverInfor.DateOfArrival, DeliverInfor.Cost, "<br />");
            return builder.ToString();
        }


    }
    public class AircraftDeliverInfor
    {
        public string FlightNo { get; set; }
        public string GateOfArrival { get; set; }
        public string DateOfArrival { get; set; }
        public string Cost { get; set; }

    }
}

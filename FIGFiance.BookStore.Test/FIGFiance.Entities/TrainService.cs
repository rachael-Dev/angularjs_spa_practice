using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIGFiance.Entities
{
    /// <summary>
    /// Ship via Train
    /// </summary>
    public class TrainService : DeliveryServiceBase 
    {
        public TrainDeliverInfor DeliverInfor { get; set; }

        public TrainService()
        {
            DeliveryService = "Train";

            BaseCost = 10.0m;

            JuneToAugFactor = 0.8m;

            SepFactor = 1.8m;

            OtherMonthFactor = 1.0m;
        }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("rain No: {0},{4}Station Of Arrival: {1},{4}Date Of Arrival: {2},{4}Cost: {3}", DeliverInfor.TrainNo, DeliverInfor.StationOfArrival, DeliverInfor.DateOfArrival, DeliverInfor.Cost, "<br />");
            return builder.ToString();
        }        
    }
    
    public class TrainDeliverInfor
        {
            public string TrainNo { get; set; }
            public string StationOfArrival { get; set; }
            public string DateOfArrival { get; set; }
            public string Cost { get; set; }

        }
}

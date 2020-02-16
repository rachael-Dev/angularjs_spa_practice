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
        private IDeliveryInfo DeliverInfor;

        //public IDeliveryInfo d { get; set; }
        public TrainService(IDeliveryInfo deliData)
        {
            DeliveryService = "Train";
            BaseCost = 10.0m;
            JuneToAugFactor = 0.8m;
            SepFactor = 1.8m;
            OtherMonthFactor = 1.0m;
            this.DeliverInfor = deliData;
        }

        public TrainService()
            : this(new TrainDeliverInfor())
        {
        }

        public override string RetrieveDeliveryInfo()
        {
            return DeliverInfor.GetDeliveryInfo();
        }     
    }
    
    public class TrainDeliverInfor: IDeliveryInfo
        {
            public string TrainNo { get; set; }
            public string StationOfArrival { get; set; }
            public string DateOfArrival { get; set; }
            public string Cost { get; set; }

            public string GetDeliveryInfo()
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendFormat("Train No: {0},{4}Station Of Arrival: {1},{4}Date Of Arrival: {2},{4}Cost: {3}", TrainNo, StationOfArrival, DateOfArrival, Cost, "<br />");
                return builder.ToString();
            }
        }
}

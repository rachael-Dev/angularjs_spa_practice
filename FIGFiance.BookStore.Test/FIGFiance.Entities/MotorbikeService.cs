using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIGFiance.Entities
{
    /// <summary>
    /// Ship by motor bike
    /// </summary>
    public class MotorbikeService : DeliveryServiceBase 
    {
        public MotorbikeDeliverInfor DeliverInfor { get; set; }

        public MotorbikeService()
        {
            DeliveryService = "Motorbike";

            BaseCost = 5.0m;

            JuneToAugFactor = 0.5m;

            SepFactor = 1.5m;

            OtherMonthFactor = 1.0m;
        }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("DriverName: {0},{4}Mobile: {1},{4}Delivery date: {2},{4}Cost: {3}", DeliverInfor.DriverName, DeliverInfor.Mobile, DeliverInfor.DeliveryDate, DeliverInfor.Cost, "<br />");
            return builder.ToString();
        }   
    }

    public class MotorbikeDeliverInfor
    {
        public string DriverName { get; set; }
        public string Mobile { get; set; }
        public string DeliveryDate { get; set; }
        public string Cost { get; set; }

    }
}

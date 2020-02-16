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
        private IDeliveryInfo DeliverInfor;

        public MotorbikeService(IDeliveryInfo deliData)
        {
            DeliveryService = "Motorbike";
            BaseCost = 5.0m;
            JuneToAugFactor = 0.5m;
            SepFactor = 1.5m;
            OtherMonthFactor = 1.0m;
            this.DeliverInfor = deliData;
        }

        public MotorbikeService()
            : this(new MotorbikeDeliverInfor())
        {
        }

        public override string RetrieveDeliveryInfo()
        {
            return DeliverInfor.GetDeliveryInfo();
        }     
    }

    public class MotorbikeDeliverInfor: IDeliveryInfo
    {
        public string DriverName { get; set; }
        public string Mobile { get; set; }
        public string DeliveryDate { get; set; }
        public string Cost { get; set; }

        public string GetDeliveryInfo()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("DriverName: {0},{4}Mobile: {1},{4}Delivery date: {2},{4}Cost: {3}", DriverName, Mobile, DeliveryDate, Cost, "<br />");
            return builder.ToString();
        }
    }
}

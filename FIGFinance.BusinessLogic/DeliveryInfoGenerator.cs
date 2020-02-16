using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIGFiance.Entities;

namespace FIGFinance.BusinessLogic 
{
    public enum DeliveryOptions
    {
        Motorbike, Train, Aircraft
    }


    /// <summary>
    /// 
    /// </summary>
    public class DeliveryInfoGenerator
    {
        /// <summary>
        /// for testing purpose, dummy data generated
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string GenerateDeliveryInfor(BuyBookModel model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.DeliveryService))
            {
                return string.Empty;
            }
            //MotorbikeService.MotorbikeDeliverInfor
            DeliveryOptions selectOption = (DeliveryOptions)Enum.Parse(typeof(DeliveryOptions), model.DeliveryService);
            string deliveryInfo = string.Empty;

            string dteFormat = "dd/MM/yyyy";
            IDeliveryInfo deliverInfor;
            var opt = new DeliveryServiceBase();
            switch (selectOption)
            {
                case DeliveryOptions.Motorbike:                 
                    deliverInfor = new MotorbikeDeliverInfor()
                    {
                        DriverName = "FigDriver 1",
                        Mobile = "021 999 9999",
                        Cost = model.DeliveryCost.ToString("F2"),
                        DeliveryDate = DateTime.Now.ToString(dteFormat)
                    };
                    opt = new MotorbikeService(deliverInfor);                    
                    break;
                case DeliveryOptions.Train:
                    IDeliveryInfo DeliverInfor = new TrainDeliverInfor()
                    {
                        TrainNo = "FigTrain 2",
                        StationOfArrival = "Auckland",
                        Cost = model.DeliveryCost.ToString("F2"),
                        DateOfArrival = DateTime.Now.ToString(dteFormat)
                    };
                    opt = new TrainService(DeliverInfor);                     
                    break;
                case DeliveryOptions.Aircraft:                  
                    deliverInfor = new AircraftDeliverInfor()
                    {
                        FlightNo = "FigFligth 3",
                        GateOfArrival = "Gate 18",
                        Cost = model.DeliveryCost.ToString("F2"),
                        DateOfArrival = DateTime.Now.ToString(dteFormat)
                    };
                    opt = new AircraftService(deliverInfor);                    
                    break;
                default:
                    break;
            }

            deliveryInfo = opt.RetrieveDeliveryInfo();
            return deliveryInfo;
        }
    }
}

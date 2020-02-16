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
            switch (selectOption)
            {
                case DeliveryOptions.Motorbike:
                    var motorOpt = new MotorbikeService();
                    motorOpt.DeliverInfor = new MotorbikeDeliverInfor()
                    {
                        DriverName = "FigDriver 1",
                        Mobile = "021 999 9999",
                        Cost = model.DeliveryCost.ToString("F2"),
                        DeliveryDate = DateTime.Now.ToString(dteFormat)
                    };
                    deliveryInfo = motorOpt.ToString();
                    break;
                case DeliveryOptions.Train:
                     var trainOpt = new TrainService();
                     trainOpt.DeliverInfor = new TrainDeliverInfor()
                    {
                        TrainNo = "FigTrain 2",
                        StationOfArrival = "Auckland",
                        Cost = model.DeliveryCost.ToString("F2"),
                        DateOfArrival = DateTime.Now.ToString(dteFormat)
                    };
                     deliveryInfo = trainOpt.ToString();
                    break;
                case DeliveryOptions.Aircraft:
                     var airOpt = new AircraftService();
                     airOpt.DeliverInfor = new AircraftDeliverInfor()
                    {
                        FlightNo = "FigFligth 3",
                        GateOfArrival = "Gate 18",
                        Cost = model.DeliveryCost.ToString("F2"),
                        DateOfArrival = DateTime.Now.ToString(dteFormat)
                    };
                     deliveryInfo = airOpt.ToString();
                    break;
                default:
                    break;

            }

            return deliveryInfo;
        }
    }
}

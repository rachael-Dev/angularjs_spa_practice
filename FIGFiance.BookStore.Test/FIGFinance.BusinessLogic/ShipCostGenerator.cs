using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIGFiance.Entities;
//using FIGFinance.RepositoryBase;


namespace FIGFinance.BusinessLogic 
{
    /// <summary>
    /// for testing purpose, create a test ship cost dataset
    /// </summary>
    public class ShipCostGenerator
    {
        public List<DeliveryServiceBase> GetAll()
        {
            List<DeliveryServiceBase> shipMethods = new List<DeliveryServiceBase>();
            shipMethods.Add(new MotorbikeService());
            shipMethods.Add(new TrainService());
            shipMethods.Add(new AircraftService());

            return shipMethods;
        }
    }
}

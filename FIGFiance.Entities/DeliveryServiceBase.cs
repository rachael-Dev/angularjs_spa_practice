using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIGFiance.Entities
{
    /// <summary>
    /// Delivery service
    /// </summary>
    public class DeliveryServiceBase : IEntityBase
    {
        public string DeliveryService { get; set; }
        
        protected decimal BaseCost { get; set; }
        
        protected decimal JuneToAugFactor { get; set; }
        
        protected decimal SepFactor { get; set; }
        
        protected decimal OtherMonthFactor { get; set; }

        private decimal _factor;

        public decimal DeliveryCost
        { 
            get {
                int month = DateTime.Now.Month;//get the current month
                if (month >= 6 && month <= 8)
                    _factor = JuneToAugFactor;
                else if (month == 9)
                    _factor = SepFactor;
                else
                    _factor = OtherMonthFactor;

                return BaseCost * _factor;
            }
          
        }

        public virtual string RetrieveDeliveryInfo()
        {
            return string.Empty;
        }

        public string ID
        {
            get;
            set;
        }
    }
}

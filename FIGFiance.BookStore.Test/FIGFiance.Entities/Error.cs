using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIGFiance.Entities
{
    /// <summary>
    /// Error handling
    /// </summary>
    public class Error : IEntityBase
    {
        public string ID { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

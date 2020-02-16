using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIGFiance.Entities
{
    /// <summary>
    /// Book : data from google book
    /// </summary>
    public class Book: IEntityBase
    {
        public string Kind { get; set; }
        public string ID { get; set; }
        public string ETag { get; set; }
        public string SelfLink { get; set; }
        public VolumeInformation VolumeInfor { get; set; }
        //public string Publisher { get; set; }
        //public string PublishDate { get; set; }
        //public string Description { get; set; }
        //public ImageLink ImagelLinks { get; set; }
        public int? PageCount { get; set; }
    }

    public class VolumeInformation
    {
        public string Title { get; set; }

        public string Subtitle { get; set; }
        public List<string> Authors { get; set; }
        public string Publisher { get; set; }
        public string PublishDate { get; set; }
        public string Description { get; set; }
        public ImageLink ImagelLinks { get; set; }
              
    }

    public class ImageLink
    {
        public string SmallThumbnail { get; set; }

        public string Thumbnail { get; set; }

    }
}

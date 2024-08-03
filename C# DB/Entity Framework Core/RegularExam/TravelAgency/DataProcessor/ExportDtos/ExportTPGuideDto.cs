using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TravelAgency.DataProcessor.ExportDtos
{
    [XmlType("TourPackageGuide")]
    public class ExportTPGuideDto
    {
        [XmlElement(nameof(GuideId))]
        public int GuideId { get; set; }
        [XmlElement(nameof(TourId))]
        public int TourId { get; set;}
    }
}

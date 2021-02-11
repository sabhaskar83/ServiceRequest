using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRequest.Models
{
    [Table("servicerequest")]
    public class ServiceRequestModel
    {
        [Key]

        public Guid id { get; set; }
        [StringLength(100)]
        public string buildingCode { get; set; }
        [StringLength(250)]

        public string description { get; set; }
        public int currentStatus { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public string lastModifiedBy { get; set; }
        public DateTime? lastModifiedDate { get; set; }

    }
}

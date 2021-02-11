using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRequest.Models
{
    public class ServiceRequestContext:DbContext
    {
        public ServiceRequestContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<ServiceRequestModel> servicerequest { get; set; }
    }
}

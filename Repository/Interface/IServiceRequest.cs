using ServiceRequest.Dtos;
using ServiceRequest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRequest.Repository.Interface
{
    public interface IServiceRequest
    {
        ServiceRequestDto GetRecordById(Guid id);
        List<ServiceRequestDto> GetAllRecords();
        ServiceRequestModel CreateRecord();

        void UpdateRecord(Guid id);

        void DeleteRecord(Guid id);
    }
}

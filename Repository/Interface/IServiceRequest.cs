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
        void CreateRecord(ServiceRequestModel request);

        int UpdateRecord(Guid id,ServiceRequestModel request);

        void DeleteRecord(Guid id);
    }
}

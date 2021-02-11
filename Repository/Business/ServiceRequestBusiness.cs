using ServiceRequest.Dtos;
using ServiceRequest.Enum;
using ServiceRequest.Models;
using ServiceRequest.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceRequest.Repository.Business
{
    public class ServiceRequestBusiness : IServiceRequest
    {
        ServiceRequestContext _serviceRequestContext;
        public ServiceRequestBusiness(ServiceRequestContext serviceRequestContext)
        {
            this._serviceRequestContext = serviceRequestContext;
        }
        public void CreateRecord(ServiceRequestModel request)
        {
            var response = _serviceRequestContext.servicerequest.Add(request);
            _serviceRequestContext.SaveChanges();
                  }

        public void DeleteRecord(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ServiceRequestDto> GetAllRecords()
        {
            var servicerequestlist = _serviceRequestContext.servicerequest.ToList();
            List<ServiceRequestDto> response = new List<ServiceRequestDto>();
            foreach (ServiceRequestModel srm in servicerequestlist)
            {
                ServiceRequestDto srd = new ServiceRequestDto()
                {
                    buildingCode = srm.buildingCode,
                    currentStatus = (Enum.Enums.CurrentStatus)System.Enum.ToObject(typeof(Enums), srm.currentStatus),
                    description=srm.description,
                    createdDate=srm.createdDate,
                    createdBy=srm.createdBy,
                    lastModifiedDate=srm.lastModifiedDate.Value,
                    id=srm.id,
                    lastModifiedBy=srm.lastModifiedBy,
                    

                };
                response.Add(srd);
            }
            return response;
        }

        public ServiceRequestDto GetRecordById(Guid id)
        {
            ServiceRequestDto srd = null;
            var record = _serviceRequestContext.servicerequest.Where(m=>m.id==id)
                                                                          .FirstOrDefault();
            if (record != null)
            {
                srd = new ServiceRequestDto()
                {
                    buildingCode = record.buildingCode,
                    description = record.description,
                    createdDate = record.createdDate,
                    lastModifiedDate = record.lastModifiedDate.Value,
                    createdBy = record.createdBy,
                    currentStatus = (Enum.Enums.CurrentStatus)System.Enum.ToObject(typeof(Enums), record.currentStatus),
                    id = record.id,
                    lastModifiedBy = record.lastModifiedBy

                };
            }
           
            return srd;
        }

        public void UpdateRecord(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

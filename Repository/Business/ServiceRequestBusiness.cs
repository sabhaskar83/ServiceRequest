using Microsoft.AspNetCore.Mvc;
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
            request.id = Guid.NewGuid();
            var response = _serviceRequestContext.servicerequest.Add(request);
            _serviceRequestContext.SaveChanges();
        }

        public int DeleteRecord(Guid id)
        {
            var record = _serviceRequestContext.servicerequest.Where(m => m.id == id).FirstOrDefault();
            if (record == null)
                return 0;
            _serviceRequestContext.servicerequest.Remove(record);
            _serviceRequestContext.SaveChanges();
            return 1;

            throw new NotImplementedException();
        }

        public List<ServiceRequestDto> GetAllRecords()
        {
            var servicerequestlist = _serviceRequestContext.servicerequest.ToList();
            List<ServiceRequestDto> response = new List<ServiceRequestDto>();
            try
            {
                foreach (ServiceRequestModel srm in servicerequestlist)
                {
                    ServiceRequestDto srd = new ServiceRequestDto()
                    {
                        buildingCode = srm.buildingCode,
                        currentStatus = (Enum.Enums.CurrentStatus)srm.currentStatus,
                        description = srm.description,
                        createdDate = srm.createdDate,
                        createdBy = srm.createdBy,
                        lastModifiedDate = srm.lastModifiedDate==null?DateTime.MinValue: srm.lastModifiedDate.Value,
                        id = srm.id,
                        lastModifiedBy = srm.lastModifiedBy,


                    };
                    response.Add(srd);
                }
            }
            catch(Exception ex)
            {

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
                    lastModifiedDate = record.lastModifiedDate == null ? DateTime.MinValue : record.lastModifiedDate.Value,
                    createdBy = record.createdBy,
                    currentStatus = (Enum.Enums.CurrentStatus)record.currentStatus,
                    id = record.id,
                    lastModifiedBy = record.lastModifiedBy

                };
            }
           
            return srd;
        }

        public int UpdateRecord(Guid id,ServiceRequestModel request)
        {
           var record= _serviceRequestContext.servicerequest.Where(m => m.id == id).FirstOrDefault();
            if (record == null)
                return 0;
            record.description = request.description;
            record.buildingCode = request.buildingCode;
            record.currentStatus = request.currentStatus;
            request.lastModifiedBy = request.lastModifiedBy;
            request.lastModifiedDate = request.lastModifiedDate;
            _serviceRequestContext.servicerequest.Add(request);
            _serviceRequestContext.SaveChanges();
            return 1;

        }
    }
}

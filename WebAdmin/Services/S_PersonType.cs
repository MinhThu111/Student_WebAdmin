using Student_WebAdmin.Lib;
using Student_WebAdmin.Models;
using System;

namespace Student_WebAdmin.Services
{
    public interface IS_PersonType
    {
        Task<ResponseData<List<M_PersonType>>> getListPersonType(string accessToken);
        Task<ResponseData<List<M_PersonType>>> getListPersonTypeByConditionSequenceStatus(string accessToken, string sequenceStatus, string name, DateTime? fdate, DateTime? tdate);
        Task<ResponseData<List<M_PersonType>>> getListPersonTypeBySequenceStatus(string accessToken, string sequenceStatus);
        Task<ResponseData<M_PersonType>> getPersonTypeById(string accessToken, int id);
        Task<ResponseData<M_PersonType>> Create(string accessToken, EM_PersonType model, string createdBy);
        Task<ResponseData<M_PersonType>> Update(string accessToken, EM_PersonType model, string updatedBy);
        Task<ResponseData<M_PersonType>> Delete(string accessToken, int id);
        Task<ResponseData<M_PersonType>> UpdateStatus(string accessToken, int id, int status, DateTime? timer, string updatedBy);
    }
    public class S_PersonType : IS_PersonType
    {
        private readonly ICallBaseApi _callApi;
        public S_PersonType(ICallBaseApi callApi)
        {
            _callApi = callApi;
        }

        public async Task<ResponseData<List<M_PersonType>>> getListPersonType(string accessToken)
        {
            return await _callApi.GetResponseDataAsync<List<M_PersonType>>("/PersonType/getlistPersonType", default(Dictionary<string, dynamic>), accessToken);
        }
        //public async Task<ResponseData<List<M_PersonType>>> getListPerson(string accessToken)
        //{
        //    return await _callApi.GetResponseDataAsync<List<M_PersonType>>("Person/getListPerson", default(Dictionary<string, dynamic>), accessToken);
        //}
        public async Task<ResponseData<List<M_PersonType>>> getListPersonTypeByConditionSequenceStatus(string accessToken, string sequenceStatus, string name, DateTime? fdate, DateTime? tdate)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"sequenceStatus", sequenceStatus},
                {"name", name},
                {"fdate", fdate?.ToString("O")},
                {"tdate", tdate?.ToString("O")},
            };
            return await _callApi.GetResponseDataAsync<List<M_PersonType>>("/PersonType/getListPersonByConditionSequenceStatus", dictPars, accessToken);
        }
        public async Task<ResponseData<List<M_PersonType>>> getListPersonTypeBySequenceStatus(string accessToken, string sequenceStatus)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"sequenceStatus", sequenceStatus},
            };
            return await _callApi.GetResponseDataAsync<List<M_PersonType>>("/PersonType/getListPersonBySequenceStatus", dictPars, accessToken);
        }
        public async Task<ResponseData<M_PersonType>> getPersonTypeById(string accessToken, int id)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"id", id},
            };
            return await _callApi.GetResponseDataAsync<M_PersonType>("/PersonType/getPersonById", dictPars, accessToken);
        }
        public async Task<ResponseData<M_PersonType>> Create(string accessToken, EM_PersonType model, string createdBy)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"firstName", model.Name}
                //{"createdBy", createdBy},
            };
            return await _callApi.PostResponseDataAsync<M_PersonType>("/PersonType/Create", dictPars, accessToken);
        }
        public async Task<ResponseData<M_PersonType>> Update(string accessToken, EM_PersonType model, string updatedBy)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                //{"id", model.id},
                //{"firstName", model.firstName},
                //{"lastName", model.lastName},
                //{"gender", model.gender},
                //{"phoneNumber", model.phoneNumber},
                //{"status", model.status},
                ////{"updatedBy", updatedBy},
                //{"timer", model.timer?.ToString("O")},
                ////{"timer",DateTime.Now.ToString("mm-dd-yyyy") },
                //{"addressId",model.addressId },
                //{"personId",model.personTypeId }
            };
            return await _callApi.PutResponseDataAsync<M_PersonType>("/PersonType/Update", dictPars, accessToken);
        }
        public async Task<ResponseData<M_PersonType>> Delete(string accessToken, int id)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"id", id},
            };
            return await _callApi.DeleteResponseDataAsync<M_PersonType>("/PersonType/Delete", dictPars, accessToken);
        }
        public async Task<ResponseData<M_PersonType>> UpdateStatus(string accessToken, int id, int status, DateTime? timer, string updatedBy)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                //{"id", id},
                //{"status", status},
                //{"updatedBy", updatedBy},
                //{"timer", timer?.ToString("O")},
            };
            return await _callApi.PutResponseDataAsync<M_PersonType>("/PersonType/UpdateStatus", dictPars, accessToken);
        }
    }
}

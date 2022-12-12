using Student_WebAdmin.Lib;
using Student_WebAdmin.Models;
using System;

namespace Student_WebAdmin.Services
{
    public interface IS_Address
    {
        Task<ResponseData<List<M_Address>>> getListAddress(string accessToken);
        //Task<ResponseData<List<M_Folk>>> getListFolkByConditionSequenceStatus(string accessToken, string sequenceStatus, string name, DateTime? fdate, DateTime? tdate);
        //Task<ResponseData<List<M_Folk>>> getListFolkBySequenceStatus(string accessToken, string sequenceStatus);
        Task<ResponseData<M_Address>> getAddressById(string accessToken, int? id);
        //Task<ResponseData<M_Folk>> Create(string accessToken, EM_Folk model, string createdBy);
        //Task<ResponseData<M_Folk>> Update(string accessToken, EM_Folk model, string updatedBy);
        //Task<ResponseData<M_Folk>> Delete(string accessToken, int id);
        //Task<ResponseData<M_Folk>> UpdateStatus(string accessToken, int id, int status, DateTime? timer, string updatedBy);
    }
    public class S_Address : IS_Address
    {
        private readonly ICallBaseApi _callApi;
        public S_Address(ICallBaseApi callApi)
        {
            _callApi = callApi;
        }

        public async Task<ResponseData<List<M_Address>>> getListAddress(string accessToken)
        {
            return await _callApi.GetResponseDataAsync<List<M_Address>>("/Folk/getListFolk", default(Dictionary<string, dynamic>), accessToken);
        }
        //public async Task<ResponseData<List<M_Folk>>> getListFolk(string accessToken)
        //{
        //    return await _callApi.GetResponseDataAsync<List<M_Folk>>("Folk/getListFolk", default(Dictionary<string, dynamic>), accessToken);
        //}
        //public async Task<ResponseData<List<M_Folk>>> getListFolkByConditionSequenceStatus(string accessToken, string sequenceStatus, string name, DateTime? fdate, DateTime? tdate)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"sequenceStatus", sequenceStatus},
        //        {"name", name},
        //        {"fdate", fdate?.ToString("O")},
        //        {"tdate", tdate?.ToString("O")},
        //    };
        //    return await _callApi.GetResponseDataAsync<List<M_Folk>>("Folk/getListFolkByConditionSequenceStatus", dictPars, accessToken);
        //}
        //public async Task<ResponseData<List<M_Folk>>> getListFolkBySequenceStatus(string accessToken, string sequenceStatus)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"sequenceStatus", sequenceStatus},
        //    };
        //    return await _callApi.GetResponseDataAsync<List<M_Folk>>("/Folk/getListFolkBySequenceStatus", dictPars, accessToken);
        //}
        public async Task<ResponseData<M_Address>> getAddressById(string accessToken, int? id)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"id", id},
            };
            return await _callApi.GetResponseDataAsync<M_Address>("/Address/getAddressById", dictPars, accessToken);
        }
        //public async Task<ResponseData<M_Folk>> Create(string accessToken, EM_Folk model, string createdBy)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"firstName", model.firstName},
        //        {"lastName", model.lastName},
        //        {"FolkTypeId",model.FolkTypeId },
        //        { "birthDay", model.birthDay},
        //        {"gender", model.gender},
        //        {"FolkId",model.FolkId },
        //        {"religionId",model.religionId },
        //        {"folkId",model.folkId },
        //        {"addressId",model.addressId },
        //        {"phoneNumber",model.phoneNumber },
        //        {"email", model.email},
        //        //{"createdBy", createdBy},
        //    };
        //    return await _callApi.PostResponseDataAsync<M_Folk>("/Folk/Create", dictPars, accessToken);
        //}
        //public async Task<ResponseData<M_Folk>> Update(string accessToken, EM_Folk model, string updatedBy)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"id", model.id},
        //        {"firstName", model.firstName},
        //        {"lastName", model.lastName},
        //        {"gender", model.gender},
        //        {"phoneNumber", model.phoneNumber},
        //        {"status", model.status},
        //        //{"updatedBy", updatedBy},
        //        {"timer", DateTime.Now.ToString("O")},
        //        //{"timer",DateTime.Now.ToString("mm-dd-yyyy") },
        //        {"addressId",model.addressId },
        //        {"FolkId",model.FolkTypeId }
        //    };
        //    return await _callApi.PutResponseDataAsync<M_Folk>("/Folk/Update", dictPars, accessToken);
        //}
        //public async Task<ResponseData<M_Folk>> Delete(string accessToken, int id)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"id", id},
        //    };
        //    return await _callApi.DeleteResponseDataAsync<M_Folk>("/Folk/Delete", dictPars, accessToken);
        //}
        //public async Task<ResponseData<M_Folk>> UpdateStatus(string accessToken, int id, int status, DateTime? timer, string updatedBy)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"id", id},
        //        {"status", status},
        //        {"updatedBy", updatedBy},
        //        {"timer", timer?.ToString("O")},
        //    };
        //    return await _callApi.PutResponseDataAsync<M_Folk>("/Folk/UpdateStatus", dictPars, accessToken);
        //}
    }
}

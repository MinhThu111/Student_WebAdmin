using Student_WebAdmin.Lib;
using Student_WebAdmin.Models;
using System;

namespace Student_WebAdmin.Services
{
    public interface IS_Religion
    {
        Task<ResponseData<List<M_Religion>>> getListReligion(string accessToken);
        //Task<ResponseData<List<M_Religion>>> getListReligionByConditionSequenceStatus(string accessToken, string sequenceStatus, string name, DateTime? fdate, DateTime? tdate);
        //Task<ResponseData<List<M_Religion>>> getListReligionBySequenceStatus(string accessToken, string sequenceStatus);
        //Task<ResponseData<M_Religion>> getReligionById(string accessToken, int id);
        //Task<ResponseData<M_Religion>> Create(string accessToken, EM_Religion model, string createdBy);
        //Task<ResponseData<M_Religion>> Update(string accessToken, EM_Religion model, string updatedBy);
        //Task<ResponseData<M_Religion>> Delete(string accessToken, int id);
        //Task<ResponseData<M_Religion>> UpdateStatus(string accessToken, int id, int status, DateTime? timer, string updatedBy);
    }
    public class S_Religion : IS_Religion
    {
        private readonly ICallBaseApi _callApi;
        public S_Religion(ICallBaseApi callApi)
        {
            _callApi = callApi;
        }

        public async Task<ResponseData<List<M_Religion>>> getListReligion(string accessToken)
        {
            return await _callApi.GetResponseDataAsync<List<M_Religion>>("/Religion/GetListReligion", default(Dictionary<string, dynamic>), accessToken);
        }
        //public async Task<ResponseData<List<M_Religion>>> getListReligion(string accessToken)
        //{
        //    return await _callApi.GetResponseDataAsync<List<M_Religion>>("Religion/getListReligion", default(Dictionary<string, dynamic>), accessToken);
        //}
        //public async Task<ResponseData<List<M_Religion>>> getListReligionByConditionSequenceStatus(string accessToken, string sequenceStatus, string name, DateTime? fdate, DateTime? tdate)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"sequenceStatus", sequenceStatus},
        //        {"name", name},
        //        {"fdate", fdate?.ToString("O")},
        //        {"tdate", tdate?.ToString("O")},
        //    };
        //    return await _callApi.GetResponseDataAsync<List<M_Religion>>("Religion/getListReligionByConditionSequenceStatus", dictPars, accessToken);
        //}
        //public async Task<ResponseData<List<M_Religion>>> getListReligionBySequenceStatus(string accessToken, string sequenceStatus)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"sequenceStatus", sequenceStatus},
        //    };
        //    return await _callApi.GetResponseDataAsync<List<M_Religion>>("/Religion/getListReligionBySequenceStatus", dictPars, accessToken);
        //}
        //public async Task<ResponseData<M_Religion>> getReligionById(string accessToken, int id)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"id", id},
        //    };
        //    return await _callApi.GetResponseDataAsync<M_Religion>("/Religion/getReligionById", dictPars, accessToken);
        //}
        //public async Task<ResponseData<M_Religion>> Create(string accessToken, EM_Religion model, string createdBy)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"firstName", model.firstName},
        //        {"lastName", model.lastName},
        //        {"ReligionTypeId",model.ReligionTypeId },
        //        { "birthDay", model.birthDay},
        //        {"gender", model.gender},
        //        {"ReligionId",model.ReligionId },
        //        {"religionId",model.religionId },
        //        {"folkId",model.folkId },
        //        {"addressId",model.addressId },
        //        {"phoneNumber",model.phoneNumber },
        //        {"email", model.email},
        //        //{"createdBy", createdBy},
        //    };
        //    return await _callApi.PostResponseDataAsync<M_Religion>("/Religion/Create", dictPars, accessToken);
        //}
        //public async Task<ResponseData<M_Religion>> Update(string accessToken, EM_Religion model, string updatedBy)
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
        //        {"ReligionId",model.ReligionTypeId }
        //    };
        //    return await _callApi.PutResponseDataAsync<M_Religion>("/Religion/Update", dictPars, accessToken);
        //}
        //public async Task<ResponseData<M_Religion>> Delete(string accessToken, int id)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"id", id},
        //    };
        //    return await _callApi.DeleteResponseDataAsync<M_Religion>("/Religion/Delete", dictPars, accessToken);
        //}
        //public async Task<ResponseData<M_Religion>> UpdateStatus(string accessToken, int id, int status, DateTime? timer, string updatedBy)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"id", id},
        //        {"status", status},
        //        {"updatedBy", updatedBy},
        //        {"timer", timer?.ToString("O")},
        //    };
        //    return await _callApi.PutResponseDataAsync<M_Religion>("/Religion/UpdateStatus", dictPars, accessToken);
        //}
    }
}

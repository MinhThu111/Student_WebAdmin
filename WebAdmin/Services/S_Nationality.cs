using Student_WebAdmin.Lib;
using Student_WebAdmin.Models;
using System;

namespace Student_WebAdmin.Services
{
    public interface IS_Nationality
    {
        Task<ResponseData<List<M_Nationality>>> getListNationality(string accessToken);
        //Task<ResponseData<List<M_Nationality>>> getListNationalityByConditionSequenceStatus(string accessToken, string sequenceStatus, string name, DateTime? fdate, DateTime? tdate);
        //Task<ResponseData<List<M_Nationality>>> getListNationalityBySequenceStatus(string accessToken, string sequenceStatus);
        //Task<ResponseData<M_Nationality>> getNationalityById(string accessToken, int id);
        //Task<ResponseData<M_Nationality>> Create(string accessToken, EM_Nationality model, string createdBy);
        //Task<ResponseData<M_Nationality>> Update(string accessToken, EM_Nationality model, string updatedBy);
        //Task<ResponseData<M_Nationality>> Delete(string accessToken, int id);
        //Task<ResponseData<M_Nationality>> UpdateStatus(string accessToken, int id, int status, DateTime? timer, string updatedBy);
    }
    public class S_Nationality : IS_Nationality
    {
        private readonly ICallBaseApi _callApi;
        public S_Nationality(ICallBaseApi callApi)
        {
            _callApi = callApi;
        }

        public async Task<ResponseData<List<M_Nationality>>> getListNationality(string accessToken)
        {
            return await _callApi.GetResponseDataAsync<List<M_Nationality>>("/Nationality/getListNationality", default(Dictionary<string, dynamic>), accessToken);
        }
        //public async Task<ResponseData<List<M_Nationality>>> getListNationality(string accessToken)
        //{
        //    return await _callApi.GetResponseDataAsync<List<M_Nationality>>("Nationality/getListNationality", default(Dictionary<string, dynamic>), accessToken);
        //}
        //public async Task<ResponseData<List<M_Nationality>>> getListNationalityByConditionSequenceStatus(string accessToken, string sequenceStatus, string name, DateTime? fdate, DateTime? tdate)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"sequenceStatus", sequenceStatus},
        //        {"name", name},
        //        {"fdate", fdate?.ToString("O")},
        //        {"tdate", tdate?.ToString("O")},
        //    };
        //    return await _callApi.GetResponseDataAsync<List<M_Nationality>>("Nationality/getListNationalityByConditionSequenceStatus", dictPars, accessToken);
        //}
        //public async Task<ResponseData<List<M_Nationality>>> getListNationalityBySequenceStatus(string accessToken, string sequenceStatus)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"sequenceStatus", sequenceStatus},
        //    };
        //    return await _callApi.GetResponseDataAsync<List<M_Nationality>>("/Nationality/getListNationalityBySequenceStatus", dictPars, accessToken);
        //}
        //public async Task<ResponseData<M_Nationality>> getNationalityById(string accessToken, int id)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"id", id},
        //    };
        //    return await _callApi.GetResponseDataAsync<M_Nationality>("/Nationality/getNationalityById", dictPars, accessToken);
        //}
        //public async Task<ResponseData<M_Nationality>> Create(string accessToken, EM_Nationality model, string createdBy)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"firstName", model.firstName},
        //        {"lastName", model.lastName},
        //        {"NationalityTypeId",model.NationalityTypeId },
        //        { "birthDay", model.birthDay},
        //        {"gender", model.gender},
        //        {"nationalityId",model.nationalityId },
        //        {"religionId",model.religionId },
        //        {"folkId",model.folkId },
        //        {"addressId",model.addressId },
        //        {"phoneNumber",model.phoneNumber },
        //        {"email", model.email},
        //        //{"createdBy", createdBy},
        //    };
        //    return await _callApi.PostResponseDataAsync<M_Nationality>("/Nationality/Create", dictPars, accessToken);
        //}
        //public async Task<ResponseData<M_Nationality>> Update(string accessToken, EM_Nationality model, string updatedBy)
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
        //        {"NationalityId",model.NationalityTypeId }
        //    };
        //    return await _callApi.PutResponseDataAsync<M_Nationality>("/Nationality/Update", dictPars, accessToken);
        //}
        //public async Task<ResponseData<M_Nationality>> Delete(string accessToken, int id)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"id", id},
        //    };
        //    return await _callApi.DeleteResponseDataAsync<M_Nationality>("/Nationality/Delete", dictPars, accessToken);
        //}
        //public async Task<ResponseData<M_Nationality>> UpdateStatus(string accessToken, int id, int status, DateTime? timer, string updatedBy)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"id", id},
        //        {"status", status},
        //        {"updatedBy", updatedBy},
        //        {"timer", timer?.ToString("O")},
        //    };
        //    return await _callApi.PutResponseDataAsync<M_Nationality>("/Nationality/UpdateStatus", dictPars, accessToken);
        //}
    }
}

using Student_WebAdmin.Lib;
using Student_WebAdmin.Models;
using Student_WebAdmin.ViewModels;
using System;

namespace Student_WebAdmin.Services
{
    public interface IS_NewsCategory
    {
        Task<ResponseData<List<M_NewsCategory>>> getListNewsCategory(string accessToken);
        //Task<ResponseData<List<M_Count>>> getCountNewsCategoryByNewsCategoryType(string accessToken);
        //Task<ResponseData<List<M_NewsCategory>>> getListNewsCategoryByConditionSequenceStatus(string accessToken, string sequenceStatus, string name, DateTime? fdate, DateTime? tdate);
        //Task<ResponseData<List<M_NewsCategory>>> getListNewsCategoryBySequenceStatus(string accessToken, string sequenceStatus, string lstNewsCategorytypeid);
        //Task<ResponseData<M_NewsCategory>> getNewsCategoryById(string accessToken, int id);
       
        //Task<ResponseData<M_NewsCategory>> Create(string accessToken, EM_NewsCategory model, string createdBy);
        //Task<ResponseData<M_NewsCategory>> Update(string accessToken, EM_NewsCategory model, string updatedBy);
        //Task<ResponseData<M_NewsCategory>> Delete(string accessToken, int id, string updatedBy);
        //Task<ResponseData<M_NewsCategory>> UpdateStatus(string accessToken, int id, int status, DateTime? timer, string updatedBy);
    }
    public class S_NewsCategory : IS_NewsCategory
    {
        private readonly ICallBaseApi _callApi;
        public S_NewsCategory(ICallBaseApi callApi)
        {
            _callApi = callApi;
        }

        public async Task<ResponseData<List<M_NewsCategory>>> getListNewsCategory(string accessToken)
        {
            return await _callApi.GetResponseDataAsync<List<M_NewsCategory>>("/NewsCategory/getListNewsCategory", default(Dictionary<string, dynamic>), accessToken);
        }

        //public async Task<ResponseData<List<M_Count>>> getCountNewsCategoryByNewsCategoryType(string accessToken)
        //{
        //    return await _callApi.GetResponseDataAsync<List<M_Count>>("/NewsCategory/getCountNewsCategoryByNewsCategoryType", default(Dictionary<string, dynamic>), accessToken);
        //}
        //public async Task<ResponseData<List<M_NewsCategory>>> getListNewsCategoryByConditionSequenceStatus(string accessToken, string sequenceStatus, string name, DateTime? fdate, DateTime? tdate)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"sequenceStatus", sequenceStatus},
        //        {"name", name},
        //        {"fdate", fdate?.ToString("O")},
        //        {"tdate", tdate?.ToString("O")},
        //    };
        //    return await _callApi.GetResponseDataAsync<List<M_NewsCategory>>("NewsCategory/getListNewsCategoryByConditionSequenceStatus", dictPars, accessToken);
        //}
        //public async Task<ResponseData<List<M_NewsCategory>>> getListNewsCategoryBySequenceStatus(string accessToken, string sequenceStatus, string lstNewsCategorytypeid)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"sequenceStatus", sequenceStatus},
        //        {"lstNewsCategorytypeid",lstNewsCategorytypeid }
        //    };
        //    return await _callApi.GetResponseDataAsync<List<M_NewsCategory>>("/NewsCategory/getListNewsCategoryBySequenceStatus", dictPars, accessToken);
        //}
        //public async Task<ResponseData<M_NewsCategory>> getNewsCategoryById(string accessToken, int id)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"id", id},
        //    };
        //    return await _callApi.GetResponseDataAsync<M_NewsCategory>("/NewsCategory/getNewsCategoryById", dictPars, accessToken);
        //}
        
        //public async Task<ResponseData<M_NewsCategory>> Create(string accessToken, EM_NewsCategory model, string createdBy)
        //{
        //    var cAddress = await _s_Address.Create(accessToken, model.addressObj, createdBy);
        //    model.addressId = cAddress.data.Id;

        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"firstName", model.firstName},
        //        {"lastName", model.lastName},
        //        {"NewsCategoryTypeId",model.NewsCategoryTypeId },
        //        { "birthDay", model.birthDay?.ToString("O")},
        //        {"gender", model.gender},
        //        {"nationalityId",model.nationalityId }, 
        //        {"religionId",model.religionId },
        //        {"folkId",model.folkId },
        //        {"addressId",model.addressId },
        //        {"phoneNumber",model.phoneNumber },
        //        {"email", model.email},
        //        {"avatarurl", model.avatarUrl}
        //        //{"createdBy", createdBy},
        //    };
        //    return await _callApi.PostResponseDataAsync<M_NewsCategory>("/NewsCategory/Create", dictPars, accessToken);
        //}
        //public async Task<ResponseData<M_NewsCategory>> Update(string accessToken, EM_NewsCategory model, string updatedBy)
        //{
        //    var res = new ResponseData<M_NewsCategory>();
        //    if (model.addressId != null && model.addressId != 0)
        //    {
        //        var resAddress = await _s_Address.Update(accessToken, model.addressObj, updatedBy);
        //        if (resAddress.result != 1 || resAddress.data == null)
        //        {
        //            res.result = resAddress.result;
        //            res.error = resAddress.error;
        //            return res;
        //        }
        //    }
        //    else
        //    {
        //        var resAddress = await _s_Address.Create(accessToken, model.addressObj, updatedBy);
        //        if (resAddress.result == 1 && resAddress.data != null)
        //            model.addressId = resAddress.data.Id;
        //        else
        //        {
        //            res.result = resAddress.result; 
        //            res.error = resAddress.error;
        //            return res;
        //        }
        //    }

            
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"id", model.id},
        //        {"firstname", model.firstName},
        //        {"lastname", model.lastName},
        //        {"gender", model.gender},
        //        {"NewsCategorytypeid",model.NewsCategoryTypeId },
        //        {"timer", model.timer?.ToString("O")},
        //        {"status", model.status},
        //        {"addressid",model.addressId },
        //        {"phonenumber", model.phoneNumber},
        //        {"email", model.email}
        //        //{"updatedBy", updatedBy}
        //    };
        //    return await _callApi.PutResponseDataAsync<M_NewsCategory>("/NewsCategory/Update", dictPars, accessToken);
        //}
        //public async Task<ResponseData<M_NewsCategory>> Delete(string accessToken, int id, string updatedBy)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"id", id},
        //        {"updatedBy", updatedBy},
        //    };
        //    return await _callApi.DeleteResponseDataAsync<M_NewsCategory>("/NewsCategory/Delete", dictPars, accessToken);
        //}
        //public async Task<ResponseData<M_NewsCategory>> UpdateStatus(string accessToken, int id, int status, DateTime? timer, string updatedBy)
        //{
        //    Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
        //    {
        //        {"id", id},
        //        {"status", status},
        //        {"updatedBy", updatedBy},
        //        {"timer", timer?.ToString("O")},
        //    };
        //    return await _callApi.PutResponseDataAsync<M_NewsCategory>("/NewsCategory/UpdateStatus", dictPars, accessToken);
        //}
    }
}

using Student_WebAdmin.Lib;
using Student_WebAdmin.Models;
using System;

namespace Student_WebAdmin.Services
{
    public interface IS_Address
    {
        Task<ResponseData<List<M_Address>>> getListAddress(string accessToken);
        Task<ResponseData<List<M_Province>>> getListProvinceByStatusCountryId(string accessToken);
        Task<ResponseData<List<M_District>>> getListDistrictByStatusProvinceId(string accessToken, int? provinceId);
        Task<ResponseData<M_District>> getListDistrict(string accessToken);
        Task<ResponseData<List<M_Ward>>> getListWardByStatusDistrictId(string accessToken, int? districtId);
        Task<ResponseData<M_Ward>> getListWard(string accessToken);
        Task<ResponseData<M_Address>> getAddressById(string accessToken, int? id);
        Task<ResponseData<M_Address>> getListAddressByProvinceDistrictWardId(string accessToken, int? provinceId, int? districtId, int ?wardId);
        Task<ResponseData<M_Address>> Create(string accessToken, EM_Address model, string createdBy);
        Task<ResponseData<M_Address>> Update(string accessToken, EM_Address model, string updatedBy);
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
        public async Task<ResponseData<List<M_Province>>> getListProvinceByStatusCountryId(string accessToken)
        {

            return await _callApi.GetResponseDataAsync<List<M_Province>>("/Province/GetListProvince", default(Dictionary<string, dynamic>), accessToken);
        }
        public async Task<ResponseData<List<M_District>>> getListDistrictByStatusProvinceId(string accessToken, int? provinceId)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"provinceId", provinceId},
            };
            return await _callApi.GetResponseDataAsync<List<M_District>>("/District/getListDistrictByStatusProvinceId", dictPars, accessToken);
        }
        public async Task<ResponseData<M_District>> getListDistrict(string accessToken)
        {
          
            return await _callApi.GetResponseDataAsync<M_District>("/District/getDistrict", default(Dictionary<string, dynamic>), accessToken);
        }
        public async Task<ResponseData<List<M_Ward>>> getListWardByStatusDistrictId(string accessToken, int? districtId)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"districtId", districtId},
            };
            return await _callApi.GetResponseDataAsync<List<M_Ward>>("/Ward/getListWardByStatusDistrictId", dictPars, accessToken);
        }
        public async Task<ResponseData<M_Ward>> getListWard(string accessToken)
        {
           
            return await _callApi.GetResponseDataAsync<M_Ward>("/Ward/getListWard", default(Dictionary<string, dynamic>), accessToken);
        }
        public async Task<ResponseData<M_Address>> getAddressById(string accessToken, int? id)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"id", id},
            };
            return await _callApi.GetResponseDataAsync<M_Address>("/Address/getAddressById", dictPars, accessToken);
        }
        public async Task<ResponseData<M_Address>> getListAddressByProvinceDistrictWardId(string accessToken, int? provinceId, int? districtId, int? wardId)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"provinceId", provinceId},
                {"districtId", districtId },
                {"wardId", wardId}
            };
            return await _callApi.GetResponseDataAsync<M_Address>("/Address/getListAddressByProvinceDistrictWardId", dictPars, accessToken);
        }
        public async Task<ResponseData<M_Address>> Create(string accessToken, EM_Address model, string createdBy)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"addresstext", model.addressText},
                {"provinceId",model.provinceId },
                {"districtId",model.districtId },
                {"wardId",model.wardId }
                
                //{"createdBy", createdBy},
            };
            return await _callApi.PostResponseDataAsync<M_Address>("/Address/Create", dictPars, accessToken);
        }
        public async Task<ResponseData<M_Address>> Update(string accessToken, EM_Address model, string updatedBy)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"id", model.id},
                {"timer",model.timer?.ToString("O")},
                {"addressText",model.addressText },
                {"provinceId",model.provinceId },
                {"districId",model.districtId },
                {"wardId",model.wardId }
                //{"updatedBy", updatedBy},

            };
            return await _callApi.PutResponseDataAsync<M_Address>("/Address/Update", dictPars, accessToken);
        }
    }
}

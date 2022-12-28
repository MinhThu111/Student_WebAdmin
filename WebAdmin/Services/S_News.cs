using Student_WebAdmin.Lib;
using Student_WebAdmin.Models;
using Student_WebAdmin.ViewModels;
using System;

namespace Student_WebAdmin.Services
{
    public interface IS_News
    {
        Task<ResponseData<List<M_News>>> getListNews(string accessToken);
        Task<ResponseData<List<M_News>>> getListNewsBySequenceStatus(string accessToken, string sequenceStatus, string lstnewscategoryid);
        Task<ResponseData<M_News>> Delete(string accessToken, int id, int updatedBy);
        Task<ResponseData<M_News>> UpdateStatus(string accessToken, int id, int status, DateTime? timer, string updatedBy);
        Task<ResponseData<M_News>> Create(string accessToken, EM_News model, string createdBy);
        Task<ResponseData<M_News>> getNewsById(string accessToken, int id);
        Task<ResponseData<M_News>> Update(string accessToken, EM_News model, string updatedBy);

    }
    public class S_News : IS_News
    {
        private readonly ICallBaseApi _callApi;
        public S_News(ICallBaseApi callApi)
        {
            _callApi = callApi;
        }

        public async Task<ResponseData<List<M_News>>> getListNews(string accessToken)
        {
            return await _callApi.GetResponseDataAsync<List<M_News>>("/News/getListNews", default(Dictionary<string, dynamic>), accessToken);
        }
        public async Task<ResponseData<List<M_News>>> getListNewsBySequenceStatus(string accessToken, string sequenceStatus, string lstnewscategoryid)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"sequenceStatus", sequenceStatus},
                {"lstcategoryid",lstnewscategoryid }
            };
            return await _callApi.GetResponseDataAsync<List<M_News>>("/News/getListNewsBySequenceStatus", dictPars, accessToken);
        }
        public async Task<ResponseData<M_News>> Delete(string accessToken, int id, int updatedBy)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"id", id},
                {"updatedBy", updatedBy},
            };
            return await _callApi.DeleteResponseDataAsync<M_News>("/News/Delete", dictPars, accessToken);
        }
        public async Task<ResponseData<M_News>> UpdateStatus(string accessToken, int id, int status, DateTime? timer, string updatedBy)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"id", id},
                {"status", status},
                {"updatedBy", updatedBy},
                {"timer", timer?.ToString("O")},
            };
            return await _callApi.PutResponseDataAsync<M_News>("/News/UpdateStatus", dictPars, accessToken);
        }
        public async Task<ResponseData<M_News>> Create(string accessToken, EM_News model, string createdBy)
        {

            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"newscategoryid",model.newscategoryid},
                {"title",model.title },
                {"description",model.description},
                {"detail",model.detail },
                {"timer",DateTime.Now.ToString("O")},
                {"createby",createdBy },
                {"avatarurl",model.avatarurl }
            };
            return await _callApi.PostResponseDataAsync<M_News>("/News/Create", dictPars, accessToken);
        }
        public async Task<ResponseData<M_News>> getNewsById(string accessToken, int id)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"id", id},
            };
            return await _callApi.GetResponseDataAsync<M_News>("/News/getNewsById", dictPars, accessToken);
        }
        public async Task<ResponseData<M_News>> Update(string accessToken, EM_News model, string updatedBy)
        {
            Dictionary<string, dynamic> dictPars = new Dictionary<string, dynamic>
            {
                {"id", model.id},
                {"newscategoryid", model.newscategoryid},
                {"title", model.title},
                {"titleslug", model.titleslug},
                {"description", model.description},
                {"detail", model.detail},               
                {"avatarurl", model.avatarurl},               
                {"timer", model.timer?.ToString("O")},
                {"status", model.status},
                {"updateby", updatedBy}
            };
            return await _callApi.PutResponseDataAsync<M_News>("/News/Update", dictPars, accessToken);
        }






    }
}

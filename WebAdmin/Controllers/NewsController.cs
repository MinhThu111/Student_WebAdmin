using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_WebAdmin.ExtensionMethods;
using Student_WebAdmin.Lib;
using Student_WebAdmin.Models;
using Student_WebAdmin.Services;
using Student_WebAdmin.ViewModels;

namespace Student_WebAdmin.Controllers
{
    [Authorize]
    public class NewsController : BaseController<NewsController>
    {
        private readonly IS_News _s_news;
        private readonly IS_NewsCategory _s_newscategory;

        public NewsController(IS_News news, IS_NewsCategory newscategory)
        {
            _s_news = news;
            _s_newscategory = newscategory;
        }

        public async Task<IActionResult> Index()
        {
            Task task1 = SetDropDownNewsCategory();
            await Task.WhenAll(task1);
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> GetList(string status, string lstnewscategoryid)
        {
            var res = await _s_news.getListNewsBySequenceStatus(_accessToken, status, lstnewscategoryid);
           

            return Json(new M_JResult(res));
        }

        [HttpGet]
        public async Task<IActionResult> P_Add()
        {
            Task task1 = SetDropDownNewsCategory();
            await Task.WhenAll(task1);
            return PartialView();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<JsonResult> P_Add(EM_News model)
        {
            M_JResult jResult = new M_JResult();
            if (!ModelState.IsValid)
            {
                jResult.error = new error(0, DataAnnotationExtensionMethod.GetErrorMessage(ModelState));
                return Json(jResult);
            }
            var res = await _s_news.Create(_accessToken, model, _userId);
            return Json(jResult.MapData(res));
        }

        [HttpGet]
        public async Task<IActionResult> P_Edit(int id)
        {
            var res = await _s_news.getNewsById(_accessToken, id);
            if (res.result != 1 || res.data == null)
                return Json(new M_JResult(res));
            var model = _mapper.Map<EM_News>(res.data);
            Task task1 = SetDropDownNewsCategory();
            await Task.WhenAll(task1);

            return PartialView(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<JsonResult> P_Edit(EM_News model)
        {
            M_JResult jResult = new M_JResult();
            if (!ModelState.IsValid)
            {
                jResult.error = new error(0, DataAnnotationExtensionMethod.GetErrorMessage(ModelState));
                return Json(jResult);
            }
            var res = await _s_news.Update(_accessToken, model, _userId);

            return Json(jResult.MapData(res));
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var res = await _s_news.Delete(_accessToken, id, int.Parse(_userId));
            return Json(new M_JResult(res));
        }

        [HttpPost]
        public async Task<JsonResult> ChangeStatus(int id, int status, DateTime? timer)
        {
            var res = await _s_news.UpdateStatus(_accessToken, id, status, timer, _userId);
            return Json(new M_JResult(res));
        }

        private async Task SetDropDownNewsCategory(int? selectedId = 0)
        {
            List<VM_SelectDropDown> result = new List<VM_SelectDropDown>();
            var res = await _s_newscategory.getListNewsCategory(_accessToken);
            if (res.result == 1 && res.data != null)
                result = _mapper.Map<List<VM_SelectDropDown>>(res.data);
            ViewBag.NewsCategory = new SelectList(result, "Id", "Name", selectedId);
        }
    }
}

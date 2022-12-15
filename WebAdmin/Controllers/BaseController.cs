using Student_WebAdmin.Models;
using Student_WebAdmin.Services;
using Student_WebAdmin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.String;
using AutoMapper;

namespace Student_WebAdmin.Controllers
{
    public abstract class BaseController<T> : Controller where T : BaseController<T>
    {
        private IHttpContextAccessor httpContextAccessor;
        private string supplierId = Empty;
        private string accessToken = Empty;
        private string userId = Empty;
        private IMapper mapper;

        protected IMapper _mapper => mapper ?? (mapper = HttpContext?.RequestServices.GetService<IMapper>());
        
        protected IHttpContextAccessor _httpContextAccessor => httpContextAccessor ?? (httpContextAccessor = HttpContext?.RequestServices.GetService<IHttpContextAccessor>());

        protected string _accessToken => IsNullOrEmpty(accessToken) ? (accessToken = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "AccessToken")?.Value) : accessToken;

        protected string _userId => IsNullOrEmpty(userId) ? (userId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value) : userId;

        protected string _supplierId => IsNullOrEmpty(supplierId) ? (supplierId = HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "SupplierId")?.Value) : supplierId;


        //protected async Task SetDropDownListProvince(string selectedId = "0")
        //{
        //    List<VM_SelectDropDown> result = new List<VM_SelectDropDown>();
        //    var res = await HttpContext?.RequestServices.GetService<IS_Address>().getListProvinceByStatusCountryId(_accessToken);
        //    if (res.result == 1 && res.data != null)
        //        result = _mapper.Map<List<VM_SelectDropDown>>(res.data);
        //    ViewBag.ProvinceId = new SelectList(result, "Id", "Name", selectedId);
        //}

        protected async Task SetDropDownListProvince(int? selectedId = 0)
        {
            List<VM_SelectDropDown> result = new List<VM_SelectDropDown>();
            var res = await HttpContext?.RequestServices.GetService<IS_Address>().getListProvinceByStatusCountryId(_accessToken);
            if (res.result == 1 && res.data != null)
                result = _mapper.Map<List<VM_SelectDropDown>>(res.data);
            ViewBag.ProvinceId = new SelectList(result, "Id", "Name", selectedId);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }

    }
}

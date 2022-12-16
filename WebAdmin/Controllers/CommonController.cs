using Microsoft.AspNetCore.Mvc;
using Student_WebAdmin.Lib;
using Student_WebAdmin.Services;

namespace Student_WebAdmin.Controllers
{
    public class CommonController : BaseController<CommonController>
    {
        private readonly IS_Address _s_address;

        public CommonController(IS_Address address)
        {
            _s_address = address;
        }

        [HttpGet]
        public async Task<JsonResult> GetListDropdownProvince()
        {
            //var res = await _s_address.getListProvinceByStatusCountryId<List<M_Province>>(_accessToken, countryId);
            var res = await _s_address.getListProvinceByStatusCountryId(_accessToken);
            return Json(new M_JResult(res));
        }

        [HttpGet]
        public async Task<JsonResult> GetListDropdownDistrict(int? provinceId = 0)
        {
            //var res = await _s_address.getListDistrictByStatusProvinceId<List<M_District>>(_accessToken, provinceId);
            var res = await _s_address.getListDistrictByStatusProvinceId(_accessToken, provinceId);

            return Json(new M_JResult(res));
        }

        [HttpGet]
        public async Task<JsonResult> GetListDropdownWard(int? districtId = 0)
        {
            //var res = await _s_address.getListWardByStatusDistrictId<List<M_Ward>>(_accessToken, districtId);
            var res = await _s_address.getListWardByStatusDistrictId(_accessToken, districtId);
            return Json(new M_JResult(res));
        }

    }
}

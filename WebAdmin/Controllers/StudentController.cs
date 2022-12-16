using AutoMapper;
using Student_WebAdmin.ExtensionMethods;
using Student_WebAdmin.Lib;
using Student_WebAdmin.Models;
using Student_WebAdmin.Services;
using Student_WebAdmin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.WebSockets;

namespace Student_WebAdmin.Controllers
{
    public class StudentController : BaseController<StudentController>
    {
        //call api new
        private static List<M_Person> _persons = new List<M_Person>();
        private readonly IS_Person _s_person;
        private readonly IS_Nationality _s_nationality;
        private readonly IS_PersonType _s_persontype;
        private readonly IS_Folk _s_folk;
        private readonly IS_Religion _s_religion;
        private readonly IMapper _mapper;
        private readonly IS_Address _s_address;

        public StudentController(IS_Person person, IS_Nationality nationality, IS_PersonType persontype, IS_Folk folk, IS_Religion religion, IMapper mapper, IS_Address s_address)
        {
            _s_person = person;
            _s_nationality = nationality;
            _s_persontype = persontype;
            _s_folk = folk;
            _s_religion = religion;
            _mapper = mapper;
            _s_address = s_address;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]//ok
        public async Task<JsonResult> GetList(string status)
        {
            var res = await _s_person.getListPersonBySequenceStatus(_accessToken, status);

            return Json(new M_JResult(res));
        }

        [HttpGet]
        public async Task<JsonResult> P_View(int id)
        {
            var res = await _s_person.getPersonById(_accessToken, id);
            return Json(new M_JResult(res));
        }


        [HttpGet]//ok
        public async Task<IActionResult> P_Add()
        {
            Task task1 = SetDropDownNationality(),
            task2 = SetDropDownPersonType(),
            task3 = SetDropDownFolk(),
            task4 = SetDropDownReligion(),
            task5 = SetDropDownListProvince();

            await Task.WhenAll(task1, task2, task3, task4, task5);
            return PartialView();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<JsonResult> P_Add(EM_Person model)
        {
            M_JResult jResult = new M_JResult();
            if (!ModelState.IsValid)
            {
                jResult.error = new error(0, DataAnnotationExtensionMethod.GetErrorMessage(ModelState));
                return Json(jResult);
            }
            var res = await _s_person.Create(_accessToken, model, _userId);
            return Json(jResult.MapData(res));
        }


        [HttpGet]//ok
        public async Task<IActionResult> P_Edit(int id)
        {
            var res = await _s_person.getPersonById(_accessToken, id);
            if (res.result != 1 || res.data == null)
                return Json(new M_JResult(res));
            var model = _mapper.Map<EM_Person>(res.data);

            Task task1 = SetDropDownNationality(model.nationalityId),
            task2 = SetDropDownPersonType(model.personTypeId),
            task3 = SetDropDownFolk(model.folkId),
            task4 = SetDropDownReligion(model.religionId),
            task5 = SetDropDownListProvince(model.addressId),
            task6 = SetDropDownDistrict(model.addressObj?.districtId, model.addressObj?.provinceId),
            task7 = SetDropDownWard(model.addressObj?.wardId, model.addressObj?.districtId);
            await Task.WhenAll(task1, task2, task3, task4, task5, task6, task7);
            return PartialView(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<JsonResult> P_Edit(EM_Person model)
        {
            M_JResult jResult = new M_JResult();
            if (!ModelState.IsValid)
            {
                jResult.error = new error(0, DataAnnotationExtensionMethod.GetErrorMessage(ModelState));
                return Json(jResult);
            }
            var res = await _s_person.Update(_accessToken, model, _userId);

            return Json(jResult.MapData(res));
        }


        [HttpPost]//ok
        public async Task<JsonResult> Delete(int id)
        {
            var res = await _s_person.Delete(_accessToken, id, _userId);
            return Json(new M_JResult(res));
        }

        [HttpPost]//ok
        public async Task<JsonResult> ChangeStatus(int id, int status, DateTime? timer)
        {
            var res = await _s_person.UpdateStatus(_accessToken, id, status, timer, _userId);
            return Json(new M_JResult(res));
        }

        private async Task SetDropDownNationality(int? selectedId = 0)
        {
            List<VM_SelectDropDown> result = new List<VM_SelectDropDown>();
            var res = await _s_nationality.getListNationality(_accessToken);
            if (res.result == 1 && res.data != null)
                result = _mapper.Map<List<VM_SelectDropDown>>(res.data);
            ViewBag.NationalityId = new SelectList(result, "Id", "Name", selectedId);
        }
        private async Task SetDropDownPersonType(int? selectedId = 0)
        {
            List<VM_SelectDropDown> result = new List<VM_SelectDropDown>();
            var res = await _s_persontype.getListPersonType(_accessToken);
            if (res.result == 1 && res.data != null)
                result = _mapper.Map<List<VM_SelectDropDown>>(res.data);
            ViewBag.PersonTypeId = new SelectList(result, "Id", "Name", selectedId);
        }
        private async Task SetDropDownFolk(int? selectedId = 0)
        {
            List<VM_SelectDropDown> result = new List<VM_SelectDropDown>();
            var res = await _s_folk.getListFolk(_accessToken);
            if (res.result == 1 && res.data != null)
                result = _mapper.Map<List<VM_SelectDropDown>>(res.data);
            ViewBag.FolkId = new SelectList(result, "Id", "Name", selectedId);
        }
        private async Task SetDropDownReligion(int? selectedId = 0)
        {
            List<VM_SelectDropDown> result = new List<VM_SelectDropDown>();
            var res = await _s_religion.getListReligion(_accessToken);
            if (res.result == 1 && res.data != null)
                result = _mapper.Map<List<VM_SelectDropDown>>(res.data);
            ViewBag.ReligionId = new SelectList(result, "Id", "Name", selectedId);
        }

        private async Task SetDropDownDistrict(int? selectedId = 0, int? provinceId = 1)
        {
            List<VM_SelectDropDown> result = new List<VM_SelectDropDown>();
            var res = await _s_address.getListDistrictByStatusProvinceId(_accessToken, provinceId);
            if (res.result == 1 && res.data != null)
                result = _mapper.Map<List<VM_SelectDropDown>>(res.data);
            ViewBag.DistrictId = new SelectList(result, "Id", "Name", selectedId);
        }

        private async Task SetDropDownWard(int? selectedId = 0, int? districtId = 1)
        {
            List<VM_SelectDropDown> result = new List<VM_SelectDropDown>();
            var res = await _s_address.getListWardByStatusDistrictId(_accessToken, districtId);
            if (res.result == 1 && res.data != null)
                result = _mapper.Map<List<VM_SelectDropDown>>(res.data);
            ViewBag.WardId = new SelectList(result, "Id", "Name", selectedId);
        }




    }
}

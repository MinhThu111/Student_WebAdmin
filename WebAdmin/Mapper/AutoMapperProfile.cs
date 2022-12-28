using AutoMapper;
using Student_WebAdmin.Models;
using Student_WebAdmin.ViewModels;

namespace Student_WebAdmin.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region SelectDropDown
            //CreateMap<M_Product, VM_SelectDropDown>();
            CreateMap<M_PersonType, VM_SelectDropDown>();
            CreateMap<M_Nationality, VM_SelectDropDown>();
            CreateMap<M_Religion, VM_SelectDropDown>();
            CreateMap<M_Folk, VM_SelectDropDown>();
            CreateMap<M_Province, VM_SelectDropDown>();
            CreateMap<M_District, VM_SelectDropDown>();
            CreateMap<M_Ward, VM_SelectDropDown>();
            CreateMap<M_News, VM_SelectDropDown>();
            CreateMap<M_NewsCategory, VM_SelectDropDown>();
            #endregion

            CreateMap<M_Person, EM_Person>();
            CreateMap<M_News, EM_News>();
            //#region Account Person
            ////CreateMap<M_Person, EM_Person>()
            ////.ForMember(des => des.imageUrl, opt => opt.MapFrom(source => source.imageObj.mediumUrl));
            ////CreateMap<M_PersonWarehouse, VM_AccountInfo>()
            ////.ForMember(des => des.accountId, opt => opt.MapFrom(source => source.personObj.accountObj.id))
            ////.ForMember(des => des.userName, opt => opt.MapFrom(source => source.personObj.accountObj.userName));
            //#endregion

        }
    }
}

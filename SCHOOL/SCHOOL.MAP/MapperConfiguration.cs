using AutoMapper;
using SCHOOL.DTOs.DTOs;
using Class = SCHOOL.DATA.Models.Class;
using DTOClass = SCHOOL.DTOs.DTOs.Class;





namespace SCHOOL.MAP
{
    public class MapperConfigurationInternal : Profile
    {
        public MapperConfigurationInternal()
        {
            #region DB to DTO
            //Db to DTO

            CreateMap<Class, DTOClass>();
            CreateMap<DTOClass, DTOClass>()
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));

            #endregion

            #region DTO to DB

            //DTO to Db
            CreateMap<DTOClass, Class>();

            #endregion

            #region Others

            #endregion

            #region ToCommonRequestModel
            CreateMap<DTOClass, CommonRequestModel>()
                .ForMember(destination => destination.RequestFor,
                    opts => opts.MapFrom(source => "Class"))
                .ForAllMembers(o => o.Condition((source, destination, member) => member != null));
            #endregion
        }
    }
}

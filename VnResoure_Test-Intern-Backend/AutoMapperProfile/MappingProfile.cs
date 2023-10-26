using AutoMapper;
using VnResoure_Test_Intern_Backend.Models;
using VnResoure_Test_Intern_Backend.Models.DTO;

namespace VnResoure_Test_Intern_Backend.AutoMapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<KhoaHoc, KhoaHocDTO>();
            CreateMap<MonHoc, MonHocDTO>();
        }

        public IMapper MapperProfile()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            return config.CreateMapper();
        }
    }
}

using API.DTO;
using API.Model;
using AutoMapper;

namespace API.DTOmaping
{
    public class Maping:Profile
    {
        public Maping()
        {

            CreateMap<NationalPark, NAtionalparkDTO>().ReverseMap();
            CreateMap<Trail,TrailDTO>().ReverseMap();
        }
    }
}

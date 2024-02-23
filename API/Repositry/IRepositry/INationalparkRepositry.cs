using API.Model;

namespace API.Repositry.IRepositry
{
    public interface INationalparkRepositry
    {
        ICollection<NationalPark> GetNationalParks();
        NationalPark GetNationalPark(int NationatparkId);
        bool NationalParkExists(int NationatparkId);
        bool NationalParkExists(string Nationatparkname);
        bool CreateNationalPark(NationalPark Nationatpark);
        bool updateNationalPark(NationalPark Nationatpark);
        bool DelateNationalPark(NationalPark Nationatpark);
        bool save();
    }
}

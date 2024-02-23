using API.ApplicationDbContext;
using API.Model;
using API.Repositry.IRepositry;

namespace API.Repositry
{
    public class NationalParkRepositry : INationalparkRepositry
    {
        private readonly ApplicationDbcontext _context;
        public NationalParkRepositry(ApplicationDbcontext context)
        {
            _context= context;
        }
        public bool CreateNationalPark(NationalPark Nationatpark)
        {
            _context.NationalParks.Add(Nationatpark);
            return save();
        }

        public bool DelateNationalPark(NationalPark Nationatpark)
        {
            _context.NationalParks.Remove(Nationatpark);
            return save();
        }

        public NationalPark GetNationalPark(int NationatparkId)
        {
            return _context.NationalParks.Find(NationatparkId);
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return _context.NationalParks.ToList();
        }

        public bool NationalParkExists(int NationatparkId)
        {
            return _context.NationalParks.Any(n => n.Id == NationatparkId);
        }

        public bool NationalParkExists(string Nationatparkname)
        {
            return _context.NationalParks.Any(n => n.Name == Nationatparkname);
        }

        public bool save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }

        public bool updateNationalPark(NationalPark Nationatpark)
        {
            _context.NationalParks.Update(Nationatpark);
            return save();
        }
    }
}

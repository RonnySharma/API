using API.ApplicationDbContext;
using API.Model;
using API.Repositry.IRepositry;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositry
{
    
    public class Trailrep : ITrail
    {

        private readonly ApplicationDbcontext _context;
        public Trailrep(ApplicationDbcontext context)
        {
            _context = context;
        }

        public bool creatTraile(Trail TrailId)
        {
            _context.Trails.Add(TrailId);
            return save();
        }

        public bool DeleteTraile(Trail TrailId)
        {
            _context.Trails.Remove(TrailId);
            return save();
        }

        public Trail GetTrail(int TailId)
        {
            return _context.Trails.Find(TailId);
        }

        public ICollection<Trail> GetTrailInNationlPakr(int nationlPakId)
        {
            return _context.Trails.Include(x => x.NationalParkId).ToList();
        }

        public ICollection<Trail> GetTrails()
        {
            return _context.Trails.Include(x => x.NationalPark).ToList();
        }

        public bool save()
        {
            return _context.SaveChanges() == 1 ? true : false;
        }

        public bool TraileExists(int TrailId)
        {
            return _context.Trails.Any(t => t.Id == TrailId);
        }

        public bool TraileExists(string TrailId)
        {
            return _context.Trails.Any(t => t.Name == TrailId);
        }

        public bool updateTraile(Trail TrailId)
        {
            _context.Trails.Update(TrailId);
            return save();
        }
    }
}

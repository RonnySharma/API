using API.Model;

namespace API.Repositry.IRepositry
{
    public interface ITrail
    {
        ICollection<Trail> GetTrails();
        ICollection<Trail> GetTrailInNationlPakr(int nationlPakId);
        Trail GetTrail(int TailId);
        bool TraileExists(int TrailId);
        bool TraileExists(string TrailId);
        bool creatTraile(Trail TrailId);
        bool updateTraile(Trail TrailId);
        bool DeleteTraile(Trail TrailId);
        bool save();
    }
}

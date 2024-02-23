namespace Api_project.Models.Viewmodel
{
    public class IndexVM
    {
        public IEnumerable<NationalPark> NationalParklist { get; set; }
        public IEnumerable<Trail> Traillist { get; set; }
    }
}

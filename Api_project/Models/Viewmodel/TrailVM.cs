using Microsoft.AspNetCore.Mvc.Rendering;

namespace Api_project.Models.Viewmodel
{
    public class TrailVM
    {
        public Trail Trail { get; set; }
        public IEnumerable<SelectListItem> NationParkLIst { get; set; }
    }
}

using System.Collections.Generic;

namespace SportWebSite.ServiceModels
{
    public class TeamInfoModel
    {
        public string name { get; set; }
        public ICollection<PlayerServiceModel> squad { get; set; }
    }
}

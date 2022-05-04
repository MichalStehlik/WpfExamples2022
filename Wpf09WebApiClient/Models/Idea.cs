using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf09WebApiClient.Models
{
    internal class Idea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Resources { get; set; }
        public string Subject { get; set; }
        public Guid UserId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public int Participants { get; set; }
        //public ICollection<IdeaGoal> Goals { get; } = new List<IdeaGoal>();
        //public ICollection<IdeaOutline> Outlines { get; } = new List<IdeaOutline>();
        //public ICollection<IdeaTarget> IdeaTargets { get; } = new List<IdeaTarget>();
        //public ICollection<IdeaOffer> IdeaOffers { get; } = new List<IdeaOffer>();
    }
}

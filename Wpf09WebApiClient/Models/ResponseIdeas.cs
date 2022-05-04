using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf09WebApiClient.Models
{
    internal class ResponseIdeas
    {
        public int Total { get; set; }
        public int Filtered { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        public int PageCount { get; set; }
        public ICollection<Idea> Data { get; set; }
    }
}

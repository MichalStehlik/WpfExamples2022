using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf09WebApiClient.Models
{

    public class Rootobject
    {
        public int total { get; set; }
        public int filtered { get; set; }
        public int count { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string resources { get; set; }
        public string subject { get; set; }
        public string userId { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public int participants { get; set; }
        public bool offered { get; set; }
        public Target[] targets { get; set; }
        public DateTime updated { get; set; }
        public DateTime created { get; set; }
    }

    public class Target
    {
        public int id { get; set; }
        public string text { get; set; }
        public Color color { get; set; }
        public object[] ideas { get; set; }
        public int rgb { get; set; }
    }

    public class Color
    {
        public int r { get; set; }
        public int g { get; set; }
        public int b { get; set; }
        public int a { get; set; }
        public bool isKnownColor { get; set; }
        public bool isEmpty { get; set; }
        public bool isNamedColor { get; set; }
        public bool isSystemColor { get; set; }
        public string name { get; set; }
    }

}

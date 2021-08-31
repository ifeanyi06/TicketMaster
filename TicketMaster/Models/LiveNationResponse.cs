using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketMaster.Models
{
    public class LiveNationResponse
    {
        public string Result { get; set; }
        public Dictionary<string, string> Summary { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticCity.Core.DTOs.PruebaCA
{
    public abstract class ActorDTO
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime last_update { get; set; }
    }

    public class ActorInsertDTO: ActorDTO
    {
     
    }

    public class ActorUpdateDTO : ActorDTO
    {
        public int actor_id { get; set; }
    }
}

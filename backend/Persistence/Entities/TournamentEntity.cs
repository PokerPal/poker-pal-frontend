using System;
using System.Collections.Generic;

namespace Persistence.Entities
{
    public class TournamentEntity
    {
        public Guid Id { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public int? Frequency { get; set; }
        
        public string Venue { get; set; }
        
        public List<UserTournamentEntity>? UserTournaments { get; set; }
    }
}
using System;

namespace Persistence.Entities
{
    public class TournamentEntity
    {
        public Guid TournamentID { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public int? Frequency { get; set; }
        
        public string Venue { get; set; }
    }
}
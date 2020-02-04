using System;

namespace Persistence.Entities
{
    public class UserTournamentEntity
    {
        public Guid UserId { get; set; }
        
        public Guid TournamentId { get; set; }
        
        public int TotalScore { get; set; }
        
        public UserEntity? User { get; set; }
        
        public TournamentEntity? Tournament { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Persistence.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public DateTime Joined { get; set; }
        
        public AuthLevel AuthLevel { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
        
        public List<UserTournamentEntity>? UserTournaments { get; set; }
    }

    public enum AuthLevel
    {
        User = 1,
        Admin,
        SuperAdmin,
    }
}
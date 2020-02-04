using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Entities;
using Persistence.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UsersController : ControllerBase
    {
        private readonly IDatabaseContextFactory<DatabaseContext> _databaseContextFactory;

        public UsersController(IDatabaseContextFactory<DatabaseContext> databaseContextFactory)
        {
            this._databaseContextFactory = databaseContextFactory;
        }

        [HttpPost("create")]
        public async void CreateUser()
        {
            await using var context = this._databaseContextFactory.CreateDatabaseContext();
            
            // TODO: Finish implementing CreateUser()
        }
    }
}
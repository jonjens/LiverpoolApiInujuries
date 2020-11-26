using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlayerApi.Model;

namespace PlayerApi.Data
{
    public class PlayerApiContext : DbContext
    {
        public PlayerApiContext (DbContextOptions<PlayerApiContext> options)
            : base(options)
        {
        }

        public DbSet<PlayerApi.Model.PlayersModel> PlayersModel { get; set; }
    }
}

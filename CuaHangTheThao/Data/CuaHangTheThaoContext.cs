using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CuaHangTheThao.Models;

namespace CuaHangTheThao.Data
{
    public class CuaHangTheThaoContext : DbContext
    {
        public CuaHangTheThaoContext (DbContextOptions<CuaHangTheThaoContext> options)
            : base(options)
        {
        }

        public DbSet<CuaHangTheThao.Models.DoTheThao> DoTheThao { get; set; }
    }
}

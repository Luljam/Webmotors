using AnuncioWebMotors.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnuncioWebMotors.Data
{
    public class AnuncioContext : DbContext
    {
        public DbSet<Anuncio> tb_AnuncioWebmotors { get; set; }

        public AnuncioContext(DbContextOptions options) : base(options)
        {

        }
    }
}

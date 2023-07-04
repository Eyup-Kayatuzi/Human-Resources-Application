using InsanKaynaklari.Application.Interfaces.Repositories;
using InsanKaynaklari.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly InsanKaynaklariDb _context;
        public Repository(InsanKaynaklariDb context)
        {
            _context = context;
        }
        public DbSet<T> Tablo => _context.Set<T>();
    }
}

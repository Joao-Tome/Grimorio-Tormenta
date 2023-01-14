using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using GrimorioTormenta.Intefaces;
using GrimorioTormenta.Intefaces.Repositorio;
using GrimorioTormenta.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace GrimorioTormenta.Repositorio.Repositorio
{
    public class GrupoRepositorio : IGrupoRepositorio
    {
        private readonly DbContext _context;

        public GrupoRepositorio(DbContext context)
        {
            _context = context;
        }   

        public void insert(GrupoModel entity)
        {
            _context.Set<GrupoModel>().Add(entity);
            _context.SaveChanges();
        }

        public void delete(GrupoModel entity)
        {
            _context.Set<GrupoModel>().Remove(entity);
            _context.SaveChanges();
        }

        public void update(GrupoModel entity)
        {
            _context.Set<GrupoModel>().Update(entity);
            _context.SaveChanges();
        }

        public GrupoModel? get(int id)
        {
            return _context.Set<GrupoModel>().Find(id);
        }

        public IEnumerable<GrupoModel>? GetAll()
        {
            return _context.Set<GrupoModel>().ToList();
        }

        public IEnumerable<GrupoModel>? Getlist(Func<GrupoModel,bool> Func)
        {
            return _context.Set<GrupoModel>().Where(Func).ToList();
        }

        
    }
}

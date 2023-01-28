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

        public GrupoModel insert(GrupoModel entity)
        {
            _context.Set<GrupoModel>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void delete(GrupoModel entity)
        {
            entity.Status = Model.Enums.Status.Inativo;
            update(entity);
            //_context.Set<GrupoModel>().Remove(entity);
            //_context.SaveChanges();
        }

        public GrupoModel update(GrupoModel entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public GrupoModel? get(int id)
        {
            return _context.Set<GrupoModel>().AsNoTracking().SingleOrDefault(o => o.Id == id);
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

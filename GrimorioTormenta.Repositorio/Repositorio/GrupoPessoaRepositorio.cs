using GrimorioTormenta.Intefaces.Repositorio;
using GrimorioTormenta.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Repositorio.Repositorio
{
    public class GrupoPessoaRepositorio : IGrupoPessoaRepositorio
    {
        private DbContext _context{ get; set; }
        public GrupoPessoaRepositorio(DbContext context)
        {
            _context = context;
        }

        public GrupoPessoaModel insert(GrupoPessoaModel? entity)
        {
            _context.Set<GrupoPessoaModel>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void delete(GrupoPessoaModel? entity)
        {
            entity.Status = Model.Enums.Status.Inativo;
            update(entity);
            //_context.Set<GrupoModel>().Remove(entity);
            //_context.SaveChanges();
        }

        public GrupoPessoaModel update(GrupoPessoaModel? entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public GrupoPessoaModel? get(int? id)
        {
            return _context.Set<GrupoPessoaModel>().AsNoTracking().SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<GrupoPessoaModel>? GetAll()
        {
            return _context.Set<GrupoPessoaModel>().ToList();
        }

        public IEnumerable<GrupoPessoaModel>? Getlist(Func<GrupoPessoaModel, bool> Func)
        {
            return _context.Set<GrupoPessoaModel>().Where(Func).ToList();
        }
    }
}

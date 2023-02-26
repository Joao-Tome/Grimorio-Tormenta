using GrimorioTormenta.Intefaces.Repositorio;
using GrimorioTormenta.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Repositorio.Repositorio
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly DbContext _context;

        public PessoaRepositorio(DbContext context)
        {
            _context = context;
        }

        public void delete(PessoaModel entity)
        {
            entity.Status = Model.Enums.Status.Inativo;
            update(entity);
            //_context.Set<GrupoModel>().Remove(entity);
            //_context.SaveChanges();
        }

        public PessoaModel? get(int id)
        {
            return _context.Set<PessoaModel>().AsNoTracking().SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<PessoaModel>? GetAll()
        {
            return _context.Set<PessoaModel>().ToList();
        }

        public IEnumerable<PessoaModel>? Getlist(Func<PessoaModel, bool> func)
        {
            return _context.Set<PessoaModel>().Where(func).ToList();
        }

        public PessoaModel insert(PessoaModel entity)
        {
            _context.Set<PessoaModel>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public PessoaModel update(PessoaModel entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}

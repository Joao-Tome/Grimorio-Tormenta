using GrimorioTormenta.Intefaces.Conversor;
using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.Models;
using GrimorioTormenta.Model.PostModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrimorioTormenta.Business.Conversor
{
    public class PessoaConversor : IPessoaConversor
    {
        public PessoaDTO ConverteToDTO(PessoaModel obj)
        {
            return new PessoaDTO() { Id = obj.Id, Email = obj.Email, NickName = obj.NickName, Senha = obj.Senha, Status = obj.Status };
        }

        public PessoaDTO ConverteToDTO(PessoaViewModel obj)
        {
            return new PessoaDTO() { Id = obj.Id, Email = obj.Email, NickName = obj.NickName, Senha = null, Status = obj.Status };
        }

        public IEnumerable<PessoaDTO>? ConverteToDTOList(IEnumerable<PessoaModel>? obj)
        {
            return (from PessoaModel? gp in obj
                    select ConverteToDTO(gp)).ToList();
        }

        public PessoaModel ConverteToModel(PessoaDTO obj)
        {
            return new PessoaModel() { Email = obj.Email, Id = obj.Id, NickName = obj.NickName, Senha = obj.Senha, Status = obj.Status };
        }

        public PessoaModel ConverteToModel(PessoaViewModel obj)
        {
            return ConverteToModel(ConverteToDTO(obj));
        }

        public IEnumerable<PessoaViewModel>? ConverteToViewList(IEnumerable<PessoaModel>? obj)
        {
            return (from PessoaModel? gp in obj
                    select ConverteToViewModel(gp)).ToList();
        }

        public IEnumerable<PessoaViewModel>? ConverteToViewList(IEnumerable<PessoaDTO>? obj)
        {
            return (from PessoaDTO? gp in obj
                    select ConverteToViewModel(gp)).ToList();
        }

        public PessoaViewModel ConverteToViewModel(PessoaModel obj)
        {
            return ConverteToViewModel(ConverteToDTO(obj));
        }

        public PessoaViewModel ConverteToViewModel(PessoaDTO obj)
        {
            return new PessoaViewModel () { Email = obj.Email, Id = obj.Id, NickName = obj.NickName, Status= obj.Status };
        }
    }
}

using GrimorioTormenta.Model.DTO;
using GrimorioTormenta.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrimorioTormenta.Intefaces;
using GrimorioTormenta.Intefaces.Conversor;
using GrimorioTormenta.Model.Enums;
using GrimorioTormenta.Model.ViewModel;

namespace GrimorioTormenta.Business.Conversor
{
    public class GrupoConversor : IGrupoConversor
    {
        public GrupoDTO ConverteToDTO(GrupoModel obj)
        {
            GrupoDTO gp = new GrupoDTO() { Id = obj.Id, Nome = obj.Nome, Tipo = obj.Tipo, Status = obj.Status};
            return gp;
        }

        public GrupoDTO ConverteToDTO(GrupoViewModel obj)
        {
            GrupoDTO gp = new GrupoDTO() { Id = obj.Id, Nome = obj.Nome, Tipo = (TiposGrupo)Enum.Parse(typeof(TiposGrupo), obj.Tipo), Status = obj.Status };
            return gp;
        }

        public GrupoViewModel ConverteToViewModel(GrupoDTO obj)
        {
            GrupoViewModel gp = new GrupoViewModel() { Id = obj.Id, Nome = obj.Nome, Tipo = obj.Tipo.ToString(), Status = obj.Status };
            return gp;
        }
        public GrupoViewModel ConverteToViewModel(GrupoModel obj)
        {
            return ConverteToViewModel(ConverteToDTO(obj));
        }

        public GrupoModel ConverteToModel(GrupoDTO obj)
        {
            GrupoModel gp = new GrupoModel() { Id = obj.Id, Nome = obj.Nome, Tipo = obj.Tipo, Status = obj.Status };
            return gp;
        }
        public GrupoModel ConverteToModel(GrupoViewModel obj)
        {
            return ConverteToModel(ConverteToDTO(obj));
        }

        public IEnumerable<GrupoDTO>? ConverteToDTOList(IEnumerable<GrupoModel>? obj)
        {
            return (from GrupoModel? gp in obj
                    select ConverteToDTO(gp)).ToList();
        }

        public IEnumerable<GrupoViewModel>? ConverteToViewList(IEnumerable<GrupoModel>? obj)
        {
            return (from GrupoModel? gp in obj
                    select ConverteToViewModel(gp)).ToList();
        }

        public IEnumerable<GrupoViewModel>? ConverteToViewList(IEnumerable<GrupoDTO>? obj)
        {
            return (from GrupoModel? gp in obj
                    select ConverteToViewModel(gp)).ToList();
        }
    }
}

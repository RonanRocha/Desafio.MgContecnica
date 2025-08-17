using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Domain.Entities;

namespace Desafio.MgContecnica.Application.Mappings
{
    public static class CategoriaMappingExtension
    {

        public static Categoria ToEntity(this CategoriaDto dto)
        {
           var entity  = new Categoria
           (
               dto.Id,
               dto.Nome,
               dto.Status,
               dto.Tipo,
               dto.DataCriacao,
               dto.DataUltimaAtualizacao
           );

            if(dto.Transacoes != null )
            {
                entity.Transacoes = dto.Transacoes.Select(t => t.ToEntity()).ToList();
            }

            return entity;
        }


        public static Categoria ToEntity(this CriarCategoriaDto dto) =>
            new Categoria
            {
                Nome = dto.Nome,
                Status = dto.Status,
                Tipo = dto.Tipo,
                DataCriacao = DateTime.Now,
                DataUltimaAtualizacao = DateTime.Now
            };



        public static CategoriaDto ToDto(this Categoria entity)
        {
            var dto = new CategoriaDto(
                entity.Id,
                entity.Nome,
                entity.Tipo,
                entity.Status,
                entity.DataCriacao,
                entity.DataUltimaAtualizacao,
                entity.Transacoes?.Select(t => t.ToDto()).ToList()
            );

            return dto;
        }
            
    }
}

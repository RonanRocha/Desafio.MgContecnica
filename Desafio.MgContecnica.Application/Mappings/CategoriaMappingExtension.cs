using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Domain.Entities;

namespace Desafio.MgContecnica.Application.Mappings
{
    public static class CategoriaMappingExtension
    {
        // CriarCategoriaDto -> Categoria
        public static Categoria ToEntity(this CategoriaDto dto) =>
            new Categoria
            (
                dto.Id,
                dto.Nome,
                dto.Status,
                dto.Tipo,
                dto.DataCriacao,
                dto.DataUltimaAtualizacao,
                dto.Transacoes?.Select(t => t.ToEntity()).ToList() ?? new List<Transacao>()            
            );


        public static Categoria ToEntity(this CreateCategoriaDto dto) =>
            new Categoria
            {
                Nome = dto.Nome,
                Status = dto.Status,
                Tipo = dto.Tipo,
                DataCriacao = DateTime.Now,
                DataUltimaAtualizacao = DateTime.Now
            };


        // Categoria -> RecuperarCategoriaDto (com recursão nas transações)
        public static CategoriaDto ToDto(this Categoria entity) =>
            new CategoriaDto (
                entity.Id,
                entity.Nome,
                entity.Tipo,
                entity.Status,
                entity.DataCriacao,
                entity.DataUltimaAtualizacao,
                entity.Transacoes?.Select(t => t.ToDto()).ToList() ?? new List<TransacaoDto>()
            );
    }
}

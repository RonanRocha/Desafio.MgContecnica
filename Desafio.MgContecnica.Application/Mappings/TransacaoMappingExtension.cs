using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Domain.Entities;

namespace Desafio.MgContecnica.Application.Mappings
{
    public static class TransacaoMappingExtension
    {
        // TransacaoDto -> Transacao
        public static Transacao ToEntity(this TransacaoDto dto) =>
            new Transacao
            (
                 dto.Id,
                 dto.Descricao,
                 dto.Valor,
                 dto.Data,
                 dto.CategoriaId,
                 dto.Observacoes,
                 dto.DataCriacao,
                 dto.DataUltimaAtualizacao

            );


        // Trasacao -> TransacaoDto
        public static TransacaoDto ToDto(this Transacao entity) =>
            new TransacaoDto(
                entity.Id,
                entity.Descricao,
                entity.Valor,
                entity.Data,
                entity.CategoriaId,
                entity.Observacoes,
                entity.DataCriacao,
                entity.DataUltimaAtualizacao
            );
           
            

    }
}

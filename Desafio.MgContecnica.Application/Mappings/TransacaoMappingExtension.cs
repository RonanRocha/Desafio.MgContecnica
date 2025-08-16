using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Domain.Entities;
using System;

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
                 dto.DataUltimaAtualizacao,
                 dto.Categoria
            );


        public static Transacao ToEntity(this CriarTransacaoDto dto) =>
        new Transacao
        {
            Descricao = dto.Descricao,
            CategoriaId = dto.CategoriaId,
            Data = dto.Data.ToDateTime(TimeOnly.MinValue),
            Valor = dto.Valor,
            Observacoes = dto.Observacoes,
            DataCriacao = DateTime.Now,
            DataUltimaAtualizacao = DateTime.Now
        };

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
                entity.DataUltimaAtualizacao,
                entity.Categoria
            );
           
            

    }
}

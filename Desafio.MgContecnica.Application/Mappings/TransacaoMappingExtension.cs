using Desafio.MgContecnica.Application.Dto;
using Desafio.MgContecnica.Domain.Entities;
using System;

namespace Desafio.MgContecnica.Application.Mappings
{
    public static class TransacaoMappingExtension
    {
 
        public static Transacao ToEntity(this TransacaoDto dto)
        {
            var entity = new Transacao
            (
                 dto.Id,
                 dto.Descricao,
                 dto.Valor,
                 dto.Data,
                 dto.CategoriaId,
                 dto.Observacoes,
                 dto.DataCriacao,
                 dto.DataUltimaAtualizacao,
                 new Categoria(dto.Categoria.Id, dto.Categoria.Nome, dto.Categoria.Status, dto.Categoria.Tipo, DateTime.UtcNow, DateTime.UtcNow)
            );

            return entity;
        }
   


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


        public static TransacaoDto ToDto(this Transacao entity)
        {

            var dto = new TransacaoDto(
                entity.Id,
                entity.Descricao,
                entity.Valor,
                entity.Data,
                entity.CategoriaId,
                entity.Observacoes,
                entity.DataCriacao,
                entity.DataUltimaAtualizacao,
                entity.Categoria != null ? new CategoriaResumoDto(entity.Categoria.Id, entity.Categoria.Nome, entity.Categoria.Tipo, entity.Categoria.Status) : null

            );

            return dto;
        }
    }
}

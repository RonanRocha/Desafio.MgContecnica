using Desafio.MgContecnica.Application.Interfaces;
using Desafio.MgContecnica.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;


namespace Desafio.MgContecnica.Application.ValidationAttributes
{
    public class CategoriaAtivaAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not int categoriaId)
                return new ValidationResult("Categoria inválida");

            var categoriaService = validationContext.GetService<ICategoriaService>();

            var categoria = categoriaService.RecuperarCategoriaPorIdAsync(categoriaId).Result;

            if (categoria == null)
                return new ValidationResult("Categoria não encontrada");

            if (categoria.Status != StatusCategoria.Ativo)
                return new ValidationResult("Categoria não está ativa");

            return ValidationResult.Success;
        }
    }
}

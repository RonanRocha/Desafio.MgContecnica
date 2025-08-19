using Bogus;
using Desafio.MgContecnica.Domain.Entities;

namespace Desafio.MgContecnica.Infrastructure.Seeds
{
    public  static class SeedData
    {

        public static List<Categoria> GerarCategorias(int quantidade = 100)
        {
            var faker = new Faker<Categoria>("pt_BR")
                .RuleFor(c => c.Id, f => 0) // EF vai gerar o Id
                .RuleFor(c => c.Nome, f => f.Commerce.Categories(1)[0])
                .RuleFor(c => c.Tipo, f => f.PickRandom<TipoCategoria>())
                .RuleFor(c => c.Status, f => f.PickRandom<StatusCategoria>())
                .RuleFor(c => c.DataCriacao, f => f.Date.Past(2))
                .RuleFor(c => c.DataUltimaAtualizacao, (f, c) => c.DataCriacao.AddDays(f.Random.Int(1, 200)));

            return faker.Generate(quantidade);
        }

        public static List<Transacao> GerarTransacoes( List<Categoria> categorias, int quantidade = 100)
        {
            var fakerTransacao = new Faker<Transacao>("pt_BR")
                         .RuleFor(t => t.Descricao, f => f.Commerce.ProductName())
                         .RuleFor(t => t.Valor, f => f.Finance.Amount(10, 500))
                         .RuleFor(t => t.Data, f => f.Date.Recent(30))
                         .RuleFor(t => t.Observacoes, f => f.Commerce.ProductDescription())
                         .RuleFor(t => t.CategoriaId, f => f.PickRandom(categorias).Id) // FK existente
                         .RuleFor(c => c.DataCriacao, f => f.Date.Past(2))
                         .RuleFor(c => c.DataUltimaAtualizacao, (f, c) => c.DataCriacao.AddDays(f.Random.Int(1, 200)));

            return  fakerTransacao.Generate(350);
        }


    }
}

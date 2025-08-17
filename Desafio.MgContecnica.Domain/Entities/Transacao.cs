using Desafio.MgContecnica.Domain.Validation;

namespace Desafio.MgContecnica.Domain.Entities
{
    public class Transacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int CategoriaId { get; set; }
        public string? Observacoes { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public Categoria Categoria { get; set; }


        public Transacao()
        {
            
        }

        public Transacao(int id, string descricao, decimal valor, DateTime data, int categoriaId, string observacoes, DateTime dataCriacao, DateTime dataUltimaAtualizacao, Categoria categoria)
        {
            Id = id;
            Descricao = descricao;
            Valor = valor;
            Data = data;
            CategoriaId = categoriaId;
            Observacoes = observacoes;
            DataCriacao = dataCriacao;
            DataUltimaAtualizacao = dataUltimaAtualizacao;
            Categoria = categoria;
            ValidarTransacao();
        }

        public void ValidarTransacao()
        {
            DomainExceptionValidation.When(String.IsNullOrEmpty(Descricao), "Descricao não pode ser nulo ou vazio");
            DomainExceptionValidation.When(CategoriaId <= 0, "Categoria não pode ser vazia");
            DomainExceptionValidation.When(Categoria.Status != StatusCategoria.Ativo, "Categoria não pode ser inativa");
            DomainExceptionValidation.When(Descricao.Length < 3, "Descricao deve ter no minimo 3 caracteres");
            DomainExceptionValidation.When(Valor <= 0, "Valor deve ser maior que zero");
            DomainExceptionValidation.When(Data.Date > DateTime.Now.Date, "A data da transacao não pode ser maior que a data atual");
            DomainExceptionValidation.When(DataCriacao.Date > DateTime.Now.Date, "A data de criação não pode ser maior que a data atual");
            DomainExceptionValidation.When(DataUltimaAtualizacao.Date > DateTime.Now.Date, "A data da última atualização não pode ser maior que a data atual");
        }
    }
}

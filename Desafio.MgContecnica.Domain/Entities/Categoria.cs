using Desafio.MgContecnica.Domain.Validation;

namespace Desafio.MgContecnica.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public StatusCategoria Status { get; set; }
        public TipoCategoria Tipo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public List<Transacao> Transacoes { get; set; }


        public Categoria()
        {
            
        }


        public Categoria(int id,string nome, StatusCategoria status, TipoCategoria tipo, DateTime dataCriacao, DateTime dataUltimaAtualizacao,List<Transacao> transacoes)
        {
            Id = id;
            Nome = nome;
            Status = status;
            Tipo = tipo;
            DataCriacao = dataCriacao;
            DataUltimaAtualizacao = dataUltimaAtualizacao;
            Transacoes = transacoes;
            ValidarCategoria();
        }

        public void ValidarCategoria()
        {
            DomainExceptionValidation.When(String.IsNullOrEmpty(Nome), "O nome não pode ser vazio ou nulo");
            DomainExceptionValidation.When(Nome.Length < 3, "O nome não pode ter menos de 3 caracteres");
            DomainExceptionValidation.When(DataCriacao.Date > DateTime.Now.Date, "A data de criação não pode ser maior que a data atual");
            DomainExceptionValidation.When(DataUltimaAtualizacao.Date > DateTime.Now.Date, "A data da última atualização não pode ser maior que a data atual");
        }
    }
}

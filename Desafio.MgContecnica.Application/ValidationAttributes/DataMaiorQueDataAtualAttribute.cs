using System.ComponentModel.DataAnnotations;

namespace Desafio.MgContecnica.Application.ValidationAttributes
{
    public class DataMaiorQueDataAtualAttribute : ValidationAttribute
    {
        public DataMaiorQueDataAtualAttribute() :base("A campo {0} não pode ser maior que a data atual")
        {
        }

        public override bool IsValid(object? value)
        {

            if (value == null)
                return true; // permite nulo, use [Required] se precisar

            if (value is DateOnly dateValue)
            {
                return dateValue <= DateOnly.FromDateTime(DateTime.Now);
                   
            }

            return false;
        }
    }
}

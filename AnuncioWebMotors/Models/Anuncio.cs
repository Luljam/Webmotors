using System.ComponentModel.DataAnnotations;

namespace AnuncioWebMotors.Models
{
    public class Anuncio
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Necessário escolher uma Marca")]
        [StringLength(45)]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Necessário escolher um Modelo")]
        [StringLength(45)]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Necessário escolher uma Versão")]
        public string Versao { get; set; }
        [Required(ErrorMessage = "Necessário informar o ano")]
        [RegularExpression(@"^(19|[2-9][0-9])\d{2}$", ErrorMessage = "Informe o ano entre 1900 e 9999")] // anos de 1900 - 9999
        public int Ano { get; set; }
        [Required(ErrorMessage = "Necessários informar KM")]
        [RegularExpression(@"^\d*\.{0,1}\d+$", ErrorMessage = "Informe apenas números positivos")] // só numeros positivos
        public int Quilometragem { get; set; }
        [Required(ErrorMessage = "Necessário informar Observação")]
        public string Observacao { get; set; }

    }

}



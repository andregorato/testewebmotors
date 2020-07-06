using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels
{
    public class AnuncioViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Marca é obrigatória")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Modelo é obrigatório")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Versão é obrigatória")]
        public string Versao { get; set; }

        [Required(ErrorMessage = "Ano é obrigatório")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "Quilometragem é obrigatória")]
        public int Quilometragem { get; set; }

        [Required(ErrorMessage = "Observação é obrigatória")]
        public string Observacao { get; set; }
    }
}

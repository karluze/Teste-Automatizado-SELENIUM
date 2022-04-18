using System.ComponentModel.DataAnnotations;

namespace IMC.Models {
    public class ImcViewModel {
        [Range (0.01, 9999.99, ErrorMessage = "Informe o valor para Altura entre 0.01 e 9999.99")]
        [Required (ErrorMessage = "Campo Obrigatório")]
        public double? Altura { get; set; }

        [Range (0.01, 9999.99, ErrorMessage = "Informe o valor para Peso entre 0.01 e 9999.99")]
        [Required (ErrorMessage = "Campo Obrigatório")]
        public double? Peso { get; set; }

        public double? ResultImc { get; set; }
    }
}

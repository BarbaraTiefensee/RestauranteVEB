using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class RefeicaoIngrediente
    {
        public int RefeicaoID { get; set; }
        public RefeicaoDTO Refeicao { get; set; }

        public int IngredienteID { get; set; }
        public IngredienteDTO Ingrediente { get; set; }
    }
}

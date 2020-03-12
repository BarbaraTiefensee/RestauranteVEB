using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class RefeicaoIngrediente
    {
        public int RefeicaoID { get; set; }
        public virtual RefeicaoDTO Refeicao { get; set; }

        public int IngredienteID { get; set; }
        public virtual IngredienteDTO Ingrediente { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class IngredienteDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public virtual ICollection<IngredienteDTO> IngredienteCollection { get; set; }

        public IngredienteDTO()
        {
            this.IngredienteCollection = new List<IngredienteDTO>();
        }
    }
}

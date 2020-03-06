using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class EstoqueDTO
    {
        public int ID { get; set; }
        public List<IngredienteDTO> Ingredientes { get; set; }

        public EstoqueDTO()
        {
            this.Ingredientes = new List<IngredienteDTO>();
        }
    }
}

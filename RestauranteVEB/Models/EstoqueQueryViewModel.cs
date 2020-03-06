using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteVEB.Models
{
    public class EstoqueQueryViewModel
    {
        public int ID { get; set; }
        public List<IngredienteDTO> Ingredientes { get; set; }
    }
}

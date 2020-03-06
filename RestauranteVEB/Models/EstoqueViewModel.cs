using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestauranteVEB.Models
{
    public class EstoqueViewModel
    {
        public List<IngredienteDTO> Ingredientes { get; set; }
    }
}

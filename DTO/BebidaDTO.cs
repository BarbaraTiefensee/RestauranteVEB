using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class BebidaDTO
    {
        

        public int ID { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

        public virtual ICollection<PedidoBebida> Pedidos { get; set; }

        public BebidaDTO()
        {
            this.Pedidos = new List<PedidoBebida>();
        }
    }
}

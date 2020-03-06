using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Response
    {
        public bool Sucesso { get; set; }

        public List<string> Erros { get; set; }

        public string GetErrorMessage()
        {
            StringBuilder builder = new StringBuilder();
            //Lambda Expression
            Erros.ForEach(erro => builder.AppendLine(erro));
            return builder.ToString();
        }

        public bool HasErrors()
        {
            return this.Erros.Count > 0;
        }

        public Response()
        {
            this.Erros = new List<string>();
        }
    }

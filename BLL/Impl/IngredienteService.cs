using BLL.Interfaces;
using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class IngredienteService : IIngredienteService
    {
        private IIngredienteRepository _ingredienteRepository;
        public IngredienteService(IIngredienteRepository ingredienteRepository)
        {
            this._ingredienteRepository = ingredienteRepository;
        }

        public async Task<Response> Insert(IngredienteDTO ingrediente)
        {
            Response response = Validate(ingrediente);

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            await _ingredienteRepository.Insert(ingrediente);
            return response;
        }

        public async Task<DataResponse<IngredienteDTO>> GetData()
        {
            return await _ingredienteRepository.GetData();
        }

        private Response Validate(IngredienteDTO item)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(item.Nome))
            {
                response.Erros.Add("Informe o nome.");
            }
            else
            {
                item.Nome = EXT.NormatizarNome(item.Nome);
                if (item.Nome.Length < 2 || item.Nome.Length > 50)
                {
                    response.Erros.Add("O nome deve conter entre 2 e 50 caracteres.");
                }
                else if (!EXT.CorrectName(item.Nome))
                {
                    response.Erros.Add("O nome está no formato incorreto.");
                }
            }

            return response;
        }
    }
}

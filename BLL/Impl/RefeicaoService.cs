using BLL.Interfaces;
using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class RefeicaoService : IRefeicaoService
    {
        private IRefeicaoRepository _refeicaoRepository;
        public RefeicaoService(IRefeicaoRepository refeicaoRepository)
        {
            this._refeicaoRepository = refeicaoRepository;
        }

        public async Task<Response> Insert(RefeicaoDTO refeicao)
        {
            Response response = Validate(refeicao);

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            await _refeicaoRepository.Insert(refeicao);
            return response;
        }

        public async Task<DataResponse<RefeicaoDTO>> GetData()
        {
            return await _refeicaoRepository.GetData();
        }
        private Response Validate(RefeicaoDTO item)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(item.Nome))
            {
                response.Erros.Add("Informe o seu nome.");
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

      


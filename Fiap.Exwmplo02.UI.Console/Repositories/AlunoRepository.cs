using Fiap.Exwmplo02.UI.Console.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exwmplo02.UI.Console.Repositories
{
    class AlunoRepository
    {
        public Uri Cadastrar(AlunoDTO aluno,Uri address)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = address;

                HttpResponseMessage response = client.PostAsJsonAsync("api/Aluno", aluno).Result;

                if (response.IsSuccessStatusCode)
                {
                    Uri uri = response.Headers.Location;
                    return uri;
                }

                return null;
            }
        }

         public IEnumerable<AlunoDTO> Listar(Uri address)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = address;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/Aluno").Result;

                IEnumerable<AlunoDTO> alunos = null;

                if (response.IsSuccessStatusCode)
                {
                    alunos = response.Content.ReadAsAsync<IEnumerable<AlunoDTO>>().Result;
                }

                return alunos;
            }
        }
    }
}

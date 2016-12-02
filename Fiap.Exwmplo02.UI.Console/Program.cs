using Fiap.Exwmplo02.UI.Console.DTOs;
using Fiap.Exwmplo02.UI.Console.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Exwmplo02.UI.Console
{
    class Program
    {
        private static Uri _uri = new Uri("http://localhost:64015/");
        private static AlunoRepository _rep = new AlunoRepository();

        public static void Main(string[] args)
        {
            int resp = 0;

            while(resp != 2)
            {
                System.Console.WriteLine("Digite corretamente \n 0 - Cadastrar \n 1 - Listar \n 2 - Sair");
                resp = Convert.ToInt32(System.Console.ReadLine());
                while (resp != 0 && resp != 1 && resp != 2)
                {
                    System.Console.WriteLine("Digite corretamente\n  0 - Cadastrar \n 1 - Listar \n 2 - Sair");
                    resp = Convert.ToInt32(System.Console.ReadLine());
                }

                if(resp == 0)
                {
                    Cadastrar();
                }
                else
                {
                    if(resp == 1)
                    {
                        Listar();
                    }
                }
            }
        }

        public static void Cadastrar()
        {
           
            System.Console.WriteLine("Nome");
            string nome = System.Console.ReadLine();

            System.Console.WriteLine("Bolsa S/M");
            bool bolsa = false;
            double desconto = 0;
            if (System.Console.ReadLine().ToUpper().Equals("S"))
            {
                bolsa = true;

                System.Console.WriteLine("Desconto");
                desconto = Convert.ToDouble(System.Console.ReadLine());
            }
            else
            {
                bolsa = false;
            }

            System.Console.WriteLine("Cep");
            string cep = System.Console.ReadLine();

            System.Console.WriteLine("Grupo ID");
            int grupoId = Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine("Data de Nascimento");
            string[] explode = System.Console.ReadLine().Split('/');
            DateTime data = new DateTime(Convert.ToInt32(explode[2]), Convert.ToInt32(explode[1]), Convert.ToInt32(explode[0]));

            AlunoDTO aluno = new AlunoDTO()
            {
                Bolsa = bolsa,
                Cep = cep,
                DataNascimento = data,
                Desconto = desconto,
                Nome = nome,
                GrupoId = grupoId
            };


            _rep.Cadastrar(aluno, _uri);

        }

        public static void Listar()
        {

            IEnumerable<AlunoDTO> lista = _rep.Listar(_uri);

            foreach (var aluno in lista)
            {
                System.Console.WriteLine("Id = "+aluno.Id);
                System.Console.WriteLine("Nome = " + aluno.Nome);
                System.Console.WriteLine("DataNascimento = " + aluno.DataNascimento);
                System.Console.WriteLine("GrupoId = " + aluno.GrupoId);
                System.Console.WriteLine("Bolsa = " + aluno.Bolsa);
                System.Console.WriteLine("Desconto = " + aluno.Desconto);
                System.Console.WriteLine("Cep = " + aluno.Cep);
                System.Console.WriteLine("\n");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using DAL.Entidade;
using DAL.Generico;
using DAL.Persistencia;

using Negocio.DTO;
using Negocio.Genericos;
using Negocio.CasosDeUso;

namespace FacadeTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IBLLCRUD<ClubeDTO> fachada =  new ManterClube();
                IList<ClubeDTO> clubes = new List<ClubeDTO>();

                foreach(ClubeDTO clube in fachada.listarTudo()){
                    //Se imprimir o DTO não terá o ToString correto
                    //Console.WriteLine(clube);
                    //Clube club = new Clube();
                    //Utils.Copy(typeof(ClubeDTO), clube, typeof(Clube), club);
                    //Console.WriteLine(club);
                    Clube club = new Clube();

                    Utils.Copy(typeof(ClubeDTO), clube, typeof(Clube), club);
                    Console.WriteLine(club.ToString());
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Erro: " + ex.Message);
            }

            Console.ReadKey();

        }

    }
}

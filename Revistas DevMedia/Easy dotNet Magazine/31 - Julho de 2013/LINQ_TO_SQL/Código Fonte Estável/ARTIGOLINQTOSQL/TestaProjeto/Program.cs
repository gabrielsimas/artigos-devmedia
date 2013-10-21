using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DAL.Entidade;
using DAL.FonteDeDados;
using DAL.Persistencia;


namespace TestaProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pais pais = new Pais();
            //PaisDAL dal = new PaisDAL();
            //Pais pais = dal.ListarPorId(p => p.Id == 2);
            //pais.Nome = "Estados Unidos da America";
            //dal.Salvar(pais);
            //Console.WriteLine("Dados Salvos com sucesso!!!" + pais);
            //Console.WriteLine(pais);
            List<Pais> paises = new List<Pais>();
            PaisDAL dal = new PaisDAL();
            paises = dal.listarTudo();
            
            foreach(Pais p in paises){
                Console.WriteLine(p);
            }

            Console.ReadKey();
        }
    }
}

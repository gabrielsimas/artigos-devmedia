using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.EnterpriseServices;
using System.Messaging;
using Drone01TriggerCOMPlus;
using Teste.ArtigoMSMQ.Mocks;

namespace RodaComponenteCOMPlus
{
    class Program
    {

        private const String FILA_ACKNOWLEDGE_PATH = @".\private$\rastreador";
        private const String FILA_TESTE_PATH = @".\private$\teste";

        static void Main(string[] args)
        {

            //MyService.LuckyNumberGenerator gen = new MyService.LuckyNumberGenerator();
            //Console.WriteLine("Your lucky number is {0}",gen.GetLuckyNumber());
            //LuckyNumberGenerator gen2 = new LuckyNumberGenerator();
            //gen.ImprimeResultado();
            //gen2.ImprimeResultado();

            Drone01TriggerCOMPlus.BaixarMensagem com = new Drone01TriggerCOMPlus.BaixarMensagem();
            com.RegraRecebeAssimQueEntra();
            //BaixarMensagem com = new BaixarMensagem();
            //com.RegraRecebeAssimQueEntra();
            //RegraRecebeAssimQueEntra();

            Console.ReadKey();

        }

        public static void RegraRecebeAssimQueEntra()
        {

            MessageQueue fila = new MessageQueue(FILA_TESTE_PATH);

            IList<Message> mensagens = new List<Message>();

            mensagens = fila.GetAllMessages();

            if (mensagens.Count > 0)
            {

                foreach (Message mensagem in mensagens)
                {
                    Message msg;
                    Pessoa pessoa = new Pessoa();
                    fila.Formatter = new XmlMessageFormatter(new Type[] { typeof(Pessoa) });
                    msg = fila.Receive();
                    if (msg.Body != null)
                    {
                        pessoa = (Pessoa)msg.Body;
                    }
                }

            }
           } 
        }
}


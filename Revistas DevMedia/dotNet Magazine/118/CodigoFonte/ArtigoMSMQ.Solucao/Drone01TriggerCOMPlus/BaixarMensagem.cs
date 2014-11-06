using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Messaging;
using Teste.ArtigoMSMQ.Mocks;


[assembly: ApplicationActivation(ActivationOption.Server)]
[assembly: ApplicationAccessControl(false)]
[assembly: ApplicationName("Drone01")]
namespace Drone01TriggerCOMPlus
{  
    [Transaction(TransactionOption.Required)]
    [ComVisible(true)]
    [Guid("8AC92A1A-43DB-4407-97F0-89E2CBE5D16D")]
   public class BaixarMensagem : ServicedComponent
    {
        private const String FILA_ACKNOWLEDGE_PATH = @".\private$\rastreador";
        private const String FILA_TESTE_PATH = @".\private$\teste";

        public BaixarMensagem()
        {

        }

        /// <summary>
        /// Método ativado por Trigger
        /// Quando mensagens são recebidas na fila de teste,
        /// utilizamos o Aknowledge rastreador para identificar o correlationID
        /// para identificar a mensagem enviada a fila e então puxar a mesma para a aplicação
        /// </summary>
        public void RegraRecebeAssimQueEntra()
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Messaging;
using Teste.ArtigoMSMQ.Mocks;

namespace Teste.ArtigoMSMQ.Utils
{
    public static class ControleMSMQ<E> where E: Pessoa
    {

        public static void Envia(E entidade, String fila, Boolean ehTransacional = false, String label = null)
        {
            MessageQueue queue = new MessageQueue(fila);

            //Joga o objeto dentro da mensagem
            Message mensagem = new Message(entidade);
            mensagem.Label = label;

            //Faz com que a mensagem fique recuperável
            //mensagem.Recoverable = true;

            //Envia a mensagem para a queue
            if (ehTransacional)
            {
                queue.Send(mensagem, MessageQueueTransactionType.Single);
            }
            else
            {
                queue.Send(mensagem, MessageQueueTransactionType.None);
            }

            queue.Close();
            
        }

        public static E Recebe(E entidade, String fila)
        {
            MessageQueue queue = new MessageQueue(fila);
            queue.Formatter = new XmlMessageFormatter(new Type[] { typeof(E) });

            E mensagem = (E)queue.Receive().Body;
                
            queue.Close();

            return mensagem;
        }

    }
}

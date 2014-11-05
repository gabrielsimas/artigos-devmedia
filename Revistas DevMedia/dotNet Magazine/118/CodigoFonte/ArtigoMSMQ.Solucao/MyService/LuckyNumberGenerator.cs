using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Messaging;

[assembly: ApplicationActivation(ActivationOption.Server)]
[assembly: ApplicationAccessControl(false)]
namespace MyService
{
    [Transaction(TransactionOption.Required)]
    [ComVisible(true)]
    [Guid("9999C265-7151-4E46-9579-A19ADD9F486F")]
    public class LuckyNumberGenerator : ServicedComponent
    {

        public LuckyNumberGenerator()
        {

        }

        [AutoComplete]
        public int GetLuckyNumber()
        {
            Random r = new Random(DateTime.Now.Second);
            return r.Next();
        }

        [AutoComplete]
        public void ImprimeResultado()
        {

            MessageQueueTransaction tx = null;
            MessageQueue path = null;

            try
            {
                
                //instancia a Fila
                //MessageQueue fila = new MessageQueue(queueName);
                if (!MessageQueue.Exists(@".\private$\inserir"))
                {
                    path = MessageQueue.Create(@".\private$\inserir");
                }
                else
                {
                    path = new MessageQueue(@".\private$\inserir");
                }

                 tx = new MessageQueueTransaction();

                tx.Begin();

                Message msg = new Message();
                msg.Label = "RetornoComponente";
                msg.Label = this.GetLuckyNumber().ToString();
                path.Send(msg, MessageQueueTransactionType.Single);

                tx.Commit();
            }
            catch
            {
                tx.Abort();
            }
            finally
            {
                path.Close();
            }
        }
    }
}

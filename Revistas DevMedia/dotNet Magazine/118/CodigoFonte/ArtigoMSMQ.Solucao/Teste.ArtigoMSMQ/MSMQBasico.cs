using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Messaging;
using Teste.ArtigoMSMQ.Mocks;
using Teste.ArtigoMSMQ.Utils;
using System.Collections.Generic;


namespace Teste.ArtigoMSMQ
{
    [TestClass]
    public class MSMQBasico
    {

        private const String EDITAR = @".\private$\EDITAR";
        private const String EXCLUIR = @".\private$\EXCLUIR";
        private const String INSERIR = @".\private$\INSERIR";
        private const String LISTAR = @".\private$\LISTAR";
        private const string queueName = @".\private$\TestQueue";

        [TestMethod]
        public void VerificaQueue()
        {
            Boolean existe;
            existe = MessageQueue.Exists(INSERIR);

            Assert.IsTrue(existe);
        }

        [TestMethod()]
        public void VerificaSeTodasAsQueuesExistem()
        {
            Assert.IsTrue(MessageQueue.Exists(INSERIR) || MessageQueue.Exists(EXCLUIR) || MessageQueue.Exists(EDITAR) || MessageQueue.Exists(LISTAR));
        }

        [TestMethod]
        public void EnvioSimplesDeObjeto()
        {
            MessageQueue fila = null;
            //instancia a Fila
            //MessageQueue fila = new MessageQueue(queueName);
            if (!MessageQueue.Exists(queueName)) {
                 fila = MessageQueue.Create(queueName);
            } else {
                fila = new MessageQueue(queueName);
            }

            //Cria o objeto de envio
            Pessoa pessoa = new Pessoa()
            {
                FirstName = "Gabriel",
                LastName = "Simas"
            };

            //Envia o Objeto
            fila.Send(pessoa);

            //Fecha o Objeto
            fila.Close();

            Assert.IsNotNull(fila);

        }

        [TestMethod]
        public void RestauraObjetosEnviados()
        {
            MessageQueue fila = new MessageQueue(queueName);

            fila.Formatter = new XmlMessageFormatter(new Type[] { typeof(Pessoa) });

            Pessoa mensagem = (Pessoa)fila.Receive().Body;

            Assert.IsNotNull(mensagem);

        }

        [Description("Envia um objeto dentro da classe Message encapsulado. Uma proteção à mais.")]
        [TestMethod]
        public void EnviaObjetoAtravesDeMensagem()
        {
            Pessoa pessoa = new Pessoa()
            {
                FirstName = "Gabriel",
                LastName = "Simas"
            };

            ControleMSMQ<Pessoa>.Envia(pessoa, queueName);

            Assert.IsTrue(true);
                    
        }

        [Description("Recebe a resposta esperada dentro de uma Classe Mensagem.")]
        [TestMethod]
        public void RecebeObjetoAtravesDeMensagem()
        {
            Pessoa pessoa = new Pessoa();

            pessoa = ControleMSMQ<Pessoa>.Recebe(pessoa, queueName);

            Assert.IsTrue(pessoa.FirstName != null);
        }

        //Transações

        [TestMethod]
        public void EnviandoMensagemUtilizadoTransacao()
        {
            MessageQueueTransaction tx = new MessageQueueTransaction();
            try
            {
                tx.Begin();
                
                Pessoa pessoa = new Pessoa()
                {
                    FirstName = "Jane",
                    LastName = "Simas"
                };

                ControleMSMQ<Pessoa>.Envia(pessoa, INSERIR,true);
                
                tx.Commit();
                
            }
            catch (MessageQueueException mqe)
            {
                Console.WriteLine("Estado da Transacao: " + tx.Status.ToString());
                Console.WriteLine("Erro: " + mqe.InnerException.ToString() + "\n Tente novamente!");
                tx.Abort();
                Console.WriteLine("Estado da Transacao: " + tx.Status.ToString());
            }           

            Assert.IsTrue(tx.Status == MessageQueueTransactionStatus.Committed);
        }

        [TestMethod]
        public void RecebeMensagemEnviadaAnteriormenteViaTransacao()
        {
            Pessoa pessoa = new Pessoa();

            pessoa = ControleMSMQ<Pessoa>.Recebe(pessoa, INSERIR);

            Assert.IsTrue(pessoa.FirstName != null);
        }

        [TestMethod]
        public void EnviaMilMensagensTransacionais()
        {
            MessageQueueTransaction tx = new MessageQueueTransaction();

            try
            {
                tx.Begin();

                for (int i = 0; i < 1000;i++ )
                {
                    Pessoa pessoa = new Pessoa()
                    {
                        FirstName = "Jane " + i.ToString(),
                        LastName = "Simas",
                        Email = "janecassani@gmail.com"
                    };

                    ControleMSMQ<Pessoa>.Envia(pessoa, INSERIR, true);
                }

                tx.Commit();
            } catch(MessageQueueException ex){
                Console.WriteLine("Erro: " + ex.ToString());
                tx.Abort();
            }

            Assert.IsTrue(tx.Status == MessageQueueTransactionStatus.Committed);
        }

        [TestMethod]
        [Description("Como são muitas mensagens, primeiro listamos todas as mensagens enviadas para guardar seu Id e em um teste posterior, as recebemos para esvaziar a nossa fila.")]
        public void ListaTodasAsMensagensDaQueue()
        {
            MessageQueue fila = new MessageQueue(INSERIR);
            fila.Formatter = new XmlMessageFormatter(new Type[] { typeof(Pessoa) });
            Message[] mensagens = fila.GetAllMessages();
            List<Pessoa> pessoas = new List<Pessoa>();


            foreach(Message mensagem in mensagens)
            {
                Pessoa pessoa = new Pessoa();
                pessoa = (Pessoa)mensagem.Body;
                pessoas.Add(pessoa);
                Console.WriteLine("Id Mensagem: "+ mensagem.Id + "\nObjeto: " + pessoa.ToString());
            }

            Assert.IsTrue(pessoas.Count > 18000);
        }

        [TestMethod]
        [Description("Podemos fazer uma lista de todas as mensagens e posteriormente recebê-las e listá-las")]
        public void ReceberTodasAsMensagensDaQueue()
        {
            //Acessa a fila para gerar a Lista e Pega as Mensagens para Id
            String queue = @".\private$\teste";
            MessageQueue filaListaMensagens = new MessageQueue(queue);            
            Message[] mensagens = filaListaMensagens.GetAllMessages();
            filaListaMensagens.Close();

            //Acessa a fila para Receber as Mensages
            MessageQueue fila = new MessageQueue(queue);
            fila.Formatter = new XmlMessageFormatter(new Type[] { typeof(Pessoa) });

            List<Pessoa> pessoas = new List<Pessoa>();
            
            foreach (Message mensagem in mensagens)
            {
                Pessoa pessoa = new Pessoa();

                pessoa = (Pessoa)fila.ReceiveById(mensagem.Id).Body;
                
                pessoas.Add(pessoa);
                Console.WriteLine("Id Mensagem: " + mensagem.Id + "\nObjeto: " + pessoa.ToString());
            }

            Assert.IsTrue(pessoas.Count > 18000);
        }

        [TestMethod]
        public void TestaTrigger()
        {
            
            MessageQueueTransaction tx = new MessageQueueTransaction();
            Pessoa entidade = new Pessoa()
            {
                Id = 1,
                FirstName = "Jane",
                LastName = "Simas",
                Email = "janecassani@gmail.com"
            };

            try
            {
                tx.Begin();
                ControleMSMQ<Pessoa>.Envia(entidade, INSERIR, true,"INSERIR");
                tx.Commit();
            }
            catch 
            {
                tx.Abort();
            }            

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EnviaMensagemParaFilaExemplo()
        {
            MessageQueue fila = new MessageQueue(@".\private$\exemplo");
           Pessoa pessoa = new Pessoa()
            {
                Id = 1,
                FirstName = "Gabriel",
                LastName = "Simas",
                Email = "autorgabrielsimas@gmail.com"
            };

            ControleMSMQ<Pessoa>.Envia(pessoa, @".\private$\exemplo",false,"Mensagem");

            //fila.Purge();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MarcandoAMensagemComoRecuperavel()
        {
            //Cria a mensagem
            Message mensagem = new Message();

            //Escreve algo no Corpo da Mensagem
            mensagem.Body = "Mensagem de Exemplo recuperavel";

            //Dá um nome à mensagem para ser identificada na fila
            mensagem.Label = "Mensagem";

            //Marca a Mensagem como Recuperável
            mensagem.Recoverable = true;

            //Cria o objeto da Fila
            MessageQueue msgQ = new MessageQueue(@".\private$\exemplo");
            
            //Envia a mensagem na Fila
            msgQ.Send(mensagem);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EnviaMensagemParaSerPegaPelaTrigger()
        {
                     
            const string path = @".\private$\teste";

            MessageQueue fila = new MessageQueue(path);

            Pessoa pessoa = new Pessoa()
            {
                Id = 1,
                FirstName = "Gabriel",
                LastName = "Simas",
                Email = "autorgabrielsimas@gmail.com"
            };

            Message msg = new Message();
            //msg.AdministrationQueue = new MessageQueue(@".\private$\rastreador");
            //msg.AcknowledgeType = AcknowledgeTypes.PositiveArrival;
            msg.Label = "INSERIR";
            msg.Body = pessoa;
            fila.Send(msg);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Teste()
        {
            const String FILA_CAMINHO = @".\private$\exemplo";

            //Instancia a fila
            MessageQueue fila = new MessageQueue(FILA_CAMINHO);

            //Cria a mensagem
            String textoMsg = "Mensagem de Teste";

            //Envia a mensagem
            //fila.Send(textoMsg);
            fila.Send(textoMsg,"Label Mensagem Simples");

            //Fecha a conexão com a Fila por questão de segurança e performance
            fila.Close();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EnviaObjetoComplexoComoMensagem()
        {
            const String FILA_CAMINHO = @".\private$\exemplo";

            //Instancia a fila
            MessageQueue fila = new MessageQueue(FILA_CAMINHO);

            //Instanciamos o Objeto Pessoa
            //e passa valor
            Pessoa pessoa = new Pessoa()
            {
                Id = 1,
                FirstName = "Gabriel",
                LastName = "Simas",
                Email = "autorgabrielsimas@gmail.com"
            };

            //Envia a mensagem
            fila.Send(pessoa, "Mensagem de " + pessoa.ToString());

            //Fecha a conexão com a Fila por questão de segurança e performance
            fila.Close();

            Assert.IsTrue(true);
        }

        [TestMethod]
        [Description("Podemos fazer uma lista de todas as mensagens e posteriormente recebê-las e listá-las")]
        public void ReceberETratarMensagensEmMassa()
        {
            //Acessa a fila para gerar a Lista e Pega as Mensagens para Id
            String queue = @".\private$\exemplo";

            //Fila apenas para fazer as operações de contagem das mensagens
            //e colocá-las em uma Lista.
            MessageQueue filaListaMensagens = new MessageQueue(queue);
            Message[] mensagens = filaListaMensagens.GetAllMessages();

            //Fecha a fila e libera a memória
            filaListaMensagens.Close();

            //Acessa a fila para Receber as Mensages
            MessageQueue fila = new MessageQueue(queue);

            //Formata as mensagens da fila como XML
            fila.Formatter = new XmlMessageFormatter(new Type[] { typeof(Pessoa) });

            //Cria a Lista para mensagens já tratadas
            List<Pessoa> pessoas = new List<Pessoa>();

            //Iteração para processamento das mensagens
            //Transformando as mensagens recebidas do Servidor
            //em objetos do tipo Pessoa
            foreach (Message mensagem in mensagens)
            {
                Pessoa pessoa = new Pessoa();

                //Localiza na Lista de mensagens do Servidor
                //As mensagens a serem processados através de sua
                //Identificação
                pessoa = (Pessoa)fila.ReceiveById(mensagem.Id).Body;

                //Adiciona o objeto para a Lista de Saída
                pessoas.Add(pessoa);
            }

           

            Assert.IsTrue(pessoas.Count > 0 );
        }


        [TestMethod]
        public void TransacaoBasica()
        {
            MessageQueueTransaction tx = new MessageQueueTransaction();
            MessageQueue fila = new MessageQueue(@".\private$\transa");

            tx.Begin();
            fila.Send("Esta é uma mensagem transacional!", tx);
            tx.Commit();

            tx.Begin();
            Message mensagem;
            mensagem = fila.Receive(tx);
            tx.Commit();



            Assert.IsTrue(true);
        }
    }
}

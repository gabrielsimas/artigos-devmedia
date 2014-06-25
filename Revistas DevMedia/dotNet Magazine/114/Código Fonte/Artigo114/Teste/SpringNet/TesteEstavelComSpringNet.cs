using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Spring.Transaction;
using Spring.Transaction.Support;
using Spring.Testing.Microsoft;
using System.IO;

namespace Teste.SpringNet
{
    /// <summary>
    /// Summary description for TesteEstavelComSpringNet
    /// </summary>
    
    public abstract class TesteEstavelComSpringNet: TesteBasicoComSpringNet
    {
        #region Atributos

        private TestContext testContextInstance;

        protected IPlatformTransactionManager gerenciadorDeTransacao;

        protected Boolean rollbackPadrao = true;

        private Boolean completo = false;

        private int transacoesIniciadas = 0;

        private ITransactionDefinition definicaoDeTransacao = new DefaultTransactionDefinition();

        protected ITransactionStatus estadoDaTransacao;

        #endregion

        #region Construtor

        public TesteEstavelComSpringNet()
        {
            
        }

        #endregion

        #region Propriedades

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        public IPlatformTransactionManager GerenciadoDeTransacao
        {
            set
            {
                this.gerenciadorDeTransacao = value;
            }
        }
        
        
        public Boolean RollbackPadrao
        {
            set
            {
                this.rollbackPadrao = value;
            }
        }

        protected ITransactionDefinition DefinicaoDeTransacao
        {
            set
            {
                this.definicaoDeTransacao = value;
            }
        }

        
        #endregion

        #region Métodos
        
        protected virtual void ImpedeTransacao()
        {
            this.definicaoDeTransacao = null;
        }
        
        [TestInitialize]
        public override void Inicializacao()
        {
            base.Inicializacao();
            this.completo = !this.rollbackPadrao;

            if (this.gerenciadorDeTransacao == null){
                logger.Info("Nenhum gerenciador de Transações selecionado: Os testes não podem continuar sem uma transação");
                System.Diagnostics.Trace.WriteLine("Nenhum gerenciador de Transações selecionado: Os testes não podem continuar sem uma transação");
            }
            else if (this.definicaoDeTransacao == null)
            {
                logger.Info("Nenhuma definição de Transações selecionado: Os testes não podem continuar sem uma transação");
                System.Diagnostics.Trace.WriteLine("Nenhuma definição de Transações selecionado: Os testes não podem continuar sem uma transação");
            }
            else
            {
                ExecutarAntesDeIniciarUmaTransacao();
    
            }

        }

        protected virtual void ExecutarAntesDeIniciarUmaTransacao()
        {

        }

        protected virtual void ExecutarDuranteUmaTransacao(){
            
        }

        [TestCleanup]
        public override void Finalizacao()
        {
            base.Finalizacao();

            if (this.estadoDaTransacao != null && !this.estadoDaTransacao.Completed)
            {
                try
                {
                    AoDestruirUmaTransacaoEmExecucao();
                }
                finally
                {
                    FinalizarTransacao();
                }
            }

            if (this.transacoesIniciadas > 0){
                AoDestruirAposAExecucaoDaTransacao();
            }
        }

        protected virtual void AoDestruirUmaTransacaoEmExecucao()
        {

        }

        protected virtual void AoDestruirAposAExecucaoDaTransacao()
        {

        }

        /// <summary>
        /// setComplete()
        /// </summary>
        protected virtual void marcarParaCommit()
        {
            if (this.gerenciadorDeTransacao == null){
                throw new InvalidOperationException("Nenhum Gerenciador de Transações Selecionado!");
            }
            this.completo = true;
        }

        protected virtual void FinalizarTransacao()
        {
            if (this.estadoDaTransacao != null){
                try
                {
                    if (!this.completo)
                    {
                        this.gerenciadorDeTransacao.Rollback(this.estadoDaTransacao);
                        System.Diagnostics.Trace.WriteLine("Dando Rollback na transação após a execução do Teste.");
                        logger.Info("Rollback efetuado na Transacao após a execução do teste.");
                    }
                    else
                    {
                        this.gerenciadorDeTransacao.Commit(this.estadoDaTransacao);
                        System.Diagnostics.Trace.WriteLine("Transação Commitada após a execução do Teste");
                        logger.Info("Transação Commitada após a execução do Teste");
                    }
                }
                finally
                {
                    this.estadoDaTransacao = null;
                }

            }
        }



        protected virtual void IniciaNovaTransacao()
        {
            if (this.estadoDaTransacao != null){
                throw new InvalidOperationException("Não posso iniciar uma nova transação sem finalizar a que já está aberta" + "Finalize esta transação antes de iniciar uma nova transação!");
            }

            if(this.gerenciadorDeTransacao == null){
                throw new InvalidOperationException("Nenhum gerenciador de Transações selecionado!");
            }

            this.estadoDaTransacao = this.gerenciadorDeTransacao.GetTransaction(this.definicaoDeTransacao);
            System.Threading.Interlocked.Increment(ref this.transacoesIniciadas);
            this.completo = !this.rollbackPadrao;

            if (logger.IsInfoEnabled ){
                System.Diagnostics.Trace.WriteLine("Transação iniciada (" + this.transacoesIniciadas.ToString() + "): gerenciador de transações [" + this.gerenciadorDeTransacao.ToString() + "]; rollback padrão = " + this.rollbackPadrao.ToString());
                logger.Info("Transação iniciada (" + this.transacoesIniciadas.ToString() + "): gerenciador de transações [" + this.gerenciadorDeTransacao.ToString() + "]; rollback padrão = " + this.rollbackPadrao.ToString());
            }
        }

        
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Xulambs
{
    internal class Pedido
    {
        static int Idpedido = 1;
        private int qtdPessoas;
        private string data;
        private byte horaPedido;
        private byte horaSaida;
        Cliente cliente;

        public Pedido(int quantidade, Cliente cliente )
        {
            this.cliente = cliente;
            qtdPessoas = quantidade;
            
        }

        public static void GerarSolicitação()
        {

        }
    }
}

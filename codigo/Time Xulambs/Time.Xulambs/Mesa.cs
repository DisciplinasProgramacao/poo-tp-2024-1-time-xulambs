using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teste
{
    internal class Mesa
    {
        private static int proximoNumero = 1;
        private int numeroMesa;
        private int capacidade;
        private bool ocupada;

        //Construtor, utiliza de uma static para armazenar o Número que a próxima mesa irá utilizar, a mesa atual pega o valor atual da static
        public Mesa(int capacidade)
        {
            this.capacidade = capacidade;
            ocupada = false;
            numeroMesa = proximoNumero;
            proximoNumero++;

        }

        // Altera o status da mesa para ocupado ou desocupado
        public bool OcuparMesa()
        {
            if (ocupada == false)
            {
                ocupada = true;
            }
            else
            {
                Console.WriteLine("A mesa ja esta desocupada")
            }
            return ocupada;
        }

        public bool DesocuparMesa()
        {
            if (ocupada == true)
            {
                ocupada = false;
            }
            else
            {
                Console.WriteLine("A mesa ja esta ocupada")
            }
            return ocupada;
        }

        // Verifica a quantidade de pessoa que a mesa suporta
        public bool AceitaPessoas(int numPessoas)
        {
            if(numPessoas == capacidade)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificarOcupacao()
        {
            return ocupada;
        }
        // Linha de código para testar a mesa

        public void RelatarMesa()
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("número da mesa: " + numeroMesa);
            Console.WriteLine("capacidade: " + capacidade);
            Console.WriteLine("ocupada: " + ocupada);
        }
    }
}

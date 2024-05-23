using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time.Xulambs.Classe
{
    internal class Restaurante
    {
        string nomeRestaurante = "XulambsFOOD";
        private const int QUANTIDADEMESA = 10;
        private Queue<Requisicao> Mesas4;
        private Queue<Requisicao> Mesas6;
        private Queue<Requisicao> Mesas8;
        private List<Mesa> ListaMesas;

        public Restaurante()
        {
            Mesas4 = new Queue<Requisicao>();
            Mesas6 = new Queue<Requisicao>();
            Mesas8 = new Queue<Requisicao>();
            ListaMesas = new List<Mesa>();

            for (int i = 0; i < QUANTIDADEMESA; i++)
            {
                int numLugares;

                if (i < 4)
                {
                    numLugares = 4;
                }
                else if (i < 8)
                {
                    numLugares = 6;
                }
                else
                {
                    numLugares = 8;
                }

                Mesa tmp = new Mesa(numLugares);
                ListaMesas.Add(tmp);
            }

        }
        public Mesa AlocarMesa(Requisicao requisicao)
        {
            int tmp = requisicao.QuantidadePessoas;
            Mesa tmpMesa = null; 

            foreach(var mesa in ListaMesas)
            {
                if(mesa.AceitaPessoas(tmp) == true && mesa.VerificarOcupacao() == false )
                {
                    tmpMesa = mesa;
                }
            }

            if( tmpMesa != null )
            {
                tmpMesa.OcuparMesa();
                requisicao.AdicionarMesa(tmpMesa);
            }

            return tmpMesa;
        }

        public void FinalizarRequisicao(Requisicao requisicao)
        {
            int tmp = requisicao.QuantidadePessoas;
            requisicao.Finalizar();
            RodarFila(requisicao);

        }

        public Requisicao enfileirarRequisicao(Requisicao requisicao)
        {
            int tmp = requisicao.QuantidadePessoas;
            
            if(tmp < 4)
            {
                Mesas4.Enqueue(requisicao);
                if(VerificarDisponibilidade(requisicao.QuantidadePessoas) == true)
                {
                    requisicao = Mesas4.Dequeue();
                    AlocarMesa(requisicao);
                }
            }
            else if(tmp < 8)
            {
                Mesas6.Enqueue(requisicao);
                if (VerificarDisponibilidade(requisicao.QuantidadePessoas) == true)
                {
                    requisicao = Mesas6.Dequeue();
                    AlocarMesa(requisicao);
                }
            }
            else
            {
                Mesas8.Enqueue(requisicao);
                if (VerificarDisponibilidade(requisicao.QuantidadePessoas) == true)
                {
                    requisicao = Mesas8.Dequeue();
                    AlocarMesa(requisicao);
                }
            }
            

            return requisicao;
        }

        private Requisicao RodarFila(Requisicao requisicao)
        {
            int tmp = requisicao.QuantidadePessoas;
            if (tmp < 4)
            {
                if (VerificarDisponibilidade(tmp) == true)
                {
                    requisicao = Mesas4.Dequeue();
                    AlocarMesa(requisicao);
                }
            }
            else if (tmp < 8)
            {
                if (VerificarDisponibilidade(tmp) == true)
                {
                    requisicao = Mesas6.Dequeue();
                    AlocarMesa(requisicao);
                }
            }
            else
            {
                if (VerificarDisponibilidade(tmp) == true)
                {
                    requisicao = Mesas8.Dequeue();
                    AlocarMesa(requisicao);
                }
            }

            return requisicao;
        }

        public bool VerificarDisponibilidade(int tmp)
        {
            bool disponivel = false;
            

            foreach (var mesa in ListaMesas )
            {
                if( mesa.AceitaPessoas(tmp) == true && mesa.VerificarOcupacao() == false)
                {
                    disponivel = true;
                }
            }

            return disponivel;
        }
    }
}

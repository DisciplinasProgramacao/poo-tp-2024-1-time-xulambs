using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Xulambs.Model
{
    public class Pedido
    {
        private int RequisicaoId { get; set; }
        private Mesa Mesa { get; set; }
        private Cliente Cliente { get; set; }
        private Restaurante Restaurante { get; set; }
        private DateTime HoraEntrada { get; set; }
        private DateTime HoraSaida { get; set; }
        private int QuantidadePessoa { get; set; }

        public Pedido(Cliente cliente, Restaurante restaurante)
        {
            Restaurante = restaurante;
            Cliente = cliente;
            HoraEntrada = DateTime.Now;
        }

        public string RequisitarMesa(int quantidadePessoa)
        {
            if (QuantidadePessoa < 0)
                return "Não pode pedir uma mesa com 0 pessoas";

            if (VerificarMesaDisponivel(QuantidadePessoa))
                return $"Você sera alocado na mesa de número{Mesa.NumeroMesa}";

            return "Não foi encontrada nenhuma mesa no momento, espere liberar alguma mesa.";
        }

        private bool VerificarMesaDisponivel(int quantidadePessoa)
        {
            var MesaEncontrada = Restaurante.Mesas.Where(x => x.Capacidade == quantidadePessoa && x.Ocupada == false).FirstOrDefault();
            if (MesaEncontrada)
            {
                Mesa = MesaEncontrada;
                return true;
            }

            return false;
        }
    }
}

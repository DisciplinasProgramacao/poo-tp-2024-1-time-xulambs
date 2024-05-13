using System.Linq;

namespace Time.Xulambs.Classes
{
    public class Pedido
    {
        private Guid RequisicaoGuid { get; set; }
        private Mesa Mesa { get; set; }
        private DateTime HoraEntrada { get; set; }
        private DateTime HoraSaida { get; set; }
        private bool Atendida { get; set; }
        private int QuantidadePessoas { get; set; }
        public int quantidadePessoas
        {
            get { return QuantidadePessoas; }
            set { QuantidadePessoas = value; }
        }
        public bool atendida
        {
            get { return Atendida; }
            set { Atendida = value; }
        }

        public Pedido(int QuantidadePessoa)
        {
            RequisicaoGuid = Guid.NewGuid();
            this.QuantidadePessoas = QuantidadePessoa;
            HoraEntrada = DateTime.Now;
            Atendida = false;
        }

        public void RequisitarMesa(Mesa mesa)
        {
            this.Mesa = mesa;
            Mesa.OcuparMesa();
            Atendida = true;
        }

        private void EncerrarRequisicao()
        {
            HoraSaida = DateTime.Now;
        }
    }
}

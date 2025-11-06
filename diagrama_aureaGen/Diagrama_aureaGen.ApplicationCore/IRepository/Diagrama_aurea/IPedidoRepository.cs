using System;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.CP.Diagrama_aurea;

namespace Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea
{
    public partial interface IPedidoRepository
    {
        void setSessionCP(GenericSessionCP session);

        PedidoEN ReadOIDDefault(int idPedido);
        PedidoEN ReadOID(int idPedido);   // ← NUEVO MÉTODO

        void ModifyDefault(PedidoEN pedido);

        System.Collections.Generic.IList<PedidoEN> ReadAllDefault(int first, int size);

        int CrearPedido(PedidoEN pedido);
        System.Collections.Generic.IList<PedidoEN> ConsultarPedido(int first, int size);

        void ModificarPedido(PedidoEN pedido);
        void EliminarPedido(int idPedido);
    }
}

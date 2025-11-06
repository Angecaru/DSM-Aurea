

using System;
using System.Text;
using System.Collections.Generic;

using Diagrama_aureaGen.ApplicationCore.Exceptions;

using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;


namespace Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea
{
/*
 *      Definition of the class PedidoCEN
 *
 */
public partial class PedidoCEN
{
private IPedidoRepository _IPedidoRepository;

public PedidoCEN(IPedidoRepository _IPedidoRepository)
{
        this._IPedidoRepository = _IPedidoRepository;
}

public IPedidoRepository get_IPedidoRepository ()
{
        return this._IPedidoRepository;
}

public int CrearPedido (int p_idPedido, int p_realizado_por, int p_usa, int p_envia_a, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DetallePedidoEN> p_detallePedido, Nullable<DateTime> p_fecha, Diagrama_aureaGen.ApplicationCore.Enumerated.Diagrama_aurea.EstadoPedidoEnum p_estado, float p_total, int p_relacionado_con)
{
        PedidoEN pedidoEN = null;
        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.IdPedido = p_idPedido;


        if (p_realizado_por != -1) {
                // El argumento p_realizado_por -> Property realizado_por es oid = false
                // Lista de oids idPedido
                pedidoEN.Realizado_por = new Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN ();
                pedidoEN.Realizado_por.IdUsuario = p_realizado_por;
        }


        if (p_usa != -1) {
                // El argumento p_usa -> Property usa es oid = false
                // Lista de oids idPedido
                pedidoEN.Usa = new Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.MetodoPagoEN ();
                pedidoEN.Usa.IdMetodo = p_usa;
        }


        if (p_envia_a != -1) {
                // El argumento p_envia_a -> Property envia_a es oid = false
                // Lista de oids idPedido
                pedidoEN.Envia_a = new Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DireccionEnvioEN ();
                pedidoEN.Envia_a.IdDireccion = p_envia_a;
        }

        pedidoEN.DetallePedido = p_detallePedido;

        pedidoEN.Fecha = p_fecha;

        pedidoEN.Estado = p_estado;

        pedidoEN.Total = p_total;


        if (p_relacionado_con != -1) {
                // El argumento p_relacionado_con -> Property relacionado_con es oid = false
                // Lista de oids idPedido
                pedidoEN.Relacionado_con = new Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DevolucionEN ();
                pedidoEN.Relacionado_con.IdDevolucion = p_relacionado_con;
        }



        oid = _IPedidoRepository.CrearPedido (pedidoEN);
        return oid;
}

public System.Collections.Generic.IList<PedidoEN> ConsultarPedido (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> list = null;

        list = _IPedidoRepository.ConsultarPedido (first, size);
        return list;
}
public void ModificarPedido (int p_Pedido_OID, Nullable<DateTime> p_fecha, Diagrama_aureaGen.ApplicationCore.Enumerated.Diagrama_aurea.EstadoPedidoEnum p_estado, float p_total)
{
        PedidoEN pedidoEN = null;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.IdPedido = p_Pedido_OID;
        pedidoEN.Fecha = p_fecha;
        pedidoEN.Estado = p_estado;
        pedidoEN.Total = p_total;
        //Call to PedidoRepository

        _IPedidoRepository.ModificarPedido (pedidoEN);
}

public void EliminarPedido (int idPedido
                            )
{
        _IPedidoRepository.EliminarPedido (idPedido);
}
}
}

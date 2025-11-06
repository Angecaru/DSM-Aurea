
using System;
// Definición clase PedidoEN
namespace Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea
{
public partial class PedidoEN
{
/**
 *	Atributo idPedido
 */
private int idPedido;



/**
 *	Atributo realizado_por
 */
private Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN realizado_por;



/**
 *	Atributo usa
 */
private Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.MetodoPagoEN usa;



/**
 *	Atributo envia_a
 */
private Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DireccionEnvioEN envia_a;



/**
 *	Atributo detallePedido
 */
private System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DetallePedidoEN> detallePedido;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo estado
 */
private Diagrama_aureaGen.ApplicationCore.Enumerated.Diagrama_aurea.EstadoPedidoEnum estado;



/**
 *	Atributo total
 */
private float total;



/**
 *	Atributo relacionado_con
 */
private Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DevolucionEN relacionado_con;






public virtual int IdPedido {
        get { return idPedido; } set { idPedido = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN Realizado_por {
        get { return realizado_por; } set { realizado_por = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.MetodoPagoEN Usa {
        get { return usa; } set { usa = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DireccionEnvioEN Envia_a {
        get { return envia_a; } set { envia_a = value;  }
}



public virtual System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DetallePedidoEN> DetallePedido {
        get { return detallePedido; } set { detallePedido = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.Enumerated.Diagrama_aurea.EstadoPedidoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual float Total {
        get { return total; } set { total = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DevolucionEN Relacionado_con {
        get { return relacionado_con; } set { relacionado_con = value;  }
}





public PedidoEN()
{
        detallePedido = new System.Collections.Generic.List<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DetallePedidoEN>();
}



public PedidoEN(int idPedido, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN realizado_por, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.MetodoPagoEN usa, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DireccionEnvioEN envia_a, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DetallePedidoEN> detallePedido, Nullable<DateTime> fecha, Diagrama_aureaGen.ApplicationCore.Enumerated.Diagrama_aurea.EstadoPedidoEnum estado, float total, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DevolucionEN relacionado_con
                )
{
        this.init (IdPedido, realizado_por, usa, envia_a, detallePedido, fecha, estado, total, relacionado_con);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (pedido.IdPedido, pedido.Realizado_por, pedido.Usa, pedido.Envia_a, pedido.DetallePedido, pedido.Fecha, pedido.Estado, pedido.Total, pedido.Relacionado_con);
}

private void init (int idPedido
                   , Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN realizado_por, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.MetodoPagoEN usa, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DireccionEnvioEN envia_a, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DetallePedidoEN> detallePedido, Nullable<DateTime> fecha, Diagrama_aureaGen.ApplicationCore.Enumerated.Diagrama_aurea.EstadoPedidoEnum estado, float total, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DevolucionEN relacionado_con)
{
        this.IdPedido = idPedido;


        this.Realizado_por = realizado_por;

        this.Usa = usa;

        this.Envia_a = envia_a;

        this.DetallePedido = detallePedido;

        this.Fecha = fecha;

        this.Estado = estado;

        this.Total = total;

        this.Relacionado_con = relacionado_con;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
        if (t == null)
                return false;
        if (IdPedido.Equals (t.IdPedido))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdPedido.GetHashCode ();
        return hash;
}
}
}

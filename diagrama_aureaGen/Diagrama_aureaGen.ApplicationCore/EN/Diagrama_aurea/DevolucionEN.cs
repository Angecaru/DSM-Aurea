
using System;
// Definición clase DevolucionEN
namespace Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea
{
public partial class DevolucionEN
{
/**
 *	Atributo idDevolucion
 */
private int idDevolucion;



/**
 *	Atributo fechaDevolucion
 */
private Nullable<DateTime> fechaDevolucion;



/**
 *	Atributo estado
 */
private Diagrama_aureaGen.ApplicationCore.Enumerated.Diagrama_aurea.EstadoDevolucionEnum estado;



/**
 *	Atributo motivo
 */
private string motivo;



/**
 *	Atributo idPedido
 */
private int idPedido;



/**
 *	Atributo idProducto
 */
private int idProducto;



/**
 *	Atributo pedido
 */
private Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN pedido;



/**
 *	Atributo producto
 */
private Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN producto;






public virtual int IdDevolucion {
        get { return idDevolucion; } set { idDevolucion = value;  }
}



public virtual Nullable<DateTime> FechaDevolucion {
        get { return fechaDevolucion; } set { fechaDevolucion = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.Enumerated.Diagrama_aurea.EstadoDevolucionEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual string Motivo {
        get { return motivo; } set { motivo = value;  }
}



public virtual int IdPedido {
        get { return idPedido; } set { idPedido = value;  }
}



public virtual int IdProducto {
        get { return idProducto; } set { idProducto = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}





public DevolucionEN()
{
}



public DevolucionEN(int idDevolucion, Nullable<DateTime> fechaDevolucion, Diagrama_aureaGen.ApplicationCore.Enumerated.Diagrama_aurea.EstadoDevolucionEnum estado, string motivo, int idPedido, int idProducto, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN pedido, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN producto
                    )
{
        this.init (IdDevolucion, fechaDevolucion, estado, motivo, idPedido, idProducto, pedido, producto);
}


public DevolucionEN(DevolucionEN devolucion)
{
        this.init (devolucion.IdDevolucion, devolucion.FechaDevolucion, devolucion.Estado, devolucion.Motivo, devolucion.IdPedido, devolucion.IdProducto, devolucion.Pedido, devolucion.Producto);
}

private void init (int idDevolucion
                   , Nullable<DateTime> fechaDevolucion, Diagrama_aureaGen.ApplicationCore.Enumerated.Diagrama_aurea.EstadoDevolucionEnum estado, string motivo, int idPedido, int idProducto, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.PedidoEN pedido, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN producto)
{
        this.IdDevolucion = idDevolucion;


        this.FechaDevolucion = fechaDevolucion;

        this.Estado = estado;

        this.Motivo = motivo;

        this.IdPedido = idPedido;

        this.IdProducto = idProducto;

        this.Pedido = pedido;

        this.Producto = producto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        DevolucionEN t = obj as DevolucionEN;
        if (t == null)
                return false;
        if (IdDevolucion.Equals (t.IdDevolucion))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdDevolucion.GetHashCode ();
        return hash;
}
}
}

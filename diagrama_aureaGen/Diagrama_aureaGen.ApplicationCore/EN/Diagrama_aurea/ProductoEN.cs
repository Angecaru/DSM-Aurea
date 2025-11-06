
using System;
// Definición clase ProductoEN
namespace Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea
{
public partial class ProductoEN
{
/**
 *	Atributo idProducto
 */
private int idProducto;



/**
 *	Atributo incluido_en
 */
private System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DetallePedidoEN> incluido_en;



/**
 *	Atributo productoCarrito
 */
private System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoCarritoEN> productoCarrito;



/**
 *	Atributo categoria
 */
private Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.CategoriaEN categoria;



/**
 *	Atributo deTemporada
 */
private Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DeTemporadaEN deTemporada;



/**
 *	Atributo favorito
 */
private Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.FavoritoEN favorito;



/**
 *	Atributo administrador
 */
private Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.AdministradorEN administrador;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo precio
 */
private float precio;



/**
 *	Atributo stock
 */
private int stock;



/**
 *	Atributo material
 */
private string material;



/**
 *	Atributo imagen
 */
private string imagen;



/**
 *	Atributo etiquetas
 */
private string etiquetas;



/**
 *	Atributo emailCliente
 */
private string emailCliente;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo metodoPago
 */
private string metodoPago;



/**
 *	Atributo datosTarjeta
 */
private string datosTarjeta;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo productos_devueltos
 */
private System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DevolucionEN> productos_devueltos;






public virtual int IdProducto {
        get { return idProducto; } set { idProducto = value;  }
}



public virtual System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DetallePedidoEN> Incluido_en {
        get { return incluido_en; } set { incluido_en = value;  }
}



public virtual System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoCarritoEN> ProductoCarrito {
        get { return productoCarrito; } set { productoCarrito = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.CategoriaEN Categoria {
        get { return categoria; } set { categoria = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DeTemporadaEN DeTemporada {
        get { return deTemporada; } set { deTemporada = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.FavoritoEN Favorito {
        get { return favorito; } set { favorito = value;  }
}



public virtual Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.AdministradorEN Administrador {
        get { return administrador; } set { administrador = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual float Precio {
        get { return precio; } set { precio = value;  }
}



public virtual int Stock {
        get { return stock; } set { stock = value;  }
}



public virtual string Material {
        get { return material; } set { material = value;  }
}



public virtual string Imagen {
        get { return imagen; } set { imagen = value;  }
}



public virtual string Etiquetas {
        get { return etiquetas; } set { etiquetas = value;  }
}



public virtual string EmailCliente {
        get { return emailCliente; } set { emailCliente = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual string MetodoPago {
        get { return metodoPago; } set { metodoPago = value;  }
}



public virtual string DatosTarjeta {
        get { return datosTarjeta; } set { datosTarjeta = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DevolucionEN> Productos_devueltos {
        get { return productos_devueltos; } set { productos_devueltos = value;  }
}





public ProductoEN()
{
        incluido_en = new System.Collections.Generic.List<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DetallePedidoEN>();
        productoCarrito = new System.Collections.Generic.List<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoCarritoEN>();
        productos_devueltos = new System.Collections.Generic.List<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DevolucionEN>();
}



public ProductoEN(int idProducto, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DetallePedidoEN> incluido_en, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoCarritoEN> productoCarrito, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.CategoriaEN categoria, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DeTemporadaEN deTemporada, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.FavoritoEN favorito, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.AdministradorEN administrador, string nombre, string descripcion, float precio, int stock, string material, string imagen, string etiquetas, string emailCliente, Nullable<DateTime> fecha, string metodoPago, string datosTarjeta, string direccion, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DevolucionEN> productos_devueltos
                  )
{
        this.init (IdProducto, incluido_en, productoCarrito, categoria, deTemporada, favorito, administrador, nombre, descripcion, precio, stock, material, imagen, etiquetas, emailCliente, fecha, metodoPago, datosTarjeta, direccion, productos_devueltos);
}


public ProductoEN(ProductoEN producto)
{
        this.init (producto.IdProducto, producto.Incluido_en, producto.ProductoCarrito, producto.Categoria, producto.DeTemporada, producto.Favorito, producto.Administrador, producto.Nombre, producto.Descripcion, producto.Precio, producto.Stock, producto.Material, producto.Imagen, producto.Etiquetas, producto.EmailCliente, producto.Fecha, producto.MetodoPago, producto.DatosTarjeta, producto.Direccion, producto.Productos_devueltos);
}

private void init (int idProducto
                   , System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DetallePedidoEN> incluido_en, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoCarritoEN> productoCarrito, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.CategoriaEN categoria, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DeTemporadaEN deTemporada, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.FavoritoEN favorito, Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.AdministradorEN administrador, string nombre, string descripcion, float precio, int stock, string material, string imagen, string etiquetas, string emailCliente, Nullable<DateTime> fecha, string metodoPago, string datosTarjeta, string direccion, System.Collections.Generic.IList<Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.DevolucionEN> productos_devueltos)
{
        this.IdProducto = idProducto;


        this.Incluido_en = incluido_en;

        this.ProductoCarrito = productoCarrito;

        this.Categoria = categoria;

        this.DeTemporada = deTemporada;

        this.Favorito = favorito;

        this.Administrador = administrador;

        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Precio = precio;

        this.Stock = stock;

        this.Material = material;

        this.Imagen = imagen;

        this.Etiquetas = etiquetas;

        this.EmailCliente = emailCliente;

        this.Fecha = fecha;

        this.MetodoPago = metodoPago;

        this.DatosTarjeta = datosTarjeta;

        this.Direccion = direccion;

        this.Productos_devueltos = productos_devueltos;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProductoEN t = obj as ProductoEN;
        if (t == null)
                return false;
        if (IdProducto.Equals (t.IdProducto))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdProducto.GetHashCode ();
        return hash;
}
}
}


using System;
using System.Text;
using Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.Exceptions;
using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.CP.Diagrama_aurea;
using Diagrama_aureaGen.Infraestructure.EN.Diagrama_aurea;


/*
 * Clase Producto:
 *
 */

namespace Diagrama_aureaGen.Infraestructure.Repository.Diagrama_aurea
{
public partial class ProductoRepository : BasicRepository, IProductoRepository
{
public ProductoRepository() : base ()
{
}


public ProductoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ProductoEN ReadOIDDefault (int idProducto
                                  )
{
        ProductoEN productoEN = null;

        try
        {
                SessionInitializeTransaction ();
                productoEN = (ProductoEN)session.Get (typeof(ProductoNH), idProducto);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ProductoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ProductoEN>();
                        else
                                result = session.CreateCriteria (typeof(ProductoNH)).List<ProductoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoNH productoNH = (ProductoNH)session.Load (typeof(ProductoNH), producto.IdProducto);







                productoNH.Nombre = producto.Nombre;


                productoNH.Descripcion = producto.Descripcion;


                productoNH.Precio = producto.Precio;


                productoNH.Stock = producto.Stock;


                productoNH.Material = producto.Material;


                productoNH.Imagen = producto.Imagen;


                productoNH.Etiquetas = producto.Etiquetas;


                productoNH.EmailCliente = producto.EmailCliente;


                productoNH.Fecha = producto.Fecha;


                productoNH.MetodoPago = producto.MetodoPago;


                productoNH.DatosTarjeta = producto.DatosTarjeta;


                productoNH.Direccion = producto.Direccion;


                session.Update (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearProducto (ProductoEN producto)
{
        ProductoNH productoNH = new ProductoNH (producto);

        try
        {
                SessionInitializeTransaction ();
                if (producto.Categoria != null) {
                        // Argumento OID y no colección.
                        productoNH
                        .Categoria = (Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.CategoriaEN)session.Load (typeof(Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.CategoriaEN), producto.Categoria.IdCategoria);

                        productoNH.Categoria.Pertenece
                        .Add (productoNH);
                }
                if (producto.Administrador != null) {
                        // Argumento OID y no colección.
                        productoNH
                        .Administrador = (Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.AdministradorEN)session.Load (typeof(Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.AdministradorEN), producto.Administrador.CodigoEmpresa);

                        productoNH.Administrador.Administra
                        .Add (productoNH);
                }

                session.Save (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return productoNH.IdProducto;
}

public System.Collections.Generic.IList<ProductoEN> ConsultarProducto (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ProductoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ProductoEN>();
                else
                        result = session.CreateCriteria (typeof(ProductoNH)).List<ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void ModificarProducto (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoNH productoNH = (ProductoNH)session.Load (typeof(ProductoNH), producto.IdProducto);

                productoNH.Nombre = producto.Nombre;


                productoNH.Descripcion = producto.Descripcion;


                productoNH.Precio = producto.Precio;


                productoNH.Stock = producto.Stock;


                productoNH.Material = producto.Material;


                productoNH.Imagen = producto.Imagen;


                productoNH.Etiquetas = producto.Etiquetas;


                productoNH.EmailCliente = producto.EmailCliente;


                productoNH.Fecha = producto.Fecha;


                productoNH.MetodoPago = producto.MetodoPago;


                productoNH.DatosTarjeta = producto.DatosTarjeta;


                productoNH.Direccion = producto.Direccion;

                session.Update (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarProducto (int idProducto
                              )
{
        try
        {
                SessionInitializeTransaction ();
                ProductoNH productoNH = (ProductoNH)session.Load (typeof(ProductoNH), idProducto);
                session.Delete (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}

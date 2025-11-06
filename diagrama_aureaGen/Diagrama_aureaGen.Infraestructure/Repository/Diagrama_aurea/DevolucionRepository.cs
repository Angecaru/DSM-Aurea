
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
 * Clase Devolucion:
 *
 */

namespace Diagrama_aureaGen.Infraestructure.Repository.Diagrama_aurea
{
public partial class DevolucionRepository : BasicRepository, IDevolucionRepository
{
public DevolucionRepository() : base ()
{
}


public DevolucionRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public DevolucionEN ReadOIDDefault (int idDevolucion
                                    )
{
        DevolucionEN devolucionEN = null;

        try
        {
                SessionInitializeTransaction ();
                devolucionEN = (DevolucionEN)session.Get (typeof(DevolucionNH), idDevolucion);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return devolucionEN;
}

public System.Collections.Generic.IList<DevolucionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<DevolucionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(DevolucionNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<DevolucionEN>();
                        else
                                result = session.CreateCriteria (typeof(DevolucionNH)).List<DevolucionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DevolucionRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (DevolucionEN devolucion)
{
        try
        {
                SessionInitializeTransaction ();
                DevolucionNH devolucionNH = (DevolucionNH)session.Load (typeof(DevolucionNH), devolucion.IdDevolucion);

                devolucionNH.FechaDevolucion = devolucion.FechaDevolucion;


                devolucionNH.Estado = devolucion.Estado;


                devolucionNH.Motivo = devolucion.Motivo;


                devolucionNH.IdPedido = devolucion.IdPedido;


                devolucionNH.IdProducto = devolucion.IdProducto;



                session.Update (devolucionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DevolucionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearDevolucion (DevolucionEN devolucion)
{
        DevolucionNH devolucionNH = new DevolucionNH (devolucion);

        try
        {
                SessionInitializeTransaction ();
                if (devolucion.Producto != null) {
                        // Argumento OID y no colección.
                        devolucionNH
                        .Producto = (Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN)session.Load (typeof(Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.ProductoEN), devolucion.Producto.IdProducto);

                        devolucionNH.Producto.Productos_devueltos
                        .Add (devolucionNH);
                }

                session.Save (devolucionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DevolucionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return devolucionNH.IdDevolucion;
}

public void ModificarDevolucion (DevolucionEN devolucion)
{
        try
        {
                SessionInitializeTransaction ();
                DevolucionNH devolucionNH = (DevolucionNH)session.Load (typeof(DevolucionNH), devolucion.IdDevolucion);

                devolucionNH.FechaDevolucion = devolucion.FechaDevolucion;


                devolucionNH.Estado = devolucion.Estado;


                devolucionNH.Motivo = devolucion.Motivo;


                devolucionNH.IdPedido = devolucion.IdPedido;


                devolucionNH.IdProducto = devolucion.IdProducto;

                session.Update (devolucionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DevolucionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarDevolucion (int idDevolucion
                                )
{
        try
        {
                SessionInitializeTransaction ();
                DevolucionNH devolucionNH = (DevolucionNH)session.Load (typeof(DevolucionNH), idDevolucion);
                session.Delete (devolucionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DevolucionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}

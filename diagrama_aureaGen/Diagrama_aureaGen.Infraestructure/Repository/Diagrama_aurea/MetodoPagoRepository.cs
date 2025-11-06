
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
 * Clase MetodoPago:
 *
 */

namespace Diagrama_aureaGen.Infraestructure.Repository.Diagrama_aurea
{
public partial class MetodoPagoRepository : BasicRepository, IMetodoPagoRepository
{
public MetodoPagoRepository() : base ()
{
}


public MetodoPagoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public MetodoPagoEN ReadOIDDefault (int idMetodo
                                    )
{
        MetodoPagoEN metodoPagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                metodoPagoEN = (MetodoPagoEN)session.Get (typeof(MetodoPagoNH), idMetodo);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return metodoPagoEN;
}

public System.Collections.Generic.IList<MetodoPagoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MetodoPagoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MetodoPagoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<MetodoPagoEN>();
                        else
                                result = session.CreateCriteria (typeof(MetodoPagoNH)).List<MetodoPagoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MetodoPagoEN metodoPago)
{
        try
        {
                SessionInitializeTransaction ();
                MetodoPagoNH metodoPagoNH = (MetodoPagoNH)session.Load (typeof(MetodoPagoNH), metodoPago.IdMetodo);



                metodoPagoNH.Tipo = metodoPago.Tipo;


                metodoPagoNH.EsPredeterminado = metodoPago.EsPredeterminado;

                session.Update (metodoPagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearMetodoPago (MetodoPagoEN metodoPago)
{
        MetodoPagoNH metodoPagoNH = new MetodoPagoNH (metodoPago);

        try
        {
                SessionInitializeTransaction ();
                if (metodoPago.Usuario != null) {
                        // Argumento OID y no colección.
                        metodoPagoNH
                        .Usuario = (Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN)session.Load (typeof(Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.UsuarioEN), metodoPago.Usuario.IdUsuario);

                        metodoPagoNH.Usuario.Posee
                        .Add (metodoPagoNH);
                }

                session.Save (metodoPagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return metodoPagoNH.IdMetodo;
}

public System.Collections.Generic.IList<MetodoPagoEN> ConsultarMetodoPago (int first, int size)
{
        System.Collections.Generic.IList<MetodoPagoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(MetodoPagoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<MetodoPagoEN>();
                else
                        result = session.CreateCriteria (typeof(MetodoPagoNH)).List<MetodoPagoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void ModificarMetodoPago (MetodoPagoEN metodoPago)
{
        try
        {
                SessionInitializeTransaction ();
                MetodoPagoNH metodoPagoNH = (MetodoPagoNH)session.Load (typeof(MetodoPagoNH), metodoPago.IdMetodo);

                metodoPagoNH.Tipo = metodoPago.Tipo;


                metodoPagoNH.EsPredeterminado = metodoPago.EsPredeterminado;

                session.Update (metodoPagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarMetodoPago (int idMetodo
                                )
{
        try
        {
                SessionInitializeTransaction ();
                MetodoPagoNH metodoPagoNH = (MetodoPagoNH)session.Load (typeof(MetodoPagoNH), idMetodo);
                session.Delete (metodoPagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}

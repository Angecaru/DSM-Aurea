
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
 * Clase DeTemporada:
 *
 */

namespace Diagrama_aureaGen.Infraestructure.Repository.Diagrama_aurea
{
public partial class DeTemporadaRepository : BasicRepository, IDeTemporadaRepository
{
public DeTemporadaRepository() : base ()
{
}


public DeTemporadaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public DeTemporadaEN ReadOIDDefault (int idTemporada
                                     )
{
        DeTemporadaEN deTemporadaEN = null;

        try
        {
                SessionInitializeTransaction ();
                deTemporadaEN = (DeTemporadaEN)session.Get (typeof(DeTemporadaNH), idTemporada);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return deTemporadaEN;
}

public System.Collections.Generic.IList<DeTemporadaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<DeTemporadaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(DeTemporadaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<DeTemporadaEN>();
                        else
                                result = session.CreateCriteria (typeof(DeTemporadaNH)).List<DeTemporadaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DeTemporadaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (DeTemporadaEN deTemporada)
{
        try
        {
                SessionInitializeTransaction ();
                DeTemporadaNH deTemporadaNH = (DeTemporadaNH)session.Load (typeof(DeTemporadaNH), deTemporada.IdTemporada);



                deTemporadaNH.Nombre = deTemporada.Nombre;


                deTemporadaNH.FechaInicio = deTemporada.FechaInicio;


                deTemporadaNH.FechaFin = deTemporada.FechaFin;

                session.Update (deTemporadaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DeTemporadaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearDeTemporada (DeTemporadaEN deTemporada)
{
        DeTemporadaNH deTemporadaNH = new DeTemporadaNH (deTemporada);

        try
        {
                SessionInitializeTransaction ();
                if (deTemporada.Administrador != null) {
                        // Argumento OID y no colección.
                        deTemporadaNH
                        .Administrador = (Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.AdministradorEN)session.Load (typeof(Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea.AdministradorEN), deTemporada.Administrador.CodigoEmpresa);

                        deTemporadaNH.Administrador.Gestiona
                        .Add (deTemporadaNH);
                }

                session.Save (deTemporadaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DeTemporadaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return deTemporadaNH.IdTemporada;
}

public void ModificarDeTemporada (DeTemporadaEN deTemporada)
{
        try
        {
                SessionInitializeTransaction ();
                DeTemporadaNH deTemporadaNH = (DeTemporadaNH)session.Load (typeof(DeTemporadaNH), deTemporada.IdTemporada);

                deTemporadaNH.Nombre = deTemporada.Nombre;


                deTemporadaNH.FechaInicio = deTemporada.FechaInicio;


                deTemporadaNH.FechaFin = deTemporada.FechaFin;

                session.Update (deTemporadaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DeTemporadaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarDeTemporada (int idTemporada
                                 )
{
        try
        {
                SessionInitializeTransaction ();
                DeTemporadaNH deTemporadaNH = (DeTemporadaNH)session.Load (typeof(DeTemporadaNH), idTemporada);
                session.Delete (deTemporadaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DeTemporadaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<DeTemporadaEN> ConsultarDeTemporada (int first, int size)
{
        System.Collections.Generic.IList<DeTemporadaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(DeTemporadaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<DeTemporadaEN>();
                else
                        result = session.CreateCriteria (typeof(DeTemporadaNH)).List<DeTemporadaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in DeTemporadaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}

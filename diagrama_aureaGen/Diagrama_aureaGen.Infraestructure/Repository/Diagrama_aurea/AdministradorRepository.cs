
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
 * Clase Administrador:
 *
 */

namespace Diagrama_aureaGen.Infraestructure.Repository.Diagrama_aurea
{
public partial class AdministradorRepository : BasicRepository, IAdministradorRepository
{
public AdministradorRepository() : base ()
{
}


public AdministradorRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public AdministradorEN ReadOIDDefault (string codigoEmpresa
                                       )
{
        AdministradorEN administradorEN = null;

        try
        {
                SessionInitializeTransaction ();
                administradorEN = (AdministradorEN)session.Get (typeof(AdministradorNH), codigoEmpresa);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return administradorEN;
}

public System.Collections.Generic.IList<AdministradorEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<AdministradorEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(AdministradorNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<AdministradorEN>();
                        else
                                result = session.CreateCriteria (typeof(AdministradorNH)).List<AdministradorEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdministradorRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (AdministradorEN administrador)
{
        try
        {
                SessionInitializeTransaction ();
                AdministradorNH administradorNH = (AdministradorNH)session.Load (typeof(AdministradorNH), administrador.CodigoEmpresa);


                session.Update (administradorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdministradorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string CrearAdministrador (AdministradorEN administrador)
{
        AdministradorNH administradorNH = new AdministradorNH (administrador);

        try
        {
                SessionInitializeTransaction ();

                session.Save (administradorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdministradorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return administradorNH.CodigoEmpresa;
}

public System.Collections.Generic.IList<AdministradorEN> ConsultarAdministrador (int first, int size)
{
        System.Collections.Generic.IList<AdministradorEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(AdministradorNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<AdministradorEN>();
                else
                        result = session.CreateCriteria (typeof(AdministradorNH)).List<AdministradorEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdministradorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void ModificarAdministrador (AdministradorEN administrador)
{
        try
        {
                SessionInitializeTransaction ();
                AdministradorNH administradorNH = (AdministradorNH)session.Load (typeof(AdministradorNH), administrador.CodigoEmpresa);
                session.Update (administradorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdministradorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarAdministrador (string codigoEmpresa
                                   )
{
        try
        {
                SessionInitializeTransaction ();
                AdministradorNH administradorNH = (AdministradorNH)session.Load (typeof(AdministradorNH), codigoEmpresa);
                session.Delete (administradorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is Diagrama_aureaGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new Diagrama_aureaGen.ApplicationCore.Exceptions.DataLayerException ("Error in AdministradorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}

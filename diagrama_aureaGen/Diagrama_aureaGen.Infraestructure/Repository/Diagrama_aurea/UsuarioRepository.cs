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
using System.Collections.Generic;

namespace Diagrama_aureaGen.Infraestructure.Repository.Diagrama_aurea
{
    public partial class UsuarioRepository : BasicRepository, IUsuarioRepository
    {
        public UsuarioRepository() : base() { }
        public UsuarioRepository(GenericSessionCP sessionAux) : base(sessionAux) { }

        public void setSessionCP(GenericSessionCP session)
        {
            sessionInside = false;
            this.session = (ISession)session.CurrentSession;
        }

        public UsuarioEN ReadOIDDefault(int idUsuario)
        {
            UsuarioEN usuarioEN = null;

            try
            {
                SessionInitializeTransaction();
                usuarioEN = (UsuarioEN)session.Get(typeof(UsuarioNH), idUsuario);
                SessionCommit();
            }
            catch (Exception) { }
            finally
            {
                SessionClose();
            }

            return usuarioEN;
        }

        public IList<UsuarioEN> ReadAllDefault(int first, int size)
        {
            IList<UsuarioEN> result = null;
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    if (size > 0)
                        result = session.CreateCriteria(typeof(UsuarioNH))
                                        .SetFirstResult(first).SetMaxResults(size).List<UsuarioEN>();
                    else
                        result = session.CreateCriteria(typeof(UsuarioNH)).List<UsuarioEN>();
                }
            }
            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is ModelException)
                    throw;
                else throw new DataLayerException("Error in UsuarioRepository.", ex);
            }

            return result;
        }

        public void ModifyDefault(UsuarioEN usuario)
        {
            try
            {
                SessionInitializeTransaction();
                UsuarioNH usuarioNH = (UsuarioNH)session.Load(typeof(UsuarioNH), usuario.IdUsuario);

                usuarioNH.NombreUsuario = usuario.NombreUsuario;
                usuarioNH.Apellidos = usuario.Apellidos;
                usuarioNH.Dni = usuario.Dni;
                usuarioNH.FechaNacimiento = usuario.FechaNacimiento;
                usuarioNH.Email = usuario.Email;
                usuarioNH.Contraseña = usuario.Contraseña;
                usuarioNH.FechaRegistro = usuario.FechaRegistro;

                session.Update(usuarioNH);
                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is ModelException)
                    throw;
                else throw new DataLayerException("Error in UsuarioRepository.", ex);
            }
            finally
            {
                SessionClose();
            }
        }

        public int CrearUsuario(UsuarioEN usuario)
        {
            UsuarioNH usuarioNH = null;

            try
            {
                SessionInitializeTransaction();

                // Si la fecha no está establecida, asignar ahora
                if (usuario.FechaRegistro == null)
                    usuario.FechaRegistro = DateTime.Now;
                if (usuario.FechaNacimiento == null)
                    usuario.FechaNacimiento = DateTime.Now;

                Console.WriteLine($"[DEBUG CrearUsuario] Nombre={usuario.NombreUsuario}, Email={usuario.Email}, DNI={usuario.Dni}");

                usuarioNH = new UsuarioNH(usuario);
                session.Save(usuarioNH);
                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                Console.WriteLine($"[ERROR CrearUsuario] {ex.Message}");
                if (ex is ModelException)
                    throw;
                else
                    throw new DataLayerException("Error in UsuarioRepository.", ex);
            }
            finally
            {
                SessionClose();
            }

            return usuarioNH.IdUsuario;
        }

        public IList<UsuarioEN> ConsultarUsuario(int first, int size)
        {
            IList<UsuarioEN> result = null;
            try
            {
                SessionInitializeTransaction();
                if (size > 0)
                    result = session.CreateCriteria(typeof(UsuarioNH))
                                    .SetFirstResult(first).SetMaxResults(size).List<UsuarioEN>();
                else
                    result = session.CreateCriteria(typeof(UsuarioNH)).List<UsuarioEN>();
                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is ModelException)
                    throw;
                else throw new DataLayerException("Error in UsuarioRepository.", ex);
            }
            finally
            {
                SessionClose();
            }

            return result;
        }

        public void ModificarUsuario(UsuarioEN usuario)
        {
            try
            {
                SessionInitializeTransaction();
                UsuarioNH usuarioNH = (UsuarioNH)session.Load(typeof(UsuarioNH), usuario.IdUsuario);

                usuarioNH.NombreUsuario = usuario.NombreUsuario;
                usuarioNH.Apellidos = usuario.Apellidos;
                usuarioNH.Dni = usuario.Dni;
                usuarioNH.FechaNacimiento = usuario.FechaNacimiento;
                usuarioNH.Email = usuario.Email;
                usuarioNH.Contraseña = usuario.Contraseña;
                usuarioNH.FechaRegistro = usuario.FechaRegistro;

                session.Update(usuarioNH);
                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is ModelException)
                    throw;
                else throw new DataLayerException("Error in UsuarioRepository.", ex);
            }
            finally
            {
                SessionClose();
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            try
            {
                SessionInitializeTransaction();
                UsuarioNH usuarioNH = (UsuarioNH)session.Load(typeof(UsuarioNH), idUsuario);
                session.Delete(usuarioNH);
                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is ModelException)
                    throw;
                else throw new DataLayerException("Error in UsuarioRepository.", ex);
            }
            finally
            {
                SessionClose();
            }
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using Diagrama_aureaGen.ApplicationCore.Exceptions;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;

namespace Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea
{
    /*
     * Definition of the class UsuarioCEN
     */
    public partial class UsuarioCEN
    {
        private IUsuarioRepository _IUsuarioRepository;

        public UsuarioCEN(IUsuarioRepository _IUsuarioRepository)
        {
            this._IUsuarioRepository = _IUsuarioRepository;
        }

        public IUsuarioRepository get_IUsuarioRepository()
        {
            return this._IUsuarioRepository;
        }

        // ================================================================
        // CREATE (ID autogenerado en BD)
        // ================================================================
        public int CrearUsuario(string p_nombreUsuario, string p_apellidos, string p_dni,
                                Nullable<DateTime> p_fechaNacimiento, string p_email,
                                string p_contraseña, Nullable<DateTime> p_fechaRegistro)
        {
            UsuarioEN usuarioEN = new UsuarioEN();

            usuarioEN.NombreUsuario = p_nombreUsuario;
            usuarioEN.Apellidos = p_apellidos;
            usuarioEN.Dni = p_dni;
            usuarioEN.FechaNacimiento = p_fechaNacimiento;
            usuarioEN.Email = p_email;
            usuarioEN.Contraseña = p_contraseña;
            usuarioEN.FechaRegistro = p_fechaRegistro;

            int oid = _IUsuarioRepository.CrearUsuario(usuarioEN);
            return oid;
        }

        // ================================================================
        // READ ALL
        // ================================================================
        public IList<UsuarioEN> ConsultarUsuario(int first, int size)
        {
            return _IUsuarioRepository.ConsultarUsuario(first, size);
        }

        // ================================================================
        // UPDATE
        // ================================================================
        public void ModificarUsuario(int p_Usuario_OID, string p_nombreUsuario, string p_apellidos,
                                     string p_dni, Nullable<DateTime> p_fechaNacimiento,
                                     string p_email, string p_contraseña, Nullable<DateTime> p_fechaRegistro)
        {
            UsuarioEN usuarioEN = new UsuarioEN();

            usuarioEN.IdUsuario = p_Usuario_OID;
            usuarioEN.NombreUsuario = p_nombreUsuario;
            usuarioEN.Apellidos = p_apellidos;
            usuarioEN.Dni = p_dni;
            usuarioEN.FechaNacimiento = p_fechaNacimiento;
            usuarioEN.Email = p_email;
            usuarioEN.Contraseña = p_contraseña;
            usuarioEN.FechaRegistro = p_fechaRegistro;

            _IUsuarioRepository.ModificarUsuario(usuarioEN);
        }

        // ================================================================
        // DELETE
        // ================================================================
        public void EliminarUsuario(int idUsuario)
        {
            _IUsuarioRepository.EliminarUsuario(idUsuario);
        }
    }
}

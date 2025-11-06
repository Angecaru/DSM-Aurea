using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Diagrama_aureaGen.ApplicationCore.Exceptions;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;

namespace Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea
{
    /// <summary>
    /// Extensión customizada de UsuarioCEN
    /// </summary>
    public partial class UsuarioCEN
    {
        /// <summary>
        /// Login de usuario con validaciones
        /// </summary>
        /// <param name="email">Email del usuario</param>
        /// <param name="contraseña">Contraseña del usuario</param>
        /// <returns>UsuarioEN si las credenciales son correctas</returns>
        public UsuarioEN Login(string email, string contraseña)
        {
            DateTime tiempoInicio = DateTime.Now;

            try
            {
                Console.WriteLine($"\n[LOGIN] Intentando login para: {email}");

                // VALIDACIÓN 1: Campos no vacíos
                if (string.IsNullOrWhiteSpace(email))
                {
                    throw new ArgumentException("El email no puede estar vacío");
                }

                if (string.IsNullOrWhiteSpace(contraseña))
                {
                    throw new ArgumentException("La contraseña no puede estar vacía");
                }

                // VALIDACIÓN 2: Formato de email básico
                if (!email.Contains("@") || !email.Contains("."))
                {
                    throw new ArgumentException("El formato del email no es válido");
                }

                // Buscar usuario por email
                IList<UsuarioEN> todosUsuarios = _IUsuarioRepository.ReadAllDefault(0, -1);

                UsuarioEN usuario = todosUsuarios
                    .FirstOrDefault(u => u.Email != null &&
                                       u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

                if (usuario == null)
                {
                    Console.WriteLine($"[LOGIN] ❌ Usuario no encontrado: {email}");
                    throw new UnauthorizedAccessException("Email o contraseña incorrectos");
                }

                // Verificar contraseña
                if (usuario.Contraseña != contraseña)
                {
                    Console.WriteLine($"[LOGIN] ❌ Contraseña incorrecta para: {email}");
                    throw new UnauthorizedAccessException("Email o contraseña incorrectos");
                }

                // Login exitoso
                Console.WriteLine($"[LOGIN] ✅ Login exitoso - Usuario ID: {usuario.IdUsuario}");
                Console.WriteLine($"[LOGIN] Nombre: {usuario.NombreUsuario} {usuario.Apellidos}");

                TimeSpan duracion = DateTime.Now - tiempoInicio;
                Console.WriteLine($"[TIEMPO] Login: {duracion.TotalMilliseconds}ms\n");

                return usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Login: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verificar si un email ya está registrado
        /// </summary>
        public bool EmailExiste(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return false;
                }

                IList<UsuarioEN> todosUsuarios = _IUsuarioRepository.ReadAllDefault(0, -1);

                return todosUsuarios.Any(u => u.Email != null &&
                                            u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] EmailExiste: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Cambiar contraseña de usuario
        /// </summary>
        public void CambiarContraseñaCustom(int idUsuario, string contraseñaActual, string contraseñaNueva)
        {
            DateTime tiempoInicio = DateTime.Now;

            try
            {
                Console.WriteLine($"\n[CUSTOM] CambiarContraseña - Usuario ID: {idUsuario}");

                // Obtener usuario
                UsuarioEN usuario = _IUsuarioRepository.ReadOIDDefault(idUsuario);

                if (usuario == null)
                {
                    throw new ArgumentException($"No existe un usuario con ID: {idUsuario}");
                }

                //VALIDACIÓN 1: Verificar contraseña actual
                if (usuario.Contraseña != contraseñaActual)
                {
                    throw new UnauthorizedAccessException("La contraseña actual es incorrecta");
                }

                //VALIDACIÓN 2: Contraseña nueva no vacía
                if (string.IsNullOrWhiteSpace(contraseñaNueva))
                {
                    throw new ArgumentException("La nueva contraseña no puede estar vacía");
                }

                //VALIDACIÓN 3: Contraseña nueva diferente a la actual
                if (contraseñaNueva == contraseñaActual)
                {
                    throw new ArgumentException("La nueva contraseña debe ser diferente a la actual");
                }

                //VALIDACIÓN 4: Longitud mínima
                if (contraseñaNueva.Length < 6)
                {
                    throw new ArgumentException("La contraseña debe tener al menos 6 caracteres");
                }

                // Modificar usuario con nueva contraseña
                ModificarUsuario(idUsuario, usuario.NombreUsuario, usuario.Apellidos,
                               usuario.Dni, usuario.FechaNacimiento, usuario.Email,
                               contraseñaNueva, usuario.FechaRegistro);

                Console.WriteLine($"[CUSTOM] ✅ Contraseña cambiada exitosamente");

                TimeSpan duracion = DateTime.Now - tiempoInicio;
                Console.WriteLine($"[TIEMPO] CambiarContraseñaCustom: {duracion.TotalMilliseconds}ms\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] CambiarContraseñaCustom: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// FILTRO CUSTOM: Obtener usuarios registrados en un rango de fechas
        /// </summary>
        public IList<UsuarioEN> FiltrarPorFechaRegistroCustom(DateTime fechaInicio, DateTime fechaFin)
        {
            DateTime tiempoInicio = DateTime.Now;

            try
            {
                Console.WriteLine($"\n[CUSTOM FILTER] FiltrarPorFechaRegistro - Desde: {fechaInicio:dd/MM/yyyy} Hasta: {fechaFin:dd/MM/yyyy}");

                IList<UsuarioEN> todosUsuarios = _IUsuarioRepository.ReadAllDefault(0, -1);

                var usuariosFiltrados = todosUsuarios
                    .Where(u => u.FechaRegistro.HasValue &&
                                u.FechaRegistro.Value >= fechaInicio &&
                                u.FechaRegistro.Value <= fechaFin)
                    .OrderByDescending(u => u.FechaRegistro)
                    .ToList();

                Console.WriteLine($"[CUSTOM FILTER] Encontrados {usuariosFiltrados.Count} usuarios en el rango");

                TimeSpan duracion = DateTime.Now - tiempoInicio;
                Console.WriteLine($"[TIEMPO] FiltrarPorFechaRegistroCustom: {duracion.TotalMilliseconds}ms\n");

                return usuariosFiltrados;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] FiltrarPorFechaRegistroCustom: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// FILTRO CUSTOM: Obtener usuarios por DNI
        /// </summary>
        public UsuarioEN BuscarPorDNICustom(string dni)
        {
            DateTime tiempoInicio = DateTime.Now;

            try
            {
                Console.WriteLine($"\n[CUSTOM FILTER] BuscarPorDNI - DNI: {dni}");

                if (string.IsNullOrWhiteSpace(dni))
                {
                    throw new ArgumentException("El DNI no puede estar vacío");
                }

                IList<UsuarioEN> todosUsuarios = _IUsuarioRepository.ReadAllDefault(0, -1);

                UsuarioEN usuario = todosUsuarios
                    .FirstOrDefault(u => u.Dni != null &&
                                       u.Dni.Equals(dni, StringComparison.OrdinalIgnoreCase));

                if (usuario != null)
                {
                    Console.WriteLine($"[CUSTOM FILTER] ✅ Usuario encontrado - ID: {usuario.IdUsuario}");
                }
                else
                {
                    Console.WriteLine($"[CUSTOM FILTER] ❌ No se encontró usuario con DNI: {dni}");
                }

                TimeSpan duracion = DateTime.Now - tiempoInicio;
                Console.WriteLine($"[TIEMPO] BuscarPorDNICustom: {duracion.TotalMilliseconds}ms\n");

                return usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] BuscarPorDNICustom: {ex.Message}");
                throw;
            }
        }
    }
}
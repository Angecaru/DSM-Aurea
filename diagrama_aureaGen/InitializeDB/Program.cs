using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

using Diagrama_aureaGen.Infraestructure.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea;
using Diagrama_aureaGen.Infraestructure.Repository.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;

namespace InitializeDB
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("-----------------------------------------------------------------------------");
            System.Console.WriteLine("A new database called: diagrama_aureaGenNHibernate will be created (the previous information will be deleted).");
            System.Console.WriteLine("-----------------------------------------------------------------------------");

            try
            {
                // Crear BD y esquema
                CreateDB.Create("diagrama_aureaGenNHibernate", "nhibernateUser", "nhibernatePass");
                var cfg = new Configuration();
                cfg.Configure();
                cfg.AddAssembly(typeof(ProductoNH).Assembly);
                new SchemaExport(cfg).Execute(true, true, false);
                System.Console.WriteLine("-------------------------------------");
                System.Console.WriteLine("Database schema created successfully");
                System.Console.WriteLine("-------------------------------------");

                // Insertar datos base
                System.Console.WriteLine("-------------------------------------------------------");
                System.Console.WriteLine("Let's initialize the data of your database! ");
                System.Console.WriteLine("-------------------------------------------------------");

                CreateDB.InitializeData();
                System.Console.WriteLine("-----------------------------------------");
                System.Console.WriteLine("The data has been inserted successfully!!");
                System.Console.WriteLine("-----------------------------------------");

                // ======================================================================
                // PRUEBA CRUD CUSTOM USUARIO
                // ======================================================================
                Console.WriteLine("\n=== PRUEBA CRUD CUSTOM USUARIO ===");

                UsuarioRepository repoUser = new UsuarioRepository();
                UsuarioCEN userCEN = new UsuarioCEN(repoUser);

                // 1️⃣ Crear usuario
                Console.WriteLine("\n[TEST] Creando usuario...");
                int idUser = userCEN.CrearUsuario("isaac",
                                                  "peiro",
                                                  "12345678A",
                                                  new DateTime(2006, 1, 4),
                                                  "isaac@aurea.com",
                                                  "123456",
                                                  DateTime.Now);

                Console.WriteLine($"Usuario creado con ID: {idUser}");

                // 2️⃣ Login correcto
                try
                {
                    var usuario = userCEN.Login("isaac@aurea.com", "123456");
                    Console.WriteLine($"Login correcto para: {usuario.NombreUsuario}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en login: {ex.Message}");
                }

                // 3️⃣ Login incorrecto
                try
                {
                    userCEN.Login("isaac@aurea.com", "000000");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Login fallido (esperado): {ex.Message}");
                }

                // 4️⃣ Cambio de contraseña
                try
                {
                    userCEN.CambiarContraseñaCustom(idUser, "123456", "654321");
                    Console.WriteLine("Contraseña cambiada correctamente");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al cambiar contraseña: {ex.Message}");
                }

                // 5️⃣ Filtro por email
                bool existe = userCEN.EmailExiste("isaac@aurea.com");
                Console.WriteLine($"¿Email existe?: {existe}");

                // 6️⃣ Filtro por rango de fecha de registro
                var usuariosRango = userCEN.FiltrarPorFechaRegistroCustom(
                    DateTime.Now.AddDays(-1),
                    DateTime.Now.AddDays(1));

                Console.WriteLine($"Usuarios registrados en los últimos 2 días: {usuariosRango.Count}");

                // 7️⃣ Filtro por DNI
                var userPorDni = userCEN.BuscarPorDNICustom("12345678A");
                if (userPorDni != null)
                    Console.WriteLine($"Usuario encontrado por DNI: {userPorDni.NombreUsuario}");
                else
                    Console.WriteLine("No se encontró usuario por DNI");
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message.ToString() + '\n' + e.StackTrace);
            }
            finally
            {
                System.Console.WriteLine("Powered by OOH4RIA. Press any key to exit....");
                Console.ReadLine();
            }
        }
    }
}

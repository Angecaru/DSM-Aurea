
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea;
using Diagrama_aureaGen.Infraestructure.Repository.Diagrama_aurea;
using Diagrama_aureaGen.Infraestructure.CP;
using Diagrama_aureaGen.ApplicationCore.Exceptions;

using Diagrama_aureaGen.ApplicationCore.CP.Diagrama_aurea;
using Diagrama_aureaGen.Infraestructure.Repository;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
        public static void Create(string databaseArg, string userArg, string passArg)
        {
            string database = databaseArg;
            string user = userArg;
            string pass = passArg;

            // Conexión directa al servidor SQL Express
            SqlConnection cnn = new SqlConnection(@"Server=(local); Database=master; Integrated Security=True");

            // Crear login si no existe
            string createUser = $@"
        IF NOT EXISTS(SELECT name FROM sys.server_principals WHERE name = '{user}')
        BEGIN
            CREATE LOGIN [{user}] WITH PASSWORD = N'{pass}', CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF;
        END";

            // Eliminar la base de datos si ya existe
            string deleteDataBase = $@"
        IF EXISTS(SELECT * FROM sys.databases WHERE name = '{database}')
        BEGIN
            ALTER DATABASE [{database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
            DROP DATABASE [{database}];
        END";

            // Crear la base de datos
            string createBD = $"CREATE DATABASE [{database}]";

            // Asociar usuario a la base y darle permisos
            string associatedUser = $@"
        USE [{database}];
        IF NOT EXISTS(SELECT name FROM sys.database_principals WHERE name = '{user}')
        BEGIN
            CREATE USER [{user}] FOR LOGIN [{user}];
        END
        EXEC sp_addrolemember N'db_owner', N'{user}';
        ALTER LOGIN [{user}] WITH DEFAULT_DATABASE = [{database}];";

            SqlCommand cmd = null;

            try
            {
                cnn.Open();

                // Crear login global
                cmd = new SqlCommand(createUser, cnn);
                cmd.ExecuteNonQuery();

                // Eliminar base si existe
                cmd = new SqlCommand(deleteDataBase, cnn);
                cmd.ExecuteNonQuery();

                // Crear base nueva
                cmd = new SqlCommand(createBD, cnn);
                cmd.ExecuteNonQuery();

                // Asociar el usuario y darle permisos dentro de la nueva base
                cmd = new SqlCommand(associatedUser, cnn);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Database created successfully and user linked correctly.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating database: " + ex.Message);
                throw;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
        }


        public static void InitializeData ()
{
        try
        {
                // Initialising  CENs
                ProductoRepository productorepository = new ProductoRepository ();
                ProductoCEN productocen = new ProductoCEN (productorepository);
                PedidoRepository pedidorepository = new PedidoRepository ();
                PedidoCEN pedidocen = new PedidoCEN (pedidorepository);
                DevolucionRepository devolucionrepository = new DevolucionRepository ();
                DevolucionCEN devolucioncen = new DevolucionCEN (devolucionrepository);
                DeTemporadaRepository detemporadarepository = new DeTemporadaRepository ();
                DeTemporadaCEN detemporadacen = new DeTemporadaCEN (detemporadarepository);
                UsuarioRepository usuariorepository = new UsuarioRepository ();
                UsuarioCEN usuariocen = new UsuarioCEN (usuariorepository);
                AdministradorRepository administradorrepository = new AdministradorRepository ();
                AdministradorCEN administradorcen = new AdministradorCEN (administradorrepository);
                MetodoPagoRepository metodopagorepository = new MetodoPagoRepository ();
                MetodoPagoCEN metodopagocen = new MetodoPagoCEN (metodopagorepository);
                DireccionEnvioRepository direccionenviorepository = new DireccionEnvioRepository ();
                DireccionEnvioCEN direccionenviocen = new DireccionEnvioCEN (direccionenviorepository);
                FavoritoRepository favoritorepository = new FavoritoRepository ();
                FavoritoCEN favoritocen = new FavoritoCEN (favoritorepository);
                ProductoCarritoRepository productocarritorepository = new ProductoCarritoRepository ();
                ProductoCarritoCEN productocarritocen = new ProductoCarritoCEN (productocarritorepository);
                DetallePedidoRepository detallepedidorepository = new DetallePedidoRepository ();
                DetallePedidoCEN detallepedidocen = new DetallePedidoCEN (detallepedidorepository);
                CategoriaRepository categoriarepository = new CategoriaRepository ();
                CategoriaCEN categoriacen = new CategoriaCEN (categoriarepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

                // You must write the initialisation of the entities inside the PROTECTED comments.
                // IMPORTANT:please do not delete them.

                usuariocen.CrearUsuario( "Juan", "Palomo", "1111111A", new DateTime(1980, 11, 10), "correo@gmail.com", "melancolia7", new DateTime(2025, 11, 10));
                Console.WriteLine("Usuario 1 creado");

                /*PROTECTED REGION END*/
            }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw;
        }
}
}
}

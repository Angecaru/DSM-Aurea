using System;
using System.Collections.Generic;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.Exceptions;

namespace Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea
{
    /*
     * Clase DireccionEnvioCEN
     * Implementa las operaciones CRUD: crear, consultar, modificar, eliminar.
     */
    public partial class DireccionEnvioCEN
    {
        private IDireccionEnvioRepository _IDireccionEnvioRepository;

        public DireccionEnvioCEN(IDireccionEnvioRepository repo)
        {
            this._IDireccionEnvioRepository = repo;
        }

        public IDireccionEnvioRepository get_IDireccionEnvioRepository()
        {
            return this._IDireccionEnvioRepository;
        }

        // ================================================================
        // CREATE
        // ================================================================
        public int crearDireccion(int idDireccion, string calle, string ciudad, string codigoPostal, string pais, bool esPredeterminada, int idUsuario = -1)
        {
            DireccionEnvioEN direccion = new DireccionEnvioEN();
            direccion.IdDireccion = idDireccion;
            direccion.Calle = calle;
            direccion.Ciudad = ciudad;
            direccion.CodigoPostal = codigoPostal;
            direccion.Pais = pais;
            direccion.EsPredeterminada = esPredeterminada;

            // Relación con Usuario (opcional)
            if (idUsuario != -1)
            {
                direccion.Usuario = new UsuarioEN();
                direccion.Usuario.IdUsuario = idUsuario;
            }

            int oid = _IDireccionEnvioRepository.CrearDireccion(direccion);
            return oid;
        }

        // ================================================================
        // READ (consultar uno)
        // ================================================================
        public DireccionEnvioEN consultarDireccion(int idDireccion)
        {
            return _IDireccionEnvioRepository.ReadOIDDefault(idDireccion);
        }

        // ================================================================
        // READ (consultar todos)
        // ================================================================
        public IList<DireccionEnvioEN> consultarDireccionTodos(int first, int size)
        {
            return _IDireccionEnvioRepository.ReadAllDefault(first, size);
        }

        // ================================================================
        // UPDATE
        // ================================================================
        public void modificarDireccion(int idDireccion, string nuevaCalle, string nuevaCiudad, string nuevoCodigoPostal, string nuevoPais, bool esPredeterminada)
        {
            DireccionEnvioEN direccion = _IDireccionEnvioRepository.ReadOIDDefault(idDireccion);
            if (direccion == null)
                throw new ModelException("Dirección no encontrada");

            direccion.Calle = nuevaCalle;
            direccion.Ciudad = nuevaCiudad;
            direccion.CodigoPostal = nuevoCodigoPostal;
            direccion.Pais = nuevoPais;
            direccion.EsPredeterminada = esPredeterminada;

            _IDireccionEnvioRepository.ModificarDireccion(direccion);
        }

        // ================================================================
        // DELETE
        // ================================================================
        public void eliminarDireccion(int idDireccion)
        {
            DireccionEnvioEN direccion = _IDireccionEnvioRepository.ReadOIDDefault(idDireccion);
            if (direccion == null)
                throw new ModelException("No existe la dirección");

            _IDireccionEnvioRepository.EliminarDireccion(idDireccion);
        }
    }
}

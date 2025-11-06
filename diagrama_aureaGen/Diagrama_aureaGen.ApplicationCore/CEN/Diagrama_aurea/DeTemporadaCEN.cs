using System;
using System.Collections.Generic;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.Exceptions;

namespace Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea
{
    /*
     * Clase DeTemporadaCEN
     * Implementa las operaciones CRUD: crear, consultar, modificar, eliminar.
     */
    public partial class DeTemporadaCEN
    {
        private IDeTemporadaRepository _IDeTemporadaRepository;

        public DeTemporadaCEN(IDeTemporadaRepository repo)
        {
            this._IDeTemporadaRepository = repo;
        }

        public IDeTemporadaRepository get_IDeTemporadaRepository()
        {
            return this._IDeTemporadaRepository;
        }

        // ================================================================
        // CREATE
        // ================================================================
        public int crearDeTemporada(int idTemporada, string nombre, DateTime fechaInicio, DateTime fechaFin, string codigoAdministrador = null)
        {
            DeTemporadaEN temporada = new DeTemporadaEN();
            temporada.IdTemporada = idTemporada;
            temporada.Nombre = nombre;
            temporada.FechaInicio = fechaInicio;
            temporada.FechaFin = fechaFin;

            // Relación con Administrador
            if (!string.IsNullOrEmpty(codigoAdministrador))
            {
                temporada.Administrador = new AdministradorEN();
                temporada.Administrador.CodigoEmpresa = codigoAdministrador;
            }

            int oid = _IDeTemporadaRepository.CrearDeTemporada(temporada);
            return oid;
        }

        // ================================================================
        // READ (consultar uno)
        // ================================================================
        public DeTemporadaEN consultarDeTemporada(int idTemporada)
        {
            return _IDeTemporadaRepository.ReadOIDDefault(idTemporada);
        }

        // ================================================================
        // READ (consultar todos)
        // ================================================================
        public IList<DeTemporadaEN> consultarDeTemporadaTodos(int first, int size)
        {
            return _IDeTemporadaRepository.ReadAllDefault(first, size);
        }

        // ================================================================
        // UPDATE
        // ================================================================
        public void modificarDeTemporada(int idTemporada, string nuevoNombre, DateTime nuevaFechaInicio, DateTime nuevaFechaFin)
        {
            DeTemporadaEN temporada = _IDeTemporadaRepository.ReadOIDDefault(idTemporada);
            if (temporada == null)
                throw new ModelException("Temporada no encontrada");

            temporada.Nombre = nuevoNombre;
            temporada.FechaInicio = nuevaFechaInicio;
            temporada.FechaFin = nuevaFechaFin;

            _IDeTemporadaRepository.ModificarDeTemporada(temporada);
        }

        // ================================================================
        // DELETE
        // ================================================================
        public void eliminarDeTemporada(int idTemporada)
        {
            DeTemporadaEN temporada = _IDeTemporadaRepository.ReadOIDDefault(idTemporada);
            if (temporada == null)
                throw new ModelException("No existe la temporada");

            _IDeTemporadaRepository.EliminarDeTemporada(idTemporada);
        }
    }
}

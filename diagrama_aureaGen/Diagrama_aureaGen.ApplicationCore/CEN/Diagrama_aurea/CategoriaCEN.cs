using System;
using System.Collections.Generic;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.Exceptions;

namespace Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea
{
    /*
     * Clase CategoriaCEN
     * Implementa las operaciones CRUD: crear, consultar, modificar, eliminar.
     */
    public partial class CategoriaCEN
    {
        private ICategoriaRepository _ICategoriaRepository;

        public CategoriaCEN(ICategoriaRepository repo)
        {
            this._ICategoriaRepository = repo;
        }

        public ICategoriaRepository get_ICategoriaRepository()
        {
            return this._ICategoriaRepository;
        }

        // ================================================================
        // CREATE
        // ================================================================
        public int crearCategoria(int idCategoria, string nombreCategoria, string descripcion)
        {
            CategoriaEN categoriaEN = new CategoriaEN();
            categoriaEN.IdCategoria = idCategoria;
            categoriaEN.NombreCategoria = nombreCategoria;
            categoriaEN.Descripcion = descripcion;

            int oid = _ICategoriaRepository.CrearCategoria(categoriaEN);
            return oid;
        }

        // ================================================================
        // READ (consultar uno)
        // ================================================================
        public CategoriaEN consultarCategoria(int idCategoria)
        {
            return _ICategoriaRepository.ReadOIDDefault(idCategoria);
        }

        // ================================================================
        // READ (consultar todos)
        // ================================================================
        public IList<CategoriaEN> consultarCategoriaTodos(int first, int size)
        {
            return _ICategoriaRepository.ReadAllDefault(first, size);
        }

        // ================================================================
        // UPDATE
        // ================================================================
        public void modificarCategoria(int idCategoria, string nuevoNombre, string nuevaDescripcion)
        {
            CategoriaEN categoria = _ICategoriaRepository.ReadOIDDefault(idCategoria);
            if (categoria == null)
                throw new ModelException("Categoría no encontrada");

            categoria.NombreCategoria = nuevoNombre;
            categoria.Descripcion = nuevaDescripcion;

            _ICategoriaRepository.ModificarCategoria(categoria);
        }

        // ================================================================
        // DELETE
        // ================================================================
        public void eliminarCategoria(int idCategoria)
        {
            CategoriaEN categoria = _ICategoriaRepository.ReadOIDDefault(idCategoria);
            if (categoria == null)
                throw new ModelException("No existe la categoría");

            _ICategoriaRepository.EliminarCategoria(idCategoria);
        }
    }
}

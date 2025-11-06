using System;
using System.Collections.Generic;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.Exceptions;

namespace Diagrama_aureaGen.ApplicationCore.CEN.Diagrama_aurea
{
    /*
     * Clase FavoritoCEN
     * Implementa las operaciones CRUD: crear, consultar, modificar, eliminar.
     */
    public partial class FavoritoCEN
    {
        private IFavoritoRepository _IFavoritoRepository;

        public FavoritoCEN(IFavoritoRepository repo)
        {
            this._IFavoritoRepository = repo;
        }

        public IFavoritoRepository get_IFavoritoRepository()
        {
            return this._IFavoritoRepository;
        }

        // ================================================================
        // CREATE
        // ================================================================
        public int crearFavorito(int idFavorito, int idUsuario = -1)
        {
            FavoritoEN favorito = new FavoritoEN();
            favorito.IdFavorito = idFavorito;

            // Relación con Usuario (opcional)
            if (idUsuario != -1)
            {
                favorito.Usuario = new UsuarioEN();
                favorito.Usuario.IdUsuario = idUsuario;
            }

            int oid = _IFavoritoRepository.CrearFavorito(favorito);
            return oid;
        }

        // ================================================================
        // READ (consultar uno)
        // ================================================================
        public FavoritoEN consultarFavorito(int idFavorito)
        {
            return _IFavoritoRepository.ReadOIDDefault(idFavorito);
        }

        // ================================================================
        // READ (consultar todos)
        // ================================================================
        public IList<FavoritoEN> consultarFavoritoTodos(int first, int size)
        {
            return _IFavoritoRepository.ReadAllDefault(first, size);
        }

        // ================================================================
        // UPDATE
        // ================================================================
        public void modificarFavorito(int idFavorito, int nuevoUsuario = -1)
        {
            FavoritoEN favorito = _IFavoritoRepository.ReadOIDDefault(idFavorito);
            if (favorito == null)
                throw new ModelException("Favorito no encontrado");

            if (nuevoUsuario != -1)
            {
                favorito.Usuario = new UsuarioEN();
                favorito.Usuario.IdUsuario = nuevoUsuario;
            }

            _IFavoritoRepository.ModificarFavorito(favorito);
        }

        // ================================================================
        // DELETE
        // ================================================================
        public void eliminarFavorito(int idFavorito)
        {
            FavoritoEN favorito = _IFavoritoRepository.ReadOIDDefault(idFavorito);
            if (favorito == null)
                throw new ModelException("No existe el favorito");

            _IFavoritoRepository.EliminarFavorito(idFavorito);
        }
    }
}

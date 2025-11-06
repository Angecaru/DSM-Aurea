using System;
using Diagrama_aureaGen.ApplicationCore.EN.Diagrama_aurea;
using Diagrama_aureaGen.ApplicationCore.CP.Diagrama_aurea;

namespace Diagrama_aureaGen.ApplicationCore.IRepository.Diagrama_aurea
{
    public partial interface IFavoritoRepository
    {
        void setSessionCP(GenericSessionCP session);

        FavoritoEN ReadOIDDefault(int idFavorito);

        void ModifyDefault(FavoritoEN favorito);

        System.Collections.Generic.IList<FavoritoEN> ReadAllDefault(int first, int size);

        int CrearFavorito(FavoritoEN favorito);

        System.Collections.Generic.IList<FavoritoEN> ConsultarFavorito(int first, int size);

        void ModificarFavorito(FavoritoEN favorito);   // ← NUEVA LÍNEA

        void EliminarFavorito(int idFavorito);
    }
}

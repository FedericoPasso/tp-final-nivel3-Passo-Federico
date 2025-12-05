using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FavoritoDatos
    {
        public int InsertarNuevo(Favorito fav)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO FAVORITOS (IdUser, IdArticulo) OUTPUT INSERTED.Id VALUES (@IdUser, @IdArticulo)");
                datos.setearParametro("@IdUser", fav.idUser);
                datos.setearParametro("@IdArticulo", fav.idArticulo);

                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Favorito> Listar(int idUser)
        {
            List<Favorito> lista = new List<Favorito>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, IdUser, IdArticulo FROM FAVORITOS WHERE IdUser = @IdUser");
                datos.setearParametro("@IdUser", idUser);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Favorito fav = new Favorito
                    {
                        Id = (int)datos.Lector["Id"],
                        idUser = (int)datos.Lector["IdUser"],
                        idArticulo = (int)datos.Lector["IdArticulo"]
                    };
                    lista.Add(fav);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void EliminarFav(Favorito fav)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM FAVORITOS WHERE IdUser = @IdUser AND IdArticulo = @IdArticulo");
                datos.setearParametro("@IdUser", fav.idUser);
                datos.setearParametro("@IdArticulo", fav.idArticulo);

                datos.ejecutarAccion(); // No se espera un valor de retorno para un DELETE
            }
            catch (Exception ex)
            {
                // Manejo de errores detallado
                throw new ApplicationException("Error al eliminar favorito.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }




        public bool ExisteFavorito(int idUser, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM FAVORITOS WHERE IdUser = @IdUser AND IdArticulo = @IdArticulo");
                datos.setearParametro("@IdArticulo", idArticulo);
                datos.setearParametro("@IdUser", idUser);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int count = (int)datos.Lector[0];
                    return count > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}

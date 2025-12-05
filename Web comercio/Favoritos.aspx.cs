using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_comercio
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> ListaFavoritos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (Seguridad.SesionActiva(Session["usuario"]))
                {
                    FavoritoDatos favorito = new FavoritoDatos();
                    Usuario user = new Usuario();
                    user = (Usuario)Session["usuario"];

                    var favoritos = favorito.Listar(user.Id);
                    ArticuloDatos datos = new ArticuloDatos();
                    ListaFavoritos = new List<Articulo>();

                    foreach (var fav in favoritos)
                    {
                        Articulo art = datos.listarConId(fav.idArticulo);
                        if (art != null)
                        {
                            ListaFavoritos.Add(art);
                        }
                    }
                    repFavoritos.DataSource = ListaFavoritos;
                    repFavoritos.DataBind();
                }
                else
                {
                    Response.Redirect("Login.aspx", false);
                }
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                Usuario user = (Usuario)Session["usuario"];
                FavoritoDatos favorito = new FavoritoDatos();

                Button btn = (Button)sender; //obtener que el boton fue clickeado
                string artIdString = btn.CommandArgument; // Obtener el ID del artículo desde el CommandArgument del botón


                if (int.TryParse(artIdString, out int idArticulo))
                {
                    Favorito fav = new Favorito
                    {
                        idUser = user.Id,
                        idArticulo = idArticulo
                    };
                    favorito.EliminarFav(fav);
                    Response.Redirect("Favoritos.aspx", false);
                }
                else
                {
                    throw new ApplicationException("ID del articulo no válido.");
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}
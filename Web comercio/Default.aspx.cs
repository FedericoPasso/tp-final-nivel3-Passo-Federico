using Dominio;
using Negocio;
using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_comercio
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloDatos datos = new ArticuloDatos();
            ListaArticulo = datos.listar();
            try
            {

                if (!IsPostBack)
                {
                    
                    repRepetidor.DataSource = ListaArticulo;
                    repRepetidor.DataBind();
                }
                
            }
            catch (Exception ex) 
            {
                ManejoError error = new ManejoError();
                Session.Add("Error", error.MensajeError(ex));
                Response.Redirect("Error.aspx", false);
                
            }
        }

       

        protected void btnFavoritos_Click1(object sender, EventArgs e)
        {
            try
            {

            
                Usuario user = (Usuario)Session["usuario"];
                if (user == null)
                {
                    // Manejar el caso donde el usuario no está autenticado
                    Session.Add("error", "Debes loguearte para agregar favoritos.");
                    Response.Redirect("Login.aspx", false);
                }

                FavoritoDatos favoritoNegocio = new FavoritoDatos();
                Favorito fav = new Favorito();

                fav.idUser = user.Id;
                int idArticulo;
                string artId = ((Button)sender).CommandArgument;

                if (int.TryParse(artId, out idArticulo))
                {

                    fav.idArticulo = idArticulo;


                    // Verificar si el artículo ya está en favoritos
                    bool selecFavoritos = favoritoNegocio.ExisteFavorito(fav.idUser, fav.idArticulo);

                    if (selecFavoritos)
                    {
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Este producto ya está en tu lista de favoritos.');", true);
                        //return;
                        string script = @"
                                var alerta = document.getElementById('alerta');
                                alerta.style.display = 'block';
                                alerta.style.opacity = '1';
                                setTimeout(function() {
                                alerta.style.opacity = '0';
                                setTimeout(function() {
                                alerta.style.display = 'none';
                                 }, 600); // Tiempo para que la alerta desaparezca
                                 }, 3000); // Tiempo que la alerta está visible";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "mostrarAlerta", script, true);
                        return;

                    }
                    else
                    {
                        // Si no está en favoritos, lo agrega
                        int idFavorito = favoritoNegocio.InsertarNuevo(fav);
                        fav.Id = idFavorito;

                        //// Opcional: Cambiar el color del corazón
                        //((Button)sender).CssClass = "btn btn-danger"; // Cambia el color del botón al rojo

                        Response.Redirect("Favoritos.aspx", false);

                    }

                }

                else
                {
                    // Manejar el caso donde CommandArgument no es un entero válido
                    // Mostrar mensaje de error o redirigir a una página de error
                    Session.Add("error", "El CommandArgument no es un número válido.");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones específicas de manera más detallada si es necesario
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}
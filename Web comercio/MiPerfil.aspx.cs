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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.SesionActiva(Session["usuario"]))
                    {
                        Usuario user = (Usuario)Session["usuario"];
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        if (!string.IsNullOrEmpty(user.UrlImagenPerfil))
                            imgAvatar.ImageUrl = "~/Imagenes/Perfil/" + user.UrlImagenPerfil;


                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                Usuario user = (Usuario)Session["usuario"];
                UsuarioDatos negocio = new UsuarioDatos();

                //Escribir img si se cargó algo
                if (txtImagen.PostedFile.FileName != "")
                {   //para que funciones en local tiene que ser ./Imagenes/Perfil/    
                    string ruta = Server.MapPath("~/Imagenes/Perfil/"); //capturo la ruta donde guardare las imagenes
                    txtImagen.PostedFile.SaveAs(ruta + "Perfil-" + user.Id + ".jpg"); //en la ruta guardamos la imagen seleccionada con el id
                    user.UrlImagenPerfil = "Perfil-" + user.Id + ".jpg";
                }

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.Email = txtEmail.Text;
                
                negocio.Actualizar(user);
                
                Response.Redirect("MiPerfil.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}
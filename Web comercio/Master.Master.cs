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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgAvatar.ImageUrl = "https://simg.nicepng.com/png/small/202-2022264_usuario-annimo-usuario-annimo-user-icon-png-transparent.png";
            if (!(Page is Login || Page is Registro || Page is Default || Page is Error || Page is DetalleArticulo))
            {
                if (!Seguridad.SesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
                else
                {
                    Usuario user = (Usuario)Session["usuario"];
                    lblUser.Text = user.Email;
                    if (!string.IsNullOrEmpty(user.UrlImagenPerfil))
                        imgAvatar.ImageUrl = "~/Images/" + user.UrlImagenPerfil;
                }
            }
        }

       

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}
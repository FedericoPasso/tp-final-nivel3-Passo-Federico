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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                {
                    return;
                }
                Usuario user = new Usuario();
                UsuarioDatos datos = new UsuarioDatos();
                user.Email = txtEmail.Text;
                user.Pass = txtPass.Text;
                if (datos.validarUser(user.Email))
                {
                    lbError.Text = "El email ya se encuentra registrado.";
                    lbError.Visible = true;
                }
                else
                {
                    user.Id = datos.InsertarNuevo(user);
                    Session.Add("usuario", user); //Mantiene la sesion abierta para navegar por la web
                    Response.Redirect("Default.aspx", false);
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
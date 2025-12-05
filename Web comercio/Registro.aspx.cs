using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

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
                    return; //con esto valida las expresiones que le pido que cumpla para registrarse,
                            //sino estuviera pasaria de largo sin validar

                Usuario user = new Usuario();
                UsuarioDatos negocio = new UsuarioDatos();
                user.Email = txtEmail.Text;
                user.Pass = txtPass.Text;
                if (negocio.validarUser(user.Email))
                {
                    lbError.Text = "El email ya está registrado.";
                    lbError.Visible = true;
                }
                else
                {
                    user.Id = negocio.InsertarNuevo(user);
                    Session.Add("usuario", user); // Mantener la sesión abierta, para ir de página en página
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
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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (Session["email"] != null) 
                {
                    txtEmail.Text = Session["email"].ToString();
                }
            }

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioDatos datos = new UsuarioDatos();

            try
            {
                if (Validacion.validaTextoVacio(txtEmail) || Validacion.validaTextoVacio(txtPass))
                {
                    Session.Add("error", "Debes completar ambos campos...");
                    Response.Redirect("Error.aspx");
                }
                usuario.Email = txtEmail.Text;
                usuario.Pass = txtPass.Text;

                if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPass.Text))
                {
                    if (!string.IsNullOrEmpty(txtEmail.Text))
                    {
                        Session["email"] = txtEmail.Text;
                    }
                    Session.Add("error", "Debes completar ambos campos");
                    Response.Redirect("Error.aspx");
                }
                if (datos.Login(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("MiPerfil.aspx");
                }
                else
                {
                    Session["email"] = txtEmail.Text;
                    Session.Add("error", "User o pass incorrectos");
                    Response.Redirect("Error.aspx");
                }
            }
            catch (System.Threading.ThreadAbortException){ }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}
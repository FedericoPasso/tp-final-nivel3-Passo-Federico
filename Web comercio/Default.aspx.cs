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

        protected void btnFavoritos_Click(object sender, EventArgs e)
        {

        }
    }
}
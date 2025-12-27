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
    public partial class Default1 : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloDatos datos = new ArticuloDatos();
            listaArticulos = datos.listar();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = listaArticulos;
                repRepetidor.DataBind();
            }

        }

       
    }
}
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
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["id"]);
                ArticuloDatos datos = new ArticuloDatos();
                Articulo aux = datos.listarConId(id);
                if (aux != null)
                {
                    txtCodigo.Text = aux.CodArticulo;
                    txtNombre.Text = aux.Nombre;
                    txtDescripcion.Text = aux.Descripcion;
                    txtMarca.Text = aux.Marca != null ? aux.Marca.ToString() : string.Empty;
                    txtCategoria.Text = aux.Categoria != null ? aux.Categoria.ToString() : string.Empty;
                    txtPrecio.Text = aux.Precio.ToString("c");
                    txtImagen.ImageUrl = aux.UrlImagen;
                }
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
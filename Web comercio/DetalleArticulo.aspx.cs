using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace Web_comercio
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Articulo> ListaArticulos = new List<Articulo>();
            if (Request.QueryString["Id"] != null)
            {
                int elegido = int.Parse(Request.QueryString["Id"].ToString());
                ArticuloDatos datos = new ArticuloDatos();
                ListaArticulos = datos.listar();
                Articulo seleccionado = ListaArticulos.Find(x => x.Id == elegido);
                imgFoto.ImageUrl = seleccionado.UrlImagen.ToString();
                if (imgFoto.ImageUrl == "") imgFoto.ImageUrl = "https://img.freepik.com/vector-premium/icono-marco-fotos-foto-vacia-blanco-vector-sobre-fondo-transparente-aislado-eps-10_399089-1290.jpg?w=740";
                lblCategoria.Text = "Categoría: " + seleccionado.categoria.ToString();
                lblMarca.Text = "Marca: " + seleccionado.marca.ToString();
                lblCodigo.Text = "Código " + seleccionado.CodArticulo;
                LblTitulo.Text = seleccionado.Nombre;
                LblDescripcion.Text = "Descripción: " + seleccionado.Descripcion;
                lblPrecio.Text = "Precio: " + seleccionado.Precio.ToString("C");

            }
            else
            {
                Session.Add("Error", "No hay ningún articulo seleccionado");
                Response.Redirect("Error.aspx", false);
            }
            
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            if (Session["paginaAnterior"] == null) 
            {
                Response.Redirect("Default.aspx", false);
            }
            else
            {
                Response.Redirect(Session["paginaAnterior"].ToString(), false);
            }
        }
    }
}
using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_comercio
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
       public bool ConfirmarEliminacion {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmarEliminacion = false;
            try
            {
                //Configuración inicial de la pantalla
                if (!IsPostBack)
                {
                    Categoriadatos categogiraDatos = new Categoriadatos();
                    MarcaDatos marcaDatos = new MarcaDatos();

                    List<Marca> listaMarcas = marcaDatos.listar();
                    List<Categoria> listaCategorias = categogiraDatos.listar();

                    ddlMarca.DataSource = listaMarcas;
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();

                    btnEliminar.Visible = false; //No se necesita si es está dando de alta un articulo
                }

                //Configuracion si estamos modificando
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ArticuloDatos datos = new ArticuloDatos();
                    Articulo seleccionado = (datos.listar(id))[0];

                    //Guardo el articulo seleccionado en sesión
                    Session.Add("ArticuloSeleccionado", seleccionado);

                    //Pre cargar todos los campos
                    txtId.Text = id;
                    txtCodArticulo.Text = seleccionado.CodArticulo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtImagenUrl.Text = seleccionado.UrlImagen;

                    ddlMarca.SelectedValue = seleccionado.marca.id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.categoria.id.ToString();
                    txtImagenUrl_TextChanged(sender, e);

                    btnEliminar.Visible = true;
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            try
            {
                if (string.IsNullOrEmpty(txtCodArticulo.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtPrecio.Text))
                {
                    Session.Add("Error", "faltan campos por completar");
                    Response.Redirect("Error.aspx", false);               
                }
                
                Articulo nuevo = new Articulo();
                ArticuloDatos datos = new ArticuloDatos();

                nuevo.CodArticulo = txtCodArticulo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;

                string precioTexto = txtPrecio.Text.Replace(",", ".");
                if (decimal.TryParse(precioTexto, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal precio))
                { nuevo.Precio = precio; }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El campo Precio debe contener solo números');", true);
                    return;
                }
                
                nuevo.UrlImagen = txtImagenUrl.Text;
                
                nuevo.marca = new Marca();
                nuevo.categoria = new Categoria();
                nuevo.marca.id = int.Parse(ddlMarca.SelectedValue);
                nuevo.categoria.id = int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    datos.modificar(nuevo);
                }
                else
                {
                    datos.agregar(nuevo);
                }
                List<Articulo> lista = datos.listar();
                Session["listaArticulo"] = lista;

                Response.Redirect("ListaArticulos.aspx" , false);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    ArticuloDatos datos = new ArticuloDatos();
                    datos.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ListaArticulos.aspx", false);
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
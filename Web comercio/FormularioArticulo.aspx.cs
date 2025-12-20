using Dominio;
using Negocio;
using System;
using System.CodeDom;
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
        public bool ConfirmaEliminacion { get;set;}
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;
            try
            {
                //configuracion inicial de la pantalla
                if (!IsPostBack)
                {
                    Categoriadatos catDatos = new Categoriadatos();
                    MarcaDatos mardatos = new MarcaDatos();

                    List<Marca> listaMarcas = mardatos.listar();
                    List<Categoria> listaCategorias = catDatos.listar();

                    ddlMarca.DataSource = listaMarcas;
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = listaCategorias;
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();

                    btnEliminar.Visible = false; //ocultar si se está dando de alta un articulo
                }

                //configuración si estamos modificando.
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {


                    ArticuloDatos negocio = new ArticuloDatos();

                    Articulo seleccionado = (negocio.listar(id))[0];

                    //guardo articulo seleccionado en session
                    Session.Add("ArticuloSeleccionado", seleccionado);

                    //pre cargar todos los campos...
                    txtId.Text = id;
                    txtCodArticulo.Text = seleccionado.CodArticulo;
                    txtNombre.Text = seleccionado.Nombre;

                    txtPrecio.Text = seleccionado.Precio.ToString();

                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtImagenUrl.Text = seleccionado.UrlImagen;

                    ddlMarca.SelectedValue = seleccionado.marca.Id.ToString();
                    ddlCategoria.SelectedValue = seleccionado.categoria.Id.ToString();
                    txtImagenUrl_TextChanged(sender, e);

                    btnEliminar.Visible = true;

                }



            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
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
                    Session.Add("Error", "Faltan campos por completar");
                    Response.Redirect("Error.aspx", false);
                }
                Articulo nuevo = new Articulo();
                ArticuloDatos negocio = new ArticuloDatos();

                nuevo.CodArticulo = txtCodArticulo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;

                string precioTexto = txtPrecio.Text.Replace(",", ".");
                if (decimal.TryParse(precioTexto, System.Globalization.NumberStyles.Number, CultureInfo.InvariantCulture, out decimal precio))
                {
                    nuevo.Precio = precio;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El campo Precio debe contener solo números');", true);
                    return;
                }

                nuevo.UrlImagen = txtImagenUrl.Text;

                nuevo.marca = new Marca();
                nuevo.marca.Id = int.Parse(ddlMarca.SelectedValue);
                nuevo.categoria = new Categoria();
                nuevo.categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificar(nuevo);
                }
                else
                {
                    negocio.agregar(nuevo);
                }
                List<Articulo> lista = negocio.listar();
                Session["listaArticulo"] = lista;

                Response.Redirect("ListaArticulos.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
            
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    ArticuloDatos negocio = new ArticuloDatos();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ListaArticulos.aspx", false);
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);

            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }

    }
}
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
    public partial class ListaArticulos : System.Web.UI.Page
    {
        public bool FiltroAvanzado
        {
            get { return chkAvanzado.Checked; } 
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.EsAdmin(Session["usuario"]))
            {
                Session.Add("error", "Se requiere permisos de administrador para acceder a esta pantalla.");
                Response.Redirect("Error.aspx");
            }
            if (!IsPostBack) 
            {
                ArticuloDatos datos = new ArticuloDatos();
                Session.Add("listaArticulo", datos.listar());
                dgvArticulos.DataSource = Session["listaArticulo"];
                dgvArticulos.DataBind();
            }
            pnlFiltroAvanzado.Visible = FiltroAvanzado;
        }
        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataSource = Session["listaArticulo"];
            dgvArticulos.DataBind();
            
        }
        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id= " + id);
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            pnlFiltroAvanzado.Visible = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }
        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listaArticulo"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();
        }


        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Categoriadatos categoria = new Categoriadatos();
            MarcaDatos marca = new MarcaDatos();

            List<Marca> listaMarcas = marca.listar();
            List<Categoria> listaCategorias = categoria.listar();


            ddlCriterio.Items.Clear();
            txtFiltroAvanzado.Text = string.Empty;


            string campoSeleccionado = ddlCampo.SelectedItem.ToString();

            switch (campoSeleccionado)
            {

                case "Precio":
                    ddlCriterio.Items.Add("Mayor a");
                    ddlCriterio.Items.Add("Menor a");
                    ddlCriterio.Items.Add("Igual a");
                    txtFiltroAvanzado.Enabled = true;
                    break;

                case "Nombre":
                    ddlCriterio.Items.Add("Contiene");
                    ddlCriterio.Items.Add("Empieza con");
                    ddlCriterio.Items.Add("Termina con");
                    txtFiltroAvanzado.Enabled = true;
                    break;

                case "Marca":
                    ddlCriterio.DataSource = listaMarcas;
                    ddlCriterio.DataTextField = "Descripcion";
                    ddlCriterio.DataValueField = "Id";
                    ddlCriterio.DataBind();
                    txtFiltroAvanzado.Enabled = false;

                    if (ddlCriterio.Items.Count > 0)
                    {
                        txtFiltroAvanzado.Text = ddlCriterio.SelectedValue;
                    }

                    break;

                case "Categoria":
                    ddlCriterio.DataSource = listaCategorias;
                    ddlCriterio.DataTextField = "Descripcion";
                    ddlCriterio.DataValueField = "Id";
                    ddlCriterio.DataBind();
                    txtFiltroAvanzado.Enabled = false;

                    if (ddlCriterio.Items.Count > 0)
                    {
                        txtFiltroAvanzado.Text = ddlCriterio.SelectedValue;
                    }
                    break;


            }
        }
        protected void ddlCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            //controlo el AutoPostBack para que me traiga solo el id en Marca y Categoria. para que sea dinámico
            string selectedValue = ddlCampo.SelectedItem.ToString();

            if (selectedValue == "Marca" || selectedValue == "Categoria")
            {
                txtFiltroAvanzado.Text = ddlCriterio.SelectedValue;
            }
            else
            {
                txtFiltroAvanzado.Text = string.Empty;
            }

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Validar que los campos ddlCampo, ddlCriterio y txtFiltroAvanzado que no estén vacíos
            if (string.IsNullOrEmpty(ddlCampo.SelectedValue) ||
                string.IsNullOrEmpty(ddlCriterio.SelectedValue) ||
                string.IsNullOrEmpty(txtFiltroAvanzado.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Llenar todos los campos');", true);
                return;
            }

            // Campo Precio: Lea solo números y validar que el separador decimal sea un punto
            if (ddlCampo.SelectedItem.Text == "Precio")
            {
                // Reemplazar coma con punto
                txtFiltroAvanzado.Text = txtFiltroAvanzado.Text.Replace(",", ".");

                decimal filtroNumerico;
                if (!decimal.TryParse(txtFiltroAvanzado.Text, out filtroNumerico))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('El campo Precio debe contener solo números.');", true);
                    return;
                }
            }
            try
            {
                ArticuloDatos datos = new ArticuloDatos();
                dgvArticulos.DataSource = datos.filtrar(
                    ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltroAvanzado.Text);
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            ArticuloDatos negocio = new ArticuloDatos();
            try
            {
                txtFiltro.Text = string.Empty;
                ddlCampo.ClearSelection();
                ddlCriterio.Items.Clear();// Limpiar los criterios del DropDownList              
                txtFiltroAvanzado.Text = string.Empty;// Limpiar el texto del filtro avanzado
                dgvArticulos.DataSource = negocio.listar();
                dgvArticulos.DataBind();

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }





    }
}
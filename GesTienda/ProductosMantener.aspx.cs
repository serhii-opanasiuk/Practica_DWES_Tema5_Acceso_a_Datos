using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace GesTienda
{
    public partial class ProductosMantener : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void FnDeshabilitarControles()
        {
            txtIdProducto.Enabled = false;
            txtDesPro.Enabled = false;
            txtPrePro.Enabled = false;
            ddlIdUnidad.Enabled = false;
            ddlIdTipo.Enabled = false;
        }
        protected string FnComaPorPunto(decimal Numero)
        {
            string StrNumero = Convert.ToString(Numero);
            string stNumeroConPunto = String.Format("{0}", StrNumero.Replace(',', '.'));
            return (stNumeroConPunto);
        }
        protected void FnHabilitarControles()
        {
            txtIdProducto.Enabled = true;
            txtDesPro.Enabled = true;
            txtPrePro.Enabled = true;
            ddlIdUnidad.Enabled = true;
            ddlIdTipo.Enabled = true;
        }
        protected void grdProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            FnDeshabilitarControles();
            string StrIdProducto = grdProductos.SelectedRow.Cells[1].Text;
            string StrCadenaConexion =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string StrComandoSql = "SELECT IdProducto,DesPro,PrePro,IdUnidad,PRODUCTO.IdTipo,DesTip " +
            " FROM PRODUCTO INNER JOIN TIPO ON PRODUCTO.IdTipo = TIPO.IdTipo " +
            "WHERE PRODUCTO.IdProducto = '" + StrIdProducto + "';";
            using (SqlConnection conexion = new SqlConnection(StrCadenaConexion))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = conexion.CreateCommand();
                    comando.CommandText = StrComandoSql;
                    SqlDataReader reader = comando.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        txtIdProducto.Text = reader.GetString(0);
                        txtDesPro.Text = reader.GetString(1);
                        txtPrePro.Text = string.Format("{0:C}", reader.GetDecimal(2));
                        ddlIdUnidad.SelectedItem.Selected = false;
                        ddlIdUnidad.SelectedItem.Text = reader.GetString(3);
                        ddlIdTipo.SelectedItem.Selected = false;
                        ddlIdTipo.SelectedItem.Text = reader.GetString(5);
                    }
                    else
                    {
                        lblMensajes.Text = "No existen registros resultantes de la consulta";
                    }
                    reader.Close();
                    btnNuevo.Visible = true;
                    btnEditar.Visible = true;
                    btnEliminar.Visible = true;
                    btnInsertar.Visible = false;
                    btnModificar.Visible = false;
                    btnBorrar.Visible = false;
                    btnCancelar.Visible = false;
                }
                catch (SqlException ex)
                {
                    string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
                    StrError = StrError + "<div>Código: " + ex.Number + "</div>";
                    StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
                    lblMensajes.Text = StrError;
                    return;
                }
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnInsertar.Visible = true;
            btnModificar.Visible = false;
            btnBorrar.Visible = false;
            btnCancelar.Visible = true;
            txtIdProducto.Text = "";
            txtDesPro.Text = "";
            txtPrePro.Text = Convert.ToString(0);
            ddlIdUnidad.DataBind(); // Vuelve a enlazar el control para que se actualicen los datos
            ddlIdTipo.DataBind();
            grdProductos.SelectedIndex = -1;
            FnHabilitarControles();
            txtIdProducto.Focus();
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            String strIdProducto, strDescripcion, strIdUnidad, strIdTipo;
            Decimal dcPrecio;
            strIdProducto = txtIdProducto.Text;
            strDescripcion = txtDesPro.Text;
            dcPrecio = Convert.ToDecimal(txtPrePro.Text);
            strIdUnidad = ddlIdUnidad.SelectedItem.Text;
            strIdTipo = ddlIdTipo.SelectedItem.Value;
            string StrCadenaConexion =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string StrComandoSql = "INSERT PRODUCTO " +
            "(IdProducto,DesPro,PrePro,IdUnidad,IdTipo) VALUES (" +
            "'" + strIdProducto + "','" + strDescripcion +
            "'," + FnComaPorPunto(dcPrecio) +
            ",'" + strIdUnidad + "','" + strIdTipo + "');";
            using (SqlConnection conexion = new SqlConnection(StrCadenaConexion))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = conexion.CreateCommand();
                    comando.CommandText = StrComandoSql;
                    int inRegistrosAfectados = comando.ExecuteNonQuery();
                    if (inRegistrosAfectados == 1)
                        lblMensajes.Text = "Registro insertado correctamente";
                    else
                        lblMensajes.Text = "Error al insertar el registro";
                    btnNuevo.Visible = true;
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                    btnInsertar.Visible = false;
                    btnModificar.Visible = false;
                    btnBorrar.Visible = false;
                    btnCancelar.Visible = false;
                }
                catch (SqlException ex)
                {
                    string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
                    StrError = StrError + "<div>Código: " + ex.Number + "</div>";
                    StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
                    lblMensajes.Text = StrError;
                    return;
                }
            }
            grdProductos.DataBind(); // Vuelve a enlazar el GridView para que se actualicen los datos
            grdProductos.SelectedIndex = -1;
            FnDeshabilitarControles();
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblMensajes.Text = "";
            btnNuevo.Visible = true;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnInsertar.Visible = false;
            btnModificar.Visible = false;
            btnBorrar.Visible = false;
            btnCancelar.Visible = false;
            txtIdProducto.Text = "";
            txtDesPro.Text = "";
            txtPrePro.Text = Convert.ToString(0);
            ddlIdUnidad.DataBind();
            ddlIdTipo.DataBind();
            grdProductos.SelectedIndex = -1;
            FnDeshabilitarControles();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            /* 
            Desarrollar el código lógico para editar los valores de los campos de la fila seleccionada en el
            control GridView y actualizar los valores de la fila correspondiente en la tabla PRODUCTO. Para
            ello, al hacer clic en el control btnEditar se deberán habilitar los controles que contienen los
            valores de los campos, excepto el control txtIdProducto y también, se deberán hacer visibles
            los controles btnModificar y btnCancelar. El código lógico necesario para ejecutar la sentencia
            de SQL de tipo UPDATE se incluirá en el evento Click del control btnModificar.
             */
            ///habilitar los controles que contienen los valores de los campos,
            ///excepto el control txtIdProducto
            FnHabilitarControles();
            txtIdProducto.Enabled = false;
            ///se deberán hacer visibles los controles btnModificar y btnCancelar
            btnModificar.Visible = true;
            btnCancelar.Visible = true;
            ///ocultar los botones Editar y Eliminar
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnNuevo.Visible = false;
            /// Esta parte de código resuelve un error, que en los ambos objetos DropDownList
            /// el primer elemento es un texto con el valor correspondiente, y este texto cambia
            /// el primer elemento del DropDownList, y por eso en la lista no hay el primer valor, 
            /// pero el valor corriente esta duplicado. Este error está creado por el manejador de evento
            /// grdProductos_SelectedIndexChanged: 
            /*
                ddlIdUnidad.SelectedItem.Selected = false;
                ddlIdUnidad.SelectedItem.Text = reader.GetString(3);
                ddlIdTipo.SelectedItem.Selected = false;
                ddlIdTipo.SelectedItem.Text = reader.GetString(5);
            */
            /// Para corregir este error, actualizamos los ambos objetos DropDownList
            /// y les habilitamos (Selected = true)
            String valorDropDownList;
            ListItem itemSelected;
            //ddlIdTipo:
            valorDropDownList = ddlIdTipo.SelectedItem.Text;
            ddlIdTipo.DataBind(); //actualizamos el DropDownList ddlIdTipo
            itemSelected = ddlIdTipo.Items.FindByText(valorDropDownList); //encontramos un elemento por su valor
            if (itemSelected != null)
                itemSelected.Selected = true; //habilitamos un elemento
            //ddlIdUnidad:
            valorDropDownList = ddlIdUnidad.SelectedItem.Text;
            ddlIdUnidad.DataBind(); //actualizamos el DropDownList ddlIdUnidad
            itemSelected = ddlIdUnidad.Items.FindByText(valorDropDownList); //encontramos un elemento por su valor
            if (itemSelected != null)
                itemSelected.Selected = true; //habilitamos un elemento
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ///Código lógico
            lblMensajes.Text = "";
            String strIdProducto, strDescripcion, strIdUnidad, strIdTipo;
            Decimal dcPrecio;
            strIdProducto = txtIdProducto.Text;
            strDescripcion = txtDesPro.Text;
            if (txtPrePro.Text.Contains(" €"))
                dcPrecio = Convert.ToDecimal(txtPrePro.Text.Substring(0, txtPrePro.Text.Length - 2));
            else
                dcPrecio = Convert.ToDecimal(txtPrePro.Text);
            strIdUnidad = ddlIdUnidad.SelectedItem.Text;
            strIdTipo = ddlIdTipo.SelectedItem.Value;
            string StrCadenaConexion =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string StrComandoSql = "UPDATE PRODUCTO \n" +
            "SET DesPro = '" + strDescripcion.Trim() + "', " +
            "PrePro = " + FnComaPorPunto(dcPrecio) + ", " +
            "IdUnidad = '" + strIdUnidad.Trim() + "', " +
            "IdTipo = '" + strIdTipo.Trim() + "'\n" +
            "WHERE IdProducto = '" + strIdProducto.Trim() + "'";
            using (SqlConnection conexion = new SqlConnection(StrCadenaConexion))
            {
                try
                {
                    conexion.Open();
                    SqlCommand comando = conexion.CreateCommand();
                    comando.CommandText = StrComandoSql;
                    int inRegistrosAfectados = comando.ExecuteNonQuery();
                    if (inRegistrosAfectados == 1)
                        lblMensajes.Text = "Registro modificado correctamente";
                    else
                        lblMensajes.Text = "Error al modificar el registro";

                }
                catch (SqlException ex)
                {
                    string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
                    StrError = StrError + "<div>Código: " + ex.Number + "</div>";
                    StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
                    
                    lblMensajes.Text = StrError;
                    return;
                }
            }
            grdProductos.DataBind(); // Vuelve a enlazar el GridView para que se actualicen los datos
            grdProductos.SelectedIndex = -1;
            FnDeshabilitarControles();
            ddlIdTipo.DataBind();
            ddlIdUnidad.DataBind();
            ///limpiamos los campos
            txtDesPro.Text = "";
            txtIdProducto.Text = "";
            txtPrePro.Text = "";
            // Ordenamos los botones
            btnNuevo.Visible = true;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnInsertar.Visible = false;
            btnModificar.Visible = false;
            btnBorrar.Visible = false;
            btnCancelar.Visible = false;
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            btnNuevo.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnBorrar.Visible = true;
            btnCancelar.Visible = true;            
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Pulse el botón 'OK' para eliminar el producto", "Eliminar" +
                    " producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                lblMensajes.Text = "";
                String strIdProducto;
                strIdProducto = txtIdProducto.Text;
                string StrCadenaConexion =
                ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                string StrComandoSql = "DELETE FROM PRODUCTO \n" +
                "WHERE IdProducto = '" + strIdProducto.Trim() + "'";
                using (SqlConnection conexion = new SqlConnection(StrCadenaConexion))
                {
                    try
                    {
                        conexion.Open();
                        SqlCommand comando = conexion.CreateCommand();
                        comando.CommandText = StrComandoSql;
                        int inRegistrosAfectados = comando.ExecuteNonQuery();
                        if (inRegistrosAfectados == 1)
                            lblMensajes.Text = "Registro eliminado correctamente";
                        else
                            lblMensajes.Text = "Error al eliminar el registro";
                        btnNuevo.Visible = true;
                        btnEditar.Visible = false;
                        btnEliminar.Visible = false;
                        btnInsertar.Visible = false;
                        btnModificar.Visible = false;
                        btnBorrar.Visible = false;
                        btnCancelar.Visible = false;
                        ///limpiamos los campos
                        txtDesPro.Text = "";
                        txtIdProducto.Text = "";
                        txtPrePro.Text = "";
                    }
                    catch (SqlException ex)
                    {
                        string StrError = "<p>Se han producido errores en el acceso a la base de datos.</p>";
                        StrError = StrError + "<div>Código: " + ex.Number + "</div>";
                        StrError = StrError + "<div>Descripción: " + ex.Message + "</div>";
                        lblMensajes.Text = StrError;
                        return;
                    }
                }
                grdProductos.DataBind(); // Vuelve a enlazar el GridView para que se actualicen los datos
                grdProductos.SelectedIndex = -1;
                FnDeshabilitarControles();
                ddlIdTipo.DataBind();
                ddlIdUnidad.DataBind();

            }
        }
    }
}
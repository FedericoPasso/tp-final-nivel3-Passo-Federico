using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloDatos
    {
        AccesoDatos datos;
        public void establecerConexion()
        {
            datos = new AccesoDatos();
        }
        public List<Articulo> listar(string id = "")
        {
            List<Articulo> lista = new List<Articulo>();
            establecerConexion();

            try
            {
                string query = "select A.Id, A.Codigo, A.Nombre Nombre, A.Descripcion Descripcion, A.Precio, A.ImagenUrl UrlImagen, A.IdCategoria, A.IdMarca, M.Descripcion Marca, C.Descripcion Categoria  from ARTICULOS A , MARCAS M, CATEGORIAS C where A.IdMarca = M.Id and A.IdCategoria = C.Id";
                if (id != "")
                {
                    query += "";
                }
                datos.setearConsulta(query);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.CodArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["UrlImagen"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    
                    aux.Precio = Math.Floor((decimal)datos.Lector["Precio"] * 100) / 100;

                    aux.categoria = new Categoria();
                    aux.categoria.id = (int)datos.Lector["IdCategoria"];
                    aux.categoria.descripcion = (string)datos.Lector["Categoria"];
                    
                    aux.marca = new Marca();
                    aux.marca.id = (int)datos.Lector["IdMarca"];
                    aux.marca.descripcion = (string)datos.Lector["Marca"];
                   
                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }
        public Articulo listarConId(int id)
        {
            establecerConexion();
            Articulo aux = new Articulo();
            aux.categoria = new Categoria();
            aux.marca = new Marca();
            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, A.ImagenUrl, A.Precio FROM ARTICULOS A INNER JOIN MARCAS M ON M.Id = A.IdMarca INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria WHERE A.Id = @id");
                datos.setearParametro("@id", id);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    aux.Id = int.Parse(datos.Lector["Id"].ToString());
                    aux.CodArticulo = datos.Lector["Codigo"].ToString();
                    aux.Nombre = datos.Lector["Nombre"].ToString();
                    aux.Descripcion = datos.Lector["Descripcion"].ToString();
                    aux.UrlImagen = datos.Lector["ImagenUrl"].ToString();
                    aux.marca.descripcion = datos.Lector["Marca"].ToString();
                    aux.categoria.descripcion = datos.Lector["Categoria"].ToString();
                    aux.Precio = Math.Floor((decimal)datos.Lector["Precio"] * 100) / 100;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return aux;
        }
       public void agregar(Articulo nuevo)
        {
            establecerConexion();
            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) values (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @precio)");
                
                
                datos.setearParametro("@Codigo", nuevo.CodArticulo);
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
                datos.setearParametro("@IdMarca", nuevo.marca.id);
                datos.setearParametro("@IdCategoria", nuevo.categoria.id);
                datos.setearParametro("@ImagenUrl", nuevo.UrlImagen);
                datos.setearParametro("@Precio", nuevo.Precio);
                
                datos.ejecutarLectura();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        } 
        public void modificar(Articulo modificado)
        {
            establecerConexion();
            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo=@codigo,Nombre=@nombre,Descripcion=@descrip,IdMarca=@idMarca,IdCategoria=@idCat,ImagenUrl=@img,Precio=@precio where Id=@id");
                
                datos.setearParametro("@codigo", modificado.CodArticulo);
                datos.setearParametro("@nombre", modificado.Nombre);
                datos.setearParametro("@descrip", modificado.Descripcion);
                datos.setearParametro("idMarca", modificado.marca.id);
                datos.setearParametro("@idCat", modificado.categoria.id);
                datos.setearParametro("@img", modificado.UrlImagen);
                datos.setearParametro("@precio", modificado.Precio);
                datos.setearParametro("@id", modificado.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void eliminar(int id)
        {
            try
            {
                establecerConexion();
                datos.setearConsulta("delete from ARTICULOS where id=@id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            establecerConexion();

            try
            {
                string consulta = "select A.Id, Codigo, Nombre, A.Descripcion, A.IdMarca, M.Descripcion Marca, A.IdCategoria, C.Descripcion Categoria, ImagenUrl, Precio  from ARTICULOS A, CATEGORIAS C, MARCAS M where A.IdMarca = M.Id and A.IdCategoria = C.Id and ";

                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filtro;
                            break;
                        default:
                            consulta += "Precio = " + filtro;
                            break;
                    }
                }

                else if (campo == "Nombre")
                {

                    switch (criterio)
                    {
                        case "Empieza con":
                            consulta += "Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";
                            break;
                        default: //case "igual a":
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;
                    }

                }
                else if (campo == "Marca")
                {
                    consulta += "a.IdMarca = " + filtro;

                }
                else if (campo == "Categoria")
                {

                    consulta += "a.IdCategoria = " + filtro;
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.CodArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["ImagenUrl"];


                    aux.Precio = Math.Floor((decimal)datos.Lector["Precio"] * 100) / 100;

                    aux.marca = new Marca();
                    aux.marca.id = (int)datos.Lector["IdMarca"];
                    aux.marca.descripcion = (string)datos.Lector["Marca"];

                    aux.categoria = new Categoria();
                    aux.categoria.id = (int)datos.Lector["IdCategoria"];
                    aux.categoria.descripcion = (string)datos.Lector["Categoria"];



                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

    }
}
    
    


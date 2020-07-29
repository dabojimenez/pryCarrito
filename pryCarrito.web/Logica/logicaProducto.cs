using pryCarrito.web.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace pryCarrito.web.Logica
{
    public class logicaProducto
    {
        private static BDCARRITOEntities3 db = new BDCARRITOEntities3();

        public static async Task<List<TBL_PRODUCTO>> getAllProduct()
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_STATUS == "A").ToListAsync();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al Obtener Productos");
            }
        }

        public static int GetNetxSecuencia()
        {
            var query = db.Database.SqlQuery<int>("SELECT NEXT VALUE FOR [dbo].[sq_ProductoID]");
            var task = query.SingleAsync();
            int nextValor = task.Result;
            return nextValor;
        }

        public static async Task<List<TBL_PRODUCTO>> getProductxCodigo(string codigoProducto)
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_STATUS == "A"
                                                    && data.PRO_CODIGO.StartsWith(codigoProducto)).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al Obtener Productos");
            }
        }

        public static async Task<List<TBL_PRODUCTO>> getProductxNombre(string nombreProducto)
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_STATUS == "A"
                                                    && data.PRO_NOMBRE.StartsWith(nombreProducto)).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al Obtener Productos");
            }
        }

        public static async Task<List<TBL_PRODUCTO>> getProductxCategoria(string categoriaProducto)
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_STATUS == "A"
                                                    && data.TBL_CATEGORIA.CAT_NOMBRE.StartsWith(categoriaProducto)).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al Obtener Productos");
            }
        }

        public static async Task<TBL_PRODUCTO> getProductXid(int idProducto)
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_STATUS == "A"
                                                    && data.PRO_ID.Equals(idProducto)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al Obtener Productos");
            }
        }

        public static async Task<TBL_PRODUCTO> getProductXcodigo(string codigoProducto)
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_STATUS == "A"
                                                    && data.PRO_CODIGO.Equals(codigoProducto)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al Obtener Productos");
            }
        }

        public static async Task<bool> saveProducto(TBL_PRODUCTO _infoProducto)
        {
            try
            {
                bool resultado = false;
                _infoProducto.PRO_ID = GetNetxSecuencia();
                _infoProducto.PRO_STATUS = "A";
                _infoProducto.PRO_FECHACREACION = DateTime.Now;
                //insertando al contexto
                db.TBL_PRODUCTO.Add(_infoProducto);
                //actualizando el contexto - commit
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al Guardar el Producto");
            }
        }

        public static async Task<bool> updateProducto(TBL_PRODUCTO _infoProducto)
        {
            try
            {
                bool resultado = false;
                _infoProducto.PRO_FECHACREACION = DateTime.Now;
                //actualizando el contexto - commit
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al Modificar el Producto");
            }
        }

        public static async Task<bool> deleteProducto(TBL_PRODUCTO _infoProducto)
        {
            try
            {
                bool resultado = false;
                _infoProducto.PRO_STATUS = "I";
                _infoProducto.PRO_FECHACREACION = DateTime.Now;
                //actualizando el contexto - commit
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al Eliminar el Producto");
            }
        }

    }
}
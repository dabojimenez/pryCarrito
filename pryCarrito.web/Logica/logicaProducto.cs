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
        private static BDCARRITOEntities1 db = new BDCARRITOEntities1();

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
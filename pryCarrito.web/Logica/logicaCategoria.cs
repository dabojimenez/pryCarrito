using pryCarrito.web.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace pryCarrito.web.Logica
{
    public class logicaCategoria
    {
        private static BDCARRITOEntities1 db = new BDCARRITOEntities1();

        public static async Task<List<TBL_CATEGORIA>> GetAllCategorias()
        {
            try
            {
                return await db.TBL_CATEGORIA.Where(data => data.CAT_STATUS == "A").ToListAsync();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al Obtener Categorias");
            }
        }
    }
}
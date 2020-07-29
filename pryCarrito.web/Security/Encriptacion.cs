using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pryCarrito.web.Security
{
    public class Encriptacion
    {
        public static string encriptarCodigo(string codigo)
        {
            string resultado = string.Empty;
            Byte[] encriptacion = System.Text.Encoding.Unicode.GetBytes(codigo);
            resultado = Convert.ToBase64String(encriptacion);
            //resultado = Convert.ToString(encriptacion);
            return resultado;
        }

        public static string desencriptarCodigo( string codigoEncriptado)
        {
            string resulDesencriptar = string.Empty;

            Byte[] desencriptacion = Convert.FromBase64String(codigoEncriptado);
            resulDesencriptar = System.Text.Encoding.Unicode.GetString(desencriptacion);
            return resulDesencriptar;
        }
    }
}
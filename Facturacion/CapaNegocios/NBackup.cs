using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class NBackup
    {
        public static string CrearBackup(string ruta, string alias, string bd) 
        {
            DBackup bk = new DBackup();
            bk.Ruta = ruta;
            bk.Alias = alias;
            bk.BD = bd;
            return bk.Backup(bk); 
        }


        public static DataTable MostrarRecordatorio(string rango) 
        {
            DBackup obj = new DBackup();
            return obj.MostrarRecordatorio(rango);

        }

    }
}


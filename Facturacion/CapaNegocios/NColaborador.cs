﻿using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NColaborador
    {
        public static string Insertar(DColaborador colaborador)
        {
            DColaborador objColaborador = new DColaborador();
            return objColaborador.InsertarColaborador(colaborador);
        }

        public static string Editar(DColaborador colaborador)
        {
            DColaborador objColaborador = new DColaborador();
            return objColaborador.EditarColaborador(colaborador);
        }
    }
}

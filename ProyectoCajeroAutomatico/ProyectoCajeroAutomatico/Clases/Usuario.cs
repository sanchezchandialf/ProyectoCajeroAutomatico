using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCajeroAutomatico.Clases
{
    public class Usuario
    {
        public string _id { get; set; }
        public string _nome { get; set; }
        public string _direccion { get; set; }
        public string _tipoUs { get; set; }
        public string[] opciones = { "jubliado", "activo" };

        public Usuario() { }

        public Usuario(string id, string nome, string direccion, int act)
        {
            _id = id;
            _nome = nome;
            _direccion = direccion;
            _tipoUs = opciones[act - 1];
        }
    }
    }


using System;
using System.Collections.Generic;

namespace Biblioteca.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string nomeUsuario { get; set; }
        public string loginUsuario { get; set; }
        public DateTime datadenascimentoUsuario { get; set; }
        public string senhaUsuario { get; set; }
        public string emailUsuario{ get; set; }
    }
}
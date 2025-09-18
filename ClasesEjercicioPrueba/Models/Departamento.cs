using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesEjercicioPrueba.Models
{
    public class Departamento
    {

        public Departamento() { }

        public Departamento(string Nombre, string Descripcion)
        {
            
            this.Nombre = Nombre;
            this.Descripcion = Descripcion; 

        }


        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }



    }
}

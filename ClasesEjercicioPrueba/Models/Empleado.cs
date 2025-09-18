using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesEjercicioPrueba.Models
{
    public class Empleado
    {

        public Empleado() { }   

        public Empleado(string Nombre, string Email, Departamento Departamento, decimal Salario)
        {
            this.Nombre = Nombre;
            this.Email = Email;
            this.Departamento = Departamento;
            this.Salario = Salario;
            IdDepartamento = Departamento.Id;



        }


        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public int IdDepartamento { get; set; }

        public Departamento Departamento { get; set; }

        public decimal Salario { get; set; }

    }
}

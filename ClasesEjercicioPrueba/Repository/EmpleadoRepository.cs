using ClasesEjercicioPrueba.Data1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesEjercicioPrueba.Data1;
using ClasesEjercicioPrueba.Models;
using System.Globalization;

namespace ClasesEjercicioPrueba.Repository
{
    public static class EmpleadoRepository
    {
        public static void ActualizarSalarioEmpleado(Empleado empleado, decimal SalarioNuevo)
        {
            using var context = new ApplicationDbContext();

            foreach (var e in context.Empleados)
            {
                if (e.Id == empleado.Id)
                {
                    e.Salario = SalarioNuevo;
                    context.SaveChanges();
                    break; 
                }
            }
        }



        public static void GuardarEmpleado(Empleado empleado)
        {
            using var context = new ApplicationDbContext();

            bool empleadoExiste = false;

            foreach (var e in context.Empleados)
            {
                if (e.Email == empleado.Email)
                {
                    empleadoExiste = true;
                    break;
                }
            }

            if (empleadoExiste == false)
            {
                context.Empleados.Add(empleado);
                context.SaveChanges();
                Console.WriteLine("Empleado registrado con éxito!");
            }
            else
            {
                Console.WriteLine("Ya existe un empleado con ese email");
            }
        }


        public static void BorrarEmpleado(Empleado Empleado)
        {
            using var context = new ApplicationDbContext();
            context.Empleados.Remove(Empleado);
            Console.WriteLine("Empleado borrado con éxito!");
            context.SaveChanges();
            
        }


        public static List<Empleado> ObtenerEmpleados()
        {
            using var context = new ApplicationDbContext();
            return context.Empleados.ToList();
        }

    }
}

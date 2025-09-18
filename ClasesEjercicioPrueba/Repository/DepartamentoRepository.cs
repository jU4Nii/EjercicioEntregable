using ClasesEjercicioPrueba.Data1;
using ClasesEjercicioPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesEjercicioPrueba.Repository
{
    public class DepartamentoRepository
    {

        public static void GuardarDepartamento(Departamento departamento)
        {
            using var context = new ApplicationDbContext();

            bool departamentoExiste = false;

            foreach (var d in context.Departamentos)
            {
                if (d.Nombre == departamento.Nombre)
                {
                    departamentoExiste = true;
                    break;
                }
            }

            if (departamentoExiste == false)
            {
                context.Departamentos.Add(departamento);
                Console.WriteLine("Departamento registrado con éxito!");
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Ya existe un departamento con ese nombre");
            }
        }

        public static List<Departamento> ObtenerDepartamentos()
        {
            using var context = new ApplicationDbContext();
            return context.Departamentos.ToList();
        }


    }
}

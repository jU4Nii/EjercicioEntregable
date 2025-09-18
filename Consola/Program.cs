namespace Consola;
using ClasesEjercicioPrueba;
using ClasesEjercicioPrueba.Models;
using ClasesEjercicioPrueba.Repository;

using System.Globalization;

internal class Program
    {
    static void Main(string[] args)
    {
        List<Empleado> empleados = EmpleadoRepository.ObtenerEmpleados();
        List<Departamento> departamentos = DepartamentoRepository.ObtenerDepartamentos();


        string eleccion = IngresarString("Elija una opción:\n1. Registrar nuevo empleado\n2. Actualizar salario de empleado\n3. Eliminar empleado\n4. Registrar nuevo departamento\n5. Estadísticas de empleados\n6. Salir");

        while (eleccion != "6")
        {

            Console.Clear();

            switch (eleccion)
            {
                case "1":
                    string nombre = IngresarString("Ingrese el nombre del empleado:");
                    string email = IngresarString("Ingrese el email del empleado");

                    Console.WriteLine("Elija un departamento:");
                    for (int i = 0; i < departamentos.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {departamentos[i].Nombre}");
                    }

                    int opcion = PedirEntero("Ingrese el número del departamento:");

                    while (opcion < 1 || opcion > departamentos.Count)
                    {
                        opcion = PedirEntero("Opción incorrecta, por favor ingresarla de nuevo:");
                    }

                    Departamento deptoElegido = departamentos[opcion - 1];

                    Console.WriteLine("Ingrese el salario del empleado:");
                    string input = Console.ReadLine();
                    decimal salario;
                    
                    bool conversion = decimal.TryParse(input, out salario);
                    while (conversion == false)
                    {
                        
                        Console.WriteLine("Valor incorrecto, ingreselo nuevamente:");
                        input = Console.ReadLine();
                        conversion = decimal.TryParse(input, out salario);
                    }

                    Empleado empleadoNuevo = new Empleado(nombre, email, deptoElegido, salario);
                    EmpleadoRepository.GuardarEmpleado(empleadoNuevo);

                    empleados = EmpleadoRepository.ObtenerEmpleados();

                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;


                case "2":
                    string emailSalario = IngresarString("Ingrese el email del empleado al cual desea actualizar su salario");
                    bool empleadoSExiste = false;
                    Empleado empleadoACambiar = null;
                    foreach (var e in empleados)
                    {

                        if (e.Email == emailSalario)
                        {

                            empleadoSExiste = true;
                            empleadoACambiar = e;
                            Console.WriteLine("Empleado encontrado");
                            break;
                        }

                    }
                    if (empleadoSExiste)
                    {

                        Console.WriteLine("Ingrese el salario nuevo:");
                        string inputSalarioNuevo = Console.ReadLine();
                        decimal salarioNuevo;
                        bool conversionSalarioNuevo = decimal.TryParse(inputSalarioNuevo, out salarioNuevo);
                        while (conversionSalarioNuevo == false)
                        {
                            Console.WriteLine("Valor incorrecto, ingreselo nuevamente:");
                            inputSalarioNuevo = Console.ReadLine();
                            conversionSalarioNuevo = decimal.TryParse(inputSalarioNuevo, out salarioNuevo);
                        }
                        EmpleadoRepository.ActualizarSalarioEmpleado(empleadoACambiar, salarioNuevo);
                        empleados = EmpleadoRepository.ObtenerEmpleados();

                    }
                    else Console.WriteLine("Empleado inexistente");
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "3":
                    string emailEliminar = IngresarString("Ingrese el email del empleado que desea eliminar");
                    bool empleadoEliminarExiste = false;
                    Empleado empleadoAEliminar = null;
                    foreach (var e in empleados)
                    {

                        if (e.Email == emailEliminar)
                        {

                            empleadoEliminarExiste = true;
                            empleadoAEliminar = e;
                            break;
                        }

                    }
                    if (empleadoEliminarExiste)
                    {
                        EmpleadoRepository.BorrarEmpleado(empleadoAEliminar);
                        empleados = EmpleadoRepository.ObtenerEmpleados();
                    }
                    else Console.WriteLine("Empleado inexistente");
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "4":
                    string nombreDepto = IngresarString("Ingrese el nombre del nuevo departamento:");
                    string descripDepto = IngresarString("Ingrese la descripción del nuevo departamento");
                    Departamento depaNuevo = new Departamento(nombreDepto, descripDepto);
                    DepartamentoRepository.GuardarDepartamento(depaNuevo);
                    departamentos = DepartamentoRepository.ObtenerDepartamentos();
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;

                case "5":
                    Console.WriteLine($"Total de empleados registrados: {empleados.Count}");
                    decimal promedioSalario = empleados.Average(e => e.Salario);
                    Console.WriteLine($"Promedio de salario general: {promedioSalario}");
                    decimal maxSalario = empleados.Max(e  => e.Salario);
                    Console.WriteLine($"Salario máximo: {maxSalario}");
                    decimal minSalario = empleados.Min(e => e.Salario);
                    Console.WriteLine($"Salario mínimo: {minSalario}");
                    Console.WriteLine("Cantidad de empleados por departamento:");
                    foreach (var depto in departamentos)
                    {
                        int contador = 0;
                        foreach (var emp in empleados)
                        {
                            if (emp.Departamento.Id == depto.Id)
                                contador++;
                        }
                        Console.WriteLine($"{depto.Nombre}: {contador} empleados");
                    }

                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                    break;



                default:
                    Console.WriteLine("Opción inexistente, pruebe con otra");
                    Console.WriteLine("\nPresione una tecla para elegir nuevamente...");
                    Console.ReadKey();
                    break;

            }

            Console.Clear();
            eleccion = IngresarString("Elija una opción:\n1. Registrar nuevo empleado\n2. Actualizar salario de empleado\n3. Eliminar empleado\n4. Registrar nuevo departamento\n5. Estadísticas de empleados\n6. Salir");
        }
    }

    public static int PedirEntero(string mensaje)
    {

        int num;
        Console.WriteLine(mensaje);
        while (int.TryParse(Console.ReadLine(), out num) == false)
        {

            Console.WriteLine("Valor incorrecto, ingreselo nuevamente:");

        }

        return num;

    }
    

    public static string IngresarString(string mensaje)
    {

        Console.WriteLine(mensaje);
        string palabra = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(palabra) == true)
        {

            Console.WriteLine("Valor incorrecto, ingreselo nuevamente:");
            palabra = Console.ReadLine();

        }

        return palabra;

    }

    }

    

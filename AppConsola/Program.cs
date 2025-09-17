using ClasesEjercicioPrueba.Models;
using ClasesEjercicioPrueba.Repository;

Console.WriteLine("Ingrese el modelo del vehiculo");
string modelo = Console.ReadLine();
Console.WriteLine("Ingrese la marca del vehiculo");
string marca = Console.ReadLine();
Console.WriteLine("Ingrese la patente del vehiculo");
string patente = Console.ReadLine();
Console.WriteLine("Ingrese la cantidad de puertas del vehiculo");
int cantidadPuertas = int.Parse(Console.ReadLine());
Console.WriteLine("Ingrese el motor del vehiculo");
string motor = Console.ReadLine();

Vehiculo vehiculo = new Vehiculo()
{
    modelo = modelo,
    marca = marca,
    patente = patente,
    cantidadPuertas = cantidadPuertas,
    motor = motor
};

VehiculoRepository.GuardarVehiculo(vehiculo);
Console.WriteLine("Vehiculo guardado con exito");


List<Vehiculo> vehiculos = VehiculoRepository.ObtenerVehiculos();

foreach(var v in vehiculos)
{
    Console.WriteLine($"Id: {v.id} - Modelo: {v.modelo} - Marca: {v.marca} - Patente: {v.patente} - Cantidad de puertas: {v.cantidadPuertas} - Motor: {v.motor}");
}

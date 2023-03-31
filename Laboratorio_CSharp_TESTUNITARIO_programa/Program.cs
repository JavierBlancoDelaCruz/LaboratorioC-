//En esta versión.NET 7.0, Program.cs se usará por defecto como el Main().

using Laboratorio_CSharp_TESTUNITARIO_programa; //Para poder hacer uso de la clase Correo.cs


Console.WriteLine("Introduce un correo electrónico: (Formato: ejemplo@email.abc)\n");

List<string> ListaCorreos = new List<string>();

while (true)
{
    Console.Write("> ");

    var correo_introducido = Console.ReadLine();
    if (correo_introducido == "quit")
        break;

    var correo = new Correo();
    //Console.WriteLine("\n--------\nValidez: " + correo.Validar1(correo_introducido) + "\n--------");
    Console.WriteLine("\n--------\nValidez: " + correo.Validar2(correo_introducido, ListaCorreos) + "\n--------");


    Console.WriteLine("\nPuedes seguir comprobando correos. Si deseas salir escribe 'quit'.\n");
}


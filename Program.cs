using System;

Console.WriteLine("================================");
Console.WriteLine("       SISTEMA BANCARIO");
Console.WriteLine("================================");

Console.Write("Ingrese el nombre del titular: ");
string titular = Console.ReadLine() ?? "";

while (string.IsNullOrWhiteSpace(titular))
{
    Console.Write("El nombre no puede estar vacío. Intente de nuevo: ");
    titular = Console.ReadLine() ?? "";
}

decimal saldo = 1000m;
int opcion;

do
{
    MostrarMenu();

    while (!int.TryParse(Console.ReadLine(), out opcion))
    {
        Console.Write("Entrada inválida. Escriba un número: ");
    }

    switch (opcion)
    {
        case 1:
            Console.WriteLine("\n===== CONSULTAR SALDO =====");
            Console.WriteLine($"Saldo disponible: RD${saldo:N2}");
            break;

        case 2:
            Console.WriteLine("\n===== DEPOSITAR DINERO =====");

            decimal deposito = LeerMontoPositivo("Ingrese el monto a depositar: RD$");
            decimal saldoAnteriorDeposito = saldo;

            saldo = CalcularDeposito(saldo, deposito);

            Console.WriteLine("\nDepósito realizado correctamente.");
            Console.WriteLine($"Saldo anterior: RD${saldoAnteriorDeposito:N2}");
            Console.WriteLine($"Depósito:       RD${deposito:N2}");
            Console.WriteLine($"Saldo actual:   RD${saldo:N2}");
            break;

        case 3:
            Console.WriteLine("\n===== RETIRAR DINERO =====");

            decimal retiro = LeerMontoPositivo("Ingrese el monto a retirar: RD$");

            if (retiro <= saldo)
            {
                decimal saldoAnteriorRetiro = saldo;
                saldo = CalcularRetiro(saldo, retiro);

                Console.WriteLine("\nRetiro realizado correctamente.");
                Console.WriteLine($"Saldo anterior: RD${saldoAnteriorRetiro:N2}");
                Console.WriteLine($"Retiro:         RD${retiro:N2}");
                Console.WriteLine($"Saldo actual:   RD${saldo:N2}");
            }
            else
            {
                Console.WriteLine("\nNo se puede realizar el retiro: saldo insuficiente.");
                Console.WriteLine($"Saldo disponible: RD${saldo:N2}");
            }

            break;

        case 4:
            MostrarDatosCuenta(titular, saldo);
            break;

        case 5:
            Console.WriteLine("\nGracias por utilizar el sistema bancario.");
            break;

        default:
            Console.WriteLine("\nOpción no válida. Elija un número del 1 al 5.");
            break;
    }

} while (opcion != 5);

static void MostrarMenu()
{
    Console.WriteLine("\n===== MENÚ PRINCIPAL =====");
    Console.WriteLine("1. Consultar saldo");
    Console.WriteLine("2. Depositar dinero");
    Console.WriteLine("3. Retirar dinero");
    Console.WriteLine("4. Mostrar datos de la cuenta");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opción: ");
}

static decimal LeerMontoPositivo(string mensaje)
{
    decimal monto;

    Console.Write(mensaje);

    while (!decimal.TryParse(Console.ReadLine(), out monto) || monto <= 0)
    {
        Console.Write("Monto inválido. Ingrese un número mayor que cero: RD$");
    }

    return monto;
}

static decimal CalcularDeposito(decimal saldoActual, decimal monto)
{
    return saldoActual + monto;
}

static decimal CalcularRetiro(decimal saldoActual, decimal monto)
{
    return saldoActual - monto;
}

static void MostrarDatosCuenta(string nombre, decimal saldoActual)
{
    Console.WriteLine("\n===== DATOS DE LA CUENTA =====");
    Console.WriteLine($"Titular: {nombre}");
    Console.WriteLine($"Saldo disponible: RD${saldoActual:N2}");
}
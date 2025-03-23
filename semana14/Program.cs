
class Nodo
{
    public int Dato;
    public Nodo? Izq, Der;

    public Nodo(int valor)
    {
        Dato = valor;
        Izq = Der = null;
    }
}

class Arbol
{
    private Nodo? raiz;

    public Arbol()
    {
        raiz = null;
    }

    public void Agregar(int valor)
    {
        raiz = AgregarNodo(raiz, valor);
    }

    private Nodo AgregarNodo(Nodo? nodo, int valor)
    {
        if (nodo == null)
        {
            return new Nodo(valor);
        }
        if (valor < nodo.Dato)
            nodo.Izq = AgregarNodo(nodo.Izq, valor);
        else
            nodo.Der = AgregarNodo(nodo.Der, valor);

        return nodo;
    }

    public void MostrarOrden()
    {
        Console.WriteLine("\nElementos en orden:");
        if (raiz != null)
            MostrarOrdenRec(raiz);
        else
            Console.WriteLine("(Árbol vacío)");
        Console.WriteLine();
    }

    private void MostrarOrdenRec(Nodo nodo)
    {
        if (nodo == null) return;

        if (nodo.Izq != null)
            MostrarOrdenRec(nodo.Izq);

        Console.Write(nodo.Dato + " ");

        if (nodo.Der != null)
            MostrarOrdenRec(nodo.Der);
    }

    public bool Buscar(int valor)
    {
        return BuscarNodo(raiz, valor);
    }

    private bool BuscarNodo(Nodo? nodo, int valor)
    {
        if (nodo == null) return false;
        if (nodo.Dato == valor) return true;
        return valor < nodo.Dato ? BuscarNodo(nodo.Izq, valor) : BuscarNodo(nodo.Der, valor);
    }
}

class Programa
{
    static void Main()
    {
        Arbol miArbol = new Arbol();
        int opcion, num;

        do
        {
            Console.WriteLine("\n*** Menú Árbol Binario ***");
            Console.WriteLine("1. Insertar número");
            Console.WriteLine("2. Mostrar elementos en orden");
            Console.WriteLine("3. Buscar número");
            Console.WriteLine("4. Salir");
            Console.Write("Elige una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Error: Ingresa un número válido.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Número a insertar: ");
                    if (int.TryParse(Console.ReadLine(), out num))
                    {
                        miArbol.Agregar(num);
                        Console.WriteLine("Número agregado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("Error: Entrada inválida.");
                    }
                    break;

                case 2:
                    miArbol.MostrarOrden();
                    break;

                case 3:
                    Console.Write("Número a buscar: ");
                    if (int.TryParse(Console.ReadLine(), out num))
                    {
                        Console.WriteLine(miArbol.Buscar(num) ? "Número encontrado." : "No se encontró el número.");
                    }
                    else
                    {
                        Console.WriteLine("Error: Entrada inválida.");
                    }
                    break;

                case 4:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción incorrecta, intenta de nuevo.");
                    break;
            }
        } while (opcion != 4);
    }
} 

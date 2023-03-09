internal class Program
{
    private static void Main(string[] args)
    {
        string ruta = @"C:\Users\elf_m\Desktop\PU-2\TALLER1\repaso\tps\practica\";
        List<string> listadoDeCarpetas = Directory.GetDirectories(ruta).ToList();
        foreach (string carp in listadoDeCarpetas)
        {
            Console.WriteLine(carp);
        }
        Console.WriteLine("Ingrese la direccion de la carpeta que desea enlistar sus archivos:");
        string buscada = Console.ReadLine();
        List<string> listaDeArchivos = Directory.GetFiles(ruta+buscada).ToList();
        for (int i = 0; i < listaDeArchivos.Count; i++)
        {
            listaDeArchivos[i] = listaDeArchivos[i].Remove(0, 60);
           // string[] nombreYextension = listaDeArchivos[i].Split('.');
           // Console.WriteLine(nombreYextension[0] + " " + nombreYextension[1]);
        }

        foreach (string archivos in listaDeArchivos)
        {
            Console.WriteLine(archivos);
        }
        FileStream copia = new FileStream("index.csv", FileMode.Create);
        using (StreamWriter escribir = new StreamWriter(copia))
        {
            escribir.WriteLine("Nombre del archivo; extension del archivo");
            foreach (var registro in listaDeArchivos)
            {
                string[] nombre = registro.Split(".");
                escribir.WriteLine("{0};{1}", nombre[0], nombre[1]);
            }
            escribir.Close();
        }
    }
}
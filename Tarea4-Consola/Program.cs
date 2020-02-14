using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tarea4_Consola
{
    class Program
    {
        static string ValidarNoArchivo(string argumentos, string target)
        {
            string target1 = "";
            string[] tmp;
            string arg1 = argumentos;
            //Verificamos que la ruta exista
            if (argumentos.Contains("c:\\Users\\") || argumentos.Contains("C:\\Users\\"))
            {
                tmp = argumentos.Split("\\");
                argumentos = "";
                for (int i = 0; i < tmp.Length - 1; i++)
                {
                    argumentos += tmp[i];
                    if (i != tmp.Length - 2)
                        argumentos += "\\";
                }
                if (!Directory.Exists(argumentos))
                {
                    Console.WriteLine("No existe el directorio \"{0}\"", argumentos);
                }
                else
                {
                    if (ExisteArchivo(tmp[tmp.Length - 1], argumentos))
                        Console.WriteLine("El archivo \"{0}\" ya existe en la ruta {1}", tmp[tmp.Length - 1], argumentos);
                    else
                        target1 = argumentos;
                }
            }
            //revisar que el archivo existe en la ruta actual
            else
            {
                if (ExisteArchivo(argumentos, target))
                    Console.WriteLine("El archivo \"{0}\" ya existe en la ruta {1}", argumentos, target); 
                else
                    target1 = target;
            }
            return target1;
        }
        static string ValidarRutas(string argumentos, string target)
        {
            string target1 = "";
            string[] tmp;
            string arg1 = argumentos;
            //Verificamos que la ruta exista
            if (argumentos.Contains("c:\\Users\\") || argumentos.Contains("C:\\Users\\"))
            {
                tmp = argumentos.Split("\\");
                argumentos = "";
                for (int i = 0; i < tmp.Length - 1; i++) {
                    argumentos += tmp[i];
                    if (i != tmp.Length - 2)
                        argumentos += "\\";
                }
                if (!Directory.Exists(argumentos))
                {
                    Console.WriteLine("No existe el directorio \"{0}\"", argumentos);
                }
                else
                {
                    if (ExisteArchivo(tmp[tmp.Length -1], argumentos))
                    {
                        target1 = argumentos + "\\" + tmp[tmp.Length - 1];
                    }
                    else
                        Console.WriteLine("No existe el archivo \"{0}\" en la ruta {1}", tmp[tmp.Length - 1], argumentos);
                }
            }
            //revisar que el archivo existe en la ruta actual
            else
            {
                if (ExisteArchivo(argumentos, target))
                {
                    target1 = target + "\\" + argumentos;
                }
                else
                    Console.WriteLine("No existe el archivo \"{0}\" en la ruta {1}", argumentos, target);
            }
            return target1;
        }
        static void ListaContenido(string directorio)
        {
            //Environment.CurrentDirectory = (@directorio);
            //Para listar los directorios
            Console.WriteLine("CARPETAS:");
            string[] dirEntries = Directory.GetDirectories(directorio);
            foreach (string dirName in dirEntries)
                Console.WriteLine(dirName.Substring(directorio.Length + 1));
            //Para listar los archivos
            string[] fileEntries = Directory.GetFiles(directorio);
            Console.WriteLine("\nARCHIVOS:");
            foreach (string fileName in fileEntries)
                Console.WriteLine(fileName.Substring(directorio.Length + 1));
        }
        static bool ExisteCarpeta(string carpeta, string directorio)
        {
            bool ok = false;
            //Environment.CurrentDirectory = (directorio);
            string[] dirEntries = Directory.GetDirectories(directorio);
            foreach (string dirName in dirEntries)
            {
                if (dirName.Substring(directorio.Length + 1) == carpeta)
                    ok = true;
            }
            return ok;
        }
        static bool ExisteArchivo(string archivo, string directorio)
        {
            bool ok = false;
            //Environment.CurrentDirectory = (directorio);
            string[] arEntries = Directory.GetFiles(directorio);
            foreach (string arName in arEntries)
            {
                if (arName.Substring(directorio.Length + 1) == archivo)
                    ok = true;
            }
            return ok;
        }
        static void Main(string[] args)
        {
            bool salir = true;                              //Cuando el comendo sea "exit" terminará el programa
            string comando;                                 //Comando que ingresará el usuario
            string[] argumentos;                            //Si el comando tiene argumentos, se separará y se guardará en este arreglo
            List<string> argumentos1;
            List<string> historia = new List<string>();     //Historial de comandos
            string tmp;
            string tmp1 = "";
            string tmp2 = "";
            //Declaramos como cadena la dirección de Documentos junto con el nombre del usuario
            string target = "c:\\Users\\" + Environment.UserName + "\\Documents";
            string target1;
            string directorio = @target;
            string[] retroceder;
            int contadorComillas = 0;
            Objeto copiar;
            Objeto mover;
            //Con esto nos cambiamos a Documentos una vez iniciado el programa
            Environment.CurrentDirectory = (directorio);
            while (salir)
            {
                try
                {
                    //Console.WriteLine("iniio: target: {0}", target);
                    if (target.EndsWith("\\"))
                        target = target.Remove(target.Length - 1, 1);
                    directorio = @target;
                    //Cuales sean los cambios, siempre nos moveremos al valor actual
                    Environment.CurrentDirectory = (directorio);
                    //Se imprime el directorio actual
                    Console.Write("\n" + directorio + ">");
                    comando = Console.ReadLine();
                    //Si el usuario sólo da enter, entonces no se guarda ni se procesa nada y se repite el ciclo
                    if (comando == "")
                        continue;
                    //Añadimos el comando ingresado al historial
                    historia.Add(comando);
                    //Si la cadena tiene más argumentos, los separamos y lo guardamos en el arreglo
                    argumentos = comando.Split(' ');
                    //Si se tiene cadenas vacías, las quitamos
                    argumentos1 = argumentos.ToList<string>();
                    argumentos1.RemoveAll(p => string.IsNullOrEmpty(p));
                    argumentos = argumentos1.ToArray();
                    /*
                     * Los comandos posibles son los siguientes:
                     * dir
                     * cd directorio
                     * touch archivo
                     * copy directorioOrigen directorioDestino
                     * move directorioOrigen directorioDestino
                     * history
                     * cls
                     * exit
                     */
                    //Para evitar la sensibilidad a mayúsculas y minúsculas, se pasará siempre el primer argumento a minúscúlas
                    tmp = argumentos[0].ToLower();
                    //Comenzamos con la lectura del argumento
                    switch (tmp)
                    {
                        case "dir":
                            if (argumentos.Length == 1)
                                ListaContenido(directorio);
                            else if (argumentos.Length == 2)
                            {
                                //Revisamos que el directorio exista
                                if (!Directory.Exists(argumentos[1]))
                                    Console.WriteLine("No existe el directorio \"{0}\"", argumentos[1]);
                                else
                                    ListaContenido(argumentos[1]);
                            }
                            else
                            {
                                if (argumentos[1].Contains("\"") && argumentos[argumentos.Length - 1].Contains("\""))
                                {
                                    tmp1 = "";
                                    for (int i = 1; i < argumentos.Length; i++)
                                    {
                                        tmp1 += argumentos[i];
                                        if (i != argumentos.Length - 1)
                                            tmp1 += " ";
                                    }
                                    tmp1 = tmp1.Substring(1);
                                    tmp1 = tmp1.Remove(tmp1.Length - 1, 1);
                                    if (!Directory.Exists(tmp1))
                                        Console.WriteLine("No existe el directorio \"{0}\"", tmp1);
                                    else
                                        ListaContenido(tmp1);
                                }
                                else
                                    Console.WriteLine("Uso del comando: dir [ directorio ]");
                            }
                            break;
                        case "cd":
                            //Si el comando tiene un sólo argumendo, el comando es válido
                            if (argumentos.Length == 1)
                                Console.WriteLine("Uso del comando: cd [ directorio | .. ]\nSi existen carpetas cuyo nombre contiene espacios, poner la dirección entre comillas \"directorio\"");
                            else
                            {
                                //Se revisa si la ruta o carpeta tiene espacios en su nombre
                                if (argumentos[1].Contains("\"") && argumentos[argumentos.Length - 1].Contains("\""))
                                {
                                    tmp1 = "";
                                    for (int i = 1; i < argumentos.Length; i++)
                                    {
                                        tmp1 += argumentos[i];
                                        if (i != argumentos.Length - 1)
                                            tmp1 += " ";
                                    }
                                    tmp1 = tmp1.Substring(1);
                                    tmp1 = tmp1.Remove(tmp1.Length - 1, 1);
                                }
                                else
                                    tmp1 = argumentos[1];
                                //Revisamos si el nombre de la carpeta está en esa carpeta
                                if (ExisteCarpeta(tmp1, directorio))
                                    target += "\\" + tmp1;
                                else if (argumentos[1] == "..")     //Si se va a retroceder carpeta
                                {
                                    tmp1 = "";
                                    retroceder = directorio.Split('\\');        //Separamos los directorios para poder concatenarlos y remover el último
                                    if (retroceder.Length >= 3)
                                    {
                                        for (int i = 0; i < retroceder.Length - 1; i++)
                                        {
                                            tmp1 += retroceder[i];
                                            if (i != retroceder.Length - 2)
                                                tmp1 += "\\";
                                        }
                                        try
                                        {
                                            Environment.CurrentDirectory = (@tmp1);     //Intenamos cambiar de directorio
                                            target = tmp1;
                                            //Console.WriteLine("target: {0}", target);
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("No tienes permisos");
                                            Console.WriteLine("The process failed: {0}", e.ToString());
                                        }
                                    }
                                    else
                                    {
                                        //Existieron errores tratando de ingresar a c:, por eso se prefirió dejar esta condición de no dejar pasar más allá
                                        Console.WriteLine("Por seguridad no se puede retroceder otra carpeta.");
                                    }
                                }
                                else
                                {
                                    //Revisamos que el directorio exista
                                    if (!Directory.Exists(tmp1))
                                        Console.WriteLine("No existe el directorio \"{0}\"", tmp1);
                                    else
                                    {
                                        //Por seguridad, no se podrá mover a ninguna otra capeta que no esté fuera de c:\Users
                                        if (tmp1.Contains("C:\\Users") || tmp1.Contains("c:\\Users"))
                                        {
                                            try
                                            {
                                                Environment.CurrentDirectory = (@tmp1);
                                                target = tmp1;
                                            }
                                            catch
                                            {
                                                Console.WriteLine("No se puede mover de carpeta.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("No tienes permisos"); 
                                        }
                                    }
                                }
                            }
                            break;
                        case "touch":
                            if (argumentos.Length == 1)
                                Console.WriteLine("Uso: touch [ nombre | ruta\\nombre ]");
                            else
                            {
                                //Se evalua el segundo argumento, si tiene comillas o en un sólo argumento sin espacios
                                if (argumentos[1].Contains("\"") && argumentos[argumentos.Length - 1].Contains("\""))
                                {
                                    tmp1 = "";
                                    for (int i = 1; i < argumentos.Length; i++)
                                    {
                                        tmp1 += argumentos[i];
                                        if (i != argumentos.Length - 1)
                                            tmp1 += " ";
                                    }
                                    tmp1 = tmp1.Substring(1);
                                    tmp1 = tmp1.Remove(tmp1.Length - 1, 1);
                                }
                                else
                                    tmp1 = argumentos[1];
                                target1 = @tmp1;
                                try
                                {
                                    if (File.Exists(target1))
                                        Console.WriteLine("El archivo ya existe.");
                                    else
                                    {
                                        File.Create(target1);
                                    }
                                }
                                catch (Exception Ex)
                                {
                                    Console.WriteLine("Uso: touch [ nombre | ruta\\nombre ]");
                                    Console.WriteLine(Ex.ToString());
                                }
                            }
                            break;
                        case "copy":
                            if (argumentos.Length == 1)
                                Console.WriteLine("Uso: copy { rutaOrigen\\archivo | archivo } { rutaDestino\\archivo | archivo }");
                            else if (argumentos.Length == 3)
                            {
                                //Verificamos que el archivo a copiar existe y que el archivo destino no exista
                                if (ValidarRutas(argumentos[1], target) != "" && ValidarNoArchivo(argumentos[2], target) != "")
                                {
                                    copiar = new Objeto(argumentos[1], argumentos[2]);
                                    copiar.Copiar();
                                }
                            }
                            else
                            {
                                contadorComillas = 0;
                                //Verificar las rutas
                                //Contamos la cantidad de comillas que hay en la cadena
                                foreach (string cad in argumentos)
                                {
                                    if (cad.Contains("\""))
                                        contadorComillas++;
                                }
                                //Si las comillas existentes son 2 o 4 entonces continuamos, de otro modo, el argumento es inválido
                                if (contadorComillas == 2 || contadorComillas == 4)
                                {
                                    tmp1 = "";
                                    tmp2 = "";
                                    contadorComillas = 0;
                                    //Si el primer parámetro tiene comillas, entonces ese será la cadena con espacios
                                    if (argumentos[1].Contains("\""))
                                    {
                                        for (int i = 1; i < argumentos.Length; i++)
                                        {
                                            tmp1 += argumentos[i];
                                            if (i != argumentos.Length - 1)
                                                tmp1 += " ";
                                            if (i != 1)
                                            {
                                                if (argumentos[i].Contains("\""))
                                                    contadorComillas = i + 1;
                                                break;
                                            }
                                        }
                                        tmp1 = tmp1.Substring(1);
                                        tmp1 = tmp1.Remove(tmp1.Length - 2, 1);
                                    }//Si no exiten comillas, entonces ese es una sola cadena sin espacios
                                    else
                                    {
                                        tmp1 = argumentos[1];
                                        contadorComillas = 2;
                                    }
                                    //Revisamos si la otra ruta tiene espacios
                                    if (argumentos[contadorComillas].Contains("\""))
                                    {
                                        for (int i = contadorComillas; i < argumentos.Length; i++)
                                        {
                                            tmp2 += argumentos[i];
                                            if (i != argumentos.Length - 1)
                                                tmp2 += " ";
                                        }
                                        tmp2 = tmp2.Substring(1);
                                        tmp2 = tmp2.Remove(tmp2.Length - 1, 1);
                                    }
                                    else
                                    {
                                        tmp2 = argumentos[contadorComillas];
                                    }
                                    //Console.WriteLine("primera ruta: {0}", tmp1);
                                    //Console.WriteLine("segunda ruta: {0}", tmp2);
                                    if (ValidarRutas(tmp1, target) != "" && ValidarNoArchivo(tmp2, target) != "")
                                    {
                                        copiar = new Objeto(tmp1, tmp2);
                                        copiar.Copiar();
                                    }
                                }
                                else
                                    Console.WriteLine("Uso: copy { rutaOrigen\\archivo | archivo } { rutaDestino\\archivo | archivo }");
                            }
                            break;
                        case "move":
                            if (argumentos.Length == 1)
                                Console.WriteLine("Uso: copy { rutaOrigen\\archivo | archivo } { rutaDestino\\archivo | archivo }");
                            else if (argumentos.Length == 3)
                            {
                                //Verificamos que el archivo a copiar existe y que el archivo destino no exista
                                if (ValidarRutas(argumentos[1], target) != "" && ValidarNoArchivo(argumentos[2], target) != "")
                                {
                                    mover = new Objeto(argumentos[1], argumentos[2]);
                                    mover.Mover();
                                }
                            }
                            else
                            {
                                contadorComillas = 0;
                                //Verificar las rutas
                                //Contamos la cantidad de comillas que hay en la cadena
                                foreach (string cad in argumentos)
                                {
                                    if (cad.Contains("\""))
                                        contadorComillas++;
                                }
                                //Si las comillas existentes son 2 o 4 entonces continuamos, de otro modo, el argumento es inválido
                                if (contadorComillas == 2 || contadorComillas == 4)
                                {
                                    tmp1 = "";
                                    tmp2 = "";
                                    contadorComillas = 0;
                                    //Si el primer parámetro tiene comillas, entonces ese será la cadena con espacios
                                    if (argumentos[1].Contains("\""))
                                    {
                                        for (int i = 1; i < argumentos.Length; i++)
                                        {
                                            tmp1 += argumentos[i];
                                            if (i != argumentos.Length - 1)
                                                tmp1 += " ";
                                            if (i != 1)
                                            {
                                                if (argumentos[i].Contains("\""))
                                                    contadorComillas = i + 1;
                                                break;
                                            }
                                        }
                                        tmp1 = tmp1.Substring(1);
                                        tmp1 = tmp1.Remove(tmp1.Length - 2, 1);
                                    }//Si no exiten comillas, entonces ese es una sola cadena sin espacios
                                    else
                                    {
                                        tmp1 = argumentos[1];
                                        contadorComillas = 2;
                                    }
                                    //Revisamos si la otra ruta tiene espacios
                                    if (argumentos[contadorComillas].Contains("\""))
                                    {
                                        for (int i = contadorComillas; i < argumentos.Length; i++)
                                        {
                                            tmp2 += argumentos[i];
                                            if (i != argumentos.Length - 1)
                                                tmp2 += " ";
                                        }
                                        tmp2 = tmp2.Substring(1);
                                        tmp2 = tmp2.Remove(tmp2.Length - 1, 1);
                                    }
                                    else
                                    {
                                        tmp2 = argumentos[contadorComillas];
                                    }
                                    //Console.WriteLine("primera ruta: {0}", tmp1);
                                    //Console.WriteLine("segunda ruta: {0}", tmp2);
                                    if (ValidarRutas(tmp1, target) != "" && ValidarNoArchivo(tmp2, target) != "")
                                    {
                                        mover = new Objeto(tmp1, tmp2);
                                        mover.Mover();
                                    }
                                }
                                else
                                    Console.WriteLine("Uso: copy { rutaOrigen\\archivo | archivo } { rutaDestino\\archivo | archivo }");
                            }
                            break;
                        case "cls":
                            Console.Clear();
                            break;
                        case "history":
                            foreach (string cmd in historia)
                                Console.WriteLine(cmd);
                            break;
                        case "exit":
                            salir = false;
                            break;
                        default:
                            Console.WriteLine("No se reconoce el comando \"{0}\" o no existe.\n", tmp);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The process failed: {0}", e.ToString());
                }
            }
        }
    }
}

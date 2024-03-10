using Microsoft.VisualBasic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;

namespace ProyectoLabI
{
    internal class Program
    {
        struct Alumno
        {
            public int indice;
            public string nombre;
            public string apellido;
            public int dni;
            public string fecha;
            public string domicilio;
            public bool activo;
        }
        private static int contadorAlumnos = 0;
        struct Carrera
        {
            public int indice;
            public string nombre;
            public bool activa;
        }
        struct Materia
        {
            public int indice;
            public string nombre;
            public bool activa;
        }

        struct CarreraMateria
        {
            public int indiceCarrera;
            public int indiceMateria;
        }

        struct AlumnoMateria
        {
            public int indiceAlumno;
            public int indiceMateria;
            public string estado;
        }
        static void Main(string[] args)
        {
            // Declaro variables y rutas de archivos
            string opcion;
            string rutaDirectorio = @"c:\Lab1";
            string rutaAlumnos = @"c:\Lab1\alumnos.txt";
            string rutaCarreras = @"c:\Lab1\carreras.txt";
            string rutaCarreraAlumno = @"c:\Lab1\carrera_alumno.txt";
            string rutaMaterias = @"c:\Lab1\materias.txt";
            string rutaCarreraMaterias = @"c:\Lab1\carrera_materias.txt";
            string rutaAlumnoMaterias = @"c:\Lab1\alumno_materias.txt";

            //Verifico si existe el directorio y los archivos de trabajo. Si no existen los creo.
            if (!Directory.Exists(rutaDirectorio))
            {
                Directory.CreateDirectory(rutaDirectorio);
            }
            if (!File.Exists(rutaAlumnos))
            {
                using (StreamWriter crearArchivo = File.CreateText(rutaAlumnos)) { }
            }
            if (!File.Exists(rutaCarreras))
            {
                using (StreamWriter crearArchivo = File.CreateText(rutaCarreras)) { }
            }
            if (!File.Exists(rutaCarreraAlumno))
            {
                using (StreamWriter crearArchivo = File.CreateText(rutaCarreraAlumno)) { }
            }
            if (!File.Exists(rutaMaterias))
            {
                using (StreamWriter crearArchivo = File.CreateText(rutaMaterias)) { }
            }
            if (!File.Exists(rutaCarreraMaterias))
            {
                using (StreamWriter crearArchivo = File.CreateText(rutaCarreraMaterias)) { }
            }
            if (!File.Exists(rutaAlumnoMaterias))
            {
                using (StreamWriter crearArchivo = File.CreateText(rutaAlumnoMaterias)) { }
            }

            // INICIO //
            do
            {
                menuPrincipal();
                opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        do
                        {
                            Console.Clear();
                            menuAlumnos();
                            opcion = Console.ReadLine();
                            Console.WriteLine();

                            switch (opcion)
                            {
                                case "1":
                                    AltaAlumnos(rutaAlumnos);
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case "2":
                                    BajaAlumnos(rutaAlumnos);
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case "3":
                                    ModificarAlumnos(rutaAlumnos);
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case "4":
                                    Console.WriteLine("  _________________________________");
                                    Console.WriteLine(" |                                 |");
                                    Console.WriteLine(" |         ALUMNOS ACTIVOS         |");
                                    Console.WriteLine(" |_________________________________|");
                                    Console.WriteLine();
                                    MostrarAlumnos(rutaAlumnos, true);
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case "5":
                                    Console.WriteLine("  _________________________________");
                                    Console.WriteLine(" |                                 |");
                                    Console.WriteLine(" |        ALUMNOS INACTIVOS        |");
                                    Console.WriteLine(" |_________________________________|");
                                    Console.WriteLine();
                                    MostrarAlumnos(rutaAlumnos, false);
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case "6":
                                    Console.Clear();
                                    break;

                                default:
                                    Console.WriteLine("Opción inválida");
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para intentar nuevamente...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                            }
                        } while (opcion != "6");
                        break;

                    case "2":
                        do
                        {
                            Console.Clear();
                            menuCarreras();
                            opcion = Console.ReadLine();
                            Console.WriteLine();

                            switch (opcion)
                            {
                                case "1":
                                    AltaCarrera(rutaCarreras);
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case "2":
                                    BajaCarrera(rutaCarreras);
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case "3":
                                    Console.WriteLine("  _________________________________");
                                    Console.WriteLine(" |                                 |");
                                    Console.WriteLine(" |            CARRERAS             |");
                                    Console.WriteLine(" |_________________________________|");
                                    Console.WriteLine();
                                    MostrarCarreras(rutaCarreras);
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case "4":
                                    ModificarCarrera(rutaCarreras);
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case "5":
                                    AsociarCarreraConAlumno(rutaCarreras, rutaAlumnos, rutaCarreraAlumno);
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case "6":
                                    Console.Clear();
                                    break;

                                default:
                                    Console.WriteLine("Opción inválida");
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para intentar nuevamente...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                            }
                        } while (opcion != "6");
                        break;

                    case "3":
                        do
                        {
                            Console.Clear();
                            menuMaterias();
                            opcion = Console.ReadLine();
                            Console.WriteLine();

                            switch (opcion)
                            {
                                case "1":
                                    AltaMateria(rutaMaterias);
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case "2":
                                    BajaMateria(rutaMaterias);
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case "3":
                                    ModificarMateria(rutaMaterias);
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case "4":
                                    Console.WriteLine("  _________________________________");
                                    Console.WriteLine(" |                                 |");
                                    Console.WriteLine(" |            MATERIAS             |");
                                    Console.WriteLine(" |_________________________________|");
                                    Console.WriteLine();
                                    MostrarMaterias(rutaMaterias);
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case "5":
                                    AsociarMateriaCarrera(rutaMaterias, rutaCarreraMaterias, rutaCarreras);
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case "6":
                                    AsociarAlumnoMateria(rutaAlumnos, rutaMaterias, rutaAlumnoMaterias);
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para continuar...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;

                                case "7":
                                    Console.Clear();
                                    break;

                                default:
                                    Console.WriteLine("Opción inválida");
                                    Console.WriteLine();
                                    Console.WriteLine("Presione enter para intentar nuevamente...");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                            }
                        } while (opcion != "7");
                        break;

                    case "4":
                        Console.WriteLine("Saliendo...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida");
                        Console.WriteLine();
                        Console.WriteLine("Presione enter para intentar nuevamente...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            } while (opcion != "4");
        }

        static void menuPrincipal()
        {
            Console.WriteLine("  _________________________________");
            Console.WriteLine(" |                                 |");
            Console.WriteLine(" |              MENU               |");
            Console.WriteLine(" |_________________________________|");
            Console.WriteLine(" |                                 |");
            Console.WriteLine(" |   1. Administrar alumnos        |");
            Console.WriteLine(" |   2. Administrar carreras       |");
            Console.WriteLine(" |   3. Administrar materias       |");
            Console.WriteLine(" |   4. Salir del programa         |");
            Console.WriteLine(" |_________________________________|");
            Console.WriteLine();
            Console.Write("Ingrese la opción deseada: ");
        }

        static void menuAlumnos()
        {
            Console.WriteLine("  _________________________________");
            Console.WriteLine(" |                                 |");
            Console.WriteLine(" |             ALUMNOS             |");
            Console.WriteLine(" |_________________________________|");
            Console.WriteLine(" |                                 |");
            Console.WriteLine(" |   1. Alta de alumno             |");
            Console.WriteLine(" |   2. Baja de alumno             |");
            Console.WriteLine(" |   3. Modificación de alumno     |");
            Console.WriteLine(" |   4. Mostrar alumnos activos    |");
            Console.WriteLine(" |   5. Mostrar alumnos inactivos  |");
            Console.WriteLine(" |   6. Volver al menú principal   |");
            Console.WriteLine(" |_________________________________|");
            Console.WriteLine();
            Console.Write("Ingrese la opción deseada: ");
        }

        static void menuCarreras()
        {
            Console.WriteLine("  _________________________________");
            Console.WriteLine(" |                                 |");
            Console.WriteLine(" |            CARRERAS             |");
            Console.WriteLine(" |_________________________________|");
            Console.WriteLine(" |                                 |");
            Console.WriteLine(" |   1. Alta de carrera            |");
            Console.WriteLine(" |   2. Baja de carrera            |");
            Console.WriteLine(" |   3. Mostrar carreras           |");
            Console.WriteLine(" |   4. Modificación de carrera    |");
            Console.WriteLine(" |   5. Asociar carrera con alumno |");
            Console.WriteLine(" |   6. Volver al menú principal   |");
            Console.WriteLine(" |_________________________________|");
            Console.WriteLine();
            Console.Write("Ingrese la opción deseada: ");
        }

        static void menuMaterias()
        {
            Console.WriteLine("  _____________________________________________");
            Console.WriteLine(" |                                             |");
            Console.WriteLine(" |                 MATERIAS                    |");
            Console.WriteLine(" |_____________________________________________|");
            Console.WriteLine(" |                                             |");
            Console.WriteLine(" |  1. Alta de Materia                         |");
            Console.WriteLine(" |  2. Baja de Materia                         |");
            Console.WriteLine(" |  3. Modificación de Materia                 |");
            Console.WriteLine(" |  4. Mostrar Materias                        |");
            Console.WriteLine(" |  5. Asociar materia a carrera               |");
            Console.WriteLine(" |  6. Asociar materia a alumno                |");
            Console.WriteLine(" |  7. Volver al menú principal                |");
            Console.WriteLine(" |_____________________________________________|");
            Console.WriteLine();
            Console.Write("Ingrese la opción deseada: ");
        }

        static void IngresarDatosAlumno(out string nombre, out string apellido, out int dni, out string fecha, out string domicilio, out bool activo)
        {

            Console.Write("Nombre: ");
            nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            apellido = Console.ReadLine();

            Console.Write("DNI: ");
            while (!int.TryParse(Console.ReadLine(), out dni))
            {
                Console.WriteLine("Error: El DNI debe ser un número entero.");
                Console.Write("DNI: ");
            }

            DateTime fechaNacimiento = DateTime.MinValue;
            bool fechaValida = false;
            while (!fechaValida)
            {
                Console.Write("Fecha de Nacimiento (dd/MM/yyyy): ");
                string fechaIngresada = Console.ReadLine();
                fechaValida = DateTime.TryParseExact(fechaIngresada, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaNacimiento);
                if (!fechaValida)
                {
                    Console.WriteLine("Error: La fecha de nacimiento no es válida. Por favor, ingrese la fecha en el formato dd/MM/yyyy.");
                }
            }
            fecha = fechaNacimiento.ToString("dd/MM/yyyy");

            Console.Write("Domicilio: ");
            domicilio = Console.ReadLine();

            Console.Write("¿Es alumno regular? ('S' para sí o 'N' para no): ");
            string respuesta = Console.ReadLine();
            while (respuesta.ToUpper() != "S" && respuesta.ToUpper() != "N")
            {
                Console.WriteLine("Error: La respuesta debe ser 'S' para sí o 'N' para no.");
                Console.Write("¿Es alumno regular? ('S' para sí o 'N' para no): ");
                respuesta = Console.ReadLine();
            }
            activo = respuesta.ToUpper() == "S";
        }

        static void AltaAlumnos(string rutaAlumnos)
        {
            Console.WriteLine("  _________________________________");
            Console.WriteLine(" |                                 |");
            Console.WriteLine(" |          ALTA DE ALUMNO         |");
            Console.WriteLine(" |_________________________________|");
            Console.WriteLine();
            Console.WriteLine("Ingrese los datos del alumno que desea dar de alta:");
            Console.WriteLine();

            Alumno alumno = new Alumno();

            IngresarDatosAlumno(out alumno.nombre, out alumno.apellido, out alumno.dni, out alumno.fecha, out alumno.domicilio, out alumno.activo);

            try
            {
                bool dniExistente = false;

                using (StreamReader lector = new StreamReader(rutaAlumnos))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        string[] campos = linea.Split(',');

                        if (campos.Length >= 4 && int.TryParse(campos[3], out int dni) && dni == alumno.dni)
                        {
                            dniExistente = true;
                            break;
                        }
                    }
                }

                if (dniExistente)
                {
                    Console.WriteLine("Error: Ya existe un alumno con el mismo DNI.");
                    return;
                }

                int ultimoIndice = 0;

                if (File.Exists(rutaAlumnos))
                {
                    using (StreamReader lector = new StreamReader(rutaAlumnos))
                    {
                        string ultimaLinea = null;
                        string linea;
                        while ((linea = lector.ReadLine()) != null)
                        {
                            ultimaLinea = linea;
                        }

                        if (!string.IsNullOrEmpty(ultimaLinea))
                        {
                            string[] camposUltimaLinea = ultimaLinea.Split(',');

                            if (camposUltimaLinea.Length > 0 && int.TryParse(camposUltimaLinea[0], out int indice))
                            {
                                ultimoIndice = indice;
                            }
                        }
                    }
                }

                alumno.indice = ultimoIndice + 1;

                string nuevaLinea = $"{alumno.indice},{alumno.nombre},{alumno.apellido},{alumno.dni},{alumno.fecha},{alumno.domicilio},{alumno.activo}";

                using (StreamWriter guardar = new StreamWriter(rutaAlumnos, true))
                {
                    guardar.WriteLine(nuevaLinea);
                }

                Console.WriteLine("Alumno registrado exitosamente.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al guardar el alumno: {e.Message}");
            }
        }

        static void BajaAlumnos(string rutaAlumnos)
        {
            Console.WriteLine("  _________________________________");
            Console.WriteLine(" |                                 |");
            Console.WriteLine(" |          BAJA DE ALUMNO         |");
            Console.WriteLine(" |_________________________________|");
            Console.WriteLine();
            Console.Write("Ingrese el DNI del alumno a dar de baja: ");
            int dni;

            if (!int.TryParse(Console.ReadLine(), out dni))
            {
                Console.WriteLine("Error: El DNI debe ser un número entero.");
                return;
            }

            try
            {
                List<string> lineas = new List<string>();
                bool alumnoEncontrado = false;

                using (StreamReader lector = new StreamReader(rutaAlumnos))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        string[] campos = linea.Split(',');

                        if (campos.Length >= 4 && int.TryParse(campos[3], out int dniAlumno) && dniAlumno == dni)
                        {
                            lineas.Add(linea.Replace("True", "False"));
                            alumnoEncontrado = true;
                        }
                        else
                        {
                            lineas.Add(linea);
                        }
                    }
                }

                using (StreamWriter guardar = new StreamWriter(rutaAlumnos))
                {
                    foreach (string linea in lineas)
                    {
                        guardar.WriteLine(linea);
                    }
                }

                if (alumnoEncontrado)
                {
                    Console.WriteLine("Alumno dado de baja exitosamente.");
                }
                else
                {
                    Console.WriteLine("No se encontró ningún alumno con el DNI especificado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al dar de baja el alumno: {e.Message}");
            }
        }


        static void ModificarAlumnos(string rutaAlumnos)
        {
            Console.WriteLine("  _________________________________");
            Console.WriteLine(" |                                 |");
            Console.WriteLine(" |      MODIFICACIÓN DE ALUMNO     |");
            Console.WriteLine(" |_________________________________|");
            Console.WriteLine();
            Console.Write("Ingrese el DNI del alumno a modificar: ");
            int dni;

            if (!int.TryParse(Console.ReadLine(), out dni))
            {
                Console.WriteLine("Error: El DNI debe ser un número entero.");
                return;
            }

            try
            {
                List<string> lineas = new List<string>();

                using (StreamReader lector = new StreamReader(rutaAlumnos))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        string[] campos = linea.Split(',');

                        if (campos.Length >= 4 && int.TryParse(campos[3], out int dniAlumno) && dniAlumno == dni)
                        {
                            Alumno alumno = new Alumno();
                            alumno.indice = int.Parse(campos[0]);
                            alumno.nombre = campos[1];
                            alumno.apellido = campos[2];
                            alumno.dni = dniAlumno;
                            alumno.fecha = campos[4];
                            alumno.domicilio = campos[5];
                            alumno.activo = bool.Parse(campos[6]);

                            Console.WriteLine("Ingrese los nuevos datos del alumno:");
                            IngresarDatosAlumno(out alumno.nombre, out alumno.apellido, out alumno.dni, out alumno.fecha, out alumno.domicilio, out alumno.activo);

                            linea = $"{alumno.indice},{alumno.nombre},{alumno.apellido},{alumno.dni},{alumno.fecha},{alumno.domicilio},{alumno.activo}";
                        }

                        lineas.Add(linea);
                    }
                }

                using (StreamWriter guardar = new StreamWriter(rutaAlumnos))
                {
                    foreach (string linea in lineas)
                    {
                        guardar.WriteLine(linea);
                    }
                }

                Console.WriteLine("Alumno modificado exitosamente.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al modificar el alumno: {e.Message}");
            }
        }

        static void MostrarAlumnos(string rutaAlumnos, bool activos)
        {
            try
            {
                using (StreamReader lector = new StreamReader(rutaAlumnos))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        string[] campos = linea.Split(',');

                        if (campos.Length >= 7 && bool.TryParse(campos[6], out bool alumnoActivo) && alumnoActivo == activos)
                        {
                            Console.WriteLine("Indice, Nombre y Apellido, DNI, Fecha de nacimiento, Domicilio, Alumno activo");
                            Console.WriteLine($"{campos[0]}. {campos[1]} {campos[2]}, {campos[3]}, {campos[4]}, {campos[5]}, {campos[6]}");
                            Console.WriteLine();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al mostrar los alumnos: {e.Message}");
            }
        }

        static void AltaCarrera(string rutaCarreras)
        {
            Console.WriteLine("  _________________________________");
            Console.WriteLine(" |                                 |");
            Console.WriteLine(" |         ALTA DE CARRERA         |");
            Console.WriteLine(" |_________________________________|");
            Console.WriteLine();
            Console.Write("Ingrese el nombre de la carrera: ");
            string nombreCarrera = Console.ReadLine();
            if (CarreraExiste(rutaCarreras, nombreCarrera))
            {
                Console.WriteLine("La carrera ya existe.");
                Console.WriteLine("¿Desea cambiar el estado de la carrera a 'Activa'?");
                Console.WriteLine("Presione 'S' para sí o 'N' para no.");
                string opcionActiva = Console.ReadLine();
                return;
            }

            int siguienteIndice = ObtenerSiguienteIndice(rutaCarreras);

            Carrera nuevaCarrera = new Carrera()
            {
                indice = siguienteIndice,
                nombre = nombreCarrera,
                activa = true
            };

            using (StreamWriter guardar = File.AppendText(rutaCarreras))
            {
                guardar.WriteLine($"{nuevaCarrera.indice},{nuevaCarrera.nombre},{nuevaCarrera.activa}");
            }

            Console.WriteLine("Carrera creada exitosamente");
        }

        static bool CarreraExiste(string rutaCarreras, string nombreCarrera)
        {
            if (File.Exists(rutaCarreras))
            {
                string[] lineas = File.ReadAllLines(rutaCarreras);

                foreach (string linea in lineas)
                {
                    string[] campos = linea.Split(',');

                    if (campos.Length >= 2 && campos[1].Equals(nombreCarrera, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static int ObtenerSiguienteIndice(string rutaArchivo)
        {
            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);

                if (lineas.Length > 0)
                {
                    string[] campos = lineas[lineas.Length - 1].Split(',');

                    if (campos.Length >= 1 && int.TryParse(campos[0], out int indice))
                    {
                        return indice + 1;
                    }
                }
            }

            return 1;
        }

        static void BajaCarrera(string rutaCarreras)
        {
            Console.WriteLine("  _________________________________");
            Console.WriteLine(" |                                 |");
            Console.WriteLine(" |         BAJA DE CARRERA         |");
            Console.WriteLine(" |_________________________________|");
            Console.WriteLine();
            MostrarCarreras(rutaCarreras);
            Console.WriteLine();
            Console.Write("Ingrese el índice de la carrera a dar de baja: ");
            int indice;

            if (!int.TryParse(Console.ReadLine(), out indice))
            {
                Console.WriteLine("Error: El índice debe ser un número entero.");
                return;
            }

            try
            {
                List<string> lineas = new List<string>();
                bool carreraEncontrada = false;

                using (StreamReader lector = new StreamReader(rutaCarreras))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        string[] campos = linea.Split(',');

                        if (campos.Length >= 3 && int.TryParse(campos[0], out int indiceCarrera) && indiceCarrera == indice)
                        {
                            lineas.Add(linea.Replace("True", "False"));
                            carreraEncontrada = true;
                        }
                        else
                        {
                            lineas.Add(linea);
                        }
                    }
                }

                using (StreamWriter guardar = new StreamWriter(rutaCarreras))
                {
                    foreach (string linea in lineas)
                    {
                        guardar.WriteLine(linea);
                    }
                }

                if (carreraEncontrada)
                {
                    Console.WriteLine("Carrera dada de baja exitosamente.");
                }
                else
                {
                    Console.WriteLine("No se encontró ninguna carrera con el índice especificado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al dar de baja la carrera: {e.Message}");
            }
        }

        static List<Carrera> ObtenerCarreras(string rutaCarreras)
        {
            List<Carrera> carreras = new List<Carrera>();

            if (File.Exists(rutaCarreras))
            {
                string[] lineas = File.ReadAllLines(rutaCarreras);

                foreach (string linea in lineas)
                {
                    string[] campos = linea.Split(',');

                    if (campos.Length >= 3 && int.TryParse(campos[0], out int indice) && bool.TryParse(campos[2], out bool activa))
                    {
                        Carrera carrera = new Carrera()
                        {
                            indice = indice,
                            nombre = campos[1],
                            activa = activa
                        };

                        carreras.Add(carrera);
                    }
                }
            }
            return carreras;
        }

        static void GuardarCarreras(string rutaCarreras, List<Carrera> carreras)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(rutaCarreras))
                {
                    foreach (Carrera carrera in carreras)
                    {
                        writer.WriteLine($"{carrera.indice},{carrera.nombre},{carrera.activa}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar las carreras: {ex.Message}");
            }
        }
        static void MostrarCarreras(string rutaCarreras)
        {
            try
            {
                Console.WriteLine("Indice, Nombre de la carrera, ¿Activa?");
                using (StreamReader lector = new StreamReader(rutaCarreras))
                {
                    string linea;
                    while ((linea = lector.ReadLine()) != null)
                    {
                        string[] campos = linea.Split(',');

                        if (campos.Length >= 3 && int.TryParse(campos[0], out int indiceCarrera) && bool.TryParse(campos[2], out bool activa))
                        {
                            string estado = activa ? "Activa" : "Inactiva";
                            Console.WriteLine($"{indiceCarrera} - {campos[1]}, {estado}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al mostrar las carreras: {e.Message}");
            }
        }

        static void ModificarCarrera(string rutaCarreras)
        {
            Console.WriteLine("  _________________________________");
            Console.WriteLine(" |                                 |");
            Console.WriteLine(" |       MODIFICAR CARRERA         |");
            Console.WriteLine(" |_________________________________|");
            Console.WriteLine();
            MostrarCarreras(rutaCarreras);
            Console.WriteLine();
            Console.Write("Ingrese el índice de la carrera a modificar: ");
            int indice;

            if (!int.TryParse(Console.ReadLine(), out indice))
            {
                Console.WriteLine("Error: El índice debe ser un número entero.");
                return;
            }

            List<Carrera> carreras = ObtenerCarreras(rutaCarreras);
            Carrera carreraModificar = carreras.FirstOrDefault(c => c.indice == indice);

            if (carreraModificar.indice == 0)
            {
                Console.WriteLine("No se encontró ninguna carrera con el índice especificado.");
                return;
            }

            Console.Write("¿Desea cambiar el nombre de la carrera? (S/N): ");
            string opcionCambioNombre = Console.ReadLine();

            if (opcionCambioNombre.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write("Ingrese el nuevo nombre de la carrera: ");
                string nuevoNombre = Console.ReadLine();
                carreraModificar.nombre = nuevoNombre;
            }

            Console.Write("¿Desea cambiar el estado de la carrera 'Activa/Inactiva'? (S/N)");
            string opcionActiva = Console.ReadLine();

            if (opcionActiva.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                carreraModificar.activa = !carreraModificar.activa;
            }

            int indexModificar = carreras.FindIndex(c => c.indice == carreraModificar.indice);
            carreras[indexModificar] = carreraModificar;
            GuardarCarreras(rutaCarreras, carreras);
        }

        static void AsociarCarreraConAlumno(string rutaCarreras, string rutaAlumnos, string rutaCarreraAlumno)
        {
            Console.WriteLine("  _________________________________");
            Console.WriteLine(" |                                 |");
            Console.WriteLine(" |    ASOCIAR CARRERA CON ALUMNO   |");
            Console.WriteLine(" |_________________________________|");
            Console.WriteLine();
            MostrarCarreras(rutaCarreras);
            Console.WriteLine();
            Console.Write("Ingrese el índice de la carrera: ");
            if (!int.TryParse(Console.ReadLine(), out int indiceCarrera))
            {
                Console.WriteLine("Error: El índice debe ser un número entero.");
                return;
            }

            List<Carrera> carreras = ObtenerCarreras(rutaCarreras);
            Carrera carreraSeleccionada = carreras.FirstOrDefault(c => c.indice == indiceCarrera);

            if (carreraSeleccionada.indice == 0)
            {
                Console.WriteLine("No se encontró ninguna carrera con el índice especificado.");
                return;
            }

            Console.WriteLine("Carrera seleccionada: " + carreraSeleccionada.nombre);


            Console.Write("Ingrese el DNI del alumno: ");
            string dniAlumno = Console.ReadLine();

            // Verificar si el alumno existe
            if (!AlumnoExiste(rutaAlumnos, dniAlumno))
            {
                Console.WriteLine("El alumno no existe");
                return;
            }

            // Verificar si la asociación ya existe
            if (CarreraAlumnoExiste(rutaCarreraAlumno, dniAlumno, indiceCarrera))
            {
                Console.WriteLine("La asociación ya existe");
                return;
            }

            // Obtener el índice siguiente para la asociación
            int siguienteIndice = ObtenerSiguienteIndice(rutaCarreraAlumno);

            // Crear el objeto de la asociación
            string asociacion = $"{siguienteIndice},{dniAlumno},{indiceCarrera}";

            // Guardar la asociación en el archivo
            using (StreamWriter writer = File.AppendText(rutaCarreraAlumno))
            {
                writer.WriteLine(asociacion);
            }

            Console.WriteLine("Asociación creada exitosamente");
        }

        static bool AlumnoExiste(string rutaAlumnos, string dniAlumno)
        {
            if (File.Exists(rutaAlumnos))
            {
                string[] lineas = File.ReadAllLines(rutaAlumnos);

                foreach (string linea in lineas)
                {
                    string[] campos = linea.Split(',');

                    if (campos.Length >= 4 && campos[3].Equals(dniAlumno, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool CarreraAlumnoExiste(string rutaCarreraAlumno, string dniAlumno, int indiceCarrera)
        {
            if (File.Exists(rutaCarreraAlumno))
            {
                string[] lineas = File.ReadAllLines(rutaCarreraAlumno);

                foreach (string linea in lineas)
                {
                    string[] campos = linea.Split(',');

                    if (campos.Length >= 3 && campos[1].Equals(dniAlumno, StringComparison.OrdinalIgnoreCase) && campos[2].Equals(indiceCarrera.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static void AltaMateria(string ruta)
        {
            List<Materia> materias = LeerMaterias(ruta);

            Materia nuevaMateria;
            nuevaMateria.indice = materias.Count + 1;

            Console.WriteLine("  _________________________________");
            Console.WriteLine(" |                                 |");
            Console.WriteLine(" |         ALTA DE MATERIA         |");
            Console.WriteLine(" |_________________________________|");
            Console.Write("Nombre de la materia: ");
            nuevaMateria.nombre = Console.ReadLine();
            nuevaMateria.activa = true;

            materias.Add(nuevaMateria);
            GuardarMaterias(materias, ruta);

            Console.WriteLine();
            Console.WriteLine("Materia agregada exitosamente");
        }

        static void BajaMateria(string ruta)
        {
            List<Materia> materias = LeerMaterias(ruta);

            Console.WriteLine("  _________________________________");
            Console.WriteLine(" |                                 |");
            Console.WriteLine(" |         BAJA DE MATERIA         |");
            Console.WriteLine(" |_________________________________|");
            Console.WriteLine();
            Console.WriteLine("Lista de materias:");
            Console.WriteLine();
            MostrarMaterias(ruta);
            Console.WriteLine();
            Console.Write("Indice de la materia a dar de baja: ");
            int indiceMateria = int.Parse(Console.ReadLine()) - 1;

            if (indiceMateria >= 0 && indiceMateria < materias.Count)
            {
                Materia materia = materias[indiceMateria];

                if (materia.activa)
                {
                    materia.activa = false;
                    materias[indiceMateria] = materia;
                    GuardarMaterias(materias, ruta);

                    Console.WriteLine();
                    Console.WriteLine("Materia dada de baja exitosamente");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("La materia ya está dada de baja");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Indice de materia inválido");
            }
        }

        static void ModificarMateria(string ruta)
        {
            List<Materia> materias = LeerMaterias(ruta);

            Console.WriteLine("  _________________________________");
            Console.WriteLine(" |                                 |");
            Console.WriteLine(" |       MODIFICAR MATERIA         |");
            Console.WriteLine(" |_________________________________|");
            Console.WriteLine();
            Console.WriteLine("Lista de materias:");
            MostrarMaterias(ruta);
            Console.WriteLine();
            Console.Write("Indice de la materia a modificar: ");
            int indiceMateria = int.Parse(Console.ReadLine()) - 1;

            if (indiceMateria >= 0 && indiceMateria < materias.Count)
            {
                Materia materia = materias[indiceMateria];

                Console.Write("¿Desea cambiar el nombre de la materia? (S/N): ");
                string opcionCambioNombre = Console.ReadLine();

                if (opcionCambioNombre.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Write("Nuevo nombre: ");
                    materia.nombre = Console.ReadLine();
                }

                Console.Write("¿Desea cambiar el estado de la materia? (S/N): ");
                string opcionActiva = Console.ReadLine();

                if (opcionActiva.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    materia.activa = !materia.activa;
                }

                materias[indiceMateria] = materia;
                GuardarMaterias(materias, ruta);

                Console.WriteLine();
                Console.WriteLine("Materia modificada exitosamente");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Índice de materia inválido");
            }
        }

        static void MostrarMaterias(string ruta)
        {
            List<Materia> materias = LeerMaterias(ruta);
            Console.WriteLine("Indice, Materia, Estado");
            foreach (Materia materia in materias)
            {
                Console.WriteLine($"{materia.indice}. {materia.nombre},{(materia.activa ? "Activa" : "Inactiva")}");
                Console.WriteLine();
            }
        }


        static void AsociarMateriaCarrera(string rutaMaterias, string rutaCarreraMaterias, string rutaCarreras)
        {
            List<Materia> materias = LeerMaterias(rutaMaterias);
            List<CarreraMateria> carreraMaterias = LeerCarreraMaterias(rutaCarreraMaterias);
            List<Carrera> carreras = ObtenerCarreras(rutaCarreras);

            Console.WriteLine("  _________________________________");
            Console.WriteLine(" |                                 |");
            Console.WriteLine(" |     ASOCIAR MATERIA A CARRERA   |");
            Console.WriteLine(" |_________________________________|");
            Console.WriteLine();
            Console.WriteLine("Lista de materias:");
            MostrarMaterias(rutaMaterias);
            Console.WriteLine();
            Console.Write("Indice de la materia a asociar: ");
            int indiceMateria = int.Parse(Console.ReadLine()) - 1;

            if (indiceMateria >= 0 && indiceMateria < materias.Count)
            {
                Console.WriteLine();
                Console.WriteLine("Lista de carreras:");
                MostrarCarreras(rutaCarreras);
                Console.WriteLine();
                Console.Write("Indice de la carrera a asociar: ");
                int indiceCarrera = int.Parse(Console.ReadLine()) - 1;

                if (indiceCarrera >= 0 && indiceCarrera < carreras.Count)
                {
                    CarreraMateria carreraMateria = new CarreraMateria();
                    carreraMateria.indiceCarrera = carreras[indiceCarrera].indice;
                    carreraMateria.indiceMateria = indiceMateria;

                    carreraMaterias.Add(carreraMateria);
                    GuardarCarreraMaterias(carreraMaterias, rutaCarreraMaterias);

                    Console.WriteLine();
                    Console.WriteLine("Materia asociada a carrera exitosamente");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Índice de carrera inválido");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Índice de materia inválido");
            }
        }

        static void AsociarAlumnoMateria(string rutaAlumnos, string rutaMaterias, string rutaAlumnoMateria)
        {
            List<Materia> materias = LeerMaterias(rutaMaterias);
            List<AlumnoMateria> alumnoMaterias = LeerAlumnoMaterias(rutaAlumnoMateria);

            Console.WriteLine("  __________________________________");
            Console.WriteLine(" |                                 |");
            Console.WriteLine(" |   ASOCIAR ALUMNO A MATERIA       |");
            Console.WriteLine(" |_________________________________|");
            Console.WriteLine();
            Console.WriteLine("Lista de alumnos:");
            MostrarAlumnos(rutaAlumnos, true);
            Console.WriteLine();
            Console.Write("Ingrese el DNI del alumno a asociar: ");
            int dni = int.Parse(Console.ReadLine());

            bool alumnoExiste = AlumnoExiste(rutaAlumnos, dni.ToString());

            if (alumnoExiste)
            {
                Console.WriteLine();
                Console.WriteLine("Lista de materias:");
                MostrarMaterias(rutaMaterias);
                Console.WriteLine();
                Console.Write("Indice de la materia a asociar: ");
                int indiceMateria = int.Parse(Console.ReadLine()) - 1;

                if (indiceMateria >= 0 && indiceMateria < materias.Count)
                {
                    AlumnoMateria alumnoMateria = new AlumnoMateria();
                    alumnoMateria.indiceAlumno = dni;
                    alumnoMateria.indiceMateria = indiceMateria;

                    alumnoMaterias.Add(alumnoMateria);
                    GuardarAlumnoMaterias(alumnoMaterias, rutaAlumnoMateria);

                    Console.WriteLine();
                    Console.WriteLine("Alumno asociado a materia exitosamente");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Indice de materia inválido");
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("No se encontró ningún alumno con el DNI especificado.");
            }
        }

        static List<Materia> LeerMaterias(string ruta)
        {
            List<Materia> materias = new List<Materia>();

            if (File.Exists(ruta))
            {
                string[] lineas = File.ReadAllLines(ruta);

                foreach (string linea in lineas)
                {
                    string[] campos = linea.Split(';');
                    Materia materia;
                    materia.indice = int.Parse(campos[0]);
                    materia.nombre = campos[1];
                    materia.activa = bool.Parse(campos[2]);
                    materias.Add(materia);
                }
            }

            return materias;
        }

        static void GuardarMaterias(List<Materia> materias, string ruta)
        {
            List<string> lineas = new List<string>();

            foreach (Materia materia in materias)
            {
                string linea = $"{materia.indice};{materia.nombre};{materia.activa}";
                lineas.Add(linea);
            }

            File.WriteAllLines(ruta, lineas);
        }

        static List<CarreraMateria> LeerCarreraMaterias(string ruta)
        {
            List<CarreraMateria> carreraMaterias = new List<CarreraMateria>();

            if (File.Exists(ruta))
            {
                string[] lineas = File.ReadAllLines(ruta);

                foreach (string linea in lineas)
                {
                    string[] campos = linea.Split(';');
                    CarreraMateria carreraMateria;
                    carreraMateria.indiceCarrera = int.Parse(campos[0]);
                    carreraMateria.indiceMateria = int.Parse(campos[1]);
                    carreraMaterias.Add(carreraMateria);
                }
            }

            return carreraMaterias;
        }

        static void GuardarCarreraMaterias(List<CarreraMateria> carreraMaterias, string ruta)
        {
            List<string> lineas = new List<string>();

            foreach (CarreraMateria carreraMateria in carreraMaterias)
            {
                string linea = $"{carreraMateria.indiceCarrera};{carreraMateria.indiceMateria}";
                lineas.Add(linea);
            }

            File.WriteAllLines(ruta, lineas);
        }

        static List<AlumnoMateria> LeerAlumnoMaterias(string ruta)
        {
            List<AlumnoMateria> alumnoMaterias = new List<AlumnoMateria>();

            if (File.Exists(ruta))
            {
                string[] lineas = File.ReadAllLines(ruta);

                foreach (string linea in lineas)
                {
                    string[] campos = linea.Split(';');
                    AlumnoMateria alumnoMateria;
                    alumnoMateria.indiceAlumno = int.Parse(campos[0]);
                    alumnoMateria.indiceMateria = int.Parse(campos[1]);
                    alumnoMateria.estado = campos[2];
                    alumnoMaterias.Add(alumnoMateria);
                }
            }

            return alumnoMaterias;
        }

        static void GuardarAlumnoMaterias(List<AlumnoMateria> alumnoMaterias, string ruta)
        {
            List<string> lineas = new List<string>();

            foreach (AlumnoMateria alumnoMateria in alumnoMaterias)
            {
                string linea = $"{alumnoMateria.indiceAlumno};{alumnoMateria.indiceMateria};{alumnoMateria.estado}";
                lineas.Add(linea);
            }

            File.WriteAllLines(ruta, lineas);
        }
    }
}
using System;
using System.Collections.Generic;

namespace ProyectoEmprendimientos
{
    class Departamento
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }

    class IntegranteEquipo
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Rol { get; set; }
        public string Email { get; set; }
    }

    class IdeaDeNegocio
    {
        public int ContadorDepartamentos { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Impacto { get; set; }
        public List<Departamento> DepartamentosBeneficiados { get; set; }
        public int ValorInversion { get; set; }
        public int Ingresos3Anios { get; set; }
        public List<IntegranteEquipo> IntegrantesEquipo { get; set; }
        public List<string> Herramientas4RI { get; set; } 
        public decimal Rentabilidad { get; set; }

    }


    public class ProyectoIdeas
    {
        static List<IdeaDeNegocio> ideasDeNegocio = new List<IdeaDeNegocio>();
        static int codigoActual = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al programa de registro de ideas de negocio");

            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\nMenú de opciones:");
                Console.WriteLine("1. Ingresar idea de negocio");
                Console.WriteLine("2. Agregar integrantes al equipo");
                Console.WriteLine("3. Eliminar integrantes del equipo");
                Console.WriteLine("4. Modificar valor de inversión");
                Console.WriteLine("5. Modificar total de ingresos en los primeros 3 años");
                Console.WriteLine("6. Mostrar resumen de ideas de negocio");
                Console.WriteLine("7. Mostrar idea de negocio que impacte más departamentos");
                Console.WriteLine("8. Mostrar idea de negocio con mayor ingresos en los primeros 3 años");
                Console.WriteLine("9. Mostrar 3 ideas con mayor rentabilidad");
                Console.WriteLine("10.Mostrar ideas que impacten a 3 departamentos o más");
                Console.WriteLine("11.Mostrar suma total de ingresos de las ideas");
                Console.WriteLine("12.Suma total de la inversión que se debe hacer en todas las ideas de negocio.");
                Console.WriteLine("13.Mostrar idea con mas herramientas de la 4RI utilizadas");
                Console.WriteLine("14.Mostrar numero de ideas que tienen inteligencia artificial");
                Console.WriteLine("15.Salir");
                Console.Write("Por favor, seleccione una opción (1-15): ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            IngresarIdeaDeNegocio();
                            break;
                        case 2:
                            AgregarIntegrantes();
                            break;
                        case 3:
                            EliminarIntegrantes();
                            break;
                        case 4:
                            ModificarValorInversion();
                            break;
                        case 5:
                            ModificarTotalIngresos();
                            break;
                        case 6:
                            MostrarResumenIdeasNegocio();
                            break;
                        case 7:
                            MostrarIdeaConMasDepartamentos();
                            break;
                        case 8:
                            MostrarIdeaMayorIngresos();
                            break;
                        case 9:
                            MostrarIdeasNegocioRentabilidad();
                            break;
                        case 10:
                            MostrarIdeasImpactanMasTresDepartamentos();
                            break;
                        case 11:
                            MostrarSumaTotalIngresos();
                            break;
                        case 12:
                            MostrarSumaTotalInversion();
                            break;
                        case 13:
                            MostrarIdeaConMasHerramientas4RI();
                            break;
                        case 14:
                            MostrarCantidadIdeasConInteligenciaArtificial();
                            break;
                        case 15:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                }
            }
        }

        static void IngresarIdeaDeNegocio()
        {
            Console.WriteLine("Ingresando nueva idea de negocio...");

            string nuevoCodigo = GenerarCodigoUnico();

            Console.Write("Ingrese el nombre de la idea de negocio: ");
            string nombreIdea = Console.ReadLine();

            Console.Write("Ingrese el impacto social o económico que genera: ");
            string impacto = Console.ReadLine();

            IdeaDeNegocio nuevaIdea = new IdeaDeNegocio();

            List<Departamento> departamentosBeneficiados = CapturarDepartamentos(nuevaIdea);

            int valorInversion;
            bool valorValido = false;
            do
            {
                Console.Write("Ingrese el valor de la inversión: ");
                string valorInversionStr = Console.ReadLine();

                if (int.TryParse(valorInversionStr, out valorInversion) && valorInversion > 0)
                {
                    valorValido = true;
                }
                else
                {
                    Console.WriteLine("Error: Ingrese un valor de inversión válido y mayor que cero.");
                }
            } while (!valorValido);

            int ingresos3Anios;
            bool ingresosValidos = false;
            do
            {
                Console.Write("Ingrese el total de ingresos a generar en los primeros 3 años: ");
                string ingresos3AniosStr = Console.ReadLine();

                if (int.TryParse(ingresos3AniosStr, out ingresos3Anios) && ingresos3Anios >= 0)
                {
                    ingresosValidos = true;
                }
                else
                {
                    Console.WriteLine("Error: Ingrese un total de ingresos válido (puede ser cero o más).");
                }
            } while (!ingresosValidos);

            List<IntegranteEquipo> integrantesEquipo = CapturarIntegrantesEquipo();
            
            Console.Write("Ingrese las herramientas de la Cuarta Revolución Industrial utilizadas (separadas por coma): ");
            string herramientas4RIInput = Console.ReadLine();

            string[] herramientas4RI = herramientas4RIInput.Split(',');


            foreach (string herramienta4RI in herramientas4RI)
            {
                if (nuevaIdea.Herramientas4RI == null)
                {
                    nuevaIdea.Herramientas4RI = new List<string>();
                }
                nuevaIdea.Herramientas4RI.Add(herramienta4RI.Trim()); // Agregar cada herramienta a la lista
            }


            ideasDeNegocio.Add(new IdeaDeNegocio
            {
                Codigo = codigoActual,
                Nombre = nombreIdea,
                Impacto = impacto,
                DepartamentosBeneficiados = departamentosBeneficiados,
                ValorInversion = valorInversion,
                Ingresos3Anios = ingresos3Anios,
                IntegrantesEquipo = integrantesEquipo,
                Herramientas4RI = nuevaIdea.Herramientas4RI // Asignar la lista de herramientas
            });


            codigoActual++;

            Console.WriteLine("¡Idea de negocio registrada exitosamente!");
        }


        static string GenerarCodigoUnico()
        {
            string codigo = $"COD{codigoActual:D4}";
            return codigo;
        }

        static List<Departamento> CapturarDepartamentos(IdeaDeNegocio idea)
        {
            List<Departamento> departamentos = new List<Departamento>();

            Console.WriteLine("Ingrese los departamentos beneficiados (Ingrese 'fin' para finalizar)");

            while (true)
            {
                Console.Write("Código del departamento (o 'fin' para finalizar): ");
                string codigo = Console.ReadLine();

                if (codigo.ToLower() == "fin")
                    break;

                Console.Write("Nombre del departamento: ");
                string nombre = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(codigo) && !string.IsNullOrWhiteSpace(nombre))
                {
                    Departamento departamento = new Departamento { Codigo = codigo, Nombre = nombre };
                    departamentos.Add(departamento);

                    // Incrementar el contador de departamentos en la idea de negocio
                    idea.ContadorDepartamentos++;
                }
                else
                {
                    Console.WriteLine("Error: Código y nombre de departamento no pueden estar vacíos.");
                }
            }

            return departamentos; // Devolver la lista de departamentos capturados
        }




        static List<IntegranteEquipo> CapturarIntegrantesEquipo()
        {
            List<IntegranteEquipo> integrantes = new List<IntegranteEquipo>();

            Console.WriteLine("Ingrese los integrantes del equipo (Ingrese 'fin' para finalizar)");

            while (true)
            {
                Console.Write("Identificación del integrante: ");
                string identificacion = Console.ReadLine();

                if (identificacion.ToLower() == "fin")
                    break;

                Console.Write("Nombre del integrante: ");
                string nombre = Console.ReadLine();

                Console.Write("Apellidos del integrante: ");
                string apellidos = Console.ReadLine();

                Console.Write("Rol del integrante: ");
                string rol = Console.ReadLine();

                Console.Write("Email del integrante: ");
                string email = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(identificacion) && !string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(apellidos) && !string.IsNullOrWhiteSpace(rol) && !string.IsNullOrWhiteSpace(email))
                {
                    integrantes.Add(new IntegranteEquipo
                    {
                        Identificacion = identificacion,
                        Nombre = nombre,
                        Apellidos = apellidos,
                        Rol = rol,
                        Email = email
                    });
                }
                else
                {
                    Console.WriteLine("Error: Todos los campos del integrante deben ser completados.");
                }
            }

            return integrantes;
        }

        static void AgregarIntegrantes()
        {
            Console.WriteLine("Agregando integrantes al equipo...");
            Console.Write("Ingrese el código de la idea de negocio: ");
            int codigoIdea = int.Parse(Console.ReadLine());

            // Buscar la idea de negocio correspondiente en la lista
            IdeaDeNegocio idea = ideasDeNegocio.Find(i => i.Codigo == codigoIdea);

            if (idea != null)
            {
                // Permitir al usuario ingresar datos de los nuevos integrantes
                List<IntegranteEquipo> nuevosIntegrantes = CapturarIntegrantesEquipo();

                // Agregar los nuevos integrantes a la lista de la idea de negocio
                idea.IntegrantesEquipo.AddRange(nuevosIntegrantes);

                Console.WriteLine("Integrantes agregados exitosamente.");
            }
            else
            {
                Console.WriteLine("Idea de negocio no encontrada.");
            }
        }

        static void EliminarIntegrantes()
        {
            Console.WriteLine("Eliminando integrantes del equipo...");
            Console.Write("Ingrese el código de la idea de negocio: ");
            int codigoIdea = int.Parse(Console.ReadLine());

            // Buscar la idea de negocio correspondiente en la lista
            IdeaDeNegocio idea = ideasDeNegocio.Find(i => i.Codigo == codigoIdea);

            if (idea != null)
            {
                // Mostrar la lista de integrantes y permitir seleccionar cuáles eliminar
                Console.WriteLine("Integrantes actuales del equipo:");
                foreach (IntegranteEquipo integrante in idea.IntegrantesEquipo)
                {
                    Console.WriteLine($"{integrante.Identificacion} - {integrante.Nombre} {integrante.Apellidos}");
                }

                Console.Write("Ingrese las identificaciones de los integrantes a eliminar (separadas por coma): ");
                string identificacionesEliminar = Console.ReadLine();

                string[] identificaciones = identificacionesEliminar.Split(',');

                foreach (string identificacion in identificaciones)
                {
                    IntegranteEquipo integranteEliminar = idea.IntegrantesEquipo.Find(i => i.Identificacion == identificacion.Trim());

                    if (integranteEliminar != null)
                    {
                        idea.IntegrantesEquipo.Remove(integranteEliminar);
                        Console.WriteLine($"Integrante {identificacion} eliminado.");
                    }
                    else
                    {
                        Console.WriteLine($"Integrante {identificacion} no encontrado.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Idea de negocio no encontrada.");
            }
        }

        static void ModificarValorInversion()
        {
            Console.WriteLine("Modificando valor de inversión...");
            Console.Write("Ingrese el código de la idea de negocio: ");
            int codigoIdea = int.Parse(Console.ReadLine());

            // Buscar la idea de negocio correspondiente en la lista
            IdeaDeNegocio idea = ideasDeNegocio.Find(i => i.Codigo == codigoIdea);

            if (idea != null)
            {
                // Solicitar el nuevo valor de inversión y validarlo
                int nuevoValorInversion;
                bool valorValido = false;

                do
                {
                    Console.Write("Ingrese el nuevo valor de inversión: ");
                    string nuevoValorInversionStr = Console.ReadLine();

                    if (int.TryParse(nuevoValorInversionStr, out nuevoValorInversion) && nuevoValorInversion > 0)
                    {
                        valorValido = true;
                    }
                    else
                    {
                        Console.WriteLine("Error: Ingrese un valor de inversión válido y mayor que cero.");
                    }
                } while (!valorValido);

                // Actualizar el valor de inversión en la idea de negocio
                idea.ValorInversion = nuevoValorInversion;

                Console.WriteLine("Valor de inversión modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("Idea de negocio no encontrada.");
            }
        }

        static void ModificarTotalIngresos()
        {
            Console.WriteLine("Modificando total de ingresos en los primeros 3 años...");
            Console.Write("Ingrese el código de la idea de negocio: ");
            int codigoIdea = int.Parse(Console.ReadLine());

            // Buscar la idea de negocio correspondiente en la lista
            IdeaDeNegocio idea = ideasDeNegocio.Find(i => i.Codigo == codigoIdea);

            if (idea != null)
            {
                // Solicitar el nuevo total de ingresos en los primeros 3 años y validarlo
                int nuevoIngresos3Anios;
                bool ingresosValidos = false;

                do
                {
                    Console.Write("Ingrese el nuevo total de ingresos en los primeros 3 años: ");
                    string nuevoIngresos3AniosStr = Console.ReadLine();

                    if (int.TryParse(nuevoIngresos3AniosStr, out nuevoIngresos3Anios) && nuevoIngresos3Anios >= 0)
                    {
                        ingresosValidos = true;
                    }
                    else
                    {
                        Console.WriteLine("Error: Ingrese un total de ingresos válido (puede ser cero o más).");
                    }
                } while (!ingresosValidos);

                // Actualizar el total de ingresos en los primeros 3 años en la idea de negocio
                idea.Ingresos3Anios = nuevoIngresos3Anios;

                Console.WriteLine("Total de ingresos en los primeros 3 años modificado exitosamente.");
            }
            else
            {
                Console.WriteLine("Idea de negocio no encontrada.");
            }
        }

        static void MostrarIdeaConMasDepartamentos()
        {
            if (ideasDeNegocio.Count == 0)
            {
                Console.WriteLine("No hay ideas de negocio registradas.");
                return;
            }

            IdeaDeNegocio maxDepartamentos = ideasDeNegocio.OrderByDescending(idea => idea.ContadorDepartamentos).First();

            Console.WriteLine("Idea de negocio que impacta a más departamentos:");
            Console.WriteLine($"Código: {maxDepartamentos.Codigo}");
            Console.WriteLine($"Nombre: {maxDepartamentos.Nombre}");
            Console.WriteLine($"Impacto: {maxDepartamentos.Impacto}");
        }

        static void MostrarIdeaMayorIngresos()
        {
            if (ideasDeNegocio.Count == 0)
            {
                Console.WriteLine("No hay ideas de negocio registradas.");
                return;
            }

            IdeaDeNegocio ideaMayorIngresos = ideasDeNegocio.OrderByDescending(idea => idea.Ingresos3Anios).First();

            Console.WriteLine("Idea de negocio con mayor total de ingresos en los primeros 3 años:");
            Console.WriteLine($"Código: {ideaMayorIngresos.Codigo}");
            Console.WriteLine($"Nombre: {ideaMayorIngresos.Nombre}");
            Console.WriteLine($"Impacto: {ideaMayorIngresos.Impacto}");
            Console.WriteLine($"Total de Ingresos en los Primeros 3 Años: {ideaMayorIngresos.Ingresos3Anios:C}");
        }


        static void MostrarResumenIdeasNegocio()
        {
            Console.WriteLine("Resumen de ideas de negocio registradas:");

            foreach (var idea in ideasDeNegocio)
            {
                Console.WriteLine($"Código: {idea.Codigo}");
                Console.WriteLine($"Nombre: {idea.Nombre}");
                Console.WriteLine($"Impacto: {idea.Impacto}");
                Console.WriteLine("Departamentos Beneficiados:");
                foreach (var departamento in idea.DepartamentosBeneficiados)
                {
                    Console.WriteLine($"  - Código: {departamento.Codigo}, Nombre: {departamento.Nombre}");
                }
                Console.WriteLine($"Valor de Inversión: {idea.ValorInversion:C}");
                Console.WriteLine($"Total de Ingresos en los Primeros 3 Años: {idea.Ingresos3Anios:C}");

                Console.WriteLine("Integrantes del Equipo:");
                foreach (var integrante in idea.IntegrantesEquipo)
                {
                    Console.WriteLine($"  - Identificación: {integrante.Identificacion}");
                    Console.WriteLine($"    Nombre: {integrante.Nombre} {integrante.Apellidos}");
                    Console.WriteLine($"    Rol: {integrante.Rol}");
                    Console.WriteLine($"    Email: {integrante.Email}");
                }
                Console.WriteLine("Herramientas de la 4RI utilizadas:");
                foreach (var herramienta in idea.Herramientas4RI)
                {
                    Console.WriteLine($"  - {herramienta}");
                }

            }
        }

        static decimal CalcularRentabilidad(IdeaDeNegocio idea)
        {
            // Calcular la rentabilidad restando la inversión de los ingresos a 3 años
            return idea.Ingresos3Anios - idea.ValorInversion;
        }

        static void MostrarIdeasNegocioRentabilidad()
        {
            if (ideasDeNegocio.Count == 0)
            {
                Console.WriteLine("No hay ideas de negocio registradas.");
                return;
            }


            Console.WriteLine("Resumen de ideas de negocio registradas:");

            // Calcular la rentabilidad de cada idea de negocio
            ideasDeNegocio.ForEach(idea => idea.Rentabilidad = CalcularRentabilidad(idea));

            // Ordenar la lista de ideas por rentabilidad de forma descendente
            List<IdeaDeNegocio> ideasOrdenadasPorRentabilidad = ideasDeNegocio.OrderByDescending(idea => idea.Rentabilidad).ToList();

            // Mostrar las 3 ideas de negocio más rentables
            int contador = 1;
            foreach (var idea in ideasOrdenadasPorRentabilidad.Take(3))
            {
                Console.WriteLine($"Idea de negocio más rentable #{contador}:");
                Console.WriteLine($"Nombre: {idea.Nombre}");
                Console.WriteLine($"Rentabilidad: {idea.Rentabilidad:C}");
                Console.WriteLine("----------------------------------------");
                contador++;
            }
        }

        static void MostrarIdeasImpactanMasTresDepartamentos()
        {
            Console.WriteLine("Ideas de negocio que impactan a más de 3 departamentos:");

            foreach (var idea in ideasDeNegocio)
            {
                if (idea.ContadorDepartamentos > 3)
                {
                    Console.WriteLine($"Nombre: {idea.Nombre}");
                }
            }
        }

        static void MostrarSumaTotalIngresos()
        {
            decimal sumaTotalIngresos = ideasDeNegocio.Sum(idea => idea.Ingresos3Anios);

            Console.WriteLine($"La suma total de ingresos de todas las ideas de negocio es: {sumaTotalIngresos:C}");
        }

        static void MostrarSumaTotalInversion()
        {
            decimal sumaTotalInversion = ideasDeNegocio.Sum(idea => idea.ValorInversion);
            Console.WriteLine($"Suma total de inversión en todas las ideas de negocio: {sumaTotalInversion:C}");
        }

        static void MostrarCantidadIdeasConInteligenciaArtificial()
        {
            string herramientaBuscada = "Inteligencia Artificial";

            int cantidadIdeasConIA = ideasDeNegocio.Count(idea =>
                idea.Herramientas4RI.Any(herramienta => herramienta.ToLower().Contains(herramientaBuscada.ToLower()))
            );

            Console.WriteLine($"Cantidad de ideas de negocio con {herramientaBuscada}: {cantidadIdeasConIA}");
        }

        static void MostrarIdeaConMasHerramientas4RI()
        {
            if (ideasDeNegocio.Count == 0)
            {
                Console.WriteLine("No hay ideas de negocio registradas.");
                return;
            }

            // Encuentra la idea con la mayor cantidad de herramientas 4RI
            IdeaDeNegocio ideaConMasHerramientas4RI = ideasDeNegocio.OrderByDescending(idea => idea.Herramientas4RI.Count).First();

            Console.WriteLine("Idea de negocio con más herramientas 4RI:");
            Console.WriteLine($"Nombre de la idea: {ideaConMasHerramientas4RI.Nombre}");

            Console.WriteLine("Integrantes del Equipo:");
            foreach (var integrante in ideaConMasHerramientas4RI.IntegrantesEquipo)
            {
                Console.WriteLine($"  - Identificación: {integrante.Identificacion}");
                Console.WriteLine($"    Nombre: {integrante.Nombre} {integrante.Apellidos}");
                Console.WriteLine($"    Rol: {integrante.Rol}");
                Console.WriteLine($"    Email: {integrante.Email}");
            }

            Console.WriteLine($"Cantidad de Herramientas 4RI: {ideaConMasHerramientas4RI.Herramientas4RI.Count}");
        }

    }
}

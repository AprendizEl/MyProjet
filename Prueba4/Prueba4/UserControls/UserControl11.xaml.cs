using MathNet.Numerics.LinearAlgebra.Factorization;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RestSharp;
using System.Drawing;
using Prueba4.Clases;
using Newtonsoft.Json.Linq;
using RiotSharp;
using RiotSharp.Endpoints.SummonerEndpoint;
using RiotSharp.Misc;



namespace Prueba4.UserControls
{
    /// <summary>
    /// Lógica de interacción para UserControl11.xaml
    /// </summary>
    public partial class UserControl11 : UserControl
    {

        private static readonly HttpClient client = new HttpClient();

        private readonly string _apiKey = "RGAPI-589a97fd-f7bf-4461-98f0-04a138bcc5ca";

        public UserControl11()
        {
            InitializeComponent();
            // Cargar automáticamente la información del invocador al iniciar
            Loaded += SummonerControl_Loaded;
        }

        private async void SummonerControl_Loaded(object sender, RoutedEventArgs e)
        {
            string summonerName = "Manute"; // Reemplaza con el nombre del invocador que deseas buscar
            await LoadSummonerDataAsync(summonerName);
        }

        private async Task LoadSummonerDataAsync(string summonerName)
        {
            string apiKey = "RGAPI-589a97fd-f7bf-4461-98f0-04a138bcc5ca";

            // Inicializa el cliente RiotSharp
            var riotApi = RiotApi.GetDevelopmentInstance(apiKey);

            // Nombre del invocador que quieres consultar
            summonerName = "NpcPromedio";

            try
            {
                // Verifica que la clave de API no esté vacía
                if (string.IsNullOrEmpty(apiKey))
                {
                    throw new ArgumentException("La clave de API no puede estar vacía.");
                }

                // Inicializa el cliente RiotSharp con tu clave de API


                // Verifica que la clave de API es válida
                if (riotApi == null)
                {
                    throw new ArgumentException("Clave de API inválida o mal configurada.");
                }

                // Verifica que el nombre del invocador no esté vacío
                if (string.IsNullOrEmpty(summonerName))
                {
                    throw new ArgumentException("El nombre del invocador no puede estar vacío.");
                }

                // Verifica que la región es válida
                var region = RiotSharp.Misc.Region.Lan;
                if (!Enum.IsDefined(typeof(RiotSharp.Misc.Region), region))
                {
                    throw new ArgumentException("La región especificada no es válida.");
                }

                // Obtiene la información del invocador en la región LAS (Latinoamérica Sur)
                var summoner = await riotApi.Summoner.GetSummonerByNameAsync(region, summonerName);

                // Verifica que se obtuvo un resultado válido
                if (summoner == null)
                {
                    throw new Exception("No se encontró el invocador con el nombre especificado en la región proporcionada.");
                }

                // Imprime la información del invocador
                Console.WriteLine($"Nombre: {summoner.Name}");
                Console.WriteLine($"Nivel: {summoner.Level}");
            }
            catch (RiotSharpException ex)
            {
                Console.WriteLine($"Error en la API de Riot: {ex.HttpStatusCode}, {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error en los argumentos: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }
}
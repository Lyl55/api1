using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using api1.Models.NewFolder;
using api1.Models.PlanetModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PatternContexts;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace ConsoleWebApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Type a number for operation\n1 for list\n2 for details\n3 for add\n4 for update\n5 for delete\n");
                int x = Convert.ToInt32(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        ListAll();
                        break;
                    case 2:
                        Details();
                        break;
                    case 3:
                        Create();
                        break;
                    case 4:
                        Update();
                        break;
                    case 5:
                        Delete();
                        break;
                        default:
                        throw new NotSupportedException();
                }

                Console.WriteLine("************************************");
            }

            static void ListAll()
            {
                HttpClient cln = new HttpClient();
                var res=cln.GetAsync("http://192.168.134.174:5000/Planet/Planets").Result;
                res.EnsureSuccessStatusCode();//cavab verib-vermediyini yoxlayir
                string cont = res.Content.ReadAsStringAsync().Result;//cavabin kontentini oxuyur
                IEnumerable<PlanetModel> planets = JsonConvert.DeserializeObject<IEnumerable<PlanetModel>>(cont);
                foreach (var item in planets)
                {
                    Console.WriteLine($"[{item.Id}]: [{item.Name}]");
                }
            }

            static void Details()
            {
                Console.Write("Enter id:");
                int id = Convert.ToInt32(Console.ReadLine());
                var clnt = new HttpClient();
                //var content = new StringContent()
                var result = clnt.GetAsync("http://192.168.134.174:5000/Planet/Planet/id?id=" + id).Result;
                result.EnsureSuccessStatusCode();
                string rawcontent = result.Content.ReadAsStringAsync().Result;
                var model = JsonConvert.DeserializeObject<PlanetDetailModel>(rawcontent);
                Console.WriteLine("id: "+model.Id);
                Console.WriteLine("Name: "+model.Name);
                Console.WriteLine("HasWater: "+model.HasWater);
                Console.WriteLine("IsLivable: "+model.Livable);
                Console.WriteLine("PlanetarySystem: "+model.PlanetarySystem);

            }

            static void Create()
            {
                CreatePlanetModel model = new CreatePlanetModel();
                Console.WriteLine("Name:");
                model.Name = Console.ReadLine();
                Console.WriteLine("PlanetarySystem:");
                model.PlanetarySystem = Console.ReadLine();
                Console.WriteLine("HasWater:");
                model.HasWater = Convert.ToBoolean(Console.ReadLine());
                Console.WriteLine("IsLivable:");
                model.Livable = Convert.ToBoolean(Console.ReadLine());
                string bodyJson = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(bodyJson, Encoding.UTF8, "application/json");//json gonderdiyimi bildirirem
                HttpClient client = new HttpClient();
                var res=client.PostAsync("http://192.168.134.174:5000/Planet/Add",content).Result;
                res.EnsureSuccessStatusCode();
                Console.WriteLine("Successfully created");
            }


            static void Update()
            {
                Console.Write("Enter id for update:");
                int id = Convert.ToInt32(Console.ReadLine());
                UpdatePlanetModel model = new UpdatePlanetModel();
                model.PlanetId = id;
                Console.WriteLine("Name:");
                model.Name = Console.ReadLine();
                Console.WriteLine("PlanetarySystem:");
                model.PlenatarySystem = Console.ReadLine();
                Console.WriteLine("HasWater:");
                model.HasWater = Convert.ToBoolean(Console.ReadLine());
                Console.WriteLine("IsLivable:");
                model.Livable = Convert.ToBoolean(Console.ReadLine());
                string bodyJson = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(bodyJson, Encoding.UTF8, "application/json");//json gonderdiyimi bildirirem
                HttpClient client = new HttpClient();
                var res = client.PostAsync("http://192.168.134.174:5000/Planet/Update", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    Console.WriteLine("Successfully updated");
                }
                else
                {
                    Console.WriteLine("Error!");
                }

            }
            static void Delete()
            {
                Console.Write("Enter id for delete:");
                int id = Convert.ToInt32(Console.ReadLine());
                var model = new DeletePlanetRequest();
                model.Id = id;
                string bodyJson = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(bodyJson, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                var res = client.PostAsync("http://192.168.134.174:5000/Planet/Delete",content).Result;
                if (res.IsSuccessStatusCode)
                {
                    Console.WriteLine("Successfully deleted");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
        }

    }
}

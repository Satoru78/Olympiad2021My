using Olympiad2021My.Context;
using Olympiad2021My.Model;
using OlymWebServer.ApiModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace OlymWebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener server = new HttpListener();
            server.Prefixes.Add("http://localhost:21342/");

            JsonSerializerOptions options = new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) };
            server.Start();

            while (true)
            {
                HttpListenerContext context = server.GetContext();
                if (context.Request.HttpMethod == "GET")
                {
                    try
                    {
                        if (context.Request.RawUrl == "/api/clients/")
                        {
                            var clientList = Data.db.Client.ToList();
                            string response = JsonSerializer.Serialize(Data.db.Client.ToList().ConvertAll(c => new ResponseClient(c)), options);
                            byte[] data = Encoding.UTF8.GetBytes(response);
                            context.Response.ContentType = "application/json;charset=utd-8";
                            using (Stream stream = context.Response.OutputStream)
                            {
                                context.Response.StatusCode = 200;
                                stream.Write(data, 0, data.Length);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        context.Response.StatusCode = 400;
                        context.Response.Close();

                    }
                }
                else if (context.Request.HttpMethod == "PUT")
                {
                    try
                    {
                        if (context.Request.RawUrl == "/api/clients/")
                        {
                            if (context.Request.ContentType == "application/json")
                            {
                                string request = "";        
                                byte[] data = new byte[context.Request.ContentLength64];
                                using (Stream stream = context.Request.InputStream)
                                {                           
                                    stream.Read(data, 0, data.Length);
                                }
                                request = UTF8Encoding.UTF8.GetString(data);
                                var clientList = JsonSerializer.Deserialize<List<ResponseClient>>(request);
                                foreach (var item in clientList)
                                {
                                    Client client = new Client();
                                    client.FirstName = item.FirstName;
                                    client.LastName = item.LastName;
                                    client.Patronymic = item.Patronymic;
                                    client.Birthday = item.Birthday;
                                    client.RegistrationDate = item.RegistrationDate;
                                    client.Email = item.Email;
                                    client.Phone = item.Phone;
                                    client.GenderCode = item.GenderCode;
                                    Data.db.Client.Add(client);
                                }
                                Data.db.SaveChanges();
                                context.Response.StatusCode = 200;
                                context.Response.Close();
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        context.Response.StatusCode = 400;
                        context.Response.Close();
                    }
                }
                else if(context.Request.HttpMethod == "PUT")
                {
                    try
                    {
                        if (context.Request.QueryString.Count == 1)
                        {
                            if (context.Request.QueryString.Keys[0] == "id")
                            {
                                int id = Convert.ToInt32(context.Request.QueryString.Get(0));
                                var currentClient = Data.db.Client.FirstOrDefault(c => c.ID == id);
                                if (currentClient != null)
                                {
                                    Data.db.Client.Remove(currentClient);
                                    Data.db.SaveChanges();
                                    context.Response.StatusCode = 200;
                                    context.Response.Close();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        context.Response.StatusCode = 400;
                        context.Response.Close();
                    }
                }
            }
        }
    }
}

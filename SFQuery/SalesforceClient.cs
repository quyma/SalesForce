using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
 




namespace SfQuery
{
    public class SalesforceClient
    {
        private const string LOGIN_ENDPOINT = "https://login.salesforce.com/services/oauth2/token";
        private const string API_ENDPOINT = "/services/data/v36.0/";
        private const string API_ENDPOINT_APEX = "/services/apexrest/comunidade";


        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AuthToken { get; set; }
        public string InstanceUrl { get; set; }

        static SalesforceClient()
        {
            // SF requires TLS 1.1 or 1.2
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
        }

        // TODO: use RestSharps
        public void Login()
        {
            String jsonResponse;
            HttpResponseMessage json2;
            using (var client = new HttpClient())
            {
                var request = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        {"grant_type", "password"},
                        {"client_id", "3MVG9mclR62wycM2v4K1sb_UZ0ZzvI417x79MJFeAsLZi2H0bbcMoyPvTZfsj9H4v3TZDR83Ol5gktbSl3vt7"},
                        {"client_secret", "1913044141285210362"},
                        {"username", Username},
                        {"password","maskarab8@nkkp9j5QAwFEUh7fNPRQGZUaB"}
                    }
                );
                request.Headers.Add("X-PrettyPrint", "1");

                var response = client.PostAsync(LOGIN_ENDPOINT, request).Result;
                Console.WriteLine("String Conexão login:" + LOGIN_ENDPOINT + request);
                jsonResponse = response.Content.ReadAsStringAsync().Result;
                 
            }
            Console.WriteLine($"Response: {jsonResponse}");
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);
            AuthToken = values["access_token"];
            InstanceUrl = values["instance_url"];

            //WebserviceComunidadePOST();
            //WebserviceComunidade();
              POST4ULTIMO();
            // POSTTEST3();
            //Post2SsalesForce();
            //WebserviceComunidade();
            // WebserviceComunidadePOST();
            // WebserviceComunidadePOST();
            //    Post2SsalesForce();

        }

        public string QueryEndpoints()
        {
            using (var client = new HttpClient())
            {
                string restQuery = InstanceUrl + API_ENDPOINT;
                var request = new HttpRequestMessage(HttpMethod.Get, restQuery);
                request.Headers.Add("Authorization", "Bearer " + AuthToken);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Add("X-PrettyPrint", "1");

                var response = client.SendAsync(request).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public string Describe(string sObject)
        {
            using (var client = new HttpClient())
            {
                string restQuery = InstanceUrl + API_ENDPOINT + "sobjects/" + sObject;
                var request = new HttpRequestMessage(HttpMethod.Get, restQuery);
                request.Headers.Add("Authorization", "Bearer " + AuthToken);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Add("X-PrettyPrint", "1");
                var response = client.SendAsync(request).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public string Query (string soqlQuery)
        {
            using (var client = new HttpClient())
            {
                string restRequest = InstanceUrl + API_ENDPOINT + "query/?q=" + soqlQuery;
                var request = new HttpRequestMessage(HttpMethod.Get, restRequest);
                request.Headers.Add("Authorization", "Bearer " + AuthToken);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Add("X-PrettyPrint", "1");
                var response = client.SendAsync(request).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public string WebserviceComunidade()
        {

            String abrechave = "{";
            String fechchave = "}";

            String aspa = "\"";

           /* String Corpo = abrechave +
                aspa + "Name" + aspa + ":" +
                aspa + "Vendas Virtual" + aspa + "," + // Nome da comunidade
                aspa + "Squad" + aspa + ":" +
                aspa + "Sales III" + aspa + "," + // Nome da Squad
                aspa + "TamanhoSquad" + aspa + ":" +
                aspa + "13" + aspa + "," + // Tamanho da Squad
                aspa + "Maturidade" + aspa + ":" +
                aspa + "79%" + aspa + "," + // Maturidade
                aspa + "TamanhoBacklog" + aspa + ":" +
                aspa + "25" + aspa + "," + // Tamanho do BackLog
                aspa + "QtdProjetos" + aspa + ":" +
                aspa + "17" + aspa + "," + // Quantidade de Projetos
                aspa + "QtdWorkItem" + aspa + ":" +
                aspa + "35" + aspa + "," + // Quantidade de Workitem
                aspa + "NrDO" + aspa + ":" +
                aspa + "10" + aspa + "," + // Numero de tarefas no DO
                aspa + "NrDOING" + aspa + ":" +
                aspa + "18" + aspa + "," + // Numero de tarefas no DOING
                aspa + "NrDONE" + aspa + ":" +
                aspa + "7" + aspa + "," + // Numero de tarefas no DONE 
                aspa + "Impedimento" + aspa + ":" +
                aspa + "4" + aspa         // Numero de impedimentos  

            + fechchave;
            */
            using (var client = new HttpClient())
            {
                String jsonResponse;
                string restRequest = InstanceUrl + "/services/apexrest/comunidade";
                var request = new HttpRequestMessage(HttpMethod.Get, restRequest);
                request.Headers.Add("Authorization", "Bearer " + AuthToken);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Add("X-PrettyPrint", "1");
                var response = client.SendAsync(request).Result;
                Console.WriteLine("String Conexão:"+request);
                jsonResponse = response.Content.ReadAsStringAsync().Result;

                Console.WriteLine($"Response: {jsonResponse}");

                // AuthToken = values["access_token"];

                var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);

                String quyma;

                quyma = values["quyma"];

                Console.WriteLine($"Response GET: {quyma}");

                return response.Content.ReadAsStringAsync().Result;

            }
        }

        public string WebserviceComunidadePOST()
        {

            String abrechave = "{";
            String fechchave = "}";

            String aspa = "''";//"\"";

            String Corpo = abrechave +
                 aspa + "Name" + aspa + ":" +
                 aspa + "Vendas Virtual" + aspa + "," + // Nome da comunidade
                 aspa + "Squad" + aspa + ":" +
                 aspa + "Sales III" + aspa + "," + // Nome da Squad
                 aspa + "TamanhoSquad" + aspa + ":" +
                 aspa + "13" + aspa + "," + // Tamanho da Squad
                 aspa + "Maturidade" + aspa + ":" +
                 aspa + "79%" + aspa + "," + // Maturidade
                 aspa + "TamanhoBacklog" + aspa + ":" +
                 aspa + "25" + aspa + "," + // Tamanho do BackLog
                 aspa + "QtdProjetos" + aspa + ":" +
                 aspa + "17" + aspa + "," + // Quantidade de Projetos
                 aspa + "QtdWorkItem" + aspa + ":" +
                 aspa + "35" + aspa + "," + // Quantidade de Workitem
                 aspa + "NrDO" + aspa + ":" +
                 aspa + "10" + aspa + "," + // Numero de tarefas no DO
                 aspa + "NrDOING" + aspa + ":" +
                 aspa + "18" + aspa + "," + // Numero de tarefas no DOING
                 aspa + "NrDONE" + aspa + ":" +
                 aspa + "7" + aspa + "," + // Numero de tarefas no DONE 
                 aspa + "Impedimento" + aspa + ":" +
                 aspa + "4" + aspa         // Numero de impedimentos  

             + fechchave;


            //joining together the json format string sample:"{"key":"valus"}";
            //                          TESTE                                //

            using (var client = new HttpClient())
            {
                string name = "teste";
                String jsonResponse;
                string restRequest = InstanceUrl + "/services/apexrest/comunidade"; //"{"+ aspa +"name"+ aspa +":"+ aspa + "oo"+aspa+"}";// + Corpo;


                // restRequest = "" + "https://inovacao-dev-ed.my.salesforce.com/services/apexrest/comunidade" + ", Version: 1.1, Content: " + "{" + "''" + "Name" + "''" + ":" + "''" + "Vendas Virtual" +"''"+","+"''" + "Squad" + "''" + ":" + "''" + "Sales III" + "''" + "," + "''" + "TamanhoSquad" + "''" + ":" + "''" + "13" + "''" + "," + "''" + "Maturidade" + "''" + ":" + "''" + "79%" + "''" +"," + "''" + "TamanhoBacklog"+"''"+":"+"''"+"25"+"''"+","+"''"+"QtdProjetos"+"''"+":"+"''"+"17"+"''"+","+"''"+"QtdWorkItem"+"''"+":"+"''"+"35"+"''"+","+"''"+"NrDO"+"''"+":"+"''"+"10"+"''"+","+"''"+"NrDOING"+"''"+":"+"''"+"18"+"''"+","+"''"+"NrDONE"+"''"+":"+"''"+"7"+"''"+","+"''"+"Impedimento"+"''"+":"+"''"+"4"+"''"+"}"+"''"+","+ "Headers"+":"+"{Authorization: Bearer 00D1N000002Jc1f!ARIAQJD4uBQB6eJwGkEXqN.A8K4JaTO0MCLMsLkAUoCjzJmercfP.aOgztWpiuX0zZxRJ8.01vE5q7zpdrvsRFNnhXUKMtSS Accept: application / json  X - PrettyPrint: 1}  }";


                string json = "{Name=9}";

                
               
                var request = new HttpRequestMessage(HttpMethod.Put,restRequest);
                // request.Headers.Add("Content", "{name:34}");
                // request.Content.Headers.Add("Name","Valor");
                request.Headers.Add("Authorization", "Bearer " + AuthToken);
                 

               // request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Add("X-PrettyPrint", "1");
                
             //   request.Headers.add = "application/json";
                // request.
                // string str = request.Content.ReadAsStringAsync().Result;
                // var request = HttpWebRequest.CreateHttp(restRequest);
                //"Body", "{\"name\":\"value\"}"




                var response = client.SendAsync(request).Result;

                Console.WriteLine("String Conexão:" + request);

                jsonResponse = response.Content.ReadAsStringAsync().Result;

                Console.WriteLine($"Response: {jsonResponse}");



                // AuthToken = values["access_token"];

                var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);

                String quyma;

                quyma = values["quyma"];

                Console.WriteLine($"Response GET: {quyma}");

                return response.Content.ReadAsStringAsync().Result;

            }


        }

        // POST 2
        
        // TODO: use RestSharps
        public void Post2SsalesForce()
        {
            String jsonResponse;
            string name;
            var authValue = new AuthenticationHeaderValue("Bearer", AuthToken);
            using (var client = new HttpClient() {
                DefaultRequestHeaders = { Authorization = authValue } })
             {

                var request = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        {"grant_type", "password"},
                        {"client_id", "3MVG9mclR62wycM2v4K1sb_UZ0ZzvI417x79MJFeAsLZi2H0bbcMoyPvTZfsj9H4v3TZDR83Ol5gktbSl3vt7"},
                        {"client_secret", "1913044141285210362"},
                        {"username", "quyma.viana@hotmail.com"},
                        {"password","maskarab8@nkkp9j5QAwFEUh7fNPRQGZUaB"}
                    }
           );

 

                request.Headers.Add("X-PrettyPrint", "1");
                 request.Headers.ContentType.MediaType = "application/json";
              //  request.Headers.ContentType = new MediaTypeHeaderValue("application/json");
               // request.Headers.ContentType.CharSet = "UTF-8";
                //var urlEncodedString = await request.ReadAsStringAsync();

                // request.Headers.deDefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                //request.Headers.ContentEncoding.Add =StringContent(Content.ToString(), Encoding.UTF8, "application/json";

                //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // request.Headers.Add("Authorization", "Bearer " + AuthToken);
                // request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



                var response = client.PostAsync(InstanceUrl + "/services/apexrest/comunidade", request).Result;
                // Create json for body
               // var content = new JObject(json);
               //  response.Content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");


              //  response.Headers.Add("Accept", "application/json");
               // response.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //request.Headers.Add("Authorization", AuthToken);
                //response.Headers.Add;
                jsonResponse = response.Content.ReadAsStringAsync().Result;
            }
            //Console.WriteLine($"POST2:" + reques);
            Console.WriteLine($"Response POST {jsonResponse}");


            var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);
      

            String quyma;

            quyma = values["quyma"];

            Console.WriteLine($"Response POST - Resultado: {quyma}");


        }


        // post teste 3
        public string POSTTEST3()
        {
            using (var client = new HttpClient())
            {
                string restQuery = InstanceUrl + API_ENDPOINT_APEX;
                var request = new HttpRequestMessage(HttpMethod.Post, restQuery);
                
                request.Headers.Add("Authorization", "Bearer " + AuthToken);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Add("X-PrettyPrint", "1");
                

                var response = client.SendAsync(request).Result;
                
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        // TODO: use RestSharps
        public void POST4ULTIMO()
        {
            String jsonResponse;
            String objeto;
            var authValue = new AuthenticationHeaderValue("Bearer", AuthToken);
            using (var client = new HttpClient()
            {
                DefaultRequestHeaders = { Authorization = authValue }
            })
            {
                /*var request = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        {"\"name\":", "value"}
                    }
                );*/

                var request = new FormUrlEncodedContent(new[]
   {
             new KeyValuePair<string, string>("name", "ovos")
        });


                String palavraJson = "{Name:45}";
                request.Headers.Add("X-PrettyPrint", "1");
                request.Headers.ContentType.MediaType = "application/json";

                var data = new
                {
                    Name = "Sales Quymã Viana"
                };

                // client.BaseAddress = new Uri(baseUri);

                var myContent = JsonConvert.SerializeObject(data);

                var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);

                var byteContent = new ByteArrayContent(buffer);

                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");



                var response = client.PostAsync(InstanceUrl+API_ENDPOINT_APEX, byteContent).Result;
                Console.WriteLine("String Conexão login POST4:" + InstanceUrl+API_ENDPOINT_APEX + request);
                jsonResponse = response.Content.ReadAsStringAsync().Result;
            }
            Console.WriteLine($"Response: {jsonResponse}");
            //  var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonResponse);
            //   AuthToken = values["access_token"];
            //    InstanceUrl = values["instance_url"];

            // teste outro metodo


 












        }




    }
}

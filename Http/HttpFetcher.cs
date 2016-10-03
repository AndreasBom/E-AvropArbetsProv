using E_AvropArbetsProv.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace E_AvropArbetsProv.Http
{
    public class HttpFetcher : IHttpFetcher
    {
        public IEnumerable<DataModel> GetData(string baseUrl, string apiUrl, string name, string date)
        {
            var objList = new List<DataModel>();
            try
            {
                using (var client = new HttpClient())
                {
                    //Setting base url
                    client.BaseAddress = new Uri(baseUrl);

                    //Get http response from api-url
                    var response = client.GetAsync(apiUrl).Result;

                    //Ensures response status code is 200 (OK)
                    response.EnsureSuccessStatusCode();

                    //Read json
                    var content = response.Content.ReadAsStringAsync().Result;

                    PopulateObjectsToList(objList, content);
                }

            }
            catch (HttpRequestException e)
            {
                //Showing error in console
                Console.WriteLine(e.ToString());
            }

            //Filter result to only contain selected name and date
            var splitDate = date.Split('-');
            var filteredResult = (from selected in objList
                                  where selected.Customer.Contains(name) &&
                                  selected.Date.Year == Convert.ToInt32(splitDate[0]) &&
                                  selected.Date.Month == Convert.ToInt32(splitDate[1])
                                  select selected).ToList();

            return filteredResult;
        }

        private void PopulateObjectsToList(ICollection<DataModel> objList, string content)
        {
            //Read string and converts to objects. Adding objects to objList

            var reader = new JsonTextReader(new StringReader(content))
            {
                SupportMultipleContent = true,
                Culture = CultureInfo.InvariantCulture,
                FloatParseHandling = FloatParseHandling.Double
            };

            while (reader.Read())
            {
                var serializer = new JsonSerializer { Culture = CultureInfo.InvariantCulture };
                var model = serializer.Deserialize<DataModel>(reader);
                objList.Add(model);
            }
            reader.Close();
        }
    }
}


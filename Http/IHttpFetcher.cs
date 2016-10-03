using E_AvropArbetsProv.Model;
using System.Collections.Generic;

namespace E_AvropArbetsProv.Http
{
    public interface IHttpFetcher
    {
        IEnumerable<DataModel> GetData(string baseUrl, string apiUrl, string name, string date);
    }
}
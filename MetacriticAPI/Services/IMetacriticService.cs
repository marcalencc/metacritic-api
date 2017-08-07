using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetacriticScraper.Interfaces;

namespace MetacriticAPI.Services
{
    public interface IMetacriticService
    {
        IMetacriticData[] GetResult(string id, string url);
        void ResponseChannel(string id, IMetacriticData[] reponses);
        string GetId();
    }
}

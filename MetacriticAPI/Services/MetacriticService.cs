using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MetacriticScraper.Scraper;
using MetacriticScraper.Interfaces;
using System.Threading;
using Newtonsoft.Json;

namespace MetacriticAPI.Services
{
    public class MetacriticService : IMetacriticService
    {
        private IScraper m_metacriticScraper;
        private Dictionary<string, ResponseItem> m_activeRequest;
        private object m_requestItemsLock;

        public MetacriticService(int limit)
        {
            m_metacriticScraper = new WebScraper(ResponseChannel, limit);
            m_activeRequest = new Dictionary<string, ResponseItem>();
            m_requestItemsLock = new object();
        }

        public IMetacriticData[] GetResult(string id, string url)
        {
            m_metacriticScraper.AddItem(id, url);

            ResponseItem item = new ResponseItem();
            lock (m_requestItemsLock)
            {
                m_activeRequest.Add(id, item);
            }
            item.WaitEvent.WaitOne(30000);

            return item.Response;
        }

        public string GetId()
        {
            return Guid.NewGuid().ToString();
        }

        public void ResponseChannel(string id, IMetacriticData[] responses)
        {
            bool existing = false;
            lock (m_requestItemsLock)
            {
                existing = m_activeRequest.ContainsKey(id);
            }

            if (existing)
            {
                lock (m_requestItemsLock)
                {
                    m_activeRequest[id].Response = responses;
                    m_activeRequest[id].WaitEvent.Set();
                    m_activeRequest.Remove(id);
                }
            }
        }

        private class ResponseItem
        {
            private IMetacriticData[] m_reponse;
            public IMetacriticData[] Response
            {
                get
                {
                    return m_reponse;
                }
                set
                {
                    m_reponse = value;
                }
            }

            private AutoResetEvent m_waitEvent;
            public AutoResetEvent WaitEvent
            {
                get
                {
                    return m_waitEvent;
                }
            }

            public ResponseItem()
            {
                m_waitEvent = new AutoResetEvent(false);
            }
        }
    }
}
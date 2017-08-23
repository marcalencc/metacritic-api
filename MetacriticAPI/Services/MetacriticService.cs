using System;
using System.Collections.Generic;
using System.Net;
using MetacriticScraper.Scraper;
using MetacriticScraper.Interfaces;
using MetacriticScraper.Errors;
using System.Threading;
using NLog;

namespace MetacriticAPI.Services
{
    public class MetacriticService : IMetacriticService
    {
        private IScraper m_metacriticScraper;
        private Dictionary<string, ResponseItem> m_activeRequest;
        private object m_requestItemsLock;
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        public MetacriticService(int limit)
        {
            m_metacriticScraper = new WebScraper(ResponseChannel, limit);
            m_activeRequest = new Dictionary<string, ResponseItem>();
            m_requestItemsLock = new object();
        }

        public IMetacriticData[] GetResult(string id, string url, string ip, out HttpStatusCode statusCode)
        {
            try
            {
                Logger.Info("Added request => IP: {0}, Url: {1}", ip, url);
                m_metacriticScraper.AddItem(id, url);
            }
            catch(SystemBusyException ex)
            {
                Logger.Error("Exception encountered {0}", ex.ToString());
                Error[] error = new Error[1];
                Error err = new Error(ex);
                error[0] = err;
                statusCode = HttpStatusCode.ServiceUnavailable;
                return error;
            }
            catch (InvalidUrlException ex)
            {
                Logger.Error("Exception encountered {0}", ex.ToString());
                Error[] error = new Error[1];
                Error err = new Error(ex);
                error[0] = err;
                statusCode = HttpStatusCode.NotFound;
                return error;
            }

            ResponseItem item = new ResponseItem();
            lock (m_requestItemsLock)
            {
                m_activeRequest.Add(id, item);
            }

            if (item.WaitEvent.WaitOne(30000))
            {
                statusCode = HttpStatusCode.OK;
            }
            else
            {
                statusCode = HttpStatusCode.ServiceUnavailable;
            }

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
            private IMetacriticData[] m_response;
            public IMetacriticData[] Response
            {
                get
                {
                    return m_response;
                }
                set
                {
                    m_response = value;
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
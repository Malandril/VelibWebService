using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace Velib
{
    public class Monitoring : IMonitoring
    {
        public int GetNbClientCalls(int n)
        {
            return Count(n, VelibIntermediary.Connections);
        }

        public int GetNbDistantRequest(int n)
        {
            return Count(n, VelibIntermediary.DistantRequests);
        }

        private static int Count(int n, List<DateTime> list)
        {
            if (n == 0)
            {
                return list.Count();
            }

            var t = TimeSpan.FromMinutes(n);
            var dateTime = DateTime.Now - t;
            return list.Count(time => time >= dateTime);
        }

        public List<string> GetNamesOfCachedItems()
        {
            return MemoryCache.Default.Select(pair => pair.Key).ToList();
        }
    }
}
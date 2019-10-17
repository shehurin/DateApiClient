using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Specialized;

namespace ClientWebApi
{
    class DateApiWorker
    {
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        private static readonly HttpClient client = new HttpClient();

        public DateApiWorker(string dateFrom, string dateTo)
        {
            DateFrom = Convert.ToDateTime(dateFrom).Date.ToString("yyyy'-'MM'-'dd");
            DateTo = Convert.ToDateTime(dateTo).Date.ToString("yyyy'-'MM'-'dd");
        }

        public async Task<bool> SendDatesAsync(string href)
        {
            var response = await client.PostAsync($"{href}{DateFrom}/{DateTo}", null);

            return true;
        }

        public async Task<Dictionary<string, string>> GetMatchesDatesAsync(string href)
        {
            Dictionary<string, string> returnedResult = new Dictionary<string, string>();

            var responseString = await client.GetStringAsync($"{href}{DateFrom}/{DateTo}");

            dynamic stuff = JsonConvert.DeserializeObject(responseString);

            foreach(var i in stuff)
            {
                returnedResult.Add(i.From.ToString(), i.To.ToString());
            }


            //string name = stuff.From;
            //string address = stuff.To;

            return returnedResult;
        }

    }
}

using NotesApplicationApi.Models;
using NotesApplicationApi.ModesApi;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;

namespace NotesApplicationApi.Services
{
    public class LogicHandler
    {
        /// <summary>
        /// This is the variable that holds the maxtemp or ?
        /// </summary>
        public string MaxTemp;
        /// <summary>
        /// this is the method for url, i stored the url in webconig appsettings
        /// </summary>
        /// <returns></returns>
        public WeatherApiUrl GetUrl()
        {
            WeatherApiUrl url = new WeatherApiUrl()
            {
                UrlApi = ConfigurationManager.AppSettings["urlapi"]
            };

            return url;
        }

        /// <summary>
        /// This were i get out json data from openweatherapi
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string GetJson(string uri)
        {
            string json = string.Empty;
            try
            {
                using (var webClient = new WebClient())
                {
                    using (var stream = webClient.OpenRead(uri))
                    {
                        using (var streamReader = new StreamReader(stream ?? throw new InvalidOperationException()))
                        {
                            json = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                throw new Exception(ex.Message);
            }
            return json;
        }


        /// <summary>
        /// This were i get out maxTemp
        /// </summary>
        /// <param name="root"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public string TempMaxvalue(RootObject root, DateTime date)
        {
            var today = DateTime.Now;
            var skipDay = today.AddDays(5);
            var connvertSkipDay = Convert.ToString(skipDay);
            var skipDaySub = connvertSkipDay.Substring(0, 10);
            var dateToday = DateTime.Now.ToShortDateString();
            var convertDateToday = Convert.ToString(dateToday);
            var dateTodaySubstring = convertDateToday.Substring(0, 10);
            var convertDate = Convert.ToString(date);
            var dateSubstring = convertDate.Substring(0, 10);

            var list = root.list.Where(x => x.dt_txt.StartsWith(dateSubstring.ToString()));
            string maxTemp = string.Empty;
            var maxTempList = new List<double>();

            var enumerable = list.ToList();
            if (enumerable.Any() && dateTodaySubstring != dateSubstring && skipDaySub != dateSubstring)
            {
                foreach (var item in enumerable)
                {
                    maxTempList.Add(item.main.temp);

                }

                double max = 0;
                max = maxTempList.Max(e => e);
                maxTemp = Convert.ToString(max);
            }
            else
                maxTemp = "?";

            return maxTemp;
        }
    }
}

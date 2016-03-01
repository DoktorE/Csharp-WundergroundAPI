using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace WunderAPI
{
    class WunderAPI
    {
        // URL: http://api.wunderground.com/api/Your_Key
        public string key { get; set; }

        /// <summary>
        /// Private method for handling requests
        /// </summary>
        /// <param name="endpoint">API endpoint</param>
        /// <param name="method">HTTP method type</param>
        /// <returns>Result of request</returns>
        private IRestResponse request(string endpoint, Method method)
        {
            RestClient client = new RestClient("http://api.wunderground.com/api/" + key + "/");
            var req = new RestRequest(endpoint, method);
            IRestResponse response = client.Execute(req);

            return response;
        }

        public IRestResponse getRadarBound(string fileFormat, string maxLat, string maxLon, string minLat, string minLon, string width, string height, string newMaps, bool animated = false)
        {
            // http://api.wunderground.com/api/Your_Key/radar/image.gif?maxlat=42.35&maxlon=-109.311&minlat=39.27&minlon=-114.644&width=600&height=480&newmaps=1
            string radar = "radar"; // trust me

            if (!animated) radar = "animatedradar";
            

            return request(radar + "/image." + fileFormat + "?maxlat=" + maxLat + "&maxlon=" + maxLon + "&minlat=" + minLat + "&minlon=" + minLon + "&width=" + width + "&height" + height + "newmaps=" + newMaps, Method.GET);
        }
    }
}

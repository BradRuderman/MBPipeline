using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace MB_Pipeline.Helper
{
    public class MapsHelper
    {


        public static bool UpdateCords(MB_Pipeline.Controllers.Models.Location location)
        {
            var address = location.address.Replace(' ', '+') + ',' + location.city.Replace(' ', '+') + ',' + location.state.Replace(' ', '+') + ' ' + location.zip_code;
            var result = get_coords_service(address);
            var obj = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(result);
            var r = false;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[usp_updateAddGeoCodes]";
                cmd.Parameters.Add("location_id", System.Data.SqlDbType.Int).Value = location.id;
                cmd.Parameters.Add("lat", System.Data.SqlDbType.NVarChar).Value = obj.results[0].geometry.location.lat;
                cmd.Parameters.Add("long", System.Data.SqlDbType.NVarChar).Value = obj.results[0].geometry.location.lng;
                r = MB_Pipeline.Helper.SqlHelper.ExecuteQuery(cmd);
            }
            return r;
        }

        private static string get_coords_service(string query)
        {
            string url = "http://maps.googleapis.com/maps/api/geocode/json?address={0}&sensor=false";
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create(string.Format(url, query));
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }

        public class GoogleGeoCodeResponse
        {

            public string status { get; set; }
            public results[] results { get; set; }

        }

        public class results
        {
            public string formatted_address { get; set; }
            public geometry geometry { get; set; }
            public string[] types { get; set; }
            public address_component[] address_components { get; set; }
        }

        public class geometry
        {
            public string location_type { get; set; }
            public location location { get; set; }
        }

        public class location
        {
            public string lat { get; set; }
            public string lng { get; set; }
        }

        public class address_component
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public string[] types { get; set; }
        }
    }
}

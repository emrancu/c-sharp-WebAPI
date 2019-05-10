using System;
using System.IO;
using System.Net;
using System.Text;

/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace WebAPI
{
  
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
     
    class RestClient
    {
        public string endPoin { get; set; }
        public httpVerb httpMethod { get; set; }
        public RestClient()
        {
            endPoin = string.Empty;
            httpMethod = httpVerb.GET;
        }

        public string makeRequest()
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoin);
            request.Method = httpMethod.ToString();

            using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if(response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("Error Code " + response.StatusCode.ToString());
                }

                using(Stream responseStream = response.GetResponseStream())
                {
                    if(responseStream != null)
                    {
                        using(StreamReader reader=new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            return strResponseValue;

        }
    }
}

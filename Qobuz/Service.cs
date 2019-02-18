using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Qobuz
{
    public class Service
    {
        private static string APP_ID = "100000000";
        private static string AUTH_TOKEN = string.Empty;        

        private HttpClient client = new HttpClient();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Login(string emailID, string password)
        {
            string _url = "https://www.qobuz.com/api.json/0.2/user/login";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", APP_ID);
            _paramsValue.Add("email", emailID);
            _paramsValue.Add("password", password);
                       
            string _parameterizedURL = CreateParameterizedQuery(_url, _paramsValue);

            var response = client.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                User user = JsonConvert.DeserializeObject<User>(result);
                return user;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// http://www.qobuz.com/api.json/0.2/album/search?app_id=100000000&query=John%20Cage&limit=2
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public List<Tracks> SearchTrack(string searchTerm, int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public bool CreatePlaylist(string name)
        {
            throw new NotImplementedException();
        }

        public bool CreatePlaylistWithItems(Playlist playlist)
        {
            throw new NotImplementedException();
        }

        public List<Playlist> GetUserPlaylist(int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public bool AddItemToPlaylist(Item item, Playlist playlist)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItemFromPlaylist(Item item, Playlist playlist)
        {
            throw new NotImplementedException();
        }

        private string CreateParameterizedQuery(string url, Dictionary<string,string> parameters)
        {
            string _paramQuery = string.Empty;

            foreach (var item in parameters)
            {
                _paramQuery +=  item.Key + "=" + item.Value + "&";
            }

            return url + "?" + _paramQuery.TrimEnd(new char[] {'&'});
        }
    }
}

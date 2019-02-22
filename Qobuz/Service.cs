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
        private static User _user;
        private HttpClient client = new HttpClient();

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
                _user = user;
                return user;
            }
            else
            {
                return null;
            }
        }
              
        public Tracks SearchTrack(string searchTerm, int offset, int limit)
        {
            string _url = "http://www.qobuz.com/api.json/0.2/track/search";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", APP_ID);
            _paramsValue.Add("query", searchTerm);
            if (offset > 0)
            {
                _paramsValue.Add("offset", offset.ToString());
            }
            if (limit != 0)
            {
                _paramsValue.Add("limit", limit.ToString());
            }

            string _parameterizedURL = CreateParameterizedQuery(_url, _paramsValue);

            var response = client.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                SearchTrackResult searchResult = JsonConvert.DeserializeObject<SearchTrackResult>(result);
                return searchResult.Tracks;
            }
            else
            {
                return null;
            }
        }

        public Playlist CreatePlaylist(string name)
        {
            if (_user == null)
            {
                return null;
            }

            string _url = "http://www.qobuz.com/api.json/0.2/playlist/create";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", APP_ID);
            _paramsValue.Add("name ", name);
            _paramsValue.Add("user_auth_token", _user.UserAuthToken);


            string _parameterizedURL = CreateParameterizedQuery(_url, _paramsValue);

            var response = client.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                Playlist searchResult = JsonConvert.DeserializeObject<Playlist>(result);
                return searchResult;
            }
            else
            {
                return null;
            }
        }

        public Playlist CreatePlaylistWithItems(string name, string trackIDCsv)
        {
            Playlist _playList = CreatePlaylist(name);
            if (_playList == null)
            {
                return null;
            }

            _playList = AddItemToPlaylist(_playList.Id, trackIDCsv);
            return _playList;
        }

        public Playlists GetUserPlaylist(int offset, int limit)
        {
            if (_user == null)
            {
                return null;
            }

            string _url = "http://www.qobuz.com/api.json/0.2/playlist/getUserPlaylists";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", APP_ID);
            _paramsValue.Add("user_id ", _user.Id.ToString());
            if (offset > 0)
            {
                _paramsValue.Add("offset", offset.ToString());
            }
            if (limit != 0)
            {
                _paramsValue.Add("limit", limit.ToString());
            }

            string _parameterizedURL = CreateParameterizedQuery(_url, _paramsValue);

            var response = client.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                PlayListResult searchResult = JsonConvert.DeserializeObject<PlayListResult>(result);
                return searchResult.Playlists;
            }
            else
            {
                return null;
            }

        }

        public Playlist AddItemToPlaylist(int playListID, string trackIDCsv)
        {
            if (_user == null)
            {
                return null;
            }

            string _url = "http://www.qobuz.com/api.json/0.2/playlist/addTracks";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", APP_ID);
            _paramsValue.Add("playlist_id", playListID.ToString());
            _paramsValue.Add("track_ids", trackIDCsv);
            _paramsValue.Add("user_auth_token", _user.UserAuthToken);

            string _parameterizedURL = CreateParameterizedQuery(_url, _paramsValue);

            var response = client.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                Playlist searchResult = JsonConvert.DeserializeObject<Playlist>(result);
                return searchResult;
            }
            else
            {
                return null;
            }
        }

        public bool RemoveItemFromPlaylist(int playListID, string trackIDCsv)
        {
            if (_user == null)
            {
                return false;
            }

            string _url = "http://www.qobuz.com/api.json/0.2/playlist/deleteTracks";
            Dictionary<string, string> _paramsValue = new Dictionary<string, string>();
            _paramsValue.Add("app_id", APP_ID);
            _paramsValue.Add("playlist_id", playListID.ToString());
            _paramsValue.Add("playlist_track_ids", trackIDCsv);
            _paramsValue.Add("user_auth_token", _user.UserAuthToken);

            string _parameterizedURL = CreateParameterizedQuery(_url, _paramsValue);

            var response = client.GetAsync(_parameterizedURL);
            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                return result.ToLower().Contains("success");
            }
            else
            {
                return false;
            }
        }

        private string CreateParameterizedQuery(string url, Dictionary<string, string> parameters)
        {
            string _paramQuery = string.Empty;

            foreach (var item in parameters)
            {
                _paramQuery += item.Key + "=" + item.Value + "&";
            }

            return url + "?" + _paramQuery.TrimEnd(new char[] { '&' });
        }
    }
}

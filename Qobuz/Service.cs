using System;
using System.Collections.Generic;
using System.Text;

namespace Qobuz
{
    public class Service
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Login(string emailID, string password)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// http://www.qobuz.com/api.json/0.2/album/search?app_id=100000000&query=John%20Cage&limit=2
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public List<Album> SearchAlbums(string searchTerm, int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public bool CreatePlaylist (string name)
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

        public bool AddItemToPlaylist(Item item,Playlist playlist)
        {
            throw new NotImplementedException();
        }

        public bool RemoveItemFromPlaylist(Item item, Playlist playlist)
        {
            throw new NotImplementedException();
        }
    }
}

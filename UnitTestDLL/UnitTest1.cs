using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qobuz;

namespace UnitTestDLL
{
    [TestClass]
    public class UnitTest1
    {
        string _testUsername = "test@test.com";
        string _testPassword = "testpassword";

        [TestMethod]
        public void Login()
        {
            Service service = new Service();
            User user;
            try
            {
                user = service.Login(_testUsername, _testPassword);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(user != null && !string.IsNullOrEmpty(user.UserAuthToken));
        }

        [TestMethod]
        public void SearchTrack()
        {
            Service service = new Service();
            Tracks tracks;
            try
            {
                tracks = service.SearchTrack("Hello", 0, 0);
            }
            catch
            {
                throw;
            }
            Assert.IsNotNull(tracks);
        }

        [TestMethod]
        public void CreatePlaylist()
        {
            Service service = new Service();

            User user;
            try
            {
                user = service.Login(_testUsername, _testPassword);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(user != null && !string.IsNullOrEmpty(user.UserAuthToken));

            Playlist playlist;
            try
            {
                playlist = service.CreatePlaylist("Sample Test");
            }
            catch
            {
                throw;
            }

            Assert.IsNotNull(playlist);
        }

        [TestMethod]
        public void CreatePlaylistWithItems()
        {
            Service service = new Service();

            User user;
            try
            {
                user = service.Login(_testUsername, _testPassword);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(user != null && !string.IsNullOrEmpty(user.UserAuthToken));

            Tracks tracks;
            try
            {
                tracks = service.SearchTrack("Hello", 0, 0);
            }
            catch
            {
                throw;
            }
            Assert.IsNotNull(tracks);

            Playlist playlist;
            try
            {
                playlist = service.CreatePlaylistWithItems("Sample Playlist", tracks.Items[0].Id.ToString());
            }
            catch
            {
                throw;
            }
            Assert.IsNotNull(playlist);
        }

        [TestMethod]
        public void GetUserPlaylist()
        {
            Service service = new Service();

            User user;
            try
            {
                user = service.Login(_testUsername, _testPassword);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(user != null && !string.IsNullOrEmpty(user.UserAuthToken));

            Playlists playlists;
            try
            {
                playlists = service.GetUserPlaylist(0, 0);
            }
            catch
            {
                throw;
            }
            Assert.IsNotNull(playlists);

        }

        [TestMethod]
        public void AddItemToPlaylist()
        {
            Service service = new Service();

            User user;
            try
            {
                user = service.Login(_testUsername, _testPassword);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(user != null && !string.IsNullOrEmpty(user.UserAuthToken));

            Playlists playlists;
            try
            {
                playlists = service.GetUserPlaylist(0, 0);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(playlists != null);

            Tracks tracks;
            try
            {
                tracks = service.SearchTrack("Hello", 0, 0);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(tracks != null);

            Playlist playlist;
            try
            {
                playlist = service.AddItemToPlaylist(playlists.Items[0].Id, tracks.Items[0].Id.ToString());
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(playlist != null);

        }

        [TestMethod]
        public void RemoveItemFromPlaylist()
        {
            Service service = new Service();

            User user;
            try
            {
                user = service.Login(_testUsername, _testPassword);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(user != null && !string.IsNullOrEmpty(user.UserAuthToken));

            Playlists playlists;
            try
            {
                playlists = service.GetUserPlaylist(0, 0);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(playlists != null);

            Tracks tracks;
            try
            {
                tracks = service.SearchTrack("Hello", 0, 0);
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(tracks != null);

            bool res;
            try
            {
                res = service.RemoveItemFromPlaylist(playlists.Items[0].Id, tracks.Items[0].Id.ToString());
            }
            catch
            {
                throw;
            }
            Assert.IsTrue(res);
              
        }
    }
}

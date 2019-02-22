using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qobuz;

namespace UnitTestDLL
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Login()
        {
            Service service = new Service();
            try
            {
                User user = service.Login("saif@gmail.com", "testpwd");

                Assert.IsTrue(user != null && !string.IsNullOrEmpty(user.UserAuthToken));
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void SearchTrack()
        {
            Service service = new Service();
            try
            {
                User user = service.Login("saif@gmail.com", "testpwd");

                Assert.IsTrue(user != null && !string.IsNullOrEmpty(user.UserAuthToken));

                Tracks tracks = service.SearchTrack("Hello", 0, 0);

                if (tracks == null)
                {
                    Assert.Fail();
                }
                else
                {
                    Assert.IsTrue(tracks.Total >= 0);
                }
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void CreatePlaylist()
        {
            Service service = new Service();
            try
            {
                User user = service.Login("saif@gmail.com", "testpwd");

                Assert.IsTrue(user != null && !string.IsNullOrEmpty(user.UserAuthToken));

                Playlist playlist = service.CreatePlaylist("Sample Test");

                Assert.IsTrue(playlist != null);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void CreatePlaylistWithItems()
        {
            Service service = new Service();
            try
            {
                User user = service.Login("saif@gmail.com", "testpwd");

                Assert.IsTrue(user != null && !string.IsNullOrEmpty(user.UserAuthToken));
               
                Tracks tracks = service.SearchTrack("Hello", 0, 0);

                Assert.IsTrue(tracks != null);

                Playlist playlist = service.CreatePlaylistWithItems("Sample Playlist", tracks.Items[0].Id.ToString());

                Assert.IsTrue(playlist != null);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void GetUserPlaylist()
        {
            Service service = new Service();
            try
            {
                User user = service.Login("saif@gmail.com", "testpwd");

                Assert.IsTrue(user != null && !string.IsNullOrEmpty(user.UserAuthToken));

                Playlists playlists = service.GetUserPlaylist(0,0);

                Assert.IsTrue(playlists != null);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void AddItemToPlaylist()
        {
            Service service = new Service();
            try
            {
                User user = service.Login("saif@gmail.com", "testpwd");

                Assert.IsTrue(user != null && !string.IsNullOrEmpty(user.UserAuthToken));

                Playlists playlists = service.GetUserPlaylist(0, 0);

                Assert.IsTrue(playlists != null);

                Tracks tracks = service.SearchTrack("Hello", 0, 0);

                Assert.IsTrue(tracks != null);

                Playlist playlist = service.AddItemToPlaylist(playlists.Items[0].Id, tracks.Items[0].Id.ToString());

                Assert.IsTrue(playlist != null);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void RemoveItemFromPlaylist()
        {
            Service service = new Service();
            try
            {
                User user = service.Login("saif@gmail.com", "testpwd");

                Assert.IsTrue(user != null && !string.IsNullOrEmpty(user.UserAuthToken));

                Playlists playlists = service.GetUserPlaylist(0, 0);

                Assert.IsTrue(playlists != null);

                Tracks tracks = service.SearchTrack("Hello", 0, 0);

                Assert.IsTrue(tracks != null);

                bool res = service.RemoveItemFromPlaylist(playlists.Items[0].Id, tracks.Items[0].Id.ToString());

                Assert.IsTrue(res);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediaManager.Models;
using System.Reflection;
using System.IO;
using System.Text;
using System.Data.Entity.Validation;
using MediaManager.Logging;

namespace MediaManager.DAL.SeedData
{

    public class MediaInitializer : System.Data.Entity.DropCreateDatabaseAlways<MediaContext>
    {
        protected override void Seed(MediaContext context)
        {
            var bs = new MediaSeeder(context);
            bs.Run();
        }
    }

    public class MediaSeeder
    {
        private IMediaContext _c;

        public MediaSeeder(IMediaContext context)
        {
            _c = context;
        }

        public void Run()
        {
            Actor actorMale = new Actor()
            {
                Name = "John Travolta",
                Sex = Sex.Male
            };
            Actor actorFemale = new Actor()
            {
                Name = "Uma Thurman",
                Sex = Sex.Female
            };
            _c.Add(actorMale);
            _c.Add(actorFemale);
            _c.SaveChanges();

            //Get IDs
            actorMale = _c.Query<Actor>().Single(a => a.Name == actorMale.Name);
            actorFemale = _c.Query<Actor>().Single(a => a.Name == actorFemale.Name);

            Genre genre = new Genre()
            {
                Name = "Hollywood"
            };
            _c.Add(genre);
            _c.SaveChanges();

            Serie videoSerie = new Serie()
            {
                Name = "Tarantino Epic Movies",
                SerieType = SerieType.VideoSerie
            };

            Serie photoSerie = new Serie()
            {
                Name = "Holiday Pictures",
                SerieType = SerieType.PhotoAlbum
            };
            _c.Add(videoSerie);
            _c.Add(photoSerie);
            _c.SaveChanges();

            Video vid = new Video()
            {
                Name = "Pulp Fiction"
            };
            _c.Add(vid);
            _c.SaveChanges();

            PhotoAlbum album = new PhotoAlbum()
            {
                Name = "Rome 2014",
                ItemCount = 20
            };
            _c.Add(album);
            _c.SaveChanges();

        }
    }
}
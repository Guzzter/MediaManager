using MediaManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace MediaManager.DAL
{
    public interface IMediaContext : IDisposable
    {
        IQueryable<T> Query<T>() where T : class;
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        int SaveChanges();
        void AddRange<T>(IEnumerable<T> entities) where T : class;
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
        int ExecuteSqlCommand(string sqlStatement, params object[] parameters);
        int ExecuteSqlCommand(string sqlStatement);

        DbRawSqlQuery<T> ExecuteSqlQuery<T>(string sqlStatement, params object[] parameters) where T : class;
        void LocalClear<T>() where T : class;
    }


    public class MediaContext : DbContext, IMediaContext
    {
        public MediaContext() : base("MediaManager")
        {

        }
        public DbSet<PhotoAlbum> PhotoAlbums { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            /*
            //Only need when no explicit model is created
            //Many to Many relationships: intermediate table MediaAuthors
            modelBuilder.Entity<Video>()
                .HasMany(b => b.Actor).WithMany(a => a.Videos)
                .Map(t => t.MapLeftKey("VideoID")
                    .MapRightKey("ActorID")
                    .ToTable("VideoActors"));

            //Many to Many relationships: intermediate table MediaSubjects
            modelBuilder.Entity<Media>()
                .HasMany(b => b.Subjects).WithMany(s => s.Medias)
                .Map(t => t.MapLeftKey("MediaID")
                    .MapRightKey("SubjectID")
                    .ToTable("MediaSubjects"));
            */
        }

        IQueryable<T> IMediaContext.Query<T>()
        {
            return Set<T>();
        }

        void IMediaContext.LocalClear<T>()
        {
            Set<T>().Local.Clear();
        }

        void IMediaContext.Add<T>(T entity)
        {
            Set<T>().Add(entity);
        }

        void IMediaContext.AddRange<T>(IEnumerable<T> entities)
        {
            Set<T>().AddRange(entities);
        }

        void IMediaContext.Update<T>(T entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        void IMediaContext.Remove<T>(T entity)
        {
            Set<T>().Remove(entity);
        }

        int IMediaContext.SaveChanges()
        {
            return SaveChanges();
        }

        IEnumerable<DbEntityValidationResult> IMediaContext.GetValidationErrors()
        {
            return GetValidationErrors();
        }

        int IMediaContext.ExecuteSqlCommand(string sqlStatement, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sqlStatement, parameters);
        }

        int IMediaContext.ExecuteSqlCommand(string sqlStatement)
        {
            return Database.ExecuteSqlCommand(sqlStatement);
        }

        DbRawSqlQuery<T> IMediaContext.ExecuteSqlQuery<T>(string sqlStatement, params object[] parameters)
        {
            return Database.SqlQuery<T>(sqlStatement, parameters);
        }
    }
}
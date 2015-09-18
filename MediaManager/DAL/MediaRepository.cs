using MediaManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaManager.DAL
{

    public interface IMediaRepository
    {
  
    }

    public class MediaRepository : IMediaRepository
    {
        private MediaContext db;
        public void SetContext(MediaContext MediaContext)
        {
            db = MediaContext;
        }
        

        
    }
}
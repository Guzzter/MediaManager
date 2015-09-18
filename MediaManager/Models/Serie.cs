using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediaManager.Models
{
    public enum SerieType
    {

        PhotoAlbum,
        VideoSerie
    }

    public class Serie
    {
        public int SerieID { get; set; }

        #region Commmon Properties
        [Required]
        public string Name { get; set; }

        [Display(Name = "Alternative Name")]
        public string AlternativeName { get; set; }

        [Range(0, 5)]
        public int? Rating { get; set; }

        [Url]
        public string WebLink { get; set; }

        public string CoverPhoto { get; set; }
        public string CoverThumbnail { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Create Date")]
        public DateTime? CreationDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Modified Date")]
        public DateTime? LastModifiedDate { get; set; }
        #endregion

        #region Entity specific properties
        [Required]
        [Display(Name = "Type")]
        public SerieType SerieType { get; set; }
        #endregion

        #region Navigational properties
        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBundleMobile.Models
{
    public class POCArticle
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int DisplayOrder { get; set; }



        public DateTime DateCreated { get; set; }

        public IList<Newsfeedcategory> Newsfeedcategories { get; set; }

        public IEnumerable<Link> Links { get; set; }

        public IEnumerable<Attachment> Attachments { get; set; }

        public string ItemGuid { get; set; }

        public int ContentTypeId { get; set; }
    }
}

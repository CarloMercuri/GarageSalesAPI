using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Data.Models
{
    public class GarageItemComment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public int ItemId { get; set; }

        public GarageItemComment(string text)
        {
            this.Text = text;    
        }

        public GarageItemComment(string text, int id)
        {
            this.CommentId = id;
            this.Text = text;
        }
    }
}
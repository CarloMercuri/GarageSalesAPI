using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Processing.Models
{
    public class SalesItemComment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }

        public SalesItemComment()
        {

        }

        public SalesItemComment(string commentText)
        {
            this.CommentText = commentText;
        }

        public SalesItemComment(string commentText, int commentId)
        {
            this.CommentId = commentId;
            this.CommentText = commentText;
        }
    }
}
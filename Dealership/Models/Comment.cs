
using Dealership.Models.Contracts;
using System.Collections.Generic;

namespace Dealership.Models
{
    public class Comment:IComment
    {
        public const int CommentMinLength = 3;
        public const int CommentMaxLength = 200;

        private string content;
        private string author;

        public Comment(string content, string author)
        {
            Content = this.content;
            Author = this.author;
        }

        public string Content
        {
            get => this.content;
            set
            {
                Validator.ValidateIntRangeComment(value.Length, CommentMinLength, CommentMaxLength, "content");
                this.content = value;
            }
        }

        public string Author 
        { 
            get=> this.author;
            set=> this.author = value;
        }

        

        public void AddComment(IComment comment)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveComment(IComment comment)
        {
            throw new System.NotImplementedException();
        }



        //ToDo
    }
}

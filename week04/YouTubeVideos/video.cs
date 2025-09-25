using System.Collections.Generic;

namespace YouTubeVideos
{
    /// <summary>
    /// Represents a YouTube video and its associated comments.
    /// Abstraction responsibilities:
    /// - Track title, author, and lengthInSeconds
    /// - Store a list of Comment objects
    /// - Provide behavior to add comments and get the comment count
    /// </summary>
    public class Video
    {
        private string _title;
        private string _author;
        private int _lengthInSeconds;
        private readonly List<Comment> _comments = new List<Comment>();

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public int LengthInSeconds
        {
            get { return _lengthInSeconds; }
            set { _lengthInSeconds = value; }
        }

        public Video(string title, string author, int lengthInSeconds)
        {
            _title = title;
            _author = author;
            _lengthInSeconds = lengthInSeconds;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return _comments.Count;
        }

        public IReadOnlyList<Comment> GetComments()
        {
            return _comments.AsReadOnly();
        }
    }
}
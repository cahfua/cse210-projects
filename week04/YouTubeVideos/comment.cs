namespace YouTubeVideos
{
    /// <summary>
    /// Represents a comment with the commenter's name and the comment text.
    /// </summary>
    public class Comment
    {
        private string _commenterName;
        private string _text;

        public string CommenterName
        {
            get { return _commenterName; }
            set { _commenterName = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public Comment(string commenterName, string text)
        {
            _commenterName = commenterName;
            _text = text;
        }
    }
}
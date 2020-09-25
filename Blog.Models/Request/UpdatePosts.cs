namespace Blog.Models.Request
{
    public class UpdatePosts
    {
        public int PostId { get; set; }
        public string PostContent { get; set; }
        public string Title { get; set; }
    }
}

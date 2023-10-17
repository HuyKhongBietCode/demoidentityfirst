namespace DemoIdentityEntityFramework.Models
{
    public class PagingModel
    {
        public int currentpage { get; set; }
        public int totalpage { get; set; }
        public Func<int?, string> generaterUrl { get; set; }    
    }
}

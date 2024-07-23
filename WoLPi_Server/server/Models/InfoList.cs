namespace server.Models
{
    public class InfoList
    {
        public int Count => InfoItems.Count;

        public List<InfoItem> InfoItems { get; set; }

        public InfoList() 
        { 
            InfoItems = new List<InfoItem>();
        }
    }
}

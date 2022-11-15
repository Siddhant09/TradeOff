namespace TradeOff.Models
{
    public class Dashboard
    {
        public List<Item> MostLiked { get; set; }
        public List<Item> MostDisiked { get; set; }
        public List<Item> MostRequested { get; set; }
        public List<Item> Users { get; set; }

        public Dashboard GetDashboard()
        {
            Dashboard dashboard = new Dashboard();
            List<Item> mostLiked = new List<Item>();
            List<Item> mostDisiked = new List<Item>();
            List<Item> mostRequested = new List<Item>();
            List<Item> users = new List<Item>();

            Item item = new Item();
            item.UserName = "John Cena";
            item.UserPicUrl = "pro.png";
            item.Title = "Projector";
            item.Likes = 15;
            item.Dislikes = 20;
            item.Requests = 18;
            item.PicUrl = "i1_1.jpg";
            item.Date = "Member Since: " + DateTime.Now.ToShortDateString();

            mostLiked.Add(item);
            mostDisiked.Add(item);
            mostRequested.Add(item);
            users.Add(item);

            Item item2 = new Item();
            item2.UserName = "Triple H";
            item2.UserPicUrl = "pro.png";
            item2.Title = "Recliner Chair";
            item2.Likes = 10;
            item2.Dislikes = 6;
            item2.Requests = 10;
            item2.PicUrl = "i2_1.png";
            item2.Date = "Member Since: " + DateTime.Now.ToShortDateString();

            mostLiked.Add(item2);
            mostDisiked.Add(item2);
            mostRequested.Add(item2);
            users.Add(item2);

            Item item3 = new Item();
            item3.UserName = "Big Show";
            item3.UserPicUrl = "pro.png";
            item3.Title = "Playing Cards";
            item3.Likes = 19;
            item3.Dislikes = 7;
            item3.Requests = 3;
            item3.PicUrl = "i3_1.png";
            item3.Date = "Member Since: " + DateTime.Now.ToShortDateString();

            mostLiked.Add(item3);
            mostDisiked.Add(item3);
            mostRequested.Add(item3);
            users.Add(item3);

            dashboard.MostLiked = mostLiked.OrderByDescending(x => x.Likes).ToList();
            dashboard.MostDisiked = mostDisiked.OrderByDescending(x => x.Dislikes).ToList();
            dashboard.MostRequested = mostRequested.OrderByDescending(x => x.Requests).ToList();
            dashboard.Users = users.OrderByDescending(x => x.Likes).ToList();

            return dashboard;
        }
    }
}

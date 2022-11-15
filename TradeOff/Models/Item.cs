namespace TradeOff.Models
{
    public class Image
    {
        public string ImageUrl { get; set; }
    }
    public class Tag
    {
        public string TagName { get; set; }
    }
    public class Item
    {
        public long? UserId { get; set; }
        public string UserName { get; set; }
        public string UserPicUrl { get; set; }
        public string PicUrl { get; set; }
        public string Date { get; set; }
        public long? ItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public long? CategoryId { get; set; }
        public string Category { get; set; }
        public long? AgeId { get; set; }
        public string Age { get; set; }
        public long? ConditionId { get; set; }
        public string Condition { get; set; }
        public string Tags { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int Requests { get; set; }
        public string Like { get; set; }
        public List<Image> Images { get; set; }
        public List<Tag> TagList { get; set; }

        public List<Item> GetItems()
        {
            List<Item> items = new List<Item>();

            Item item = new Item();
            item.UserName = "Siddhant Chawade";
            item.UserPicUrl = "pro.png";
            item.Date = "Added On: " + DateTime.Now.ToLongDateString();
            item.Title = "Projector";
            item.Description = "Raydem Native 1080P Video Projector, Projector with 5GHz Wi-Fi and Bluetooth, 13000 Lux Portable Projector.";
            item.Category = "Electronics";
            item.Age = "4 to 6 Months";
            item.Condition = "Good";
            item.Tags = "Projector, 4K Support, Lens";
            item.Likes = 15;
            item.Dislikes = 2;
            item.Details = item.Category + " | " + item.Age + " old | " + item.Condition + " condition";
            item.Like = "Likes/Dislikes: " + item.Likes.ToString() + "/" + item.Dislikes.ToString();
            item.TagList = new List<Tag>() { new Tag { TagName = "Projector" }, new Tag { TagName = "4K Support" }, new Tag { TagName = "Lens" } };

            List<Image> images = new List<Image>();
            images.Add(new Image { ImageUrl = "i1_1.jpg" });
            images.Add(new Image { ImageUrl = "i1_2.jpg" });
            images.Add(new Image { ImageUrl = "i1_3.jpg" });
            item.Images = images;

            Item item2 = new Item();
            item2.UserName = "Nithika Sanghi";
            item2.UserPicUrl = "pro.png";
            item2.Date = "Added On: " + DateTime.Now.ToLongDateString();
            item2.Title = "Recliner Chair";
            item2.Description = "Bosmiller Massage Recliner Chair Fabric Overstuffed Lounge Single Sofa for Living Room.";
            item2.Category = "Furniture";
            item2.Age = "1 to 3 Months";
            item2.Condition = "Excellent";
            item2.Tags = "Chair, Recliner, Lounger";
            item2.Likes = 10;
            item2.Dislikes = 6;
            item2.Details = item2.Category + " | " + item2.Age + " old | " + item2.Condition + " condition";
            item2.Like = "Likes/Dislikes: " + item2.Likes.ToString() + "/" + item2.Dislikes.ToString();
            item2.TagList = new List<Tag>() { new Tag { TagName = "Chair" }, new Tag { TagName = "Lounger" }, new Tag { TagName = "Recliner" } };

            List<Image> images2 = new List<Image>();
            images2.Add(new Image { ImageUrl = "i2_1.jpg" });
            images2.Add(new Image { ImageUrl = "i2_2.jpg" });
            item2.Images = images2;
            
            Item item3 = new Item();
            item3.UserName = "Nithika Sanghi";
            item3.UserPicUrl = "pro.png";
            item3.Date = "Added On: " + DateTime.Now.ToLongDateString();
            item3.Title = "Playing Cards";
            item3.Description = "IUPUI merchandise playing cards.";
            item3.Category = "Entertainment";
            item3.Age = "Less than 1 Month";
            item3.Condition = "Excellent";
            item3.Tags = "Cards, Games, Fun";
            item3.Likes = 19;
            item3.Dislikes = 7;
            item3.Details = item3.Category + " | " + item3.Age + " old | " + item3.Condition + " condition";
            item3.Like = "Likes/Dislikes: " + item3.Likes.ToString() + "/" + item3.Dislikes.ToString();
            item3.TagList = new List<Tag>() { new Tag { TagName = "Cards" }, new Tag { TagName = "Games" }, new Tag { TagName = "Fun" } };

            List<Image> images3 = new List<Image>();
            images3.Add(new Image { ImageUrl = "i3_1.jpg" });
            item3.Images = images3;

            Item item4 = new Item();
            item4.UserName = "Siddhant Chawade";
            item4.UserPicUrl = "pro.png";
            item4.Date = "Added On: " + DateTime.Now.ToLongDateString();
            item4.Title = "Coffee Table";
            item4.Description = "AZL1 Life Concept Modern Coffee Table, 1pc.";
            item4.Category = "Furniture";
            item4.Age = "9 to 12 Months";
            item4.Condition = "Good";
            item4.Tags = "Table, Study table";
            item4.Likes = 10;
            item4.Dislikes = 20;
            item4.Details = item4.Category + " | " + item4.Age + " old | " + item4.Condition + " condition";
            item4.Like = "Likes/Dislikes: " + item4.Likes.ToString() + "/" + item4.Dislikes.ToString();
            item4.TagList = new List<Tag>() { new Tag { TagName = "Table" }, new Tag { TagName = "Study table" } };

            List<Image> images4 = new List<Image>();
            images4.Add(new Image { ImageUrl = "i4_1.jpg" });
            images4.Add(new Image { ImageUrl = "i4_2.jpg" });
            item4.Images = images4;

            Item item5 = new Item();
            item5.UserName = "Siddhant Chawade";
            item5.UserPicUrl = "pro.png";
            item5.Date = "Added On: " + DateTime.Now.ToLongDateString();
            item5.Title = "Couch";
            item5.Description = "Lifestyle Solutions HRFKS3BK Grayson Sofa, 78.7 W x 31.5 D x 32.7 H, Brown.";
            item5.Category = "Furniture";
            item5.Age = "4 to 6 Months";
            item5.Condition = "Good";
            item5.Tags = "Sofa, Couch";
            item5.Likes = 10;
            item5.Dislikes = 8;
            item5.Details = item5.Category + " | " + item5.Age + " old | " + item5.Condition + " condition";
            item5.Like = "Likes/Dislikes: " + item5.Likes.ToString() + "/" + item5.Dislikes.ToString();
            item5.TagList = new List<Tag>() { new Tag { TagName = "Sofa" }, new Tag { TagName = "Couch" }, new Tag { TagName = "Confortable" } };

            List<Image> images5 = new List<Image>();
            images5.Add(new Image { ImageUrl = "i5_1.jpg" });
            images5.Add(new Image { ImageUrl = "i5_2.jpg" });
            item5.Images = images5;

            Item item6 = new Item();
            item6.UserName = "Siddhant Chawade";
            item6.UserPicUrl = "pro.png";
            item6.Date = "Added On: " + DateTime.Now.ToLongDateString();
            item6.Title = "Power Bank";
            item6.Description = "Anker Portable Charger, 313 Power Bank (PowerCore Slim 10K) 10000mAh Battery Pack with PowerIQ Charging Technology.";
            item6.Category = "Electronics";
            item6.Age = "1 to 3 Months";
            item6.Condition = "Excellent";
            item6.Tags = "Power bank, ";
            item6.Likes = 8;
            item6.Dislikes = 2;
            item6.Details = item6.Category + " | " + item6.Age + " old | " + item6.Condition + " condition";
            item6.Like = "Likes/Dislikes: " + item6.Likes.ToString() + "/" + item6.Dislikes.ToString();
            item6.TagList = new List<Tag>() { new Tag { TagName = "Charger" }, new Tag { TagName = "Power Source" } };

            List<Image> images6 = new List<Image>();
            images6.Add(new Image { ImageUrl = "i6_1.jpg" });
            images6.Add(new Image { ImageUrl = "i6_2.jpg" });
            item6.Images = images6;

            Item item7 = new Item();
            item7.UserName = "Nithika Sanghi";
            item7.UserPicUrl = "pro.png";
            item7.Date = "Added On: " + DateTime.Now.ToLongDateString();
            item7.Title = "Echo";
            item7.Description = "Echo Dot (3rd Gen, 2018 release) - Smart speaker with Alexa - Charcoal.";
            item7.Category = "Electronics";
            item7.Age = "less than 1 Month";
            item7.Condition = "Good";
            item7.Tags = "Speaker, Smart device, Alexa";
            item7.Likes = 50;
            item7.Dislikes = 0;
            item7.Details = item7.Category + " | " + item7.Age + " old | " + item7.Condition + " condition";
            item7.Like = "Likes/Dislikes: " + item7.Likes.ToString() + "/" + item7.Dislikes.ToString();
            item7.TagList = new List<Tag>() { new Tag { TagName = "Speaker" }, new Tag { TagName = "Smart device" }, new Tag { TagName = "Alexa" } };

            List<Image> images7 = new List<Image>();
            images7.Add(new Image { ImageUrl = "i7_1.jpg" });
            images7.Add(new Image { ImageUrl = "i7_2.jpg" });
            item7.Images = images7;

            items.Add(item);
            items.Add(item2);
            items.Add(item3);
            items.Add(item4);
            items.Add(item5);
            items.Add(item6);
            items.Add(item7);

            return items;
        }
    }
}

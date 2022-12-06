using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeOff.ClassLibrary
{
    public class Request
    {
        public long? TradeRequestId { get; set; }
        public string? Date { get; set; }
        public long? IUserId { get; set; }
        public string? IUserName { get; set; }
        public string? IUserPicUrl { get; set; }
        //public string? IDate { get; set; }
        public long? IProductId { get; set; }
        public string? ITitle { get; set; }
        public string? IDescription { get; set; }
        public string? IDetails { get; set; }
        //public long? ICategoryId { get; set; }
        public string? ICategory { get; set; }
        //public long? IAgeId { get; set; }
        public string? IAge { get; set; }
        //public long? IConditionId { get; set; }
        public string? ICondition { get; set; }
        //public string? ITags { get; set; }
        public int? ILikes { get; set; }
        public int? IDislikes { get; set; }
        public string? ILike { get; set; }
        public List<LookupOption>? IImageList { get; set; }
        public List<LookupOption>? ITagList { get; set; }
        public long? OUserId { get; set; }
        public string? OUserName { get; set; }
        public string? OUserPicUrl { get; set; }
        //public string? ODate { get; set; }
        public long? OProductId { get; set; }
        public string? OTitle { get; set; }
        public string? ODescription { get; set; }
        public string? ODetails { get; set; }
        //public long? OCategoryId { get; set; }
        public string? OCategory { get; set; }
        //public long? OAgeId { get; set; }
        public string? OAge { get; set; }
        //public long? OConditionId { get; set; }
        public string? OCondition { get; set; }
        //public string? OTags { get; set; }
        public int? OLikes { get; set; }
        public int? ODislikes { get; set; }
        public string? OLike { get; set; }
        public List<LookupOption>? OImageList { get; set; }
        public List<LookupOption>? OTagList { get; set; }
        public string? Type { get; set; }
        public bool IsIncoming { get; set; }
        public bool IsOutgoing { get; set; }
        public string? Color { get; set; }
        public string? Status { get; set; }

        //public List<Request> GetRequests()
        //{
        //    List<Request> items = new List<Request>();

        //    Request item = new Request();
        //    item.Color = "LightGreen";
        //    item.Type = "(Incoming)";
        //    item.Status = "(Incoming - Accepted)";
        //    item.IsIncoming = true;
        //    item.IsOutgoing = false;
        //    item.OUserName = "Siddhant Chawade";
        //    item.OUserPicUrl = "pro.png";
        //    item.ODate = "Received On: " + DateTime.Now.ToLongDateString();
        //    item.OTitle = "Projector";
        //    item.ODescription = "Raydem Native 1080P Video Projector, Projector with 5GHz Wi-Fi and Bluetooth, 13000 Lux Portable Projector.";
        //    item.OCategory = "Electronics";
        //    item.OAge = "4 to 6 Months";
        //    item.OCondition = "Good";
        //    item.OTags = "Projector, 4K Support, Lens";
        //    item.OLikes = 15;
        //    item.ODislikes = 2;
        //    item.ODetails = item.OCategory + " | " + item.OAge + " old | " + item.OCondition + " condition";
        //    item.OLike = "Likes/IDislikes: " + item.OLikes.ToString() + "/" + item.ODislikes.ToString();
        //    item.OTagList = new List<Tag>() { new Tag { TagName = "Projector" }, new Tag { TagName = "4K Support" }, new Tag { TagName = "Lens" } };

        //    List<Image> images = new List<Image>();
        //    images.Add(new Image { ImageUrl = "i1_1.jpg" });
        //    images.Add(new Image { ImageUrl = "i1_2.jpg" });
        //    images.Add(new Image { ImageUrl = "i1_3.jpg" });
        //    item.OImages = images;

        //    item.IUserName = "Nithika Sanghi";
        //    item.IUserPicUrl = "pro.png";
        //    item.IDate = "Received On: " + DateTime.Now.ToLongDateString();
        //    item.ITitle = "Echo";
        //    item.IDescription = "Echo Dot (3rd Gen, 2018 release) - Smart speaker with Alexa - Charcoal.";
        //    item.ICategory = "Electronics";
        //    item.IAge = "less than 1 Month";
        //    item.ICondition = "Good";
        //    item.ITags = "Speaker, Smart device, Alexa";
        //    item.ILikes = 50;
        //    item.IDislikes = 0;
        //    item.IDetails = item.ICategory + " | " + item.IAge + " old | " + item.ICondition + " condition";
        //    item.ILike = "Likes/IDislikes: " + item.ILikes.ToString() + "/" + item.IDislikes.ToString();
        //    item.ITagList = new List<Tag>() { new Tag { TagName = "Speaker" }, new Tag { TagName = "Smart device" }, new Tag { TagName = "Alexa" } };

        //    List<Image> images7 = new List<Image>();
        //    images7.Add(new Image { ImageUrl = "i7_1.jpg" });
        //    images7.Add(new Image { ImageUrl = "i7_2.jpg" });
        //    item.IImages = images7;

        //    Request item2 = new Request();
        //    item2.Color = "LightGreen";
        //    item2.Type = "(Incoming)";
        //    item2.Status = "(Outgoing - Accepted)";
        //    item2.IsIncoming = true;
        //    item2.IsOutgoing = false;
        //    item2.IUserName = "Nithika Sanghi";
        //    item2.IUserPicUrl = "pro.png";
        //    item2.IDate = "Received On: " + DateTime.Now.ToLongDateString();
        //    item2.ITitle = "Recliner Chair";
        //    item2.IDescription = "Bosmiller Massage Recliner Chair Fabric Overstuffed Lounge Single Sofa for Living Room.";
        //    item2.ICategory = "Furniture";
        //    item2.IAge = "1 to 3 Months";
        //    item2.ICondition = "Excellent";
        //    item2.ITags = "Chair, Recliner, Lounger";
        //    item2.ILikes = 10;
        //    item2.IDislikes = 6;
        //    item2.IDetails = item2.ICategory + " | " + item2.IAge + " old | " + item2.ICondition + " condition";
        //    item2.ILike = "Likes/IDislikes: " + item2.ILikes.ToString() + "/" + item2.IDislikes.ToString();
        //    item2.ITagList = new List<Tag>() { new Tag { TagName = "Chair" }, new Tag { TagName = "Lounger" }, new Tag { TagName = "Recliner" } };

        //    List<Image> images2 = new List<Image>();
        //    images2.Add(new Image { ImageUrl = "i2_1.jpg" });
        //    images2.Add(new Image { ImageUrl = "i2_2.jpg" });
        //    item2.IImages = images2;

        //    item2.OUserName = "Siddhant Chawade";
        //    item2.OUserPicUrl = "pro.png";
        //    item2.ODate = "Received On: " + DateTime.Now.ToLongDateString();
        //    item2.OTitle = "Coffee Table";
        //    item2.ODescription = "AZL1 Life Concept Modern Coffee Table, 1pc.";
        //    item2.OCategory = "Furniture";
        //    item2.OAge = "9 to 12 Months";
        //    item2.OCondition = "Good";
        //    item2.OTags = "Table, Study table";
        //    item2.OLikes = 10;
        //    item2.ODislikes = 20;
        //    item2.ODetails = item2.OCategory + " | " + item2.OAge + " old | " + item2.OCondition + " condition";
        //    item2.OLike = "Likes/IDislikes: " + item2.OLikes.ToString() + "/" + item2.ODislikes.ToString();
        //    item2.OTagList = new List<Tag>() { new Tag { TagName = "Table" }, new Tag { TagName = "Study table" } };

        //    List<Image> images4 = new List<Image>();
        //    images4.Add(new Image { ImageUrl = "i4_1.jpg" });
        //    images4.Add(new Image { ImageUrl = "i4_2.jpg" });
        //    item2.OImages = images4;

        //    Request item3 = new Request();
        //    item3.Color = "OrangeRed";
        //    item3.Type = "(Outgoing)";
        //    item3.Status = "(Incoming - Rejected)";
        //    item3.IsIncoming = false;
        //    item3.IsOutgoing = true;
        //    item3.IUserName = "Nithika Sanghi";
        //    item3.IUserPicUrl = "pro.png";
        //    item3.IDate = "Sent On: " + DateTime.Now.ToLongDateString();
        //    item3.ITitle = "Playing Cards";
        //    item3.IDescription = "IUPUI merchandise playing cards.";
        //    item3.ICategory = "Entertainment";
        //    item3.IAge = "Less than 1 Month";
        //    item3.ICondition = "Excellent";
        //    item3.ITags = "Cards, Games, Fun";
        //    item3.ILikes = 19;
        //    item3.IDislikes = 7;
        //    item3.IDetails = item3.ICategory + " | " + item3.IAge + " old | " + item3.ICondition + " condition";
        //    item3.ILike = "Likes/IDislikes: " + item3.ILikes.ToString() + "/" + item3.IDislikes.ToString();
        //    item3.ITagList = new List<Tag>() { new Tag { TagName = "Cards" }, new Tag { TagName = "Games" }, new Tag { TagName = "Fun" } };

        //    List<Image> images3 = new List<Image>();
        //    images3.Add(new Image { ImageUrl = "i3_1.jpg" });
        //    item3.IImages = images3;

        //    item3.OUserName = "Siddhant Chawade";
        //    item3.OUserPicUrl = "pro.png";
        //    item3.ODate = "Sent On: " + DateTime.Now.ToLongDateString();
        //    item3.OTitle = "Couch";
        //    item3.ODescription = "Lifestyle Solutions HRFKS3BK Grayson Sofa, 78.7 W x 31.5 D x 32.7 H, Brown.";
        //    item3.OCategory = "Furniture";
        //    item3.OAge = "4 to 6 Months";
        //    item3.OCondition = "Good";
        //    item3.OTags = "Sofa, Couch";
        //    item3.OLikes = 10;
        //    item3.ODislikes = 8;
        //    item3.ODetails = item3.OCategory + " | " + item3.OAge + " old | " + item3.OCondition + " condition";
        //    item3.OLike = "Likes/IDislikes: " + item3.OLikes.ToString() + "/" + item3.ODislikes.ToString();
        //    item3.OTagList = new List<Tag>() { new Tag { TagName = "Sofa" }, new Tag { TagName = "Couch" }, new Tag { TagName = "Confortable" } };

        //    List<Image> images5 = new List<Image>();
        //    images5.Add(new Image { ImageUrl = "i5_1.jpg" });
        //    images5.Add(new Image { ImageUrl = "i5_2.jpg" });
        //    item3.OImages = images5;

        //    items.Add(item);
        //    items.Add(item2);
        //    items.Add(item3);

        //    return items;
        //}
    }
}

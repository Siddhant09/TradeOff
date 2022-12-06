using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeOff.ClassLibrary
{
    public class Inventory
    {
        public List<Product>? ProductList { get; set; }
    }

    public class Product
    {
        public long? ProductId { get; set; }
        public string? Title { get; set; }
        public long? UserId { get; set; }
        public string? UserName { get; set; }
        public string? PicUrl { get; set; }
        public string? Date { get; set; }
        public string? Description { get; set; }
        public long? CategoryId { get; set; }
        public string? Category { get; set; }
        public long? AgeId { get; set; }
        public string? Age { get; set; }
        public long? ConditionId { get; set; }
        public string? Condition { get; set; }
        public int? Likes { get; set; }
        public int? Dislikes { get; set; }
        public string? Tags { get; set; }
        public string? Details { get; set; }
        public string? Like { get; set; }
        public List<LookupOption>? ImageList { get; set; }
        public List<LookupOption>? TagList { get; set; }
        public bool? Liked { get; set; }
        public bool? Disiked { get; set; }
        public string? Status { get; set; }
    }

    public class LookupOption
    {
        public long? LookupId { get; set; }
        public string? LookupName { get; set; }
        public long? CodeMasterId { get; set; }
        public string? CodeMasterName { get; set; }
    }

    public class InventoryOptions
    {
        public List<LookupOption>? CategoryList { get; set; }
        public List<LookupOption>? AgeList { get; set; }
        public List<LookupOption>? ConditionList { get; set; }
    }
}

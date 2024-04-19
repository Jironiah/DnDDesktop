using DnDDesktop.Models.Commons;
using MongoDB.Bson.Serialization.Attributes;

namespace DnDDesktop.Models.SubModels
{
    [BsonNoId]
    public class ItemsChoiceFeature
    {
        [BsonElement("choose")]
        public int[]? Choose { get; set; }

        [BsonElement("from")]
        public ArrayedFrom[]? Item { get; set; }
    }
}

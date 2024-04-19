using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDDesktop.Models.Commons
{
    [BsonNoId]
    public class UnitQuantity
    {
        [BsonElement("quantity")]
        public double? Quantity { get; set; }

        [BsonElement("unit")]
        public string String { get; set; } = String.Empty;
    }
}

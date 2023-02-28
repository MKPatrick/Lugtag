using MongoDB.Bson;

namespace Lugtag.Models
{
    public class TagModel
    {
        public ObjectId Id { get; set; }

        public string LinkIdentifier { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EMail { get; set; }
        public string Phone { get; set; }
        //long,let
        public float[] Coordinates { get; set; }


        public bool IsMissing { get; set; }=false;

        public string MissingNote { get; set; }


    }
}

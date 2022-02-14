namespace SpoilBlock.Models
{
    public class IMDbEntry
    {
        public string? id;
        public string? resultType;
        public string? image;
        public string? title;
        public string? description;

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            if(obj.GetType() != typeof(IMDbEntry)) return false;
            IMDbEntry other = (IMDbEntry)obj;
            if(id != other.id) return false;
            return true;
        }
    }
}

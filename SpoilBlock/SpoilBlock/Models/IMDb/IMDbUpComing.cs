namespace SpoilBlock.Models
{
    public class IMDbUpComing
    {
        public string? id;
        public string? resultType;
        public string? image;
        public string? title;
        public string? description;

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(IMDbUpComing)) return false;
            IMDbUpComing other = (IMDbUpComing)obj;
            if (id != other.id) return false;
            return true;
        }
    }
}

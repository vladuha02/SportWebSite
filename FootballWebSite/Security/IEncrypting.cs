namespace SportWebSite.Security
{
    public interface IEncrypting
    {
        public string HashString(string toHashStr);
    }
}

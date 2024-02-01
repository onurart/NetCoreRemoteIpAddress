namespace NetCoreRemoteIpAddress.Controllers
{
    public class LogService
    {
        private List<string> userEntries = new List<string>();

        public void LogUserEntry(string ip)
        {
            var entry = $"User entered with IP: {ip} at {DateTime.Now}";
            userEntries.Add(entry);
        }

        public List<string> GetUserEntries()
        {
            return userEntries;
        }
    }
}

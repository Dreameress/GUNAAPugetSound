namespace Entities.Models
{
    public partial class MigrationHistory
    {
        public string Id { get; set; }
        public string ContextKey { get; set; }
        public byte[] Model { get; set; }
        public string ProductVersion { get; set; }
    }
}

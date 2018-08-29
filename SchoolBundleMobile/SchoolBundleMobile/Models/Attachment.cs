namespace SchoolBundleMobile.Models
{
    public class Attachment
    {
        public long AttachmentId { get; set; }

        public string FileDisplayName { get; set; }

        public string UniqueFileName { get; set; }

        public int DisplayOrder { get; set; }
    }
}
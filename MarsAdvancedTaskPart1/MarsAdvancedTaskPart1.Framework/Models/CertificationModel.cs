namespace MarsAdvancedTaskPart1.Framework.Models
{
    public class CertificationModel
    {
        public List<TestItem> TestItems { get; set; } = [];
    }

    public class TestItem
    {
        public CertificationDetails CertificationDetailsToAdd { get; set; } = new();
        public CertificationDetails CertificationDetailsToUpdate { get; set; } = new();
        public CertificationDetails CertificationDetailsToDelete { get; set; } = new();
    }

    public class CertificationDetails
    {
        public string CertificateOrAward { get; set; } = string.Empty;
        public string CertifiedFrom { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
        public string ExpectedMessage { get; set; } = string.Empty;
    }
}

namespace MicrosoftEntraId.Auth.WebApp.Constants;

public static class AuthorizationConstants
{
    public static class Roles
    {
        public const string DocumentContributor = "Document.Contributor";
        public const string DocumentReader = "Document.Reader";
        public const string DocumentEditor = "Document.Editor";
        public const string DocumentManager = "Document.Manager";
    }

    public static class ClaimType
    {
        public const string Role = "roles";
    }

    public static class Policy
    {
        public const string ReportsListing = "ReportsListing";
        public const string EditReports = "EditReportsRequirement";
        public const string CreateReports = "CreateReportsRequirement";
        public const string ReadReports = "ReadReportsRequirement";
    }
}
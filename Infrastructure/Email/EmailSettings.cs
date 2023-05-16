using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infrastructure.Email
{
    public static class EmailSettings
    {
        private static IConfiguration configuration;
        public static void SetSettings()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            configuration = builder.Build();
        }

        public static string AppID => configuration.GetValue<string>("MailSettings:AppID");
        public static string AppSecret => configuration.GetValue<string>("MailSettings:AppSecret");
        public static string TenantID => configuration.GetValue<string>("MailSettings:TenantID");
        public static string UserID => configuration.GetValue<string>("MailSettings:UserID");
        public static string Signature => configuration.GetValue<string>("MailSettings:Signature");
        public static string BodyTemplate => configuration.GetValue<string>("MailSettings:BodyTemplate");
    }
}


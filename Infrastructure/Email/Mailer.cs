namespace Infrastructure.Email
{
    public class Mailer
    {
        public static async Task SendWithGraph(
            string recipients,
            string subject,
            string content,
            string signaturePath = "",
            string attachmentPath = "",
            string sendAs = "")
        {
            var graphClient = new GraphClient();
            await graphClient.SendEmailAsync(subject, content, recipients, signaturePath, attachmentPath, sendAs);
        }
    }
}

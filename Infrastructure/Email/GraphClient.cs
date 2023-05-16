using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace Infrastructure.Email
{
    public class GraphClient
    {
        public GraphClient()
        {
            EmailSettings.SetSettings();
        }
        private IUserRequestBuilder serviceUserRequest;

        #region Public Methods

        public async Task SendEmailAsync(string subject, string content, string recipients, string signaturePath = "", string attachmentPath = "", string sendAs = "", bool saveToSendItems = false)
        {
            if (serviceUserRequest == null)
            {
                serviceUserRequest = await BuildGraphServiceUserRequest();
            }

            var message = BuildMailMessage(subject, content, recipients, signaturePath, attachmentPath, sendAs);
            await serviceUserRequest
                .SendMail(message, saveToSendItems)
                .Request()
                .PostAsync();
        }

        #endregion

        #region Helper Methods

        private static async Task<IUserRequestBuilder> BuildGraphServiceUserRequest()
        {
            var token = await GetAccessToken();

            // Build the Microsoft Graph client. As the authentication provider, set an async lambda
            // which uses the MSAL client to obtain an app-only access token to Microsoft Graph,
            // and inserts this access token in the Authorization header of each API request. 
            var graphService = new GraphServiceClient(new DelegateAuthenticationProvider(async requestMessage =>
            {
                // Add the access token in the Authorization header of the API request.
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            })
                );

            return graphService.Users[EmailSettings.UserID];
        }

        private static async Task<string> GetAccessToken()
        {
            var confidentialClient = BuildConfidentialClient();
            var graphScopes = new[] { "https://graph.microsoft.com/.default" };

            // Retrieve an access token for Microsoft Graph (gets a fresh token if needed).
            var authResult = await confidentialClient
                .AcquireTokenForClient(graphScopes)
                .ExecuteAsync().ConfigureAwait(false);

            return authResult.AccessToken;
        }

        private static IConfidentialClientApplication BuildConfidentialClient()
        {
            var clientId = EmailSettings.AppID;
            var clientSecret = EmailSettings.AppSecret;
            var tenantId = EmailSettings.TenantID;

            return ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority(new Uri($"https://login.microsoftonline.com/{tenantId}/v2.0"))
                .Build();
        }

        private static Message BuildMailMessage(string subject, string emailContent, string recipients,
            string signaturePath, string attachmentPath, string sendAs)
        {
            var allRecipients = recipients.Split(',');

            var message = new Message
            {
                Subject = subject,
                Body = new ItemBody
                {
                    ContentType = BodyType.Html,
                    Content = emailContent
                },
                Attachments = new MessageAttachmentsCollectionPage()
            };

            if (!string.IsNullOrEmpty(sendAs))
            {
                message.From = new Recipient
                { EmailAddress = new EmailAddress { Address = sendAs } };
            }

            if (allRecipients.Length > 1)
            {
                message.BccRecipients = allRecipients.Select(emailAddress =>
                new Recipient
                {
                    EmailAddress = new EmailAddress
                    {
                        Address = emailAddress
                    }
                }).ToList();
            }
            else
            {
                message.ToRecipients = allRecipients.Select(emailAddress =>
                new Recipient
                {
                    EmailAddress = new EmailAddress
                    {
                        Address = emailAddress
                    }
                }).ToList();
            }

            if (!string.IsNullOrEmpty(signaturePath))
            {
                message.Attachments.Add
                (
                    new FileAttachment
                    {
                        Name = Path.GetFileName(signaturePath),
                        ODataType = "#microsoft.graph.fileAttachment",
                        ContentBytes = System.IO.File.ReadAllBytes(signaturePath),
                        ContentId = Path.GetFileNameWithoutExtension(signaturePath),
                        IsInline = true
                    }
                );
            }

            if (!string.IsNullOrEmpty(attachmentPath))
            {
                message.Attachments.Add
                (
                    new FileAttachment
                    {
                        Name = Path.GetFileName(attachmentPath),
                        ODataType = "#microsoft.graph.fileAttachment",
                        ContentBytes = System.IO.File.ReadAllBytes(attachmentPath)
                    }
                );
            }

            return message;
        }

        #endregion
    }
}

using Microsoft.JSInterop;

namespace OnBoarding.Services
{
    public class AppService
    {
        // The JavaScript namespace 
        const string JsNamespace = "ClientExporter";

        public AppService(IJSRuntime js) => Js = js;

        public IJSRuntime Js { get; }

        public async ValueTask<string> ExportPDF(string option) =>
              await Js.InvokeAsync<string>($"{JsNamespace}.generatePDF", option);

        public async ValueTask<string> ScrollTop(string element) =>
             await Js.InvokeAsync<string>($"{JsNamespace}.scrollTop");
    }
}

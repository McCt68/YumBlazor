using Microsoft.JSInterop;

namespace YumBlazor.Services.Extensions
{
    // Static class can not be instantiated. members can be used directly on the class.
    public static class IJSRuntimeExtensions
    {
        // Extending the IJSRuntime class with customized methods
        public static async Task ToastrSuccess(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }

        public static async Task ToastrError(this IJSRuntime jsRuntime, string message)
        {
            await jsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }
    }
}

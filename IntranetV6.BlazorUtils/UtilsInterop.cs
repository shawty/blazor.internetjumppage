using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace IntranetV6.BlazorUtils
{
  public class UtilsInterop
  {
    private IJSRuntime _jsRuntime;

    public UtilsInterop(IJSRuntime jsRuntime)
    {
      _jsRuntime = jsRuntime;
    }

    public Task<object> SetFocus(string elementId)
    {
      return _jsRuntime.InvokeAsync<object>(
          "blazorUtilsFunctions.setFocus",
          elementId);
    }

    public Task<object> Message(string message)
    {
      return _jsRuntime.InvokeAsync<object>(
          "blazorUtilsFunctions.message",
          message);
    }

    public async Task<bool> IsFormValidationValid(ElementRef formRef)
    {
      return await _jsRuntime.InvokeAsync<bool>(
          "blazorUtilsFunctions.isFormValid",
          formRef);
    }

  }
}

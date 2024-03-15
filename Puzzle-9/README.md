# Blazor Puzzle #9

## A Matter of Focus

YouTube Video: https://youtu.be/5OVEktC_h0M

BlazorPuzzle Home Page: https://blazorpuzzle.com

### The Challenge:

It should be an easy task. Press a button and a text field appears. Now, how do we make that input have focus?

Here's the code:

```c#
@page "/"

<PageTitle>Index</PageTitle>

<h1>Hello, world!</h1>

<button class="btn btn-primary" @onclick="ShowTextField">Show Text Field</button>

@if (show)
{
    <br/>
    <br/>
    <input @ref="myTextBox" />
}


@code 
{
    ElementReference myTextBox { get; set; }

    bool show = false;

    async Task ShowTextField()
    {
        show = true;
        await InvokeAsync(StateHasChanged);
        await myTextBox.FocusAsync();
    }
}
```

It looks like it should work, but it throws the following exception on the following line:

```c#
await myTextBox.FocusAsync();
```

Exception:

```
blazor.server.js:1 [2023-10-19T09:32:54.345Z] Error: System.InvalidOperationException: ElementReference has not been configured correctly.
   at Microsoft.AspNetCore.Components.ElementReferenceExtensions.GetJSRuntime(ElementReference elementReference)
   at Microsoft.AspNetCore.Components.ElementReferenceExtensions.FocusAsync(ElementReference elementReference, Boolean preventScroll)
   at Puzzle_9.Pages.Index.ShowTextField() in C:\Users\carl\Desktop\Code\Puzzle-9\Puzzle-9\Pages\Index.razor:line 27
   at Microsoft.AspNetCore.Components.ComponentBase.CallStateHasChangedOnAsyncCompletion(Task task)
   at Microsoft.AspNetCore.Components.RenderTree.Renderer.GetErrorHandledTask(Task taskToHandle, ComponentState owningComponentState)
```

How can we make this work?


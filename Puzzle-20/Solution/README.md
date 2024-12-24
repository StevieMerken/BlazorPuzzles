# Blazor Puzzle #20

## It's a 404 World

YouTube Video: https://youtu.be/K92HNUQzqVc

BlazorPuzzle Home Page: https://blazorpuzzle.com

#### The Challenge:

This is a .NET 8 Blazor Web App with the Interactive render mode set to "WebAssembly" and the Interactivity location set to "Global", However, this problem arises with any flavor of Blazor Web App. Blazor Web Apps do not allow you to use the `<NotFound/>` section in Routes.razor to handle 404 errors. 

How can we implement a 404 page in a Blazor Web App?

#### The Solution:

First, Carl create a new page in the client project:

*StatusCode.razor*:

```c#
@page "/StatusCode/{code:int}"

<p>@Message</p>

@code {

    string Message = string.Empty;

    [Parameter]
    public int code { get; set; }

    protected override void OnInitialized()
    {
        switch (code)
        {
            case 404:
                Message = "Page not found";
                break;
            case 500:
                Message = "Internal server error";
                break;
            default:
                Message = "Unknown error";
                break;
        }
    }
}
```

This page accepts an `int` code and will be called automatically when there is a problem.

Next, he added the following to line 12 in the server project's *Program.cs* file:

```c#
app.UseStatusCodePagesWithRedirects("/StatusCode/{0}");
```

This configuration tells Blazor to redirect to our page whenever there's a 400 error.

Boom!

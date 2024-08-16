# Blazor Puzzle #15

## Unexpected Behavior

YouTube Video: https://youtu.be/AXUeCHraVWY

BlazorPuzzle Home Page: https://blazorpuzzle.com

### The Challenge:

This is a Blazor Web App with the global Interactive mode set to Server. The OnInitialized method is called twice. Why? How can we prevent this?

### The Solution:

When you specify an Interactive Render Mode at the time you create the solution in Visual Studio, pre-rendering is enabled by default.

The first time OnInizialized is called is during pre-rendering, and the second call occurs after the circuit has been established and the app is ready to use.

To turn off pre-rendering in a Blazor Web App, you can specify this in *App.razor*.

Change the `<Routes>` definition to this:

```xml
<Routes @rendermode="new InteractiveServerRenderMode(prerender: false)" />
```

You can also use `InteractiveWebAssemblyRenderMode` or `InteractiveAutoRenderMode` as long as those renderings are configured in your *Program.cs* file.

Boom!


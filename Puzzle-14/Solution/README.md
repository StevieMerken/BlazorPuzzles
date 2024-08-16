# Blazor Puzzle #14

## Simple App Doesn't Work

YouTube Video: https://youtu.be/FZ5QtXmGmv4

BlazorPuzzle Home Page: https://blazorpuzzle.com

### The Challenge:

Why doesn't this simple Blazor Web App with Server interactivity work?

### The Solution:

When Carl created this solution, he did so with the Interactivity Location set to **per-page/component**. Since there is no interactivity, the button click handler doesn't work. 

The reason we chose this topic is because Blazor in .NET 8 changed people's expectations. There are no error messages. The compiler is happy to let you create a button click handler and run your app, leaving you scratching your head.

The solution is to add Interactivity on line 2 of *Home.razor*:

```
@rendermode RenderMode.InteractiveServer
```

Boom!
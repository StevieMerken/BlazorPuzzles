# Blazor Puzzle #16

## No Message For You!

YouTube Video: https://youtu.be/CYfKMUwHZfA

BlazorPuzzle Home Page: https://blazorpuzzle.com

#### The Challenge:

This is a .NET 8 Blazor Web App project with Interactive render mode set to **Server**, and the Interactivity location set to "**per page/component**."

Put a breakpoint on line 45 of *FormDemo.razor*. 

Navigate to the **Form Demo** page, fill in the form, and submit it.

Why is Message empty the second time the breakpoint is hit?

#### The Solution:

The reason the message is empty on the second time, is that there is no interactivity. With no interactivity there is no state. The page is rebuilt on every request because it is being rendered server-side.

Simply add the following at the top of *FormDemo.razor*:

```
@rendermode InteractiveServer
```

Boom!
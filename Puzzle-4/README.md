# Blazor Puzzle 4 - Lazy Not Loading

In this puzzle we are lazy loading a big class, one that has 100,000 methods.

We're using the Counter page, because we want to be able to measure the time it takes to load, at least by eye.

We are referencing the `BigAssembly` project, which contains the `BigAssembly` class, with 100,000 methods.

In *Program.cs* we add this method:

```c#
builder.Services.AddScoped<BogusClass>();
```

In *Counter.razor* we are injecting an instance of *BogusClass*:

```c#
@page "/counter"
@inject BogusClass BogusThingy

<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="LoadBigLibrary">Click me</button>

@code {
    private int currentCount = 0;

    private void LoadBigLibrary()
    {
        BogusThingy.Method852();
        currentCount++;
    }
}
```

When the user clicks the button, we are calling one of the methods (randomly chosen), which should trigger the lazy load.

However, we get an exception when the application is run.

Why?

If you think know the answer, do NOT post it on social media. Instead email us at [blazorpuzzle@appvnext.com](mailto:blazorpuzzle@appvnext.com?subject=Puzzle-4) by Tuesday, September 19th, 2003. 

We will select a winner randomly from all of the correct answers, and that winner will receive a Blazor Puzzle mug AND a DevExpress T-Shirt.

![mug](images/mug.png)

Good Luck!

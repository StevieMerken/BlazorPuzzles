# Blazor Puzzle #19

## To layout or not layout

YouTube Video: https://youtu.be/mPdqZfuTP4w

BlazorPuzzle Home Page: https://blazorpuzzle.com

#### The Challenge:

In this puzzle, we're going to emulate a common request that folks have when they're building websites with Blazor. In this scenario we want to take a page that we already have rendered with html and has all kinds of formatting and navigation around it provided by our layout, in this case the weather page, and we want to make a version of the weather page that's available as a report. That is: it doesn't have any of the layout components around it and is suitable to sending to the printer.

Previously with razor pages or mvc we could just specify that the layout of the cshtml file was an empty string or null and it would forget the layout. What's the technique that we need to use with Blazor?

#### The Solution:

Since every page needs a layout, we can't use the following:

```
@layout null
```

So, we created a new layout with nothing in it except the Body:

Add the following to the *Components/Layout* folder:

*EmptyLayout.razor*:

```
@inherits LayoutComponentBase
@Body
```

Now, change line 2 of *Components/Pages/Report.razor* to this:

```
@layout Layout.EmptyLayout
```

Boom!

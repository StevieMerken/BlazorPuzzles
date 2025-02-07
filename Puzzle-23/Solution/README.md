# Blazor Puzzle #23

## Forge Ahead!

YouTube Video: https://youtu.be/ulOD1qUhGZE

BlazorPuzzle Home Page: https://blazorpuzzle.com

#### The Challenge:

In this puzzle, we're building a contact form and it just doesn't work right.  Why?

#### The Solution:

The solution is to remove the `<AntiForgeryToken/>` from line 12.

The Blazor `<EditForm>` already includes an anti-forgery token. Adding another one causes the problem.
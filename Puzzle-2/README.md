# Blazor Puzzle #2

Code shown in episode #2 of The Blazor Puzzle (with Carl Franklin and Jeff Fritz), which you can see at https://blazorpuzzle.com

This is a demo of calling JavaScript from C# and calling C# from JavaScript. 

When you press the button, a JavaScript method (`DoSomeJavaScript`) is called passing this page as the .NET Object reference. 

You can see this JavaScript method in the *wwwroot/index.html* file. 

The JavaScript function waits 5 seconds, and then calls our C# method `SomethingHappened`, which sets the Message string variable. 

We are showing the Message string in the UI. At least, that's our intent. However, the message is never shown. 

The question is "why?"
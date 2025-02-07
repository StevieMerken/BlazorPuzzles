# Blazor Puzzle #25

## ButtonNumber++

YouTube Video: https://youtu.be/zqsQdzboarE

BlazorPuzzle Home Page: https://blazorpuzzle.com

### The Challenge:

This is a .NET 8 Blazor Web App with Interactive Render Mode set to "Server" and the Interactivity Location set to "Global".

We are using the amazing <a href="https://blazicons.com" target="_blank">Blazicons</a> Font Awesome library to show a solid "Plus" icon in a toolbar.

When the plus icon is clicked, a new dynamic button is created and added to the Toolbar.

The dynamic buttons are created using a record type called DynamicType that has two immutable properties: Type and Parameters. 

A private ButtonModel class defines the properties of a button, including the OnClick handler, which accepts a message string.

When a dynamic button is clicked, a message is shown in the Toolbar that includes the button number (1, 2, 3, etc.) which is incremented and assigned to each new dynamic button.

The problem is that no matter which dynamic button is clicked, the message shown indicates the button number is always 1 more than the number of buttons!
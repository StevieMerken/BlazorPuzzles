# Puzzle-7 - A Parameter Problem, Part 2

Ok ok.. we got lots of feedback about our parameter problem in Puzzle 6, and a great suggestion we heard was that you should use a class to pass data as a cascading parameter.  So... we did that.

We added a footer to our `Grid` component and want to activate a checkbox in that footer that allows the user of the grid to toggle a 'dark theme' for the grid.  We've allocated a CSS class called `darkMode` that will set the background color of the table to a darker palette.  

How do we update the files in our component library so that the checkbox can toggle between dark and light themes?

Our `Grid.razor` looks like this:

```razor
@using System.Reflection;
@typeparam TItem
<table class="@_GridClass">
	<CascadingValue Name="HeaderRowClass" Value="@HeaderClass">
		<GridHeader HeaderType="@typeof(TItem)"></GridHeader>
	</CascadingValue>
	<tbody>

		@if (Items is null)
		{
			@EmptyTemplate
		} else
		{
			@foreach (var item in Items)
			{
				<tr>
					@foreach (var column in Columns)
					{
						<td>@column.GetValue(item)</td>
					}
				</tr>
			}
		}

	</tbody>
	<CascadingValue Name="FooterStyle" Value="@_FooterStyle">
		<GridFooter />
	</CascadingValue>
</table>

@code {

	[Parameter]
	public string HeaderClass { get; set; } = string.Empty;

	[Parameter]
	public string FooterClass { get; set; } = string.Empty;

	[Parameter]
	public IEnumerable<TItem> Items { get; set; } = null;

	[Parameter, EditorRequired]
	public RenderFragment EmptyTemplate  { get; set; }

	private IEnumerable<PropertyInfo> Columns { get; set; }

	private FooterStyle _FooterStyle = new FooterStyle();

	private string _GridClass = "";

	protected override Task OnInitializedAsync()
	{

		Columns = typeof(TItem).GetProperties();
		_FooterStyle.FooterClass = FooterClass;
		_FooterStyle.NumColumns = Columns.Count();

		return base.OnInitializedAsync();
	}

}
```

The new `FooterStyle` class is a simple set of properties:

```csharp
internal class FooterStyle {

	public string FooterClass { get; set; } = string.Empty;

	public int NumColumns { get; set; } = 1;

}
```

The `GridFooter` component is a simple bit of markup with a checkbox

```razor
<tfoot>
	 <tr class="@Style?.FooterClass">
		<td colspan="@(Style?.NumColumns ?? 1)">
			Is Darkmode? <input type="checkbox" />
		</td>
	</tr> 
</tfoot>

@code {

	[CascadingParameter(Name="FooterStyle")] internal FooterStyle Style { get; set; }

}
```

How should we update our component library to allow the checkbox in the grid footer component to toggle the application of the `darkMode` class on the HTML table tag?
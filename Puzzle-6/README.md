# Puzzle-6 - A Parameter Problem

It's no secret that you can pass Parameters around blazer applications and components. However things can get a little dicey when you've got multiple components in a larger hierarchy.

In this sample we have an external grid component that we want to pass in a CSS class for the header row presented in the grid.  What code do we need to add to the files `Grid.razor` and `HeaderRow.razor` in order to allow the `HeaderRow` parameter on the `PuzzleLibrary6.Grid` element to be consumed by the `HeaderRow` component?

When this is working properly, the grid header should be blue with white text.

Our `Index.razor` looks like this:

```razor
<h1>Favorite Podcasts</h1>

<PuzzleLibrary6.Grid Items="Podcasts" HeaderClass="gridHeader">
	<EmptyTemplate>
		<tr>
			<td colspan="2">No podcasts found</td>
		</tr>
	</EmptyTemplate>
</PuzzleLibrary6.Grid>

@code {

	public Podcast[] Podcasts = new Podcast[]
		{
		new Podcast("DotNetRocks", "https://www.dotnetrocks.com/"),
		new Podcast("Hanselminutes", "https://hanselminutes.com/"),
		new Podcast("RunAsRadio", "https://runasradio.com/"),
		new Podcast("The Azure Podcast", "https://www.azurepodcast.com/"),
		new Podcast("The Tablet Show", "https://thetabletshow.com/"),

		};

	public record Podcast(string Title, string Url);

}
```

# Blazor Puzzle #22

## Icon Not Find Icons!

YouTube Video: https://youtu.be/Fa4MZ2wc12o

BlazorPuzzle Home Page: https://blazorpuzzle.com

#### The Challenge:

In this puzzle, we can't find any additional Bootstrap Icons in the Visual Studio template. It seems that the three icons in the NavBar are the only ones you get.

#### The Solution:

We checked out the Bootstrap Icon website install section at https://icons.getbootstrap.com/#install

We added the following to *App.razor* at line 12:

```html
<link href="https://cdn.jsdelivr.net/npm/bootstrap-icons/font/bootstrap-icons.css" rel="stylesheet">
```

This gets the icons from the Bootstrap CDN.

Next, we changed the Weather icon in the NavBar to use a circle icon:

```html
<div class="nav-item px-3">
    <NavLink class="nav-link" href="weather">
        <span class="bi bi-1-circle bi-blazor-navmenu" aria-hidden="true"></span> Weather
    </NavLink>
</div>
```

We also added a new CSS class in *NavMenu.razor.css* to properly size and position any additional bootstrap icons:

```css
.bi-blazor-navmenu {
    font-size: 1.5em;
    color: white;
    background-color: transparent;
    display: block;
    text-align: center;
    line-height: normal;
}
```

And with that, we can use any Bootstrap icon anywhere in our project!

#### Honorable Mention

Our winner, Kyle Herzog, offered **BlazIcons**, a series of NuGet packages for Blazor to use icons from all the major collections. You can check it out at https://www.blazicons.com/


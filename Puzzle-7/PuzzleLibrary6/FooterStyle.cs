namespace PuzzleLibrary6;

internal class FooterStyle
{
	private bool isDarkMode;

	public string FooterClass { get; set; } = string.Empty;

	public int NumColumns { get; set; } = 1;

	public bool IsDarkMode 
	{ 
		get => isDarkMode; 
		set 
		{ 
			if(isDarkMode == value) 
				return;

			isDarkMode = value; 
			OnDarkModeChanged?.Invoke(this, EventArgs.Empty);
		}
	}

	public event EventHandler? OnDarkModeChanged;

}
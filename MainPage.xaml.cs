namespace CanILoadFormttedTextInLoadFromXaml;

public partial class MainPage : ContentPage
{
	int count = 0;

    /// <summary>
    /// Taken from https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/label#use-formatted-text with the guesture recognizer removed.
    /// </summary>
    private static string xaml = """
		  <Label LineBreakMode="WordWrap">
		    <Label.FormattedText>
		        <FormattedString>
		            <Span Text="Red Bold, " TextColor="Red" FontAttributes="Bold" />
		            <Span Text="default, " FontSize="14"/>		          
		            <Span Text="italic small." FontAttributes="Italic" FontSize="12" />
		        </FormattedString>
		    </Label.FormattedText>
		</Label>
		""";


    public MainPage()
	{
		InitializeComponent();
        var label = new Label().LoadFromXaml(xaml);
        if (label.FormattedText is null)
        {
            throw new Exception("This does not work");
        }
        TheVerticalStackLayout.Children.Add(label);
    }


	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
        if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}



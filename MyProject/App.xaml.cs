namespace MyProject;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
        //
        //new NavigationPage(new MainPage()){ BackgroundColor = Colors.Orange };
        //
    }
}

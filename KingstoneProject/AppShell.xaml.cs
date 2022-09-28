namespace KingstoneProject;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		SetTabBarBackgroundColor(tabbar, Color.FromArgb("331940"));
		SetTabBarTitleColor(tabbar, Color.FromArgb("00FFCC"));
		SetTabBarUnselectedColor(tabbar, Color.FromArgb("0CCA98"));

	}

}

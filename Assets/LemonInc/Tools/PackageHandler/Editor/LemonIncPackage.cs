namespace LemonInc.Tools.PackageHandler
{
	public class LemonIncPackage
	{
		public string Name { get; set; }
		public string FullName => Name.ToLemonIncPackageName();
		public bool Installed  { get; set; }
	}
}
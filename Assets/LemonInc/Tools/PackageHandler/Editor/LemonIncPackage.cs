namespace LemonInc.Tools.PackageHandler
{
	public class LemonIncPackage
	{
		public string BranchName { get; set; }
		public string Scope { get; set; }
		public string Feature { get; set; }
		public string FullName => BranchName.ToLemonIncPackageName();
		public bool Installed  { get; set; }
	}
}
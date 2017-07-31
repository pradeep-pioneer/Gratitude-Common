using System;
using System.IO;

namespace Gratitude.Droid
{
    public static class Helper
    {
		public static string GetLocalFilePath(string filename)
		{
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			//string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(docFolder))
			{
                Directory.CreateDirectory(docFolder);
			}
			var path = Path.Combine(docFolder, filename);
			if (File.Exists(path))
				File.Delete(path);
			return path;
		}
    }
}

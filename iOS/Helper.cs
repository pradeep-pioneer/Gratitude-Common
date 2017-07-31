using System;
using System.IO;

namespace Gratitude.iOS
{
    public static class Helper
    {
		public static string GetLocalFilePath(string filename)
		{
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

			if (!Directory.Exists(libFolder))
			{
				Directory.CreateDirectory(libFolder);
			}
            var path = Path.Combine(libFolder, filename);
            if (File.Exists(path))
                File.Delete(path);
            return path;
		}
    }
}

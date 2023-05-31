using System.Web;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography.X509Certificates;

namespace ThePizzaProject.Data
{
	public class FileRepository
	{
		private readonly IConfiguration configuration;
		private readonly IWebHostEnvironment environment;

		public FileRepository(IConfiguration configuration, IWebHostEnvironment environment)
		{
			this.configuration = configuration;
			this.environment = environment;

			string relativeFolderPath = Path.Combine(
				environment.ContentRootPath,
				configuration["Uploads:FolderPath"]
			);
			FolderPath = Path.GetFullPath(relativeFolderPath) + Path.DirectorySeparatorChar;
		}

		public string FolderPath { get; set; }
		
		public async Task SaveFileAsync(IFormFile formFile, string path)
		{
			string relativeFilePath = Path.Combine(FolderPath, path);
			string absoluteFilePath = Path.GetFullPath(relativeFilePath);
			if (!absoluteFilePath.StartsWith(FolderPath))
			{
				throw new Exception(
					"File cannot be uploaded to path outside of the uploads folder."
					+ Environment.NewLine
					+ "Uploads folder: " + FolderPath
					+ Environment.NewLine
					+ "File path: " + absoluteFilePath
					);
			}

			Directory.CreateDirectory(Path.GetDirectoryName(absoluteFilePath));

			using var stream = new FileStream(absoluteFilePath, FileMode.Create);
			await formFile.CopyToAsync(stream);
		}

		public string GetFileURL(string path)
		{
			string fileSystemPath = configuration["Uploads:URLPath"]
				+ "/"
				+ Path.GetRelativePath(FolderPath, path);
			string urlPath = fileSystemPath.Replace(Path.DirectorySeparatorChar, '/');
			string encodedURLPath = HttpUtility.UrlPathEncode(urlPath);
			return encodedURLPath;
		}
	}
}
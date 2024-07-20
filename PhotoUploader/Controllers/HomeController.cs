using Microsoft.AspNetCore.Mvc;
using PhotoUploader.Models;
using System.Diagnostics;

namespace PhotoUploader.Controllers
{
	public class HomeController : Controller
	{
		ApplicationContext _context;		
		IWebHostEnvironment _appEnvironment;
				
		public HomeController(ApplicationContext context, IWebHostEnvironment appEnvironment)
		{
			_context = context;
			_appEnvironment = appEnvironment;
		}

		public IActionResult Index()
		{
            var uploadedPhotos = _context.Files.OrderByDescending(f => f.UploadedTime).ToList();
            return View(uploadedPhotos);
		}
		
		[HttpPost]
		public async Task<IActionResult> AddFile(IFormFile uploadedFile)
		{
			if (uploadedFile != null)
			{

				string path = "/files/" + uploadedFile.FileName;

				using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
				{
					await uploadedFile.CopyToAsync(fileStream);
				}

				FileModel file = new FileModel 
				{
					Name = uploadedFile.FileName, 
					Path = path,
					UploadedTime=DateTime.Now
				};

				_context.Files.Add(file);

				_context.SaveChanges();
			}

			return RedirectToAction("Index");
		}
	}
}

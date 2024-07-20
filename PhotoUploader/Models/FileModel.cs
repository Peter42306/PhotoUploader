namespace PhotoUploader.Models
{
	public class FileModel
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Path { get; set; }
		public DateTime UploadedTime { get; set; }
	}
}

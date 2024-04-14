using Microsoft.AspNetCore.Mvc;

namespace ShowNest.Web.Controllers
{
    public class UploadImageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //圖床:前端WEB API 
        //[Route("api/[controller]")]
        //[ApiController]

        //public class UploadImageController : ControllerBase
        //{
        //    private readonly IImageFileUploadService _cloudinaryService;

        //    public UploadImageController(IImageFileUploadService cloudinaryService)
        //    {
        //        _cloudinaryService = cloudinaryService;
        //    }

        //    [HttpPost]
        //    [Route("upload")]
        //    public async Task<ActionResult> UploadImages([FromForm] List<IFormFile> files)
        //    {
        //        List<string> urls = new List<string>();

        //        foreach (var file in files)
        //        {
        //            if (file.Length > 0)
        //            {
        //                var url = await _cloudinaryService.UploadImageAsync(file, "uploadFolder");
        //                urls.Add(url);
        //            }
        //        }

        //        if (!urls.Any())
        //        {
        //            return BadRequest("No valid images were uploaded.");
        //        }

        //        // 將圖像的URL存儲到前端的cookie或是以其他方式返回給客戶端
        //        // 這裡僅示例返回URLs列表
        //        return Ok(urls);
        //    }
        //}


        //圖床:直接上傳
        //public class CloudinaryController : Controller
        //{
        //    private readonly IConfiguration _config;
        //    private readonly Cloudinary _cloudinary;
        //    public CloudinaryController(IConfiguration config)
        //    {
        //        _config = config;

        //        string cloudname = _config["Cloudinary:cloudname"];
        //        string apikey = _config["Cloudinary:apikey"];
        //        string apisecret = _config["Cloudinary:apisecret"];

        //        Account account = new Account(cloudname, apikey, apisecret);

        //        _cloudinary = new Cloudinary(account);
        //        _cloudinary.Api.Secure = true;
        //    }

        //    [HttpGet]
        //    public IActionResult CloudinaryUploadFile()
        //    {
        //        return View();
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> UploadToCloudinary(string filePath)
        //    {
        //        try
        //        {
        //            var uploadParams = new ImageUploadParams()
        //            {
        //                File = new FileDescription(filePath),
        //                PublicId = Path.GetFileName(filePath)
        //            };

        //            var uploadResult = _cloudinary.Upload(uploadParams);

        //            // 將Cloudinary的圖片URL儲存到ViewBag或ViewData中
        //            ViewBag.ImageUrl = uploadResult.Url;

        //            return View("SetEvent");
        //        }
        //        catch (Exception ex)
        //        {
        //            ViewData["UploadMessage"] = "上傳失敗:" + ex.ToString();
        //            return View("CloudinaryUploadResult");
        //        }
        //    }
        //}
    }
}

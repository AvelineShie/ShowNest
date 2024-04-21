using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShowNest.Web.Interfaces;

namespace ShowNest.Web.WebAPI
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImgUploadApiController : ControllerBase
    {
        private readonly IImgUploadService _cloudinaryService;

        public ImgUploadApiController(IImgUploadService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
        }


        [HttpPost]
        public async Task<ActionResult> UploadImages([FromForm] List<IFormFile> files)
        {
            List<string> urls = new List<string>();

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var url = await _cloudinaryService.UploadImageAsync(file, "ShowNestImg");
                    urls.Add(url);
                }
            }

            if (!urls.Any())
            {
                return BadRequest("No valid images were uploaded.");
            }

            // 將圖像的URL存儲到前端的cookie或是以其他方式返回給客戶端
            // 這裡僅示例返回URLs列表
            return Ok(urls);
        }

    }
}

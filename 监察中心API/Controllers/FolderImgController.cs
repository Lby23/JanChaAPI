using DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace 监察中心API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FolderImgController : ControllerBase
    {
        FolderImg_DAL folderimg = new FolderImg_DAL();

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="folname"></param>
        /// <returns></returns>
        [HttpGet]
        [EnableCors("any")]
        public ObjectResult Index(int page = 1, int limit = 5, string folname = "")
        {
            var data = folderimg.GetFolderImgs(folname, page, limit);
            var count = data.Count();
            data = data.Skip((page - 1) * limit).Take(limit).ToList();
            return Ok(new { data = data, code = 0, count = count });
        }

        /// <summary>
        /// 下拉框
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [EnableCors("any")]
        public ObjectResult GetFolderImgs()
        {
            var data = folderimg.GetFolders();
            return Ok(new { data = data });
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        [HttpPost]
        [EnableCors("any")]
        public int Add(FolderImg f)
        {
            var code = folderimg.Add(f);
            return code == 1 ? 1 : 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        [HttpPost]
        [EnableCors("any")]
        public int Alter(FolderImg f)
        {
            var code = folderimg.Alter(f);
            return code == 1 ? 1 : 0;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [EnableCors("any")]
        public int Del(int id)
        {
            var code = folderimg.Remove(id);
            return code == 1 ? 1 : 0;
        }

        /// <summary>
        /// 返填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [EnableCors("any")]
        public List<FolderImg> Edit(int id)
        {
            var code = folderimg.GetId(id);
            return code;
        }


        [HttpPost]
        [EnableCors("any")]
        public object InsertPicture([FromForm] IFormCollection formData)
        {
            IFormFile uploadfile = formData.Files[0];
            if (uploadfile != null)
            {
                //文件后缀
                var fileExtension = Path.GetExtension(uploadfile.FileName);
                var strDateTime = DateTime.Now.ToString("yyMMddhhmmssfff"); //取得时间字符串
                var strRan = Convert.ToString(new Random().Next(100, 999)); //生成三位随机数
                var saveName = strDateTime + strRan + fileExtension;
                var path = "image";
                var di = ("/" + path + "/" + saveName);
                var bi = Path.Combine("wwwroot", path);
                if (!Directory.Exists(bi))
                {
                    Directory.CreateDirectory(bi);
                }
                using (FileStream fs = System.IO.File.Create(Path.Combine(bi, saveName)))
                {
                    uploadfile.CopyTo(fs);
                    fs.Flush();
                }
                return new { code = 0, path = di };
            }
            return new { code = 1 };
        }

    }
}

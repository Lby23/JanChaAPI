using DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 监察中心API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        Folder_DAL folder = new Folder_DAL();

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [EnableCors("any")]
        public ObjectResult Index(string folname="",int status=0)
        {
            var data = folder.GetFolders(folname,status);
            var count = data.Count();
            return Ok(new { data = data, code = 0 ,count=count});
        }

        /// <summary>
        /// 下拉框
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [EnableCors("any")]
        public ObjectResult GetFolders()
        {
            var data = folder.Folders();
            return Ok(new { data = data });
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        [HttpPost]
        [EnableCors("any")]
        public int Add(Folder f)
        {
            var code = folder.Add(f);
            return code == 1 ? 1 : 0;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        [HttpPost]
        [EnableCors("any")]
        public int Alter(Folder f)
        {
            var code = folder.Alter(f);
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
            var code = folder.Remove(id);
            return code == 1 ? 1 : 0;
        }

        /// <summary>
        /// 返填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [EnableCors("any")]
        public List<Folder> Edit(int id)
        {
            var code = folder.GetId(id);
            return code;
        }
    }
}

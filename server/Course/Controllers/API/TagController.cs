using Course.Model;
using Course.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RevWorld.Model;
using RevWorld.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevWorld.Controllers.API
{
   // [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class tagsController : ControllerBase
    {
        private static List<Tag> Tags;
        private readonly TagService tagService;


        public tagsController(TagService tagService)
        {
            this.tagService = tagService;
        }

       // [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            bool success = true;
            Tag tag = await tagService.GetTag(id);
            if (tag == null)
            {
                success = false;
            }
            return success ? new JsonResult(tag) : new JsonResult("Tag not found");
        }

        [HttpPost]
        public async Task<JsonResult> AddTag(DTOTag tag)
        {
            Tag tag1 = new Tag()
            {
                TagName = tag.TagName
            };
            return new JsonResult(await tagService.AddTag(tag1));
        }
    }
}

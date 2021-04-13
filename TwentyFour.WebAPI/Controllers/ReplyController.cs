using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TwentyFour.Models;
using TwentyFour.Services;

namespace TwentyFour.WebAPI.Controllers
{
    public class ReplyController : ApiController
    {
        [Authorize]
        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(userId);
            return replyService;
        }
        public IHttpActionResult Post(PostAReplyToAComment model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateReplyService();
            if (!service.CreateReply(model))
                return InternalServerError();
            return Ok();
        }
        //get replies by comment id controller
        public IHttpActionResult Get(int id)
        {
            ReplyService replyService = CreateReplyService();
            var posts = replyService.GetComment();
            return Ok(posts);
        }
    }
}

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
    [Authorize]
    public class CommentController : ApiController
    {
        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new CommentService(userId);
            return postService;
        }
        public IHttpActionResult Post(PostACommentOnAPost model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCommentService();
            if (!service.CreateComment(model))
                return InternalServerError();
            return Ok();
        }
        //get comment by post ID controller
        public IHttpActionResult Get(GetPostComment id)
        {
            CommentService commentService = CreateCommentService();
            var posts = commentService.GetPosts();
            return Ok(posts);
        }
    }
}

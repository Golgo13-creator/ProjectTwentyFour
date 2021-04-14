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
    public class PostController : ApiController
    {
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userId);
            return postService;
        }
        public IHttpActionResult Post(PostAPost model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePostService();
            if (!service.CreatePost(model))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            PostService postService = CreatePostService();
            var posts = postService.GetPost();
            return Ok(posts);
        }
    }
}

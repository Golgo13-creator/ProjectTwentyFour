using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;
using TwentyFour.Models;

namespace TwentyFour.Services
{
    public class PostService
    {
        private readonly Guid _userId;
        public PostService(Guid userId) // Creater a constructor
        {
            _userId = userId;
        }

        // Posting a Post

        public bool CreatePost(PostAPost model)
        {
            var entity = new Post()
            {
                AuthorId = _userId,
                Title = model.Title,
                Text = model.Text
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // Get Post

        public IEnumerable<GetPosts> GetPost()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.AuthorId == _userId)
                        .Select(e => new GetPosts
                        {
                            Id = e.PostId,
                            Title = e.Title,
                            Text = e.Text
                        });
                return query.ToArray();
            }
        }
    }
}
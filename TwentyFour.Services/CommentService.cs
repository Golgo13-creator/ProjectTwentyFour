using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;
using TwentyFour.Models;

namespace TwentyFour.Services
{
    public class CommentService
    {
        private readonly Guid _userId;
        public CommentService(Guid userId)
        {
            _userId = userId;
        }
        // Posting a Comment

        public bool CreateComment(PostACommentOnAPost model)
        {
            var entity = new Comment()
            {
                AuthorId = _userId,
                Text = model.Text
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //get comment by post id
        public IEnumerable<GetPostComment> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.AuthorId == _userId)
                        .Select(E => new GetPostComment
                        {
                            Id = E.PostId,
                            Text = E.Text
                        });
                return query.ToArray();
            }
        }
    }
}

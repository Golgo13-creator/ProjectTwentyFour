using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;
using TwentyFour.Models;

namespace TwentyFour.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;
        public ReplyService(Guid userId)
        {
            _userId = userId;
        }
        // Post Reply

        public bool CreateReply(PostAReplyToAComment model)
        {
            var entity = new Reply()
            {
                AuthorId = _userId,
                Text = model.Text
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //Get Reply
        public IEnumerable<GetCommentReplies> GetComment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.AuthorId == _userId)
                        .Select(E => new GetCommentReplies
                        {
                            Id = E.PostId,
                            Text = E.Text

                        });
                return query.ToArray();
            }
        }
    }
}

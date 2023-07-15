using InterCommunicationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.Repository
{
    public class CommonRepository : ICommonRepository
    {

        private readonly InterCommContext _db;


        public CommonRepository(InterCommContext context)
        {
            _db = context;
        }


        public async Task<Boolean> AddLikeAsync(int userID , int postid)
        {
            var id = await _db.Posts.FindAsync(postid);

            var like = new Like()
            {
               UserId=userID,
               PostId=id.PostId
              


            };


              _db.Likes.Add(like);

            await _db.SaveChangesAsync();



            return true;




           


        }

        public async Task<Comment> AddUCommentAsync(Comment comment)
        {
            var comments = new Comment()
            {

                Comment1 = comment.Comment1,
                CommentedAt = comment.CommentedAt,
                CommentedBy = comment.CommentedBy,
                PostId = comment.PostId


            };

                _db.Comments.Add(comments);

            await _db.SaveChangesAsync();


            return comments;

        }

        public async Task DeleteCommentAsync(int commentId)
        {
            var comments = _db.Comments.Where(x => x.CommentId == commentId).FirstOrDefault();
            _db.Comments.Remove(comments);

            await _db.SaveChangesAsync();

        }

        public async Task<Comment> getAllPostComment(int postid)

        {
            var comments = await _db.Comments.Where(u => u.PostId == postid).Select(u => new Comment()

            {
                CommentedBy = u.CommentedBy,
                CommentedAt = u.CommentedAt,
                Comment1 = u.Comment1
            }).FirstOrDefaultAsync();

            return comments;
        }
    }
}

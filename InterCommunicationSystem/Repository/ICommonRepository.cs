using InterCommunicationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.Repository
{
    public interface ICommonRepository
    {


        Task<Boolean> AddLikeAsync(int userID, int postid);
        Task<Comment> AddUCommentAsync(Comment comment);

        Task DeleteCommentAsync(int commentId);
        Task<Comment> getAllPostComment(int postid);
    }
}

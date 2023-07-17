using InterCommunicationSystem.Models;
using InterCommunicationSystem.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.Repository
{
    public class PostRepository  :IPostRepository
    {

        private readonly InterCommContext context;

        public PostRepository(InterCommContext context)
        {
            this.context = context;
        }


        public async Task<List<Post>> GetPostAsync(int groupid)
        {
            var posts = await context.Posts.Where(p => p.PostedOn == groupid).ToListAsync();
            return posts;



        }

        public async Task<PostViewModel> AddNewPost(PostViewModel post)
        {
            var posts = new Post()
            {
                PostDescription = post.PostDescription,
                PostedAt = post.PostedAt,
                PostedBy = post.PostedBy,
                PostedOn = post.PostedOn,
                PostType = post.PostType,



            };


            this.context.Posts.Add(posts);

            await context.SaveChangesAsync();


            return post;
        }


        public async Task DeletePostASync(int postid)
        {
            var post = context.Posts.Where(x => x.PostId == postid).FirstOrDefault();
            context.Posts.Remove(post);

            await context.SaveChangesAsync();

        }
    }
}


 


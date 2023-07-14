using InterCommunicationSystem.Models;
using InterCommunicationSystem.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.Repository
{
    public class PostRepository
    {

        private readonly InterCommContext context;

        public PostRepository(InterCommContext context)
        {
            this.context = context;
        }


        public async Task<List<Post>> GetPostAsync(int groupid )
        {
            var posts = await context.Posts.Where(p => p.PostedOn == groupid).ToListAsync();
                return posts;



        }

    }
    }
    


 


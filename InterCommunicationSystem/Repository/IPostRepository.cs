﻿using InterCommunicationSystem.Models;
using InterCommunicationSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterCommunicationSystem.Repository
{
    public interface IPostRepository
    {

        Task<List<Post>> GetPostAsync(int groupid);
    }
}

﻿using HiringCompanyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringCompanyService.Access
{
    public interface IUserStoryDB
    {
        List<UserStory> GetUserStory(string projectName);
    }
}
﻿using AcademyHomework.Models;
using AcademyHomework.ServicesContract;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyHomework.Services
{
    public class GitService : IGitService
    {
        IWebConfigurations webConfig;
        public GitService(IWebConfigurations webConfig)
        {
            this.webConfig = webConfig;
        }
        
        public async Task<GitInfo> GetGitInfo(string url, string gitProjectname,string gitTestProjectPath)
        {
            var validate = !string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(gitProjectname);
            if (!validate) return null;

            try
            {
                var urlSplited = url.Split("/", StringSplitOptions.RemoveEmptyEntries);

                if (string.IsNullOrEmpty(urlSplited[GitstringValuPlattern.projectName]) ||
                    urlSplited[GitstringValuPlattern.projectName] != gitProjectname+".git") return null;

                var client = new GitHubClient(new ProductHeaderValue(webConfig.UserAgent));
                //Auth
                var basicAuth = new Credentials(webConfig.Username, webConfig.Password); 
                client.Credentials = basicAuth;
                //Get user
                var username = urlSplited[GitstringValuPlattern.username];
                var user =  await client.User.Get(username);
                
                if (string.IsNullOrEmpty(user.Email)) return null;

                var result = new GitInfo
                {
                    Email = user.Email,
                    Username = username,
                    GitUrl = url,
                    GitTestProjectPath = gitTestProjectPath
                };

                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public class GitstringValuPlattern
        {
            public static int scheme { get; set; } = 0;
            public static int hostUrl { get; set; } = 1;
            public static int username { get; set; } = 2;
            public static int projectName { get; set; } = 3;
        }
    }
}

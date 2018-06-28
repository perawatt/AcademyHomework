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
        public string GetUsernameByGitUrl(string url)
        {
            var urlSplited = url.Split("/" , StringSplitOptions.RemoveEmptyEntries);
            var client = new GitHubClient(new ProductHeaderValue("Unlocking_The_Futhur_Code"));
            var tokenAuth = new Credentials("0ab8687f9efd605baf8812f267d181f5d27979e6");
            client.Credentials = tokenAuth;
            var user = client.User.Get(urlSplited[GitstringValuPlattern.username]).Result;
            throw new NotImplementedException();
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

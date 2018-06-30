using AcademyHomework.Models;
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

        public async Task<GitInfo> GetGitInfo(string url, string gitProjectname, string gitTestProjectPath)
        {
            var validate = !string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(gitProjectname);
            if (!validate) throw new Exception("ข้อมูลไม่ถูกต้อง กรุณาลองอีกครั้ง");


            var urlSplited = url.Split("/", StringSplitOptions.RemoveEmptyEntries);

            if(urlSplited.Count() != 4) throw new Exception("ข้อมูลไม่ถูกต้อง กรุณาลองอีกครั้ง");

            if (string.IsNullOrEmpty(urlSplited[GitstringValuPlattern.projectName]) ||
                urlSplited[GitstringValuPlattern.projectName].Replace(".git", "").ToLower() != gitProjectname.ToLower())
                throw new Exception("Project ไม่ถูกต้อง กรุณากรอก git url ของโปรเจคให้ถูกต้อง");

            var client = new GitHubClient(new ProductHeaderValue(webConfig.UserAgent));
            //Auth
            var basicAuth = new Credentials(webConfig.Username, webConfig.Password);
            client.Credentials = basicAuth;
            //Get user
            var username = urlSplited[GitstringValuPlattern.username];
            var user = await client.User.Get(username);

            if (string.IsNullOrEmpty(user.Email)) throw new Exception("ระบบไม่พบ e-mail ของคุณ กรุณาตั้งค่าให้ e-mail ของคุณเป็นสาธารณะ");

            var result = new GitInfo
            {
                Email = user.Email,
                Username = username,
                GitUrl = url,
                GitTestProjectPath = gitTestProjectPath
            };

            return result;

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

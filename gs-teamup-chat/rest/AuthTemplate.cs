using System.Configuration;

namespace GsTeamupChat
{
    class AuthTemplate : BaseTemplate
    {
        private string authUrl = ConfigurationManager.AppSettings["authUrl"];

        public UserResponse GetUser(long team, long user)
        {
            return Get<UserResponse>(authUrl, "/v1/user/" + user + "/team/" + team);
        }
    }
}

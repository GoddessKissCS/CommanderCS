using Newtonsoft.Json;
using Org.BouncyCastle.Bcpg;
using StellarGK.Database;
using StellarGK.Host.Handlers.Nickname;
using StellarGK.Logic.Protocols;

namespace StellarGK.Host.Handlers.Chat
{
    [Command(Id = CommandId.GetChatIgnoreList)]
    public class GetChatIgnoreList : BaseCommandHandler<GetChatIgnoreListRequest>
    {
        public override string Handle(GetChatIgnoreListRequest @params)
        {
            ResponsePacket response = new();

            var user = DatabaseManager.Account.FindBySession(GetSession());

            List<BlockUser> blockuser = new() { };

            if (user.blockedUsers == null)
            {
                blockuser = new() { };
            }
            else
            {
                blockuser = user.blockedUsers;
            }

            response.result = blockuser;
            response.id = BasePacket.Id;

            return JsonConvert.SerializeObject(response);
        }


    }

    public class GetChatIgnoreListRequest
    {

    }
}
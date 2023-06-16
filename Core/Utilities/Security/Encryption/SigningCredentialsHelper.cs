using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Utilities.Security.Encryption;

public class SigningCredentialsHelper
{
    public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
    {
        //securityKey.KeySize = 512;
        //securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisismycustomSecretkeyforauthneticationthisismycustomSecretkeyforauthnetication"));
        return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);
    }
}
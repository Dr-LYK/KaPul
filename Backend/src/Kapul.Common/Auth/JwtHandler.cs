using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Kapul.Common.Auth
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        private readonly JwtOptions _options;
        private readonly SecurityKey _issuerSigningKey;
        private readonly SigningCredentials _signingCredentials;
        private readonly JwtHeader _jwtHeader;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public JwtHandler(IOptions<JwtOptions> options)
        {
            this._options = options.Value;
            this._issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
            this._signingCredentials = new SigningCredentials(_issuerSigningKey, SecurityAlgorithms.HmacSha256);
            this._jwtHeader = new JwtHeader(_signingCredentials);
            this._tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidIssuer = _options.Issuer,
                IssuerSigningKey = _issuerSigningKey
            };
        }

        public JsonWebToken Create(Guid userId)
        {
            DateTime nowUtc = DateTime.UtcNow;
            DateTime expires = nowUtc.AddMinutes(_options.ExpiryMinutes);
            DateTime centuryBegin = new DateTime(1970, 1, 1).ToUniversalTime();
            long exp = (long)(new TimeSpan(expires.Ticks - centuryBegin.Ticks).TotalSeconds);
            long now = (long)(new TimeSpan(nowUtc.Ticks - centuryBegin.Ticks).TotalSeconds);
            JwtPayload payload = new JwtPayload
            {
                { "sub", userId },
                { "iss", _options.Issuer },
                { "iat", now },
                { "exp", exp },
                { "unique_name", userId }
            };
            JwtSecurityToken jwt = new JwtSecurityToken(_jwtHeader, payload);
            string token = _jwtSecurityTokenHandler.WriteToken(jwt);
            return new JsonWebToken
            {
                Token = token,
                Expires = exp
            };
        }
    }
}

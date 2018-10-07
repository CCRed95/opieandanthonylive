namespace opieandanthonylive.Auth {

  using Microsoft.IdentityModel.Tokens;

  public class JwtIssuerOptions {
    public string             Issuer      { get; set; }
    public string             Audience    { get; set; }
    public SigningCredentials Credentials { get; set; }
  }

}
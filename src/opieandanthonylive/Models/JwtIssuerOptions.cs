namespace opieandanthonylive.Models {

  using Microsoft.IdentityModel.Tokens;

  class JwtIssuerOptions {
    public string             Issuer               { get; set; }
    public string             Audience             { get; set; }
    public SigningCredentials SigniningCredentials { get; set; }
  }

}
var api = CheckoutApi.Create("your secret key");

var tokenData = new Dictionary<string, object>
            {
                { "version", "EC_v1" },
                { "data", "..." },
                { "signature", "..." },
                { "header", new Dictionary<string, string>
                    {
                        { "ephemeralPublicKey", "..." },
                        { "publicKeyHash", "..." },
                        { "transactionId", "..." }
                    }
                }
            };
var request = new WalletTokenRequest(WalletType.ApplePay, tokenData);

try
{
  var token = await api.Tokens.RequestAsync(request);
  token.ShouldNotBeNull();
  token.Token.ShouldNotBeNullOrEmpty();
  token.Type.ShouldBe(WalletType.ApplePay.ToString());
  token.ExpiresOn.ShouldBeGreaterThan(DateTime.UtcNow);
  
  return response.Token;
}
catch (CheckoutValidationException validationEx)
{
  return ValidationError(validationEx.Error);
}
catch (CheckoutApiException apiEx)
{
  Log.Error("Token request failed with status code {HttpStatusCode}", apiEx.HttpStatusCode);
  throw;
}
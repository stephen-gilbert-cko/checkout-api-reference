var api = CheckoutApi.Create("your secret key");

var address = new Address()
{
  AddressLine1 = "Checkout.com",
  AddressLine2 = "90 Tottenham Court Road",
  City = "London",
  State = "London",
  Zip = "W1T 4TJ",
  Country = "GB"
};

var sourceRequest = new SourceRequest("sepa", address);
sourceRequest.Reference = ".NET SDK test";
sourceRequest.Phone = new Phone()
{
  CountryCode = "+1",
  Number = "415 555 2671"
};
sourceRequest.SourceData = new SourceData()
{
    { "first_name", "Marcus" },
    { "last_name", "Barrilius Maximus" },
    { "account_iban", "DE68100100101234567895" },
    { "bic", "PBNKDEFFXXX" },
    { "billing_descriptor", ".NET SDK test" },
    { "mandate_type", "single" }
};

try
{
  var sourceResponse = await api.Sources.RequestAsync(sourceRequest);
  var source = sourceResponse.Source;
}
catch (CheckoutValidationException validationEx)
{
  return ValidationError(validationEx.Error);
}
catch (CheckoutApiException apiEx)
{
  Log.Error("Source request failed with status code {HttpStatusCode}", apiEx.HttpStatusCode);
  throw;
}
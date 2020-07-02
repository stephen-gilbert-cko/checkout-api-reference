var api = CheckoutApi.Create("your secret key");

var getFileResponse = await _api.Files.GetFileAsync(id: "file_zna32sccqbwevd3ldmejtplbhu");
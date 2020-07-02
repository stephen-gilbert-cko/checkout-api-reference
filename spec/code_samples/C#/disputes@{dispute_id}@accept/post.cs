var api = CheckoutApi.Create("your secret key");

var accept = await api.Disputes.AcceptDisputeAsync(id: "dsp_bc94ebda8d275i461229");
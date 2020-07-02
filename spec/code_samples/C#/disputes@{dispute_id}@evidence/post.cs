var api = CheckoutApi.Create("your secret key");

var submitEvidence = await api.Disputes.SubmitDisputeEvidenceAsync(id: "dsp_bc94ebda8d275i461229");
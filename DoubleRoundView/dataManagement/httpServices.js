var baseUrl = "http://localhost:5000/api/DoubleRound/";

window.saveNewDoubleRound = function(inputData) {
	let url = baseUrl + "InsertDoubleRound";

	$.ajax({
		url: url,
		data: JSON.stringify(inputData),
		method: "post",
		contentType: "application/json",
		success: function(response){
			console.log(response);
		},
		error: function(xhr, status, error){
			console.log(error);
		}
	});
}
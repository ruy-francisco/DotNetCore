var NewDoubleRoundForm = new Vue({
	el: '#NewDoubleRoundForm',
	data: {
		errors: [],
		placeName: null,
		placeAddress: null,
		beginDate: null,
		endDate: null
	},
	methods: {
		validadeInputInformation: function(e) {
			this.errors = [];

			if (this.areAllInformationSet())
				return this.insertNewDoubleRound();

			if (!this.placeName)
				this.errors.push("Digite o nome do estabelecimento");

			if (!this.placeAddress)
				this.errors.push("Digite o endereço do estabelecimento");

			if (!this.beginDate)
				this.errors.push("Escolha a data de início.");

			if (!this.endDate)
				this.errors.push("Escolha a data fim.");

			e.preventDefault();
		},
		areAllInformationSet: function () { return this.placeName && this.placeAddress && this.beginDate && this.endDate },
		insertNewDoubleRound: function() {
			let data = {
				"begindate": this.beginDate,
				"enddate": this.endDate,
				"place": this.placeName,
				"latitude": $("#placeLatitude").val(),
				"longitude": $("#placeLongitude").val(),
				"placeId": $("#placeId").val(),
				"placeaddress": $("#placeDefinitiveAddress").val()
			};

			saveNewDoubleRound(data);		
		}
	}
});
var DoubleRoundeSearchArea = new Vue({
	el: "#DoubleRoundeSearchArea",
	data: {
		doubleRoundDate: null,
		doubleRounds: []
	},
	methods: {
		searchDoubleRoundsByDate: function(){
			
			if (!this.doubleRoundDate)
				return alert("Preencha a data e a hora.");

			getDoubleRoundsByDate(this.doubleRoundDate);
		}
	}
});
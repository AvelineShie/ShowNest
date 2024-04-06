const {createApp} = Vue

createApp({
    data() {
        return {
            ticketTypeSelection: {},
            isAgreed: false
        }
    },
    methods: {
        async fetchTicketTypes(eventId) {
            const response = await fetch(`/api/tickettypes/gettickettypeselection?eventId=${eventId}`);
            const data = await response.json()

            this.ticketTypeSelection = data
        },
        onTicketPriceRowClicked(ticketPriceRow, num) {
            if (ticketPriceRow.tickets.purchaseAmount + num < 0) {
                return
            }

            ticketPriceRow.tickets.purchaseAmount += num
        },
        onNextStepClicked() {
            if (!this.isAgreed) {
                alert('Not agreed');
                return;
            }

            const params = new URLSearchParams();
            for (const ticketPriceRow of this.ticketTypeSelection.ticketPriceRow) {
                if (ticketPriceRow.tickets.purchaseAmount !== 0) {
                    params.append(ticketPriceRow.id, ticketPriceRow.tickets.purchaseAmount);
                }
            }

            const redirectUrl = `/events/seatSelector?${params.toString()}`
            window.location = redirectUrl;
        },
    },
    async mounted() {
        const urlParams = new URLSearchParams(window.location.search);
        const eventId = urlParams.get('eventId');

        await this.fetchTicketTypes(eventId);
    }
}).mount('#app')
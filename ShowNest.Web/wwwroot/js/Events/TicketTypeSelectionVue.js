const {createApp, onMounted, ref} = Vue

createApp({
    setup() {
        const ticketTypeSelection = ref({})
        const isAgreed = ref(false)

        async function fetchTicketTypes() {
            const response = await fetch('/api/tickettypes/gettickettypeselection?eventId=100');
            const data = await response.json()

            ticketTypeSelection.value = data
        }

        function onTicketPriceRowClicked(ticketPriceRow, num) {
            if (ticketPriceRow.tickets.purchaseAmount + num < 0) {
                return
            }

            ticketPriceRow.tickets.purchaseAmount += num
        }

        function onNextStepClicked() {
            if (!isAgreed.value) {
                alert('Not agreed');
                return;
            }

            const params = new URLSearchParams();
            for (const ticketPriceRow of ticketTypeSelection.value.ticketPriceRow) {
                if (ticketPriceRow.tickets.purchaseAmount !== 0) {
                    params.append(ticketPriceRow.id, ticketPriceRow.tickets.purchaseAmount);
                }
            }
          
            const redirectUrl = `/events/seatSelector?${params.toString()}`
            window.location = redirectUrl;
        }

        onMounted(async () => {
            await fetchTicketTypes();
        })

        return {
            isAgreed,
            ticketTypeSelection,
            onNextStepClicked,
            onTicketPriceRowClicked
        }
    }
}).mount('#app')
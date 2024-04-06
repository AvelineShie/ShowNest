const {createApp} = Vue

createApp({
    data() {
        return {
            mode: 'selectArea',
            seatAreaId: 1,
            seatViewModel: {},
            selectedSeats: []
        }
    },
    methods: {
        async onAreaSelected(areaId) {
            this.mode = "selectSeat";
            
            this.seatAreaId = areaId;

            await this.fetchSeats();
            this.mountBSTooltips();
        },
        onBackToAreaSelected() {
            this.mode = "selectArea";
        },
        onSeatSelected(rowIndex, seatIndex) {
            const seat = this.seatViewModel.seats[rowIndex][seatIndex];
            if (seat.seatStatus === 0) {
                this.seatViewModel.seats[rowIndex][seatIndex] = {...seat, seatStatus: 1}
            }
            if (seat.seatStatus === 1) {
                this.seatViewModel.seats[rowIndex][seatIndex] = {...seat, seatStatus: 0}
            }
        },
        async fetchSeats() {
            const response = await fetch(`/api/seats?seatAreaId=${this.seatAreaId}`);
            this.seatViewModel = await response.json();
        },
        mountBSTooltips() {
            //Bootstrap tooltip trigger
            const tooltipTriggerList = document.querySelectorAll('[data-bs-toggle="tooltip"]')
            const tooltipList = [...tooltipTriggerList].map(tooltipTriggerEl => new bootstrap.Tooltip(tooltipTriggerEl))
        }
    },
    computed: {
        isAreaMode() {
            return this.mode === 'selectArea'
        },
        isSeatMode() {
            return this.mode === 'selectSeat'
        }
    },
    mounted() {
    },
}).mount('#app')


const {createApp} = Vue

createApp({
    data() {
        return {
            counter: '',
            remainTime: 0,
            mode: 'selectArea',
            showModal: false,
            seatAreaId: 1,
            seatViewModel: {},
            selectedSeats: [],
            tickets: []
        }
    },
    methods: {
        startCountdown() {
            setInterval(() => {

                let minutes = Math.floor(this.remainTime / 60);
                let seconds = Math.floor(this.remainTime % 60);

                minutes = minutes < 10 ? '0' + minutes : minutes;
                seconds = seconds < 10 ? '0' + seconds : seconds;

                this.counter = minutes + ':' + seconds;

                if (this.remainTime > 0) {
                    this.remainTime--;
                } else {
                    clearInterval();
                }

            }, 1000);
        },
        setExpireTime(timesUp) {
            $cookies.set("expireTimeOnSelection", timesUp)
        },
        getExpireTime() {
            return $cookies.get("expireTimeOnSelection");
        },
        onConfirmSeatClicked() {
            this.showModal = !this.showModal;
        },
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
        async fetchTickets() {
            const params = new URLSearchParams(window.location.search);
            const criteria = []
            for (const [key, value] of params) {
                criteria.push({
                    TicketTypeId: key,
                    TicketCount: value
                })
            }

            const response = await fetch('/api/TicketTypes/GetAutoSelectedSeats', {
                method: 'POST',
                headers: {
                    "content-type": "application/json"
                },
                body: JSON.stringify({
                    Criteria: criteria
                })
            });
            this.tickets = (await response.json()).tickets;
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
        },
        subtotalTicketsPrice() {
            if (this.tickets.length === 0) {
                return 0;
            }

            return this.tickets.reduce((total, ticket) => total + ticket.price, 0);
        }
    },
    async mounted() {
        let expireTime = this.getExpireTime();
        let setTimer = 600000;
        if (!expireTime) {
            expireTime = new Date().getTime() + setTimer * 1000;

            this.setExpireTime(expireTime);
        }

        const remainTimeMs = expireTime - new Date().getTime();
        if (remainTimeMs <= 0) {
            window.alert('選位已截止，請重新購票');
            window.location.href = 'TicketTypeSelection';
            $cookies.remove('expireTimeOnSelection');
        } else {
            this.remainTime = remainTimeMs / 1000;
            this.startCountdown();
        }

        await this.fetchTickets();
    },
}).mount('#app')


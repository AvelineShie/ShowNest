const {createApp} = Vue
const {createVuetify} = Vuetify

const vuetify = createVuetify()

const options = {
    data() {
        return {
            e1: 1,
            message: 'Hello Vue!',
            selectTicketTypeStatus: false,
            ticketTypes: [
                {
                    id: 1,
                    name: "全票",
                    seatAreas: ["B1特一", "B1特二"],
                    price: 3000
                },
                {
                    id: 2,
                    name: "全票",
                    seatAreas: ["B1特一", "B1特二"],
                    price: 2600
                },
                {
                    id: 3,
                    name: "全票",
                    seatAreas: ["B1特一", "B1特二"],
                    price: 2400
                }
            ],
            selectedTicketTypeResult: [
                {
                    id: 1,
                    name: "全票",
                    seatArea: ["B1特一", "B1特二"],
                    price: 3000,
                    count: 2
                }
            ],
            resultTicketTypeResult: [
                {
                    id: 1,
                    name: "全票",
                    seatArea: "B1特一",
                    price: 3000,
                    seatNumber: "1-8"
                },
                {
                    id: 90,
                    name: "全票",
                    seatArea: "B1特一",
                    price: 3000,
                    seatNumber: "1-2"
                }
            ],
            editTicket:{
                id: 1,
                name: "全票",
                seatArea: "B1特一",
                price: 3000,
                seatNumber: "1-8"
            },
            //counter
            counter: '',
            remainTime: 0,
        }
    },
    mounted() {
        console.log('App mounted!')
        let expireTime = this.getExpireTime();
        let setTimer = 600;
        if (!expireTime) {
            expireTime = new Date().getTime() + setTimer * 1000;

            this.setExpireTime(expireTime);
        }

        const remainTimeMs = expireTime - new Date().getTime();
        if (remainTimeMs <= 0 ) {
            window.alert('選位已截止，請重新購票');
            window.location.href = 'TicketTypeSelection';
            $cookies.remove('expireTimeOnSelection');
        } else {
            this.remainTime = remainTimeMs / 1000;
            this.startCountdown();
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
                }
                else {
                    clearInterval();
                }

            }, 1000);
        },
        setExpireTime(timesUp) {
            $cookies.set("expireTimeOnSelection", timesUp)
        },
        getExpireTime() {
            return $cookies.get("expireTimeOnSelection");
        }
    }
}
const app = createApp(options)
app.use(vuetify).mount('#app')

// Element
const displayConfirmWrap = document.querySelector('.confirm-wrap');
const $btnConfirm = document.querySelector('.action-bar :nth-child(3)');
const $btnRwdConfirm = document.querySelector('.rwd-fixed-btns :nth-child(2)');

// EventHandler
$btnConfirm.addEventListener('click', btnConfirmOnClicked);
$btnRwdConfirm.addEventListener('click', btnConfirmOnClicked);

//Function
function btnConfirmOnClicked() {
    displayConfirmWrap.style.display = (displayConfirmWrap.style.display === 'none') ? '' : 'none';
}


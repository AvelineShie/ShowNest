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

//Vue.js
const {createApp} = Vue

createApp({
    data() {
        return {
            counter: '',
            remainTime: 0,
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
    },
    mounted() {
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
}).mount('#countdownOnSelection')


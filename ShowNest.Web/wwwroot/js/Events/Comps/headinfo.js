import {
    step
} from "/js/Events/Comps/step.js";

export const headinfo = {
    template: /*html*/ `
<div class="title">
    <h2>{{title}}</h2>
    <a class="event_link" target="_blank" href="#">
        <i class="fa fa-external-link fa-front"></i>
        活動頁面
    </a>
</div>
<div class="event_details">
    <div class="collapse_group">
        <p class="d-inline-flex gap-1">
            <button class="event_detail_collapse btn" type="button" data-bs-toggle="collapse" data-bs-target="#collapse-example" aria-expanded="false" aria-controls="collapse-example" stlye="box-shadow: none; background-color:none;">
                顯示活動詳細資料
            </button>
        </p>
        <div class="collapse" id="collapse-example">
            <table class="details">
                <tbody>
                    <tr class="">
                        <th class="start_time">開始時間</th>
                        <td class="time">
                            {{startTime}}
                            <a class="is_following binding" :href="'http://www.google.com/calendar/event?action=TEMPLATE&text='+title+'&dates='+startTime+'&trp=false'" target="_blank">
                                <!-- <a class="is_following binding" :href="ymd(startTime)" target="_blank"> -->
                                <i class="fa fa-calendar fa-front"></i>
                                加入行事曆
                                <!-- &dates=[start-custom format='Ymd\\THi00\\Z']/[end-custom format='Ymd\\THi00\\Z'] -->

                                <!-- https://www.google.com/calendar/event?action=TEMPLATE&text=%E7%94%B2%E7%99%BE%E5%90%88-%E4%B8%96%E7%95%8C%E6%96%B0%E5%B7%A1%E8%BF%B4%E6%BC%94%E5%94%B1%E6%9C%83&dates=20240406T110000Z/20240406T110000Z&details=https://jiazamusic.kktix.cc/events/5c77a8c5&location=%E9%AB%98%E9%9B%84%E5%9C%8B%E5%AE%B6%E9%AB%94%E8%82%B2%E5%A0%B4&trp=true&sprop=https://jiazamusic.kktix.cc/events/5c77a8c5&sprop=name:KKTIX -->
                            </a>
                        </td>
                    </tr>
                    <!-- location -->
                    <tr class="">
                        <th class="event_location">活動地點</th>
                        <td class="location">
                            {{eventLocation}} / {{eventAddress}}
                            <a class="is_following binding " target="_blank" :href="'https://www.google.com.tw/maps/search/'+eventAddress">
                                <i class="fa fa-map-marker fa-front"></i>
                                檢視地圖
                            </a>
                        </td>
                    </tr>
                    <!-- event.co_organizer -->
                    <tr>
                        <th class="co_organizer">主辦單位</th>
                        <td class="co_organizer_name">{{eventHost}}</td>
                    </tr>
                    <!--  pickup_types -->
                    <tr class="pickup_types_group">
                        <th class="pickup_types">票券種類</th>
                        <td class="type_names">
                            {{ticketCollectionChannel}}
                        </td>

                    </tr>
                    <!--payment_terms -->
                    <tr class="payment_terms_group">
                        <th class="payment_terms">付款方式</th>
                        <td class="payment_names">
                            {{paymentMethodName}}
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div class="progress_container">
        <step :step="step"></step>
    </div>
</div>
`,
    props: {
        'step': {
            type: Number
        },
        'title': {
            type: String
        },
        'startTime': {
            type: String
        },
        'eventLocation': {
            type: String
        },
        'eventAddress': {
            type: String
        },
        'eventHost': {
            type: String
        },
        'ticketCollectionChannel': {
            type: String
        },
        'paymentMethodName': {
            type: String
        }
    },
    components: {
        step
    },

    methods: {
        ymd(str) {
            let dt = new Date(str).toISOString().replace('-', '/').split('T')[0].replace('-', '/');
            alert(dt);
        }
    },
}
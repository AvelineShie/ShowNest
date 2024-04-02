import {api} from "/js/api/api.js"

export const user = {
    GetUserOrderList: function (handler, error){
        api.request.get('api/UserAccount/GetUserOrderList', handler, error);
    }
}
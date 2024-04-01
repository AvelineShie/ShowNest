export const tools = {
    moneyformatter(value) {
        if (value == 0 || value == null) {
            return "免費";
        }
        let NTDollar = new Intl.NumberFormat('en-US', {
            style: 'currency',
            currency: 'TWD',
        });

        return NTDollar.format(value);
    },

    dateformatter(value) {
        //2013/01/12 09:00
        let d = new Date(value);
        return `${d.getFullYear()}/${double(d.getMonth() + 1)}/${double(d.getDate())} ${double(d.getHours())}:${double(d.getMinutes())}`;
    }
}

function double(value) {
    if (value < 10) {
        return `0${value}`;
    } else {
        return value;
    }
}


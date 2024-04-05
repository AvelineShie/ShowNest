import draggable from "@/vuedraggable";

export default {
    name: "two-lists",
    display: "Two Lists",
    order: 1,
    components: {
        draggable
    },
    data() {
        return {
            list1: [
                { name: "一般票", id: 1 },
                { name: "兒童票", id: 2 },
                { name: "VIP票", id: 3 },
                { name: "敬老票", id: 4 }
            ],
            list2: [
                
            ]
        };
    },
    methods: {
        add: function () {
            this.list.push({ name: "Juan" });
        },
        replace: function () {
            this.list = [{ name: "Edgard" }];
        },
        clone: function (el) {
            return {
                name: el.name + " cloned"
            };
        },
        log: function (evt) { //拖曳紀錄
            window.console.log(evt);
        }

        //log: function (evt) {
        //    if (evt.type === "dragend") {
        //        // 獲取使用者選定的List2中的選項
        //        const selectedOptions = evt.target.querySelectorAll(".list-group-item");

        //        // 處理選定的選項
        //        for (const option of selectedOptions) {
        //            console.log(option.textContent);
        //        }
        //    }
        //}
    }
};
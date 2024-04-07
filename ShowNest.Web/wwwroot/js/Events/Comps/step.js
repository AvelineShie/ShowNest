export const step = {
    template: /*html*/ `
<div class="progress_container" v-if="step>0">
    <div class="step_progress_bar" id="step_progress_bar">
        <span class="step disabled" :class="{progressing  : step == 1}">
            <span class="number ">1</span>
            <p class="step_text">選擇票種</p>
        </span>
        <span class="step disabled" :class="{progressing  : step == 2}">
            <span class="number ">2</span>
            <p class="step_text">劃位</p>
        </span>
        <span class="step disabled" :class="{progressing  : step == 3}">
            <span class="number">3</span>
            <p class="step_text">填寫表單</p>
        </span>
        <span class="step disabled" :class="{progressing  : step == 4}">
            <span class="number">4</span>
            <p class="step_text">取票繳費</p>
        </span>
    </div>
</div>
`,
    props: {
        'step': {
            type: Number
        }
    }
}
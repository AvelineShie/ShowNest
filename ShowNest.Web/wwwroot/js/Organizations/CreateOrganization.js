const { createApp } = Vue

createApp({
    data() {
        return {
            // for rapid testing

            // name: 'aaaa',
            // organizationUrl: 'organizationUrl',
            // outerUrl: 'outerUrl',
            // editor: ClassicEditor,
            // description: '<p>editor.</p>',
            // editorConfig: {
            //     language: 'zh-cn',
            //     toolbar: ['bold', 'italic', 'link', 'undo', 'redo']
            // },
            // fbLink: 'fb',
            // igAccount: 'ig',
            // email: 'emailllll',
            // imgUrl: 'https://picsum.photos/800/180/?random=87',
            // contactName: 'ccname',
            // contactMobile: 'ccmobile',
            // contactTelephone: 'cctele',

            // for real using

            name: '',
            organizationUrl: '',
            outerUrl: '',
            editor: ClassicEditor,
            description: '',
            editorConfig: {
                language: 'zh-cn',
                toolbar: ['bold', 'italic', 'link', 'undo', 'redo']
            },
            fbLink: '',
            igAccount: '',
            email: '',
            imgUrl: 'https://picsum.photos/800/180/?random=87',
            contactName: '',
            contactMobile: '',
            contactTelephone: '',
            isChecked: false,
        }
    },
    methods: {
        createOrganization() {
            console.log('createOrganization')
            axios.post('/api/CreateOrganization/CreateOrganization', {
                name: this.name,
                organizationUrl: this.organizationUrl,
                outerUrl: this.outerUrl,
                description: this.description,
                fbLink: this.fbLink,
                igAccount: this.igAccount,
                email: this.email,
                imgUrl: this.imgUrl,
                contactName: this.contactName,
                contactMobile: this.contactMobile,
                contactTelephone: this.contactTelephone
            }).then(operationResult => {
                console.log('axios createOrganization res')
                console.log(operationResult)
                window.location.href = `/Dashboard/Organizations/${operationResult.data.data}?viewType=Overview`
            }).catch(operationResult => {
                console.log('axios createOrganization err')
                console.log(operationResult.message)
            })
        }
    },
}).use(CKEditor).mount('#app')
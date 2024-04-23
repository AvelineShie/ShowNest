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

            creating: false,
            editing: false,
            orgId: 0,

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
            imgUrl: 'https://res.cloudinary.com/do2tfk5nk/image/upload/v1713610498/ShowNestImg/UnUploadedImg_vsrtfu.jpg',
            contactName: '',
            contactMobile: '',
            contactTelephone: '',

            isChecked: false,
        }
    },
    methods: {
        checkPagePurpose() {
            let lowerCaseUrl = window.location.href.toLocaleLowerCase()
            if (lowerCaseUrl.includes('edit')) {
                this.editing = true
                this.creating = false
            } else if (lowerCaseUrl.includes('create')) {
                this.creating = true
                this.editing = false
            } else {
                this.editing = false
                this.creating = false
            }
            console.log('creating :')
            console.log(this.creating)
            console.log('editing :')
            console.log(this.editing)
        },
        submit() {
            console.log('submit()')

            console.log(
                this.orgId,
                this.name,
                this.organizationUrl,
                this.outerUrl,
                this.description,
                this.fbLink,
                this.igAccount,
                this.email,
                this.imgUrl,
                this.contactName,
                this.contactMobile,
                this.contactTelephone
            )
            axios.post('/api/CreateAndUpdateOrganization/CreateAndUpdateOrganization', {
                orgId: this.orgId,
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
        },
        imgUpload(e) {
            let formData = new FormData();
            for (let i = 0; i < e.target.files.length; i++) {
                formData.append('files', e.target.files[i]);
            }
            axios.post('/api/ImgUploadApi/UploadImages', formData, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            })
                .then(res => {
                    console.log(res)
                    this.imgUrl = res.data[0]
                })
                .catch(err => {
                    console.error(err);
                })
        },
        dataFillingForEditOrg() {
            console.log('dataFillingForEditOrg()')
            if (this.editing) {
                // 從網址拿到組織id
                // 看EditOrganization/(數字是多少)
                let regex = /editorganization\/\d+/i
                let orgIdFromLink = null
                let match = window.location.href.match(regex)
                if (match) {
                    orgIdFromLink = match[0].match(/\d+/)[0]
                    this.orgId = orgIdFromLink
                }

                axios.get(`/api/CreateAndUpdateOrganization/EditOrganizationDataFilling/${orgIdFromLink}`)
                    .then(res => {
                        console.log(res)
                        let info = res.data.data
                        this.name = info.name
                        this.organizationUrl = info.name
                        this.outerUrl = info.outerUrl
                        this.description = info.description
                        this.fbLink = info.fbLink
                        this.igAccount = info.igAccount
                        this.email = info.email
                        this.imgUrl = info.imgUrl
                        this.contactName = info.contactName
                        this.contactMobile = info.contactMobile
                        this.contactTelephone = info.contactTelephone
                    })
                    .catch(err => {
                        console.error(err);
                    })
            }
        }
    },
    mounted() {
        this.checkPagePurpose()
        if (this.editing) {
            this.dataFillingForEditOrg()
        }
    },
}).use(CKEditor).mount('#app')
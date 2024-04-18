const { createApp } = Vue

createApp({
	data() {
		return {

		}
	},
	methods: {
		redirectToEditOrganizationPage() {
			window.location.href = `/Organizations/EditOrganization/${this.orgId}`
		}
	},
	mounted() {
		this.orgId = $('.org-info-title button').attr('orgId')
	},
}).mount('#app')
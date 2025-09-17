<template>
    <div>
        <div class="d-flex flex-column flex-root app-root" id="kt_app_root">
            <div class="app-page flex-column flex-column-fluid" id="kt_app_page">
                <div class="app-wrapper flex-column flex-row-fluid" id="kt_app_wrapper">
                    <div class="app-main flex-column flex-row-fluid" id="kt_app_main">
                        <div class="d-flex flex-column flex-column-fluid">
                            <div id="kt_app_toolbar" class="app-toolbar py-3 py-lg-6">
                                <div id="kt_app_toolbar_container"
                                    class="app-container container-xxl d-flex flex-stack">
                                    <div class="page-title d-flex flex-column justify-content-center flex-wrap me-3">
                                        <h1
                                            class="page-heading d-flex text-gray-900 fw-bold fs-3 flex-column justify-content-center my-0">
                                            Şirket Kayıt Formu</h1>
                                    </div>
                                </div>
                            </div>

                            <div id="kt_app_content" class="app-content flex-column-fluid">
                                <div id="kt_app_content_container" class="app-container container-xxl">
                                    <div class="card p-5">
                                        <div class="card-body">
                                            <form id="company-register-form">
                                                <div class="row">
                                                    <h4 class="mb-5">Şirket Bilgileri</h4>
                                                    <div class="col-md-6 mb-4">
                                                        <label class="form-label fs-6">Şirket Adı</label>
                                                        <input type="text" class="form-control"
                                                            v-model="form.companyName" required>
                                                    </div>
                                                    <div class="col-md-6 mb-4">
                                                        <label class="form-label fs-6">Şirket E-posta Adresi</label>
                                                        <input type="email" class="form-control"
                                                            v-model="form.companyEmail" required>
                                                    </div>
                                                </div>

                                                <div class="row mt-5">
                                                    <h4 class="mb-5">Süper Admin Bilgileri</h4>
                                                    <div class="col-md-6 mb-4">
                                                        <label class="form-label fs-6">Adınız</label>
                                                        <input type="text" class="form-control" v-model="form.userName"
                                                            required>
                                                    </div>
                                                    <div class="col-md-6 mb-4">
                                                        <label class="form-label fs-6">Soyadınız</label>
                                                        <input type="text" class="form-control"
                                                            v-model="form.userSurname" required>
                                                    </div>
                                                    <div class="col-md-6 mb-4">
                                                        <label class="form-label fs-6">Kullanıcı Adı</label>
                                                        <input type="text" class="form-control"
                                                            v-model="form.userUsername" required>
                                                    </div>
                                                    <div class="col-md-6 mb-4">
                                                        <label class="form-label fs-6">E-posta Adresiniz</label>
                                                        <input type="email" class="form-control"
                                                            v-model="form.userEmail" required>
                                                    </div>
                                                    <div class="col-md-6 mb-4">
                                                        <label class="form-label fs-6">Şifreniz</label>
                                                        <input type="password" class="form-control"
                                                            v-model="form.userPassword" required>
                                                    </div>
                                                    <div class="col-md-6 mb-4">
                                                        <label class="form-label fs-6">Şifreniz Tekrar</label>
                                                        <input type="password" class="form-control"
                                                            v-model="form.userPasswordConfirm" required>
                                                    </div>
                                                </div>

                                                <div class="d-grid mt-5">
                                                    <button type="button" class="btn btn-primary btn-lg"
                                                        :disabled="isLoading" @click="registerCompany()">
                                                        <span v-if="isLoading"
                                                            class="spinner-border spinner-border-sm me-2" role="status"
                                                            aria-hidden="true"></span>
                                                        Kayıt Ol
                                                    </button>
                                                </div>
                                                <div class="text-center mt-4">
                                                    <a href="/login" class="text-primary fw-bold">Zaten hesabın var mı?
                                                        Giriş Yap</a>
                                                </div>
                                            </form>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';

export default {
    name: "CompanyCreate",
    data() {
        return {
            form: {
                companyName: null,
                companyEmail: null,
                userName: null,
                userSurname: null,
                userUsername: null,
                userPassword: null,
                userEmail: null,
                userPasswordConfirm: null
            },
            isLoading: false
        };
    },
    methods: {
        validateForm() {
            if (!this.form.companyName || !this.form.companyEmail || !this.form.userName || !this.form.userSurname || !this.form.userUsername || !this.form.userPassword || !this.form.userEmail) {
                this.$swal("Hata", "Lütfen tüm zorunlu alanları doldurunuz.", "error");
                return false;
            }
             if (this.form.userPassword !== this.form.userPasswordConfirm) {
                this.$swal("Hata", "Şifreler birbiriyle eşleşmiyor.", "error");
                return false;
            }
            return true;
        },
        registerCompany() {
            if (!this.validateForm()) {
                return;
            }
            delete this.form.confirmPassword; // confirmPassword'ı backend'e göndermiyoruz
            this.isLoading = true;
            axios.post("/api/company/CreateCompany", this.form, {
                "Content-Type": "application/json"
            })
                .then((response) => {
                    this.isLoading = false;
                    if (response.data === "Kayıt işlemi başarılı.") {
                        this.$swal("Başarılı", "Şirket ve Süper Admin hesabı başarıyla oluşturuldu.", "success").then((result) => {
                            if (result.isConfirmed) {
                                this.$router.push('/login');
                            }
                        });
                        this.form = {
                            companyName: null,
                            companyEmail: null,
                            userName: null,
                            userSurname: null,
                            userUsername: null,
                            userPassword: null,
                            userEmail: null,
                        };
                    } else {
                        this.$swal("Hata", response.data, "error");
                    }
                })
                .catch((error) => {
                    this.isLoading = false;
                    let errorMessage = "Kayıt işlemi sırasında bir hata oluştu. Lütfen daha sonra tekrar deneyin.";
                    if (error.response && error.response.data) {
                        errorMessage = error.response.data;
                    }
                    this.$swal("Hata", errorMessage, "error");
                });
        }
    }
};
</script>

<style scoped>
/* Mevcut CSS dosyanızdaki stillere uygun eklemeler buraya gelebilir */
</style>
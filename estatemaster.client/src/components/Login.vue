<template>
    <div class="backgroung-login">
        <div class="d-flex flex-column flex-root" id="kt_app_root">
            <!--begin::Authentication - Sign-in -->
            <div class="d-flex flex-column flex-column-fluid flex-lg-row">
                <!--begin::Aside-->
                <div class="d-flex flex-center w-lg-50 pt-15 pt-lg-0 px-10">
                    <!--begin::Aside-->
                    <div class="d-flex flex-center flex-lg-start flex-column">
                        <!--begin::Logo-->
                        <a href="index.html" class="mb-7">
                            <img alt="Logo" src="/assets/media/logos/custom-3.svg" />
                        </a>
                        <!--end::Logo-->
                        <!--begin::Title-->
                        <h2 class="text-white fw-normal m-0">Branding tools designed for your business</h2>
                        <!--end::Title-->
                    </div>
                    <!--begin::Aside-->
                </div>
                <!--begin::Aside-->
                <div class="foxy-welcome-box text-center">
                    <img src="/assets/media/foxy/welcome_fox.png" alt="Hoşgeldiniz Tilkisi" class="foxy-img" />
                </div>
                <!--begin::Body-->
                <div
                    class="d-flex flex-column-fluid flex-lg-row-auto justify-content-center justify-content-lg-end p-12 p-lg-20">
                    <!--begin::Card-->
                    <div class="bg-body d-flex flex-column align-items-stretch flex-center rounded-4 w-md-600px p-20">
                        <!--begin::Wrapper-->
                        <div class="d-flex flex-center flex-column flex-column-fluid px-lg-10 pb-15 pb-lg-20">
                            <!--begin::Form-->
                            <form class="form w-100" id="kt_sign_in_form" data-kt-redirect-url="index.html" action="#">
                                <!--begin::Heading-->
                                <div class="text-center mb-11">
                                    <!--begin::Title-->
                                    <h1 class="text-gray-900 fw-bolder mb-3">Giriş Yap</h1>
                                    <!--end::Title-->
                                    <!--begin::Subtitle-->
                                    <div class="text-gray-500 fw-semibold fs-6">Hoşgeldiniz</div>
                                    <!--end::Subtitle=-->
                                </div>
                                <!--begin::Heading-->
                                <!--begin::Input group=-->
                                <div class="fv-row mb-8">
                                    <!--begin::Email-->
                                    <input v-model="this.username" type="text" placeholder="Kullanıcı Adı" name="email"
                                        autocomplete="off" class="form-control bg-transparent" />
                                    <!--end::Email-->
                                </div>
                                <!--end::Input group=-->
                                <div class="fv-row mb-3">
                                    <!--begin::Password-->
                                    <input v-model="this.password" type="password" placeholder="Şifre" name="password"
                                        autocomplete="off" class="form-control bg-transparent" />
                                    <!--end::Password-->
                                </div>
                                <!--end::Input group=-->
                                <!--begin::Wrapper-->
                                <div class="d-flex flex-stack flex-wrap gap-3 fs-base fw-semibold mb-8">
                                    <div></div>
                                    <!--begin::Link-->
                                    <a href="authentication/layouts/creative/reset-password.html"
                                        class="link-primary">Forgot Password ?</a>
                                    <!--end::Link-->
                                </div>
                                <!--end::Wrapper-->
                                <!--begin::Submit button-->
                                <div class="d-grid mb-10">
                                    <button type="button" id="kt_sign_in_submit" class="btn btn-primary"
                                        @click="submit()">
                                        <!--begin::Indicator label-->
                                        <span class="indicator-label">Giriş Yap</span>
                                        <!--end::Indicator label-->
                                        <!--begin::Indicator progress-->
                                        <span class="indicator-progress">Lütfen Bekleyin...
                                            <span
                                                class="spinner-border spinner-border-sm align-middle ms-2"></span></span>
                                        <!--end::Indicator progress-->
                                    </button>
                                </div>
                                <!--end::Submit button-->
                                <!--begin::Sign up-->
                                <div class="d-flex flex-stack px-lg-10">
                                    <div class="d-flex fw-semibold text-primary fs-base gap-5">
                                        <div class="text-gray-500 text-center fw-semibold fs-6">
                                            <router-link :to="{ name: 'SelfRegistration' }">
                                                <span class="link-primary"> Kullanıcı Kaydı Oluştur</span>
                                            </router-link>
                                        </div>
                                    </div>
                                    <div class="d-flex fw-semibold text-primary fs-base gap-5">
                                        <div class="text-gray-500 text-center fw-semibold fs-6">
                                            <router-link :to="{ name: 'CompanyCreate' }">
                                                <span class="link-primary">Şirket Hesabı Oluştur</span>
                                            </router-link>
                                        </div>
                                    </div>
                                </div>
                                <!--end::Sign up-->
                            </form>
                            <!--end::Form-->
                        </div>
                        <!--end::Wrapper-->
                        <!--begin::Footer-->
                        <div class="d-flex flex-stack px-lg-10">

                            <!--end::Languages-->
                            <!--begin::Links-->
                            <div class="d-flex fw-semibold text-primary fs-base gap-5">
                                <a href="pages/team.html" target="_blank">Terms</a>
                                <a href="pages/pricing/column.html" target="_blank">Plans</a>
                                <a href="pages/contact.html" target="_blank">Contact Us</a>
                            </div>
                            <!--end::Links-->
                        </div>
                        <!--end::Footer-->
                    </div>
                    <!--end::Card-->
                </div>
                <!--end::Body-->
            </div>
            <!--end::Authentication - Sign-in-->
        </div>
    </div>
</template>
<script>
import axios from 'axios'
import { mapActions } from "vuex";
// SecureLS'i sadece Vuex modülünde kullanalım, burada direkt kullanmaya gerek yok
// import SecureLS from "secure-ls"; 
// const ls = new SecureLS({ isCompression: true, encodingType: 'aes' });

export default {
    name: 'Login',
    data() {
        return {
            username: null,
            password: null
        }
    },
    methods: {
        ...mapActions('auth', ["LogIn"]),

        async submit() {
            console.log("Submit metodu çalıştı. Kullanıcı adı:", this.username); // Yeni eklenen satır
            const loginPayload = new FormData();
            loginPayload.append("username", this.username);
            loginPayload.append("password", this.password);

            try {
                const result = await this.LogIn(loginPayload);
                console.log("LogIn action'ından dönen sonuç:", result); // Yeni eklenen satır

                if (result.success) {
                    this.$swal("Giriş Başarılı", result.message || "Hoşgeldiniz!", 'success').then(() => {
                    });
                     window.location.href = "/";
                } else {
                    this.$swal("Giriş Başarısız", result.message || "Bilinmeyen bir hata oluştu. Lütfen tekrar deneyiniz.", 'error');
                }
            } catch (error) {
                console.error("Login işlemi sırasında beklenmedik bir hata oluştu:", error);
                this.$swal("Hata", "Beklenmedik bir hata oluştu. Lütfen tekrar deneyiniz.", 'error');
            }
        },
    }
}
</script>



<style scoped>
.backgroung-login {
    background-image: url('assets/media/auth/bg4.jpg');
    height: 100vh;
    background-size: cover;
}

.foxy-welcome-box {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin-right: -271px;
}

.foxy-img {
    width: 720px;
    max-width: 100%;
    margin-bottom: 16px;
    filter: drop-shadow(0 4px 16px rgba(0, 0, 0, 0.08));
}
</style>
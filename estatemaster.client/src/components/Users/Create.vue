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
                                            Yeni Kullanıcı Oluştur
                                        </h1>
                                        <span class="text-muted fs-7">Yönetici olarak kendi şirketinize yeni bir
                                            kullanıcı hesabı oluşturun.</span>
                                    </div>
                                </div>
                            </div>
                            <div id="kt_app_content" class="app-content flex-column-fluid">
                                <div id="kt_app_content_container" class="app-container container-xxl">
                                    <div class="card p-5">
                                        <div class="card-body">
                                            <form id="admin-user-create-form" @submit.prevent="createAdminUser()">
                                                <div class="row">
                                                    <h4 class="mb-5">Kullanıcı Bilgileri</h4>

                                                    <div class="col-md-6 mb-4">
                                                        <label class="form-label fs-6">Adı <span
                                                                class="text-danger">*</span></label>
                                                        <input type="text" class="form-control" v-model="form.name"
                                                            required>
                                                    </div>

                                                    <div class="col-md-6 mb-4">
                                                        <label class="form-label fs-6">Soyadı <span
                                                                class="text-danger">*</span></label>
                                                        <input type="text" class="form-control" v-model="form.surname"
                                                            required>
                                                    </div>

                                                    <div class="col-md-6 mb-4">
                                                        <label class="form-label fs-6">Kullanıcı Adı <span
                                                                class="text-danger">*</span></label>
                                                        <input type="text" class="form-control" v-model="form.username"
                                                            required>
                                                    </div>

                                                    <div class="col-md-6 mb-4">
                                                        <label class="form-label fs-6">E-posta Adresi <span
                                                                class="text-danger">*</span></label>
                                                        <input type="email" class="form-control" v-model="form.email"
                                                            required>
                                                    </div>

                                                    <div class="col-md-6 mb-4">
                                                        <label class="form-label fs-6">Şifre <span
                                                                class="text-danger">*</span></label>
                                                        <input type="password" class="form-control"
                                                            v-model="form.password" required>
                                                    </div>

                                                    <div class="col-md-6 mb-4">
                                                        <label class="form-label fs-6">Şifre Tekrar <span
                                                                class="text-danger">*</span></label>
                                                        <input type="password" class="form-control"
                                                            v-model="form.confirmPassword" required>
                                                    </div>

                                                    <div class="col-md-6 mb-4">
                                                        <label class="form-label fs-6">Telefon</label>
                                                        <input type="text" class="form-control" v-model="form.phone">
                                                    </div>

                                                    <div class="col-md-6 mb-4">
                                                        <label class="form-label fs-6">Durum <span
                                                                class="text-danger">*</span></label>
                                                        <select class="form-select" v-model="form.state" required>
                                                            <option value="Aktif">Aktif</option>
                                                            <option value="Pasif">Pasif</option>
                                                            <option value="Askıda">Askıda</option>
                                                        </select>
                                                    </div>

                                                    <div class="col-md-6 mb-4">
                                                        <label class="form-label fs-6">Kullanıcı Tipi <span
                                                                class="text-danger">*</span></label>
                                                        <select class="form-select" v-model="form.userType" required>
                                                            <option value="USER">Standart Kullanıcı</option>
                                                            <option value="MANAGER">Yönetici</option>
                                                            <option value="ADMIN">Admin</option>
                                                        </select>
                                                    </div>

                                                    <div class="col-12 mb-4">
                                                        <label class="form-label fs-6">Açıklama</label>
                                                        <textarea class="form-control" v-model="form.description"
                                                            rows="3"></textarea>
                                                    </div>

                                                </div>

                                                <div class="d-grid mt-5">
                                                    <button type="submit" class="btn btn-primary btn-lg"
                                                        :disabled="isLoading">
                                                        <span v-if="isLoading"
                                                            class="spinner-border spinner-border-sm me-2" role="status"
                                                            aria-hidden="true"></span>
                                                        Kullanıcı Oluştur
                                                    </button>
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
    name: "UserCreate",
    data() {
        return {
            form: {
                name: null,
                surname: null,
                phone: null,
                state: 'Aktif',
                userType: 'USER',
                username: null,
                password: null,
                confirmPassword: null,
                email: null,
                description: null,
            },
            sid: null,
            isLoading: false
        };
    },
    created() {
        const userData = this.$getUser();
        if (userData && userData.session_id) {
            this.sid = userData.session_id;
        } else {
            this.$swal("Hata", "Oturum bilgisi bulunamadı. Lütfen giriş yapınız.", "error");
            this.$router.push('/login');
        }
    },
    methods: {
        validateForm() {
            if (!this.form.name || !this.form.surname || !this.form.username ||
                !this.form.email || !this.form.password || !this.form.confirmPassword ||
                !this.form.state || !this.form.userType) {
                this.$swal("Hata", "Lütfen tüm zorunlu alanları doldurunuz.", "error");
                return false;
            }
            if (this.form.password !== this.form.confirmPassword) {
                this.$swal("Hata", "Şifreler birbiriyle eşleşmiyor.", "error");
                return false;
            }
            if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(this.form.email)) {
                this.$swal("Hata", "Lütfen geçerli bir email adresi giriniz.", "error");
                return false;
            }
            if (this.form.password.length < 6) {
                this.$swal("Hata", "Şifre en az 6 karakter olmalıdır.", "error");
                return false;
            }
            if (this.form.username.length < 4) {
                this.$swal("Hata", "Kullanıcı adı en az 4 karakter olmalıdır.", "error");
                return false;
            }
            return true;
        },
        async createAdminUser() {
            if (!this.validateForm()) {
                return;
            }

            if (!this.sid) {
                this.$swal("Hata", "Oturum bilgisi bulunamadı. Lütfen giriş yapınız.", "error");
                this.$router.push('/login');
                return;
            }

            this.isLoading = true;
            try {
                const payload = { ...this.form };
                delete payload.confirmPassword;

                // Backend artık HTTP 200 OK durumunda { message: '...', userId: '...' } dönecek
                const response = await axios.post("/api/user/AdminCreateUser", payload, {
                    headers: {
                        'sid': this.sid
                    }
                });

                this.isLoading = false;

                // response.data artık doğrudan SuccessResponse nesnesi olacak
                this.$swal("Başarılı", `${response.data.message || 'Kullanıcı başarıyla oluşturuldu.'} Kullanıcı ID: ${response.data.userId}`, "success")
                    .then((swalResult) => {
                        if (swalResult.isConfirmed) {
                            this.resetForm();
                        }
                    });

            } catch (error) {
                this.isLoading = false;
                let errorMessage = "Kullanıcı oluşturulurken bir hata oluştu. Lütfen daha sonra tekrar deneyin.";

                // Axios hata yakaladığında (HTTP 4xx veya 5xx), error.response.data ErrorResponse nesnesi olacaktır.
                if (error.response && error.response.data) {
                    if (error.response.data.message) {
                        errorMessage = error.response.data.message;
                    }
                    // Ek doğrulama hataları (örneğin ASP.NET Core model validasyon hataları)
                    else if (error.response.data.errors) {
                        const validationErrors = Object.values(error.response.data.errors).flat();
                        if (validationErrors.length > 0) {
                            errorMessage = validationErrors.join(', ');
                        }
                    }
                } else if (error.message) {
                    // Axios'un kendi network hatası gibi durumları
                    errorMessage = error.message;
                }

                this.$swal("Hata", errorMessage, "error");
            }
        },
        resetForm() {
            this.form = {
                name: null, surname: null, phone: null, state: 'Aktif', userType: 'USER',
                username: null, password: null, confirmPassword: null, email: null,
                description: null,
            };
        }
    }
};
</script>
<style scoped>
/* Mevcut Metronic/Bootstrap tabanlı tema stilleriniz burada geçerli olacaktır */
.card-header {
    text-align: center;
    padding-bottom: 10px;
    border-bottom: 1px solid var(--bs-card-border-color);
    margin-bottom: 20px;
}

.card-title {
    font-size: 24px;
    font-weight: bold;
    color: var(--bs-gray-900);
    display: block;
    margin-bottom: 5px;
}

.card-subtitle {
    font-size: 14px;
    color: var(--bs-gray-600);
}

.text-center {
    text-align: center;
}
</style>
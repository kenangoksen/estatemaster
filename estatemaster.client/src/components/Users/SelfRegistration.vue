<template>
  <div>
    <div class="d-flex flex-column flex-root app-root" id="kt_app_root">
      <div class="app-page flex-column flex-column-fluid" id="kt_app_page">
        <div class="app-wrapper flex-column flex-row-fluid" id="kt_app_wrapper">
          <div class="app-main flex-column flex-row-fluid" id="kt_app_main">
            <div class="d-flex flex-column flex-column-fluid">
              <div id="kt_app_toolbar" class="app-toolbar py-3 py-lg-6">
                <div id="kt_app_toolbar_container" class="app-container container-xxl d-flex flex-stack">
                  <div class="page-title d-flex flex-column justify-content-center flex-wrap me-3">
                    <h1 class="page-heading d-flex text-gray-900 fw-bold fs-3 flex-column justify-content-center my-0">
                      Yeni Hesap Oluştur
                    </h1>
                    <span class="text-muted fs-7">Şirket kodunuz ile kendi hesabınızı oluşturun.</span>
                  </div>
                </div>
              </div>
              <div id="kt_app_content" class="app-content flex-column-fluid">
                <div id="kt_app_content_container" class="app-container container-xxl">
                  <div class="card p-5">
                    <div class="card-body">
                      <form id="self-registration-form" @submit.prevent="registerUserSelf()">
                        <div class="row">
                          <h4 class="mb-5">Hesap Bilgileri</h4>

                          <div class="col-md-6 mb-4">
                            <label class="form-label fs-6">Şirket Kodu <span class="text-danger">*</span></label>
                            <input type="text" class="form-control" v-model="form.CompanyCode" required>
                          </div>

                          <div class="col-md-6 mb-4">
                            <label class="form-label fs-6">Adınız <span class="text-danger">*</span></label>
                            <input type="text" class="form-control" v-model="form.name" required>
                          </div>

                          <div class="col-md-6 mb-4">
                            <label class="form-label fs-6">Soyadınız <span class="text-danger">*</span></label>
                            <input type="text" class="form-control" v-model="form.surname" required>
                          </div>

                          <div class="col-md-6 mb-4">
                            <label class="form-label fs-6">Kullanıcı Adı <span class="text-danger">*</span></label>
                            <input type="text" class="form-control" v-model="form.username" required>
                          </div>

                          <div class="col-md-6 mb-4">
                            <label class="form-label fs-6">E-posta Adresi <span class="text-danger">*</span></label>
                            <input type="email" class="form-control" v-model="form.email" required>
                          </div>

                          <div class="col-md-6 mb-4">
                            <label class="form-label fs-6">Şifreniz <span class="text-danger">*</span></label>
                            <input type="password" class="form-control" v-model="form.password" required>
                          </div>

                          <div class="col-md-6 mb-4">
                            <label class="form-label fs-6">Şifreniz Tekrar <span class="text-danger">*</span></label>
                            <input type="password" class="form-control" v-model="form.confirmPassword" required>
                          </div>

                          <div class="col-md-6 mb-4">
                            <label class="form-label fs-6">Telefon</label>
                            <input type="text" class="form-control" v-model="form.phone">
                          </div>

                          <div class="col-12 mb-4">
                            <label class="form-label fs-6">Açıklama</label>
                            <textarea class="form-control" v-model="form.description" rows="3"></textarea>
                          </div>

                          <input type="hidden" v-model="form.state">
                          <input type="hidden" v-model="form.userType">
                        </div>

                        <div class="d-grid mt-5">
                          <button type="submit" class="btn btn-primary btn-lg" :disabled="isLoading">
                            <span v-if="isLoading" class="spinner-border spinner-border-sm me-2" role="status" aria-hidden="true"></span>
                            Kayıt Ol
                          </button>
                        </div>

                        <div class="text-center mt-4">
                          <a href="/login" class="text-primary fw-bold">Zaten hesabın var mı? Giriş Yap</a>
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
    name: "SelfRegistration",
    data() {
        return {
            form: {
                CompanyCode: null,
                name: null,
                surname: null,
                username: null,
                email: null,
                password: null,
                confirmPassword: null, // Sadece UI validasyonu için
                phone: null,
                state: 'Aktif',
                description: null,
                userType: 'USER'
            },
            isLoading: false
        };
    },
    methods: {
        validateForm() {
            // Basit istemci tarafı validasyonu
            if (!this.form.CompanyCode || !this.form.name || !this.form.surname || !this.form.username || 
                !this.form.email || !this.form.password || !this.form.confirmPassword) {
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
        async registerUserSelf() {
            if (!this.validateForm()) {
                return;
            }

            this.isLoading = true;
            try {
                const payload = { ...this.form };
                delete payload.confirmPassword; // confirmPassword'ı backend'e göndermiyoruz

                // Backend artık HTTP 200 OK durumunda SuccessResponse nesnesi dönecek
                const response = await axios.post("/api/user/CreateUserSelf", payload);
                
                this.isLoading = false;

                // response.data artık doğrudan SuccessResponse nesnesi olacak
                this.$swal("Başarılı", `${response.data.message || 'Hesabınız başarıyla oluşturuldu.'} Kullanıcı ID: ${response.data.userId}`, "success")
                    .then((swalResult) => {
                        if (swalResult.isConfirmed) {
                            this.$router.push('/login'); // Başarılı kayıttan sonra giriş sayfasına yönlendir
                        }
                    });
                this.resetForm(); // Formu temizle

            } catch (error) {
                this.isLoading = false;
                let errorMessage = "Kayıt işlemi sırasında bir hata oluştu. Lütfen daha sonra tekrar deneyin.";

                // Axios hata yakaladığında (HTTP 4xx veya 5xx), error.response.data ErrorResponse nesnesi olacaktır.
                if (error.response && error.response.data && error.response.data.message) {
                    errorMessage = error.response.data.message;
                }
                // C# tarafındaki model validasyon hatalarını (eğer [ApiController] annotation'ı otomatik döndürüyorsa)
                else if (error.response && error.response.data && error.response.data.errors) {
                    const validationErrors = Object.values(error.response.data.errors).flat();
                    if (validationErrors.length > 0) {
                        errorMessage = validationErrors.join(', ');
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
                CompanyCode: null, name: null, surname: null, username: null,
                email: null, password: null, confirmPassword: null, phone: null,
                state: 'Aktif', description: null, userType: 'USER'
            };
        }
    }
};
</script>

<style scoped>
/* Mevcut stil aynı kalabilir, sadece genel stil tanımları için yer tutucu */
.registration-page {
  display: flex;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  background-color: #f3f6f9;
}

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

.full-width-button {
  width: 100%;
}

.text-center {
  text-align: center;
}
</style>
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
                                            Kullanıcı Güncelle</h1>
                                        <ul class="breadcrumb breadcrumb-separatorless fw-semibold fs-7 my-0 pt-1">
                                            <li class="breadcrumb-item text-muted">
                                                <a href="#" class="text-muted text-hover-primary">Anasayfa</a>
                                            </li>
                                            <li class="breadcrumb-item">
                                                <span class="bullet bg-gray-500 w-5px h-2px"></span>
                                            </li>
                                            <li class="breadcrumb-item text-muted">Kullanıcı Yönetimi</li>
                                            <li class="breadcrumb-item">
                                                <span class="bullet bg-gray-500 w-5px h-2px"></span>
                                            </li>
                                            <li class="breadcrumb-item text-muted">Kullanıcı Güncelle</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>

                            <div id="kt_app_content" class="app-content flex-column-fluid">
                                <div id="kt_app_content_container" class="app-container container-xxl">
                                    <div class="card p-5">
                                        <div class="card-body">
                                            <div v-if="isLoading" class="text-center py-5">
                                                <div class="spinner-border text-primary" role="status">
                                                    <span class="visually-hidden">Yükleniyor...</span>
                                                </div>
                                                <p class="mt-2 text-muted">Kullanıcı bilgileri yükleniyor...</p>
                                            </div>
                                            <form v-else @submit.prevent="updateUser()">
                                                <div class="row mb-5">
                                                    <div class="col-md-6 mb-3">
                                                        <label for="name" class="form-label">Adı <span
                                                                class="text-danger">*</span></label>
                                                        <input type="text" class="form-control" id="name"
                                                            v-model="userToUpdate.name" required>
                                                    </div>
                                                    <div class="col-md-6 mb-3">
                                                        <label for="surname" class="form-label">Soyadı <span
                                                                class="text-danger">*</span></label>
                                                        <input type="text" class="form-control" id="surname"
                                                            v-model="userToUpdate.surname" required>
                                                    </div>
                                                </div>

                                                <div class="row mb-5">
                                                    <div class="col-md-6 mb-3">
                                                        <label for="username" class="form-label">Kullanıcı Adı</label>
                                                        <input type="text" class="form-control" id="username"
                                                            v-model="userToUpdate.username" disabled
                                                            title="Kullanıcı adı değiştirilemez.">
                                                        <small class="form-text text-muted">Kullanıcı adları
                                                            benzersizdir ve değiştirilemez.</small>
                                                    </div>
                                                    <div class="col-md-6 mb-3">
                                                        <label for="email" class="form-label">E-posta <span
                                                                class="text-danger">*</span></label>
                                                        <input type="email" class="form-control" id="email"
                                                            v-model="userToUpdate.email" required>
                                                    </div>
                                                </div>

                                                <div class="row mb-5">
                                                    <div class="col-md-6 mb-3">
                                                        <label for="phone" class="form-label">Telefon</label>
                                                        <input type="text" class="form-control" id="phone"
                                                            v-model="userToUpdate.phone">
                                                    </div>
                                                    <div class="col-md-6 mb-3">
                                                        <label for="state" class="form-label">Durum <span
                                                                class="text-danger">*</span></label>
                                                        <select class="form-select" id="state"
                                                            v-model="userToUpdate.state" required>
                                                            <option value="Aktif">Aktif</option>
                                                            <option value="Pasif">Pasif</option>
                                                            <option value="Askıda">Askıda</option>
                                                        </select>
                                                    </div>
                                                </div>

                                                <div class="row mb-5">
                                                    <div class="col-md-12 mb-3">
                                                        <label for="userType" class="form-label">Kullanıcı Tipi <span
                                                                class="text-danger">*</span></label>
                                                        <select class="form-select" id="userType"
                                                            v-model="userToUpdate.userType" required
                                                            :disabled="userToUpdate.userType === 'SUPER_ADMIN'">
                                                            <option value="USER">Standart Kullanıcı</option>
                                                            <option value="MANAGER">Yönetici</option>
                                                            <option value="ADMIN">Admin</option>
                                                            <option value="SUPER_ADMIN">Süper Admin</option>
                                                        </select>
                                                        <small v-if="userToUpdate.userType === 'SUPER_ADMIN'"
                                                            class="form-text text-danger">SUPER_ADMIN kullanıcı tipi
                                                            değiştirilemez.</small>
                                                    </div>
                                                </div>

                                                <div class="mb-5">
                                                    <label for="description" class="form-label">Açıklama</label>
                                                    <textarea class="form-control" id="description"
                                                        v-model="userToUpdate.description" rows="3"></textarea>
                                                </div>

                                                <div class="d-flex justify-content-end">
                                                    <button type="button" class="btn btn-secondary me-3"
                                                        @click="$router.go(-1)">İptal</button>
                                                    <button type="submit" class="btn btn-primary" :disabled="isSaving">
                                                        <span v-if="isSaving"
                                                            class="spinner-border spinner-border-sm me-2" role="status"
                                                            aria-hidden="true"></span>
                                                        Güncelle
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
    name: "UserUpdate",
    props: ['id'], // Vue Router'dan gelen 'id' parametresini prop olarak al
    data() {
        return {
            userToUpdate: {
                id: null,
                name: '',
                surname: '',
                phone: '',
                state: '',
                userType: '',
                username: '', // Username disable edilecek ama veriyi tutmak için burada
                email: '',
                description: ''
            },
            originalUserType: '',
            isLoading: false,
            isSaving: false,
            sid: null,
        };
    },
    async created() {
        const userData = this.$getUser();

        if (userData && userData.session_id) {
            this.sid = userData.session_id;
            if (this.id) {
                await this.fetchUserById(this.id);
            } else {
                this.$swal("Hata", "Güncellenecek kullanıcı ID'si bulunamadı.", "error");
                this.$router.push('/user/list');
            }
        } else {
            this.$swal("Hata", "Oturum bilgisi bulunamadı. Lütfen giriş yapınız.", "error");
            this.$router.push('/login');
        }
    },
    methods: {
        async fetchUserById(userId) {
            this.isLoading = true;
            try {
                const headers = { 'sid': this.sid };
                const payload = { id: userId }; // ID'yi body'de göndereceğiz

                const response = await axios.post(`/api/user/GetUserById`, payload, { headers });

                if (typeof response.data === 'string' && response.data.startsWith('Hata:')) {
                    this.$swal("Hata", response.data, "error");
                    this.$router.push('/user/list');
                } else {
                    const user = response.data
                    if (user && user.id) {
                        this.userToUpdate = { ...user };
                        this.originalUserType = user.userType;
                    } else {
                        this.$swal("Hata", "Kullanıcı bulunamadı.", "error");
                        this.$router.push('/user/list');
                    }
                }
            } catch (error) {
                let errorMessage = "Kullanıcı bilgileri getirilemedi.";
                if (error.response && error.response.data && typeof error.response.data === 'string') {
                    errorMessage = error.response.data;
                } else if (error.message) {
                    errorMessage = error.message;
                }
                this.$swal("Hata", errorMessage, "error");
                this.$router.push('/user/list');
            } finally {
                this.isLoading = false;
            }
        },
        async updateUser() {
            this.isSaving = true;
            try {
                if (this.originalUserType === 'SUPER_ADMIN' && this.userToUpdate.userType !== 'SUPER_ADMIN') {
                    this.$swal("Hata", "SUPER_ADMIN rolüne sahip kullanıcının tipi değiştirilemez.", "error");
                    this.isSaving = false;
                    return;
                }

                const headers = { 'sid': this.sid };
                const payload = { ...this.userToUpdate };
                delete payload.username; // Username güncellenmeyeceği için payload'dan kaldır

                const response = await axios.post("/api/user/UpdateUser", payload, { headers });

                if (response.data && response.data.startsWith('Hata:')) {
                    this.$swal("Hata", response.data, "error");
                } else {
                    this.$swal("Başarılı", response.data, "success")
                        .then(() => {
                            this.$router.push('/user/list');
                        });
                }
            } catch (error) {
                console.error("Kullanıcı güncellenirken hata:", error);
                let errorMessage = "Kullanıcı güncellenirken bir hata oluştu.";
                if (error.response && error.response.data && typeof error.response.data === 'string') {
                    errorMessage = error.response.data;
                } else if (error.message) {
                    errorMessage = error.message;
                }
                this.$swal("Hata", errorMessage, "error");
            } finally {
                this.isSaving = false;
            }
        }
    }
};
</script>

<style scoped>
.page-heading {
    font-size: 24px;
    font-weight: bold;
    color: var(--bs-gray-900);
}
</style>
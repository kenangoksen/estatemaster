<template>
    <div class="d-flex flex-column flex-root app-root" id="kt_app_root">
        <div class="app-page flex-column flex-column-fluid" id="kt_app_page">
            <div class="app-wrapper flex-column flex-row-fluid" id="kt_app_wrapper">
                <!--begin::Main-->
                <div class="app-main flex-column flex-row-fluid" id="kt_app_main">
                    <div class="d-flex flex-column flex-column-fluid">
                        <div class="app-content flex-column-fluid">
                            <div id="kt_app_toolbar" class="app-toolbar py-3 py-lg-6">
                                <!--begin::Toolbar container-->
                                <div id="kt_app_toolbar_container"
                                    class="app-container container-xxl d-flex flex-stack">
                                    <!--begin::Page title-->
                                    <div class="page-title d-flex flex-column justify-content-center flex-wrap me-3">
                                        <!--begin::Title-->
                                        <h1
                                            class="page-heading d-flex text-gray-900 fw-bold fs-3 flex-column justify-content-center my-0">
                                            Müşteri Güncelleme</h1>
                                        <!--end::Title-->
                                        <!--begin::Breadcrumb-->
                                        <ul class="breadcrumb breadcrumb-separatorless fw-semibold fs-7 my-0 pt-1">
                                            <!--begin::Item-->
                                            <li class="breadcrumb-item text-muted">
                                                <a href="index.html" class="text-muted text-hover-primary">Anasayfa</a>
                                            </li>
                                            <!--end::Item-->
                                            <!--begin::Item-->
                                            <li class="breadcrumb-item">
                                                <span class="bullet bg-gray-500 w-5px h-2px"></span>
                                            </li>
                                            <!--end::Item-->
                                            <!--begin::Item-->
                                            <li class="breadcrumb-item text-muted">Müşteri Güncelleme</li>
                                            <!--end::Item-->
                                        </ul>
                                        <!--end::Breadcrumb-->
                                    </div>
                                    <!--end::Page title-->
                                </div>
                                <!--end::Toolbar container-->
                            </div>
                            <div class="app-container container-xxl">
                                <div class="d-flex flex-column flex-lg-row">
                                    <div class="card shadow">
                                        <div class="card-body">
                                            <h4 class="card-title text-center mb-4">Müşteri Güncelle</h4>

                                            <form>
                                                <div class="row g-3">
                                                    <!-- ID (görünmez) -->
                                                    <input type="hidden" v-model="form.id" />

                                                    <!-- Ad Soyad -->
                                                    <div class="col-md-6">
                                                        <label class="form-label">Ad</label>
                                                        <input v-model="form.first_name" class="form-control"
                                                            required />
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label class="form-label">Soyad</label>
                                                        <input v-model="form.last_name" class="form-control" required />
                                                    </div>

                                                    <!-- E-posta ve Telefon -->
                                                    <div class="col-md-6">
                                                        <label class="form-label">E-posta</label>
                                                        <input v-model="form.email" type="email" class="form-control"
                                                            required />
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label class="form-label">Telefon</label>
                                                        <input v-model="form.phone" class="form-control" maxlength="19"
                                                            placeholder="+90 5XX XXX XX XX" />
                                                    </div>

                                                    <!-- Doğum Tarihi & Cinsiyet -->
                                                    <div class="col-md-6">
                                                        <label class="form-label">Doğum Tarihi</label>
                                                        <input v-model="form.BirthDate" type="date"
                                                            class="form-control" />
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label class="form-label">Cinsiyet</label>
                                                        <select v-model="form.gender" class="form-select">
                                                            <option value="">Seçiniz</option>
                                                            <option value="Male">Erkek</option>
                                                            <option value="Female">Kadın</option>
                                                        </select>
                                                    </div>

                                                    <!-- Müşteri tipi ve Danışman -->
                                                    <div class="col-md-6">
                                                        <label class="form-label">Müşteri Tipi</label>
                                                        <select v-model="form.customer_type" class="form-select"
                                                            required>
                                                            <option disabled value="">Müşteri tipi seçiniz</option>
                                                            <option value="Potansiyel">Potansiyel</option>
                                                            <option value="Aktif">Aktif</option>
                                                            <option value="Eski">Eski</option>
                                                        </select>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label class="form-label">Danışman</label>
                                                        <select v-model="form.assigned_user_id" class="form-select">
                                                            <option disabled value="">Danışman seçiniz</option>
                                                            <option v-for="advisor in advisors" :key="advisor.id"
                                                                :value="advisor.id">
                                                                {{ advisor.name }}
                                                            </option>
                                                        </select>
                                                    </div>

                                                    <!-- Bütçe -->
                                                    <div class="col-md-6">
                                                        <label class="form-label">Minimum Bütçe</label>
                                                        <input v-model="form.budget_min" type="number"
                                                            class="form-control" />
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label class="form-label">Maksimum Bütçe</label>
                                                        <input v-model="form.budget_max" type="number"
                                                            class="form-control" />
                                                    </div>

                                                    <!-- Konum -->
                                                    <div class="col-md-4">
                                                        <label class="form-label">İl</label>
                                                        <input v-model="form.preferred_province" class="form-control" />
                                                    </div>
                                                    <div class="col-md-4">
                                                        <label class="form-label">İlçe</label>
                                                        <input v-model="form.preferred_district" class="form-control" />
                                                    </div>
                                                    <div class="col-md-4">
                                                        <label class="form-label">Mahalle</label>
                                                        <input v-model="form.preferred_neighborhood"
                                                            class="form-control" />
                                                    </div>

                                                    <!-- Konut Bilgileri -->
                                                    <div class="col-md-6">
                                                        <label class="form-label">Tercih Edilen m²</label>
                                                        <input v-model="form.preferred_square_meters" type="number"
                                                            class="form-control" />
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label class="form-label">Oda Sayısı</label>
                                                        <input v-model="form.preferred_room_count"
                                                            class="form-control" />
                                                    </div>

                                                    <!-- Ek Bilgiler -->
                                                    <div class="col-md-6">
                                                        <label class="form-label">Sosyal Olanaklar</label>
                                                        <textarea v-model="form.amenities" class="form-control"
                                                            rows="2" />
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label class="form-label">Cephe</label>
                                                        <input v-model="form.facade" class="form-control" />
                                                    </div>

                                                    <div class="col-md-6">
                                                        <label class="form-label">Kaynak</label>
                                                        <input v-model="form.source" class="form-control" />
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label class="form-label">Son Etkileşim</label>
                                                        <input v-model="form.last_interaction" type="datetime-local"
                                                            class="form-control" />
                                                    </div>

                                                    <div class="col-12">
                                                        <label class="form-label">Notlar</label>
                                                        <textarea v-model="form.notes" class="form-control" rows="2" />
                                                    </div>

                                                    <!-- Sistemsel Bilgiler (Görsel Amaçlı) -->
                                                    <div class="col-md-6">
                                                        <label class="form-label">Oluşturan</label>
                                                        <input v-model="form.created_by" class="form-control"
                                                            disabled />
                                                    </div>
                                                    <div class="col-md-6">
                                                        <label class="form-label">Güncelleyen</label>
                                                        <input v-model="form.updated_by" class="form-control"
                                                            disabled />
                                                    </div>

                                                    <!-- Buton -->
                                                    <div class="col-12 mt-4">
                                                        <button type="button" @click="updateCustomer"
                                                            class="btn btn-warning w-100">Güncelle</button>
                                                    </div>
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
import { mapGetters } from 'vuex'
import SecureLS from "secure-ls";

const ls = new SecureLS({ isCompression: false });
export default {
    name: 'CustomerUpadate',
    props: ['id'],
    data() {
        return {
            form: {
                id: "",
                first_name: "",
                last_name: "",
                email: "",
                phone: "",
                BirthDate: "",
                gender: "",
                customer_type: "",
                assigned_user_id: "",
                budget_min: "",
                budget_max: "",
                preferred_province: "",
                preferred_district: "",
                preferred_neighborhood: "",
                preferred_square_meters: "",
                preferred_room_count: "",
                amenities: "",
                facade: "",
                source: "",
                notes: "",
                created_at: "",
                updated_at: "",
                created_by: "",
                last_interaction: "",
                updated_by: ""

            },
            advisors: [
                { id: "de8f59c4-9a6a-4900-b7b0-cb4db7f92951", name: "Ayşe Demir" },
                { id: "7d3e7c20-709c-4895-996d-2b9331ae4663", name: "Mehmet Yıldız" },
                { id: "a8f01963-4722-4045-ae35-1ec6c74d25cd", name: "Zeynep Şahin" }
            ]
        };
    },
    created() {
        const params = {
            id: this.id
        }
        axios.post('/api/customer/GetCustomerById', params, { headers: { 'Content-Type': 'application/json' } })
            .then((respone) => {
                const output = respone.data;
                if (output) {
                    this.form = output;
                    if (output.birth_date !== '' && output.birth_date !== null) {
                        this.form.BirthDate = output.birth_date.split('T')[0]; // "1996-12-29"
                    }
                } else {
                    this.$swal("Hata", "Müşteri bilgileri alınamadı", "error");
                }
            })
            .catch(() => {
                this.$swal("Sunucu Hatası", "Lütfen tekrar deneyin", "error");
            });
    },
    // mounted() {
    //     if (this.initialData?.id) {
    //         this.form = { ...this.initialData };
    //     }
    // },
    computed: {

    },
    methods: {
        updateCustomer() {
            this.$swal
                .fire({
                    title: "Müşteri bilgileri güncellensin mi?",
                    icon: "warning",
                    showCancelButton: true,
                    confirmButtonText: "Güncelle",
                    cancelButtonText: "İptal"
                })
                .then((result) => {
                    if (result.isConfirmed) {
                        this.form.updated_by = this.user.username;
                        axios.post("/api/customer/UpdateCustomer", this.form)
                            .then((res) => {
                                const output = res.data;
                                if (output === "UPDATED") {
                                    this.$swal("Başarılı", "Müşteri bilgileri güncellendi", "success");
                                    this.$emit("updated", this.form.id);
                                } else {
                                    this.$swal("Hata", "Güncelleme işlemi başarısız oldu", "error");
                                }
                            })
                            .catch(() => {
                                this.$swal("Sunucu Hatası", "Lütfen tekrar deneyin", "error");
                            });
                    }
                });
        }
    },
    computed: {
        ...mapGetters(['getUser']),
        user() {
            return this.getUser();
        },
    }
};
</script>
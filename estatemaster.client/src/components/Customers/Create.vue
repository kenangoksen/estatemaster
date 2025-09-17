<template>
    <div class="d-flex flex-column flex-root app-root" id="kt_app_root">
        <div class="app-page flex-column flex-column-fluid" id="kt_app_page">
            <div class="app-wrapper flex-column flex-row-fluid" id="kt_app_wrapper">
                <div class="app-main flex-column flex-row-fluid" id="kt_app_main">
                    <div class="d-flex flex-column flex-column-fluid">
                        <div id="kt_app_content" class="app-content flex-column-fluid">
                            <div id="kt_app_content_container" class="app-container container-xxl">

                                <div class="card shadow">
                                    <div class="card-body">
                                        <h4 class="card-title mb-4 text-center">Yeni Müşteri Oluştur</h4>

                                        <form>
                                            <div class="row g-3">

                                                <!-- Ad Soyad -->
                                                <div class="col-md-6">
                                                    <label class="form-label">Adı</label>
                                                    <input v-model="form.firstName" class="form-control" required />
                                                </div>
                                                <div class="col-md-6">
                                                    <label class="form-label">Soyadı</label>
                                                    <input v-model="form.lastName" class="form-control" required />
                                                </div>

                                                <!-- Email Telefon -->
                                                <div class="col-md-6">
                                                    <label class="form-label">E-posta</label>
                                                    <input v-model="form.email" type="email" class="form-control"
                                                        required />
                                                </div>
                                                <div class="col-md-6">
                                                    <label class="form-label">Telefon</label>
                                                    <input v-model="form.phone" v-mask="'(###) ### ## ##'"
                                                        class="form-control" />
                                                </div>

                                                <!-- Cinsiyet / Doğum -->
                                                <div class="col-md-6">
                                                    <label class="form-label">Doğum Tarihi</label>
                                                    <input v-model="form.birthDate" type="date" class="form-control" />
                                                </div>
                                                <div class="col-md-6">
                                                    <label class="form-label">Cinsiyet</label>
                                                    <select v-model="form.gender" class="form-select">
                                                        <option value="">Seçiniz</option>
                                                        <option value="Male">Erkek</option>
                                                        <option value="Female">Kadın</option>
                                                    </select>
                                                </div>

                                                <!-- Müşteri tipi / Danışman -->
                                                <div class="col-md-6">
                                                    <label class="form-label">Müşteri Tipi</label>
                                                    <select v-model="form.customerType" class="form-select">
                                                        <option disabled value="">Müşteri tipi seçiniz</option>
                                                        <option value="Potansiyel">Potansiyel</option>
                                                        <option value="Aktif">Aktif</option>
                                                        <option value="Eski">Eski</option>
                                                    </select>
                                                </div>
                                                <div class="col-md-6">
                                                    <label class="form-label">Danışman Seç</label>
                                                    <select v-model="form.assignedUserId" class="form-select">
                                                        <option disabled value="">Danışman Seçiniz</option>
                                                        <option v-for="advisor in advisors" :key="advisor.id"
                                                            :value="advisor.id">
                                                            {{ advisor.name }}
                                                        </option>
                                                    </select>
                                                </div>

                                                <!-- Tercihler -->
                                                <div class="col-md-6">
                                                    <label class="form-label">Minimum Bütçe</label>
                                                    <input v-model="form.budgetMin" type="number"
                                                        class="form-control" />
                                                </div>
                                                <div class="col-md-6">
                                                    <label class="form-label">Maksimum Bütçe</label>
                                                    <input v-model="form.budgetMax" type="number"
                                                        class="form-control" />
                                                </div>

                                                <div class="col-md-4">
                                                    <label class="form-label">İl</label>
                                                    <input v-model="form.preferredProvince" class="form-control" />
                                                </div>
                                                <div class="col-md-4">
                                                    <label class="form-label">İlçe</label>
                                                    <input v-model="form.preferredDistrict" class="form-control" />
                                                </div>
                                                <div class="col-md-4">
                                                    <label class="form-label">Mahalle</label>
                                                    <input v-model="form.preferredNeighborhood" class="form-control" />
                                                </div>

                                                <div class="col-md-6">
                                                    <label class="form-label">Net m²</label>
                                                    <input v-model="form.preferredSquareMeters" type="number"
                                                        class="form-control" />
                                                </div>
                                                <div class="col-md-6">
                                                    <label class="form-label">Oda Sayısı</label>
                                                    <input v-model="form.preferredRoomCount" class="form-control" />
                                                </div>

                                                <!-- Ekstra Bilgiler -->
                                                <div class="col-md-6">
                                                    <label class="form-label">Sosyal Olanaklar</label>
                                                    <textarea v-model="form.amenities" class="form-control" rows="2" />
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
                                                    <input v-model="form.lastInteraction" type="datetime-local"
                                                        class="form-control" />
                                                </div>

                                                <div class="col-12">
                                                    <label class="form-label">Notlar</label>
                                                    <textarea v-model="form.notes" class="form-control" rows="2" />
                                                </div>

                                                <div class="col-12 mt-4">
                                                    <button type="button" data-kt-contacts-type="submit" class="btn btn-primary w-100" @click="saveCustomer()">
                                                        Kaydet
                                                    </button>
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
</template>

<script>
import axios from 'axios'
import { mapGetters } from 'vuex'
import SecureLS from "secure-ls";

const ls = new SecureLS({ isCompression: false });
export default {
    name: "CustomerCreate",
    data() {
        return {
            form: {
                firstName: "",
                lastName: "",
                email: "",
                phone: "",
                birthDate: "",
                gender: "",
                customerType: "",
                assignedUserId: "",
                budgetMin: 0,
                budgetMax: 0,
                preferredProvince: "",
                preferredDistrict: "",
                preferredNeighborhood: "",
                preferredSquareMeters: 0,
                preferredRoomCount: "",
                amenities: "",
                facade: "",
                source: "",
                lastInteraction: "",
                notes: "",
                createdBy: ""
            },
               advisors: [
                { id: "de8f59c4-9a6a-4900-b7b0-cb4db7f92951", name: "Ayşe Demir" },
                { id: "7d3e7c20-709c-4895-996d-2b9331ae4663", name: "Mehmet Yıldız" },
                { id: "a8f01963-4722-4045-ae35-1ec6c74d25cd", name: "Zeynep Şahin" }
            ]
        };
    },
    created() {
        // Eğer kullanıcı bilgileri SecureLS'de saklanıyorsa, burada alabilirsiniz
        const user = ls.get("user");
        console.log("Kullanıcı Bilgisi:", this.user);
        if (user) {
            this.form.createdBy = user.username; // Kullanıcı adını form'a ekle
        }
    },
    methods: {
        saveCustomer() {
            this.$swal
                .fire({
                    title: "Yeni müşteri kaydı oluşturulsun mu?",
                    confirmButtonColor: "#04b440",
                    showCancelButton: true,
                    confirmButtonText: "Kaydet",
                    cancelButtonText: "İptal",
                    icon: "info"
                })
                .then((result) => {
                    if (result.isConfirmed) {
                        const parameters = {
                            CustomerType: this.form.customerType,
                            AssignedUserId: this.form.assignedUserId,
                            FirstName: this.form.firstName,
                            LastName: this.form.lastName,
                            Email: this.form.email,
                            Phone: this.form.phone,
                            BirthDate: this.form.birthDate,
                            Gender: this.form.gender,
                            budgetMin: this.form.budgetMin,
                            BudgetMax: this.form.budgetMax,
                            PreferredProvince: this.form.preferredProvince,
                            PreferredDistrict: this.form.preferredDistrict,
                            PreferredNeighborhood: this.form.preferredNeighborhood,
                            PreferredSquareMeters: this.form.preferredSquareMeters,
                            PreferredRoomCount: this.form.preferredRoomCount,
                            Amenities: this.form.amenities,
                            Facade: this.form.facade,
                            Source: this.form.source,
                            LastInteraction: this.form.lastInteraction,
                            Notes: this.form.notes,
                            created_by: this.user.username,
                            session_id: this.user.session_id,
                            company_id: this.user.company_id
                        };

                        axios
                            .post("/api/customer/CreateCustomer", parameters, {
                                headers: { "Content-Type": "application/json" }
                            })
                            .then((response) => {
                                const result = response.data?.result;
                                const id = response.data?.id;

                                if (result === "EMAIL_EXISTS") {
                                    this.$swal("Hata", "Bu e-posta adresi zaten kayıtlı!", "error");
                                } else if (response.data != null && response.data.length == 36) {
                                    this.$swal("Başarılı", "Müşteri başarıyla oluşturuldu", "success");
                                    this.form = {
                                        customerType: null,
                                        assignedUserId: null,
                                        firstName: null,
                                        lastName: null,
                                        email: null,
                                        phone: null,
                                        birthDate: null,
                                        gender: null,
                                        budgetMin: 0,
                                        budgetMax: 0,
                                        preferredProvince: null,
                                        preferredDistrict: null,
                                        preferredNeighborhood: null,
                                        preferredSquareMeters: 0,
                                        preferredRoomCount: null,
                                        amenities: null,
                                        facade: null,
                                        source: null,
                                        lastInteraction: null,
                                        notes: null
                                    };
                                    this.$emit("completed", id); // Üst bileşene bildir
                                } else {
                                    this.$swal("Hata", "Kayıt işlemi başarısız oldu", "error");
                                }
                            })
                            .catch(() => {
                                this.$swal("Sunucu Hatası", "Lütfen daha sonra tekrar deneyiniz", "error");
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
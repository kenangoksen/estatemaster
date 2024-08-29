<template>
    <div>
        <div class="d-flex flex-column flex-root app-root" id="kt_app_root">
            <!--begin::Page-->
            <div class="app-page flex-column flex-column-fluid" id="kt_app_page">
                <div class="app-wrapper flex-column flex-row-fluid" id="kt_app_wrapper">
                    <!--begin::Main-->
                    <div class="app-main flex-column flex-row-fluid" id="kt_app_main">
                        <!--begin::Content wrapper-->
                        <div class="d-flex flex-column flex-column-fluid">
                            <!--begin::Toolbar-->
                            <div id="kt_app_toolbar" class="app-toolbar py-3 py-lg-6">
                                <!--begin::Toolbar container-->
                                <div id="kt_app_toolbar_container"
                                    class="app-container container-xxl d-flex flex-stack">
                                    <!--begin::Page title-->
                                    <div class="page-title d-flex flex-column justify-content-center flex-wrap me-3">
                                        <!--begin::Title-->
                                        <h1
                                            class="page-heading d-flex text-gray-900 fw-bold fs-3 flex-column justify-content-center my-0">
                                            Kullanıcı Oluştur</h1>
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
                                            <li class="breadcrumb-item text-muted">Kullanıcı Oluştur</li>
                                            <!--end::Item-->
                                        </ul>
                                        <!--end::Breadcrumb-->
                                    </div>
                                    <!--end::Page title-->
                                </div>
                                <!--end::Toolbar container-->
                            </div>
                            <!--end::Toolbar-->
                            <!--begin::Content-->
                            <div id="kt_app_content" class="app-content flex-column-fluid">
                                <!--begin::Content container-->
                                <div id="kt_app_content_container" class="app-container container-xxl">
                                    <!--begin::Contacts App- Add New Contact-->
                                    <div class="row g-7">
                                        <!--begin::Content-->
                                        <div class="col-xl-12">
                                            <!--begin::Contacts-->
                                            <div class="card card-flush h-lg-100" id="kt_contacts_main">
                                                <!--begin::Card header-->
                                                <div class="card-header pt-7" id="kt_chat_contacts_header">
                                                    <!--begin::Card title-->
                                                    <div class="card-title">
                                                        <i class="ki-duotone ki-badge fs-1 me-2">
                                                            <span class="path1"></span>
                                                            <span class="path2"></span>
                                                            <span class="path3"></span>
                                                            <span class="path4"></span>
                                                            <span class="path5"></span>
                                                        </i>
                                                        <h2>Kullanıcı Oluştur</h2>
                                                    </div>
                                                    <!--end::Card title-->
                                                </div>
                                                <!--end::Card header-->
                                                <!--begin::Card body-->
                                                <div class="card-body pt-5">
                                                    <!--begin::Form-->
                                                    <form id="kt_ecommerce_settings_general_form" class="form"
                                                        action="#">
                                                        <!--begin::Input group-->
                                                        <div class="mb-7">
                                                            <!--begin::Label-->
                                                            <label class="fs-6 fw-semibold mb-3">
                                                                <span>Profil Fotoğrafı Ekle</span>
                                                                <span class="ms-1" data-bs-toggle="tooltip"
                                                                    title="Allowed file types: png, jpg, jpeg.">
                                                                    <i class="ki-duotone ki-information fs-7">
                                                                        <span class="path1"></span>
                                                                        <span class="path2"></span>
                                                                        <span class="path3"></span>
                                                                    </i>
                                                                </span>
                                                            </label>
                                                            <!--end::Label-->
                                                            <!--begin::Image input wrapper-->
                                                            <div class="mt-1">
                                                                <!--begin::Image input-->
                                                                <div class="image-input image-input-outline image-input-placeholder image-input-empty image-input-empty"
                                                                    data-kt-image-input="true">
                                                                    <!--begin::Preview existing avatar-->
                                                                    <div class="image-input-wrapper w-100px h-100px"
                                                                        style="background-image: url('')"></div>
                                                                    <!--end::Preview existing avatar-->
                                                                    <!--begin::Edit-->
                                                                    <label
                                                                        class="btn btn-icon btn-circle btn-active-color-primary w-25px h-25px bg-body shadow"
                                                                        data-kt-image-input-action="change"
                                                                        data-bs-toggle="tooltip" title="Change avatar">
                                                                        <i class="ki-duotone ki-pencil fs-7">
                                                                            <span class="path1"></span>
                                                                            <span class="path2"></span>
                                                                        </i>
                                                                        <!--begin::Inputs-->
                                                                        <input type="file" name="avatar"
                                                                            accept=".png, .jpg, .jpeg" />
                                                                        <input type="hidden" name="avatar_remove" />
                                                                        <!--end::Inputs-->
                                                                    </label>
                                                                    <!--end::Edit-->
                                                                    <!--begin::Cancel-->
                                                                    <span
                                                                        class="btn btn-icon btn-circle btn-active-color-primary w-25px h-25px bg-body shadow"
                                                                        data-kt-image-input-action="cancel"
                                                                        data-bs-toggle="tooltip" title="Cancel avatar">
                                                                        <i class="ki-duotone ki-cross fs-2">
                                                                            <span class="path1"></span>
                                                                            <span class="path2"></span>
                                                                        </i>
                                                                    </span>
                                                                    <!--end::Cancel-->
                                                                    <!--begin::Remove-->
                                                                    <span
                                                                        class="btn btn-icon btn-circle btn-active-color-primary w-25px h-25px bg-body shadow"
                                                                        data-kt-image-input-action="remove"
                                                                        data-bs-toggle="tooltip" title="Remove avatar">
                                                                        <i class="ki-duotone ki-cross fs-2">
                                                                            <span class="path1"></span>
                                                                            <span class="path2"></span>
                                                                        </i>
                                                                    </span>
                                                                    <!--end::Remove-->
                                                                </div>
                                                                <!--end::Image input-->
                                                            </div>
                                                            <!--end::Image input wrapper-->
                                                        </div>
                                                        <!--end::Input group-->
                                                        <!--begin::Input group-->
                                                        <div class="fv-row mb-7">
                                                            <!--begin::Label-->
                                                            <label class="fs-6 fw-semibold form-label mt-3">
                                                                <span class="required">İsim</span>
                                                            </label>
                                                            <!--end::Label-->
                                                            <!--begin::Input-->
                                                            <input type="text" class="form-control form-control-solid"
                                                                name="name" value="" v-model="form.name" />
                                                            <!--end::Input-->
                                                        </div>
                                                        <!--end::Input group-->
                                                        <!--begin::Input group-->
                                                        <div class="fv-row mb-7">
                                                            <!--begin::Label-->
                                                            <label class="fs-6 fw-semibold form-label mt-3">
                                                                <span class="required">Soyisim</span>
                                                            </label>
                                                            <!--end::Label-->
                                                            <!--begin::Input-->
                                                            <input type="text" class="form-control form-control-solid"
                                                                name="surname" value="" v-model="form.surname" />
                                                            <!--end::Input-->
                                                        </div>
                                                        <!--end::Input group-->
                                                        <!--begin::Row-->
                                                        <div
                                                            class="row row-cols-1 row-cols-sm-2 rol-cols-md-1 row-cols-lg-2">
                                                            <!--begin::Col-->
                                                            <div class="col">
                                                                <!--begin::Input group-->
                                                                <div class="fv-row mb-7">
                                                                    <!--begin::Label-->
                                                                    <label class="fs-6 fw-semibold form-label mt-3">
                                                                        <span class="required">Telefon</span>
                                                                    </label>
                                                                    <!--end::Label-->
                                                                    <!--begin::Input-->
                                                                    <input type="text"
                                                                        class="form-control form-control-solid"
                                                                        name="phone" value="" v-model="form.phone" />
                                                                    <!--end::Input-->
                                                                </div>
                                                                <!--end::Input group-->
                                                            </div>
                                                            <!--end::Col-->
                                                        </div>
                                                        <!--end::Row-->
                                                        <!--begin::Row-->
                                                        <div
                                                            class="row row-cols-1 row-cols-sm-2 rol-cols-md-1 row-cols-lg-2">
                                                            <!--begin::Col-->
                                                            <div class="col">
                                                                <!--begin::Input group-->
                                                                <div class="fv-row mb-7">
                                                                    <!--begin::Label-->
                                                                    <label class="fs-6 fw-semibold form-label mt-3">
                                                                        <span class="required">E-mail</span>
                                                                    </label>
                                                                    <!--end::Label-->
                                                                    <!--begin::Input-->
                                                                    <input type="text"
                                                                        class="form-control form-control-solid"
                                                                        name="email" value="" v-model="form.email" />
                                                                    <!--end::Input-->
                                                                </div>
                                                                <!--end::Input group-->
                                                            </div>
                                                            <!--end::Col-->
                                                        </div>
                                                        <!--end::Row-->
                                                        <!--begin::Row-->
                                                        <div
                                                            class="row row-cols-1 row-cols-sm-2 rol-cols-md-1 row-cols-lg-2">
                                                            <!--begin::Col-->
                                                            <div class="col">
                                                                <!--begin::Input group-->
                                                                <div class="fv-row mb-7">
                                                                    <!--begin::Label-->
                                                                    <label class="fs-6 fw-semibold form-label mt-3">
                                                                        <span class="required">Kullanıcı Tipi</span>
                                                                    </label>
                                                                    <!--end::Label-->
                                                                    <div class="w-100">
                                                                        <!--begin::Select2-->
                                                                        <select id="kt_ecommerce_select2_country"
                                                                            class="form-select form-select-solid"
                                                                            name="userType"
                                                                            data-kt-ecommerce-settings-type="select2_flags"
                                                                            data-placeholder="Kullanıcı Tipi Seçiniz.."
                                                                            v-model="form.userType">
                                                                            <option v-for="userType of userTypeList" :value="userType.value"> {{ userType.name }}</option>
                                                                        </select>
                                                                        <!--end::Select2-->
                                                                    </div>
                                                                </div>
                                                                <!--end::Input group-->
                                                            </div>
                                                            <!--end::Col-->
                                                        </div>
                                                        <!--end::Row-->
                                                        <!--begin::Row-->
                                                        <div
                                                            class="row row-cols-1 row-cols-sm-2 rol-cols-md-1 row-cols-lg-2">
                                                            <!--begin::Col-->
                                                            <div class="col">
                                                                <!--begin::Input group-->
                                                                <div class="fv-row mb-7">
                                                                    <!--begin::Label-->
                                                                    <label class="fs-6 fw-semibold form-label mt-3">
                                                                        <span class="required">Şehir</span>
                                                                    </label>
                                                                    <!--end::Label-->
                                                                    <div class="w-100">
                                                                        <!--begin::Select2-->
                                                                        <select id="kt_ecommerce_select2_country"
                                                                            class="form-select form-select-solid"
                                                                            name="state"
                                                                            data-kt-ecommerce-settings-type="select2_flags"
                                                                            data-placeholder="Şehir Seçiniz.."
                                                                            v-model="form.state">
                                                                            <option v-for="state of stateList" :value="state.name"> {{ state.name }}</option>
                                                                        </select>
                                                                        <!--end::Select2-->
                                                                    </div>
                                                                </div>
                                                                <!--end::Input group-->
                                                            </div>
                                                            <!--end::Col-->
                                                        </div>
                                                        <!--end::Row-->
                                                           <!--begin::Row-->
                                                           <div
                                                            class="row row-cols-1 row-cols-sm-2 rol-cols-md-1 row-cols-lg-2">
                                                            <!--begin::Col-->
                                                            <div class="col">
                                                                <!--begin::Input group-->
                                                                <div class="fv-row mb-7">
                                                                    <!--begin::Label-->
                                                                    <label class="fs-6 fw-semibold form-label mt-3">
                                                                        <span class="required">Kullanıcı Adı</span>
                                                                    </label>
                                                                    <!--end::Label-->
                                                                    <!--begin::Input-->
                                                                    <input type="text"
                                                                        class="form-control form-control-solid"
                                                                        name="username" value="" v-model="form.username" />
                                                                    <!--end::Input-->
                                                                </div>
                                                                <!--end::Input group-->
                                                            </div>
                                                            <!--end::Col-->
                                                        </div>
                                                        <!--end::Row-->
                                                           <!--begin::Row-->
                                                           <div
                                                            class="row row-cols-1 row-cols-sm-2 rol-cols-md-1 row-cols-lg-2">
                                                            <!--begin::Col-->
                                                            <div class="col">
                                                                <!--begin::Input group-->
                                                                <div class="fv-row mb-7">
                                                                    <!--begin::Label-->
                                                                    <label class="fs-6 fw-semibold form-label mt-3">
                                                                        <span class="required">Şifre</span>
                                                                    </label>
                                                                    <!--end::Label-->
                                                                    <!--begin::Input-->
                                                                    <input type="text"
                                                                        class="form-control form-control-solid"
                                                                        name="password" value="" v-model="form.password" />
                                                                    <!--end::Input-->
                                                                </div>
                                                                <!--end::Input group-->
                                                            </div>
                                                            <!--end::Col-->
                                                        </div>
                                                        <!--begin::Input group-->
                                                        <div class="fv-row mb-7">
                                                            <!--begin::Label-->
                                                            <label class="fs-6 fw-semibold form-label mt-3">
                                                                <span>Açıklama</span>
                                                            </label>
                                                            <!--end::Label-->
                                                            <!--begin::Input-->
                                                            <textarea class="form-control form-control-solid"
                                                                name="description" v-model="form.description"></textarea>
                                                            <!--end::Input-->
                                                        </div>
                                                        <!--end::Input group-->
                                                        <!--begin::Separator-->
                                                        <div class="separator mb-6"></div>
                                                        <!--end::Separator-->
                                                        <!--begin::Action buttons-->
                                                        <div class="d-flex justify-content-end">
                                                            <!--begin::Button-->
                                                            <button type="button" data-kt-contacts-type="submit"
                                                                class="btn btn-success" @click="saveUser()">
                                                                <span class="indicator-label">Kaydet</span>
                                                                <span class="indicator-progress">Lütfen bekleyin...
                                                                    <span
                                                                        class="spinner-border spinner-border-sm align-middle ms-2"></span></span>
                                                            </button>
                                                            <!--end::Button-->
                                                        </div>
                                                        <!--end::Action buttons-->
                                                    </form>
                                                    <!--end::Form-->
                                                </div>
                                                <!--end::Card body-->
                                            </div>
                                            <!--end::Contacts-->
                                        </div>
                                        <!--end::Content-->
                                    </div>
                                    <!--end::Contacts App- Add New Contact-->
                                </div>
                                <!--end::Content container-->
                            </div>
                            <!--end::Content-->
                        </div>
                        <!--end::Content wrapper-->
                    </div>
                    <!--end:::Main-->
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
    name: 'UserCreate',
    data() {
        return {
            form: {
                name: null,
                surname: null,
                phone: null,
                state: null,
                userType: null,
                username: null,
                password: null,
                email: null,
                description: null
            },
            userTypeList: [],
            stateList: [],
            userData: null
        };
    },
    created() {
        this.userTypeList = this.getUserTypeList;
        this.stateList = this.getStateList;
        this.userData = this.getUser;

    },
    methods: {
        saveUser() {
            this.$swal
                .fire({
                    title: "Kullanıcı oluşturmak istediğinize emin misiniz?",
                    confirmButtonColor: "#04b440",
                    showDenyButton: false,
                    showCancelButton: true,
                    confirmButtonText: "Onay",
                    icon: 'info'
                })
                .then((result) => {
                    if (result.isConfirmed) {
                        const parameters = {
                            name: this.form.name,
                            surname: this.form.surname,
                            phone: this.form.phone,
                            state: this.form.state,
                            userType: this.form.userType,
                            created_by: this.user.username,
                            username: this.form.username,
                            password: this.form.password,
                            descrtiption: this.form.descrtiption,
                            email: this.form.email
                        }
                        axios.post("/api/user/CreateUser", parameters, { "Content-Type": "application/json" }).then((response) => {
                            if (response.status == 200) {
                                this.$swal("Başarılı", "Kullanıcı Oluşturuldu", 'success');
                                this.form = null
                            } else {
                                this.$swal("Hata", "Kayıt oluşturulamadı", "error");

                            }
                        });
                    }
                });
        }
    },
    computed: {
        ...mapGetters(['getUserTypeList']),
        ...mapGetters(['getStateList']),
        ...mapGetters(['getUser']),
		user() {
			return this.getUser();
		},
    }
}
</script>
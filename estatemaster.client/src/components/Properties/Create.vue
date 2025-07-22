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
                                            Kategori Seçimi</h1>
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
                                            <li class="breadcrumb-item text-muted">Kategori Seçimi </li>
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
                                    <div class="flex-lg-row-fluid mb-10 mb-lg-0 me-lg-7 me-xl-10">
                                        <!--begin::Card-->
                                        <div class="card shadow-sm border-0">
                                            <!--begin::Card body-->
                                            <div class="card-body p-12">
                                                <select class="form-select form-select-lg rounded-pill border-primary"
                                                    aria-label="Select example" data-placeholder="Emlak Türünü Seçiniz"
                                                    data-allow-clear="true" v-model="form.estateType"
                                                    @change="activateForm">
                                                    <option v-for="item of estateTypeList" :value="item"
                                                        :key="item.value"> {{ item.name }}</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--begin::Content wrapper-->
                    <div class="d-flex flex-column flex-column-fluid" v-if="this.formIsActive == true">
                        <!--begin::Toolbar-->
                        <div id="kt_app_toolbar" class="app-toolbar py-3 py-lg-6">
                            <!--begin::Toolbar container-->
                            <div id="kt_app_toolbar_container" class="app-container container-xxl d-flex flex-stack">
                                <!--begin::Page title-->
                                <div class="page-title d-flex flex-column justify-content-center flex-wrap me-3">
                                    <!--begin::Title-->
                                    <h1
                                        class="page-heading d-flex text-gray-900 fw-bold fs-3 flex-column justify-content-center my-0">
                                        {{ this.form.estateType.name }} Ekle</h1>
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
                                        <li class="breadcrumb-item text-muted"> {{ this.form.estateType.name }} Ekle
                                        </li>
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
                                <!--begin::Layout-->
                                <div class="d-flex flex-column flex-lg-row">
                                    <!--begin::Content-->
                                    <div class="flex-lg-row-fluid mb-10 mb-lg-0 me-lg-7 me-xl-10">
                                        <!--begin::Card-->
                                        <div class="card shadow-sm border-0">
                                            <!--begin::Card body-->
                                            <div class="card-body p-12">
                                                <!--begin::Form-->
                                                <form action="" id="kt_invoice_form">
                                                    <!--begin::Wrapper-->
                                                    <!--begin::Separator-->
                                                    <div class="separator separator-content border-dark my-15">
                                                        <span class="w-350px fw-bold h1 text-primary">
                                                            {{ this.form.estateType.name }} Bilgileri</span>
                                                    </div>
                                                    <!--end::Separator-->
                                                    <!--begin::Wrapper-->
                                                    <div class="mb-0">
                                                        <!--begin::Row-->
                                                        <div class="mb-10">
                                                            <label for="exampleFormControlInput1"
                                                                class="required form-label">Başlık
                                                            </label>
                                                            <input type="titile" v-model="this.propertyInfo.title"
                                                                class="form-control form-control-solid rounded-pill border-primary"
                                                                placeholder="Başlık" />
                                                        </div>
                                                        <div class="mb-0 mb-10">
                                                            <label class="form-label fs-6 fw-bold text-gray-700">İlan
                                                                Açıklaması</label>
                                                            <textarea name="notes"
                                                                v-model="this.propertyInfo.description"
                                                                class="form-control form-control-solid rounded border-primary"
                                                                rows="3" placeholder="İlan Açıklaması"></textarea>
                                                        </div>
                                                        <div class="row gx-10 mb-5">
                                                            <!--begin::Col-->
                                                            <div class="col-lg-6">

                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Fiyat
                                                                    </label>
                                                                    <input type="number"
                                                                        v-model="this.propertyInfo.price"
                                                                        class="form-control form-control-solid rounded-pill border-primary"
                                                                        placeholder="Fiyat" />
                                                                </div>
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">m² (Net)

                                                                    </label>
                                                                    <input type="number"
                                                                        v-model="this.propertyInfo.squareMetersNet"
                                                                        class="form-control form-control-solid rounded-pill border-primary"
                                                                        placeholder="m² (Net)" />
                                                                </div>
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Emlak Durumu

                                                                    </label>
                                                                    <select
                                                                        class="form-select form-select-lg rounded-pill border-primary"
                                                                        aria-label="Select example"
                                                                        data-placeholder="Mülk Durumunu Seçiniz"
                                                                        data-allow-clear="true"
                                                                        v-model="propertyInfo.estateStatusType">
                                                                        <option v-for="item of estateStatusTypeList"
                                                                            :value="item" :key="item.value"> {{
                                                                                item.name }}</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                            <!--end::Col-->
                                                            <!--begin::Separator-->
                                                            <div class="separator separator-content border-dark my-15">
                                                                <span class="w-250px fw-bold h1">Adres Bilgileri</span>
                                                            </div>
                                                            <!--end::Separator-->
                                                            <!--begin::Col-->
                                                            <!-- <h1
                                                                class="mb-10 page-heading d-flex text-gray-900 fw-bold fs-3 flex-column justify-content-center my-0">
                                                                Adres Bilgiler</h1> -->
                                                            <div class="col-lg-6">
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">İl
                                                                    </label>
                                                                    <input type="email"
                                                                        v-model="this.propertyInfo.province"
                                                                        class="form-control form-control-solid rounded-pill border-primary"
                                                                        placeholder="İl" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">İlçe
                                                                    </label>
                                                                    <input type="email"
                                                                        v-model="this.propertyInfo.district"
                                                                        class="form-control form-control-solid rounded-pill border-primary"
                                                                        placeholder="İlçe" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Mahalle
                                                                    </label>
                                                                    <input type="email"
                                                                        v-model="this.propertyInfo.neighborhood"
                                                                        class="form-control form-control-solid rounded-pill border-primary"
                                                                        placeholder="Mahalle" />
                                                                </div>

                                                            </div>
                                                            <!--end::Col-->
                                                        </div>
                                                        <!--end::Row-->
                                                        <!--begin::Item template-->
                                                        <table class="table d-none" data-kt-element="item-template">
                                                            <tr class="border-bottom border-bottom-dashed"
                                                                data-kt-element="item">
                                                                <td class="pe-7">
                                                                    <input type="text"
                                                                        class="form-control form-control-solid mb-2"
                                                                        name="name[]" placeholder="Item name" />
                                                                    <input type="text"
                                                                        class="form-control form-control-solid"
                                                                        name="description[]"
                                                                        placeholder="Description" />
                                                                </td>
                                                                <td class="ps-0">
                                                                    <input class="form-control form-control-solid"
                                                                        type="number" min="1" name="quantity[]"
                                                                        placeholder="1" data-kt-element="quantity" />
                                                                </td>
                                                                <td>
                                                                    <input type="text"
                                                                        class="form-control form-control-solid text-end"
                                                                        name="price[]" placeholder="0.00"
                                                                        data-kt-element="price" />
                                                                </td>
                                                                <td class="pt-8 text-end">$
                                                                    <span data-kt-element="total">0.00</span>
                                                                </td>
                                                                <td class="pt-5 text-end">
                                                                    <button type="button"
                                                                        class="btn btn-sm btn-icon btn-active-color-primary"
                                                                        data-kt-element="remove-item">
                                                                        <i class="ki-duotone ki-trash fs-3">
                                                                            <span class="path1"></span>
                                                                            <span class="path2"></span>
                                                                            <span class="path3"></span>
                                                                            <span class="path4"></span>
                                                                            <span class="path5"></span>
                                                                        </i>
                                                                    </button>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table class="table d-none" data-kt-element="empty-template">
                                                            <tr data-kt-element="empty">
                                                                <th colspan="5" class="text-muted text-center py-10">No
                                                                    items</th>
                                                            </tr>
                                                        </table>
                                                        <!--end::Item template-->
                                                    </div>
                                                    <!--end::Wrapper-->

                                                    <div class="separator mb-6"></div>
                                                    <!--end::Separator-->
                                                    <!--begin::Action buttons-->
                                                    <div class="d-flex justify-content-end">
                                                        <!--begin::Button-->
                                                        <button type="button" data-kt-contacts-type="submit"
                                                            class="btn btn-success" @click="saveProperty()">
                                                            <span class="indicator-label">Kaydet</span>
                                                            <span class="indicator-progress">Lütfen bekleyin...
                                                                <span
                                                                    class="spinner-border spinner-border-sm align-middle ms-2"></span></span>
                                                        </button>
                                                        <!--end::Button-->
                                                    </div>
                                                </form>
                                                <!--end::Form-->
                                            </div>
                                            <!--end::Card body-->
                                        </div>
                                        <!--end::Card-->
                                    </div>
                                    <!--end::Content-->
                                    <!--begin::Sidebar-->
                                    <div class="flex-column flex-lg-row-auto w-100 w-xl-350px mb-10">
                                        <!--begin::Card-->
                                        <div class="card mb-5 mb-xl-8">
                                            <!--begin::Card body-->
                                            <div class="card-body pt-15">
                                                <!--begin::Summary-->
                                                <div class="d-flex flex-center flex-column mb-5">
                                                    <!--begin::Avatar-->
                                                    <div class="symbol symbol-100px symbol-square mb-7">
                                                        <img src="/assets/media/avatars/konutPP.jpg" alt="image" />
                                                    </div>
                                                    <!--end::Avatar-->
                                                    <!--begin::Title-->
                                                    <a href="#"
                                                        class="fs-3 text-gray-800 text-hover-primary fw-bold mb-1">
                                                        <span
                                                            v-if="this.propertyInfo.title !== null && this.propertyInfo.title !== ''">
                                                            {{ this.propertyInfo.title }} </span>
                                                        <span
                                                            v-if="this.propertyInfo.title == null || this.propertyInfo.title == ''">Başlık</span>
                                                    </a>
                                                    <!--end::Title-->
                                                    <!--begin::Description-->
                                                    <div class="fs-5 fw-semibold text-muted mb-6">{{
                                                        this.propertyInfo.description }}</div>
                                                    <!--end::Description-->
                                                    <!--begin::Info-->
                                                    <div class="d-flex flex-wrap flex-center">
                                                        <!--begin::Stats-->
                                                        <div
                                                            class="border border-gray-300 border-dashed rounded py-3 px-3 mb-3">
                                                            <div class="fs-4 fw-bold text-gray-700">
                                                                <span class="w-75px">6,900</span>
                                                                <i class="ki-duotone ki-arrow-up fs-3 text-success">
                                                                    <span class="path1"></span>
                                                                    <span class="path2"></span>
                                                                </i>
                                                            </div>
                                                            <div class="fw-semibold text-muted">Earnings</div>
                                                        </div>
                                                        <!--end::Stats-->
                                                        <!--begin::Stats-->
                                                        <div
                                                            class="border border-gray-300 border-dashed rounded py-3 px-3 mx-4 mb-3">
                                                            <div class="fs-4 fw-bold text-gray-700">
                                                                <span class="w-50px">130</span>
                                                                <i class="ki-duotone ki-arrow-down fs-3 text-danger">
                                                                    <span class="path1"></span>
                                                                    <span class="path2"></span>
                                                                </i>
                                                            </div>
                                                            <div class="fw-semibold text-muted">Tasks</div>
                                                        </div>
                                                        <!--end::Stats-->
                                                        <!--begin::Stats-->
                                                        <div
                                                            class="border border-gray-300 border-dashed rounded py-3 px-3 mb-3">
                                                            <div class="fs-4 fw-bold text-gray-700">
                                                                <span class="w-50px">500</span>
                                                                <i class="ki-duotone ki-arrow-up fs-3 text-success">
                                                                    <span class="path1"></span>
                                                                    <span class="path2"></span>
                                                                </i>
                                                            </div>
                                                            <div class="fw-semibold text-muted">Hours</div>
                                                        </div>
                                                        <!--end::Stats-->
                                                    </div>
                                                    <!--end::Info-->
                                                </div>
                                                <!--end::Summary-->
                                                <!--begin::Details toggle-->
                                                <div class="d-flex flex-stack fs-4 py-3">
                                                    <div class="fw-bold rotate collapsible collapsed"
                                                        data-bs-toggle="collapse" href="#kt_customer_view_details"
                                                        role="button" aria-expanded="false"
                                                        aria-controls="kt_customer_view_details">Detaylar
                                                        <span class="ms-2 rotate-180">
                                                            <i class="ki-duotone ki-down fs-3"></i>
                                                        </span>
                                                    </div>
                                                    <span data-bs-toggle="tooltip" data-bs-trigger="hover"
                                                        title="Edit customer details">
                                                        <a href="#" class="btn btn-sm btn-light-primary"
                                                            data-bs-toggle="modal"
                                                            data-bs-target="#kt_modal_update_customer">Edit</a>
                                                    </span>
                                                </div>
                                                <!--end::Details toggle-->
                                                <div class="separator separator-dashed my-3"></div>
                                                <!--begin::Details content-->
                                                <div id="kt_customer_view_details" class="collapse">
                                                    <div class="py-5 fs-6">
                                                        <!--begin::Details item-->
                                                        <div class="fw-bold mt-5">Fiyat</div>
                                                        <div v-if="this.propertyInfo.price !== null && this.propertyInfo.price !== ''"
                                                            class="text-gray-600"> {{ this.propertyInfo.price }}</div>
                                                        <div v-if="this.propertyInfo.price == null || this.propertyInfo.price == ''"
                                                            class="text-gray-600"> Bilinmiyor</div>
                                                        <!--end::Details item-->
                                                        <div class="separator my-5"></div>
                                                        <!--begin::Details item-->
                                                        <div class="fw-bold mt-5">m² (Brüt) </div>
                                                        <div v-if="this.propertyInfo.squareMetersGross !== null && this.propertyInfo.squareMetersGross !== ''"
                                                            class="text-gray-600"> {{
                                                                this.propertyInfo.squareMetersGross }}</div>
                                                        <div v-if="this.propertyInfo.squareMetersGross == null || this.propertyInfo.squareMetersGross == ''"
                                                            class="text-gray-600"> Bilinmiyor</div>
                                                        <!--end::Details item-->
                                                        <div class="separator my-5"></div>
                                                        <!--begin::Details item-->
                                                        <div class="fw-bold mt-5">m² (Net) </div>
                                                        <div v-if="this.propertyInfo.squareMetersNet !== null && this.propertyInfo.squareMetersNet !== ''"
                                                            class="text-gray-600"> {{ this.propertyInfo.squareMetersNet
                                                            }}</div>
                                                        <div v-if="this.propertyInfo.squareMetersNet == null || this.propertyInfo.squareMetersNet == ''"
                                                            class="text-gray-600"> Bilinmiyor</div>
                                                        <!--end::Details item-->

                                                    </div>
                                                </div>
                                                <!--end::Details content-->
                                            </div>
                                            <!--end::Card body-->
                                        </div>
                                        <!--end::Card-->
                                    </div>
                                    <!--end::Sidebar-->
                                </div>
                                <!--end::Layout-->
                            </div>
                            <!--end::Content container-->
                        </div>
                        <!--end::Content-->
                    </div>
                    <!--end::Content wrapper-->
                </div>
            </div>
        </div>
    </div>
    <!--end:::Main-->
</template>
<script>
import axios from 'axios'
import { mapGetters } from 'vuex'
import SecureLS from "secure-ls";
const ls = new SecureLS({ isCompression: false });
export default {
    name: 'PropertiesCreate',
    data() {
        return {
            form: {
                estateType: { value: null, name: "Emlak Türünü Seçiniz" },

            },
            propertyInfo: {
                title: null,
                description: null,
                price: null,
                squareMetersNet: null,
                province: null,
                district: null,
                neighborhood: null,
                estateStatusType: { value: null, name: "Mülk Durumu Seçiniz" },
            },
            estateTypeList: [],
            estateStatusTypeList: [],
            residentialPropertyList: [],
            formIsActive: false,
            userData: null,
        }
    },
    created() {
        this.estateTypeList = this.getEstateTypeList;
        this.estateStatusTypeList = this.getEstateStatusTypeList;
        this.residentialPropertyList = this.getResidentialPropertyList;
        if (this.estateStatusTypeList.length > 0) {
            this.propertyInfo.estateStatusType = this.estateStatusTypeList[0];
        }
        this.userData = this.getUser;
    },
    methods: {
        activateForm() {
            if (this.form.estateType.value == null) {
                this.formIsActive = false;
            } else
                this.formIsActive = true;
        },
        validateForm() {
            const requiredFields = [
                { field: this.propertyInfo.title, name: 'Başlık' },
                { field: this.propertyInfo.description, name: 'Açıklama' },
                { field: this.propertyInfo.price, name: 'Fiyat' },
                { field: this.propertyInfo.squareMetersNet, name: 'm² (Net)' },
                { field: this.propertyInfo.province, name: 'İl' },
                { field: this.propertyInfo.district, name: 'İlçe' },
                { field: this.propertyInfo.neighborhood, name: 'Mahalle' },
                { field: this.propertyInfo.estateStatusType.value, name: 'Mülk Durumu' },
            ];

            for (const field of requiredFields) {
                if (!field.field || field.field === '' || field.field === null) {
                    this.$swal('Hata', `${field.name} alanı boş bırakılamaz.`, 'error');
                    return false;
                }
            }

            return true;
        },
        saveProperty() {
            if (!this.validateForm()) {
                return;
            }

            this.$swal
                .fire({
                    title: "Bu mülkü kaydetmek istediğinize emin misiniz?",
                    confirmButtonColor: "#04b440",
                    showDenyButton: false,
                    showCancelButton: true,
                    confirmButtonText: "Onayla",
                    icon: 'info'
                })
                .then((result) => {
                    if (result.isConfirmed) {
                        const parameters = {
                            created_by: this.user.username,
                            property_type: this.form.estateType.value, //Emlak Türü
                            user_id: this.user.id,
                            title: this.propertyInfo.title,
                            description: this.propertyInfo.description,
                            price: this.propertyInfo.price,
                            square_meters_net: this.propertyInfo.squareMetersNet,
                            province: this.propertyInfo.province,
                            district: this.propertyInfo.district,
                            neighborhood: this.propertyInfo.neighborhood,
                            estate_status_type: this.propertyInfo.estateStatusType.value,
                        };
                        // API isteği
                        axios.post("/api/property/SaveProperty", parameters, { "Content-Type": "application/json" })
                            .then((response) => {
                                if (response.data != null && response.data.length == 36) {
                                    this.$swal("Başarılı", this.form.estateType.name + " başarıyla kaydedildi!", 'success');
                                    this.propertyInfo = {}; // Formu sıfırla
                                } else {
                                    this.$swal("Hata", this.form.estateType.name + " kaydedilemedi", "error");
                                }
                            })
                            .catch((error) => {
                                console.error('Hata:', error);
                                this.$swal("Hata", "Bir hata oluştu. Lütfen tekrar deneyin.", "error");
                            });
                    }
                });
        },

    },
    computed: {
        ...mapGetters(['getEstateTypeList']),
        ...mapGetters(['getEstateStatusTypeList']),
        ...mapGetters(['getResidentialPropertyList']),
        ...mapGetters(['getUser']),
        user() {
            return this.getUser();
        },
    }
}
</script>
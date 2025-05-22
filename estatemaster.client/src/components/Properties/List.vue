<template>
    <div>
        <div class="d-flex flex-column flex-root app-root" id="kt_app_root">
            <div class="app-page flex-column flex-column-fluid" id="kt_app_page">
                <div class="app-wrapper flex-column flex-row-fluid" id="kt_app_wrapper">
                    <div class="app-main flex-column flex-row-fluid" id="kt_app_main">
                        <div class="d-flex flex-column flex-column-fluid">
                            <div id="kt_app_content" class="app-content flex-column-fluid">
                                <div id="kt_app_content_container" class="app-container container-xxl">
                                    <!--begin::Tables Widget 11-->
                                    <div class="card mb-5 mb-xl-8">
                                        <!--begin::Header-->
                                        <div class="card-header border-0 pt-5">
                                            <h3 class="card-title align-items-start flex-column">
                                                <span class="card-label fw-bold fs-3 mb-1">Portföy</span>
                                            </h3>
                                            <div class="card-toolbar">
                                                <a href="#" class="btn btn-sm btn-light-primary">
                                                    <i class="ki-duotone ki-plus fs-2"></i>Mülk Ekle</a>
                                            </div>
                                        </div>
                                        <!--end::Header-->
                                        <!--begin::Body-->
                                        <div class="card-body py-3">
                                            <!--begin::Table container-->
                                            <div class="table-responsive">
                                                <!--begin::Table-->
                                                <table class="table table-hover align-middle gs-0 gy-4">
                                                    <!--begin::Table head-->
                                                    <thead>
                                                        <tr class="fw-bold text-muted bg-light">
                                                            <th class="ps-4">-</th>
                                                            <th class="ps-4 min-w-325px rounded-start">Başlık</th>
                                                            <th class="min-w-125px">Açıklama</th>
                                                            <th class="min-w-125px">Fiyat</th>
                                                            <th class="min-w-125px">Metrekare</th>
                                                            <th class="min-w-150px">Emlak Türü</th>
                                                            <th class="min-w-150px">Emlak Durumu</th>
                                                            <th class="min-w-150px">Kayıt Tarihi</th>
                                                            <th class="min-w-150px">İl/İlçe</th>
                                                            <th class="min-w-150px text-end rounded-end"></th>
                                                        </tr>
                                                    </thead>
                                                    <!--end::Table head-->
                                                    <!--begin::Table body-->
                                                    <tbody class="text-gray-600 fw-semibold">
                                                        <tr v-for="item of properties" v-bind:key="item">
                                                            <td>
                                                                <div class="d-flex align-items-center">
                                                                    <div class="symbol symbol-50px me-5">
                                                                        <img src="/assets/media/stock/600x400/img-26.jpg"
                                                                            class="" alt="" />
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div class="d-flex align-items-center">
                                                                    <div
                                                                        class="d-flex justify-content-start flex-column">
                                                                        <a href="#"
                                                                            class="text-gray-900 fw-bold text-hover-primary mb-1 fs-6">{{
                                                                                item.title }}</a>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <a href="#"
                                                                    class="text-gray-900 fw-bold text-hover-primary d-block mb-1 fs-6">{{
                                                                        item.description }}₺</a>
                                                            </td>
                                                            <td>
                                                                <a href="#"
                                                                    class="text-gray-900 fw-bold text-hover-primary d-block mb-1 fs-6">{{
                                                                        item.price }}</a>
                                                            </td>
                                                            <td>
                                                                <a href="#"
                                                                    class="text-gray-900 fw-bold text-hover-primary d-block mb-1 fs-6">{{
                                                                        item.square_meters_net }}</a>
                                                            </td>
                                                            <td>
                                                                <a href="#"
                                                                    class="text-gray-900 fw-bold text-hover-primary d-block mb-1 fs-6">{{
                                                                        getEstateTypeList.find(type => type.value ===
                                                                    item.property_type)?.name || item.property_type
                                                                    }}</a>
                                                            </td>
                                                            <td>
                                                                <span class="badge badge-light-primary fs-7 fw-bold"> {{
                                                                   getEstateStatusTypeList.find(type => type.value ===
                                                                    item.estate_status_type)?.name || item.estate_status_type }}</span>
                                                            </td>
                                                              <td>
                                                                <a href="#"
                                                                    class="text-gray-900 fw-bold text-hover-primary d-block mb-1 fs-6">{{
                                                                        $formatDate(item.created_at) }}</a>
                                                            </td>
                                                            <td>
                                                                <span class="badge badge-light-primary fs-7 fw-bold"> {{
                                                                    item.province }}/{{ item.district }}</span>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                    <!--end::Table body-->
                                                </table>
                                                <!--end::Table-->
                                            </div>
                                            <!--end::Table container-->
                                        </div>
                                        <!--begin::Body-->
                                    </div>
                                    <!--end::Tables Widget 11-->
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
import { mapGetters } from 'vuex';

export default {
    name: 'PropertiesList',
    data() {
        return {
            properties: [],
            loading: false,
            error: null,
        };
    },
    created() {
        axios.post('/api/property/GetProperties',).then((response) => {
            this.properties = response.data;
        })
    },
    computed: {
        ...mapGetters(['getEstateTypeList']),
        ...mapGetters(['getEstateStatusTypeList']),
    },
}
</script>
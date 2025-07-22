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
                                                <button class="btn btn-sm btn-light-primary" @click="showModal = true">
                                                    <i class="ki-duotone ki-plus fs-2"></i> Mülk Ekle
                                                </button>
                                            </div>
                                        </div>
                                        <!--end::Header-->
                                        <!-- Modal -->
                                        <div v-if="showModal" class="modal fade show d-block" tabindex="-1"
                                            style="background:rgba(0,0,0,0.3)">
                                            <div class="modal-dialog modal-xl">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <h5 class="modal-title">Mülk Ekle</h5>
                                                        <button type="button" class="btn-close"
                                                            @click="showModal = false"></button>
                                                    </div>
                                                    <div class="modal-body">
                                                        <PropertiesCreate @close="showModal = false" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- end::Modal -->
                                        <!--begin::Body-->
                                        <div class="card-body py-3">
                                            <!--begin::Table container-->
                                            <div class="table-responsive">
                                                <!--begin::Table-->
                                                <table class="table table-hover align-middle gs-0 gy-4">
                                                    <!--begin::Table head-->
                                                    <thead>
                                                        <tr class="fw-bold text-muted bg-light">
                                                            <th class="min-w-125px">-</th>
                                                            <th class="min-w-125px">Başlık</th>
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
                                                        <tr v-for="item in properties" :key="item.id">
                                                            <td>
                                                                <div class="d-flex align-items-center">
                                                                    <div class="symbol symbol-50px me-5">
                                                                        <img src="/assets/media/stock/600x400/img-26.jpg"
                                                                            alt="" />
                                                                    </div>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <a href="#"
                                                                    class="text-gray-900 fw-bold text-hover-primary mb-1 fs-6">{{
                                                                        item.title }}</a>
                                                            </td>
                                                            <td>
                                                                <span class="text-gray-900 fw-bold d-block mb-1 fs-6">{{
                                                                    item.description }}</span>
                                                            </td>
                                                            <td>
                                                                <span class="text-gray-900 fw-bold d-block mb-1 fs-6">
                                                                    {{ Number(item.price).toLocaleString('tr-TR') }} ₺
                                                                </span>
                                                            </td>
                                                            <td>
                                                                <span class="text-gray-900 fw-bold d-block mb-1 fs-6">{{
                                                                    item.square_meters_net }}m²</span>
                                                            </td>
                                                            <td>
                                                                <span class="badge fs-7 fw-bold" :class="{
                                                                    'badge-primary': item.property_type === 'residential_propery',
                                                                    'badge-info': item.property_type === 'commercial_property',
                                                                    'badge-warning': item.property_type === 'land',
                                                                    'badge-dark': item.property_type === 'building',
                                                                    'badge-success': item.property_type === 'timeshare',
                                                                    'badge-danger': item.property_type === 'tourist_facility'
                                                                }">
                                                                    {{
                                                                        getEstateTypeList.find(type => type.value ===
                                                                            item.property_type)?.name || item.property_type
                                                                    }}
                                                                </span>
                                                            </td>
                                                            <td>
                                                                <span class="badge fs-7 fw-bold" :class="{
                                                                    'badge-success': item.estate_status_type === 'sale',
                                                                    'badge-warning': item.estate_status_type === 'rent'
                                                                }">
                                                                    {{
                                                                        getEstateStatusTypeList.find(type => type.value ===
                                                                            item.estate_status_type)?.name ||
                                                                        item.estate_status_type
                                                                    }}
                                                                </span>
                                                            </td>
                                                            <td>
                                                                <span class="text-gray-900 fw-bold d-block mb-1 fs-6">{{
                                                                    $formatDate(item.created_at) }}</span>
                                                            </td>
                                                            <td>
                                                                <span class="badge badge-light-primary fs-7 fw-bold">
                                                                    {{ item.province }}/{{ item.district }} 
                                                                </span>
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
import PropertiesCreate from './Create.vue'
import { mapGetters } from 'vuex';

export default {
    name: 'PropertiesList',
    components: {
        PropertiesCreate,
    },
    data() {
        return {
            showModal: false,
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
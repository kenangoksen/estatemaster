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
                                                <span class="card-label fw-bold fs-3 mb-1">Müşteriler</span>
                                            </h3>
                                            <div class="card-toolbar">
                                                <button class="btn btn-sm btn-light-primary" @click="showModal = true">
                                                    <i class="ki-duotone ki-plus fs-2"></i> Müşteri Ekle
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
                                                            <th class="min-w-125px">İsim</th>
                                                            <th class="min-w-125px">Soyisim</th>
                                                            <th class="min-w-125px">Mail</th>
                                                            <th class="min-w-125px">Telefon</th>
                                                            <th class="min-w-125px">Müşteri Tipi</th>
                                                            <th class="min-w-150px">Oluşturulma Tarihi</th>
                                                            <th class="min-w-150px text-end rounded-end"></th>
                                                        </tr>
                                                    </thead>
                                                    <!--end::Table head-->
                                                    <!--begin::Table body-->
                                                    <tbody class="text-gray-600 fw-semibold">
                                                        <tr v-for="item in customers" :key="item.id">
                                                            <td>
                                                                <router-link
                                                                    :to="{ name: 'CustomerUpadate', params: { id: item.id } }">
                                                                    <span
                                                                        class="text-gray-900 fw-bold d-block mb-1 fs-6">{{
                                                                            item.firstName }}</span>
                                                                </router-link>
                                                            </td>
                                                            <td>
                                                                <span class="text-gray-900 fw-bold d-block mb-1 fs-6">{{
                                                                    item.lastName }}</span>
                                                            </td>
                                                            <td>
                                                                <span class="text-gray-900 fw-bold d-block mb-1 fs-6">
                                                                    {{ item.email }}
                                                                </span>
                                                            </td>
                                                            <td>
                                                                <span class="text-gray-900 fw-bold d-block mb-1 fs-6">{{
                                                                    item.phone }}</span>
                                                            </td>
                                                            <td>
                                                                <span class="badge fs-7 fw-bold">
                                                                    {{
                                                                        item.customerType == 'seller' ? 'Satıcı' : 'Alıcı'
                                                                    }}
                                                                </span>
                                                            </td>
                                                            <td>
                                                                <span class="text-gray-900 fw-bold d-block mb-1 fs-6">{{
                                                                    $formatDate(item.createdAt) }}</span>
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
import axios from "axios";

export default {
    name: "CustomerList",
    data() {
        return {
            customers: []
        };
    },
    mounted() {
        this.loadCustomers();
    },
    methods: {
        async loadCustomers() {
            try {
                const res = await axios.get("/api/customer/GetCustomers");
                this.customers = res.data;
                console.log("Müşteriler yüklendi:", this.customers[0].firstname);
                console.log("Müşteri sayısı:", res.data);
            } catch (err) {
                console.error("Müşteri yüklenemedi:", err);
            }
        },
        async toggleCustomer(id) {
            try {
                await axios.post("/api/customer/ToggleCustomerState", { id });
                this.loadCustomers(); // listeyi yenile
            } catch (err) {
                console.error("Durum değiştirilemedi:", err);
            }
        }
    }
};
</script>
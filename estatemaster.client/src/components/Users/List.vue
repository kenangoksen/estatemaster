<template>
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
                            <div id="kt_app_toolbar_container" class="app-container container-xxl d-flex flex-stack">
                                <!--begin::Page title-->
                                <div class="page-title d-flex flex-column justify-content-center flex-wrap me-3">
                                    <!--begin::Title-->
                                    <h1
                                        class="page-heading d-flex text-gray-900 fw-bold fs-3 flex-column justify-content-center my-0">
                                        Kullanıcı Listesi</h1>
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
                                        <li class="breadcrumb-item text-muted">Kullanıcı Yönetimi</li>
                                        <!--end::Item-->
                                        <!--begin::Item-->
                                        <li class="breadcrumb-item">
                                            <span class="bullet bg-gray-500 w-5px h-2px"></span>
                                        </li>
                                        <!--end::Item-->
                                        <!--begin::Item-->
                                        <li class="breadcrumb-item text-muted">Kullanıcı</li>
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
                                <!--begin::Card-->
                                <div class="card">
                                    <!--begin::Card header-->
                                    <div class="card-header border-0 pt-6">
                                        <!--begin::Card title-->
                                        <div class="card-title">
                                            <!--begin::Search-->
                                            <div class="d-flex align-items-center position-relative my-1">
                                                <i class="ki-duotone ki-magnifier fs-3 position-absolute ms-5">
                                                    <span class="path1"></span>
                                                    <span class="path2"></span>
                                                </i>
                                                <input type="text" data-kt-user-table-filter="search"
                                                    class="form-control form-control-solid w-250px ps-13"
                                                    placeholder="Kullanıcı Ara" />
                                            </div>
                                            <!--end::Search-->
                                        </div>
                                        <!--begin::Card title-->
                                        <!--begin::Card toolbar-->
                                        <div class="card-toolbar">
                                            <!--begin::Toolbar-->
                                            <div class="d-flex justify-content-end" data-kt-user-table-toolbar="base">
                                                <!--begin::Filter-->
                                                <button type="button" class="btn btn-light-primary me-3"
                                                    data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end"
                                                    @click="getListUsers();">
                                                    <i class="ki-duotone ki-filter fs-2">
                                                        <span class="path1"></span>
                                                        <span class="path2"></span>
                                                    </i>Listele
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-body py-4">
                                        <table class="table align-middle table-row-dashed fs-6 gy-5"
                                            id="kt_table_users">
                                            <thead>
                                                <tr class="text-start text-muted fw-bold fs-7 text-uppercase gs-0">
                                                    <th class="min-w-125px">Kullanıcı</th>
                                                    <th class="min-w-125px">Telefon</th>
                                                    <th class="min-w-125px">Email</th>
                                                    <th class="min-w-125px">Son Giriş</th>
                                                    <th class="min-w-125px">Yaşadığı il</th>
                                                    <th class="min-w-125px">Kullanıcı Tipi</th>
                                                    <th class="min-w-125px">Oluşuturulma Tarihi</th>
                                                    <th class="min-w-125px">Açıklama</th>
                                                    <th class="min-w-125px">İşlemler</th>
                                                </tr>
                                            </thead>
                                            <tbody class="text-gray-600 fw-semibold">
                                                <tr v-for="item of userList" v-bind:key="item">
                                                    <td class="d-flex align-items-center">
                                                        <div
                                                            class="symbol symbol-circle symbol-50px overflow-hidden me-3">
                                                            <a href="apps/user-management/users/view.html">
                                                                <div class="symbol-label">
                                                                    <img src="/assets/media/avatars/300-1.jpg"
                                                                        alt="Max Smith" class="w-100" />
                                                                </div>
                                                            </a>
                                                        </div>
                                                        <div class="d-flex flex-column">
                                                            <a href="apps/user-management/users/view.html"
                                                                class="text-gray-800 text-hover-primary mb-1">{{
                                                                    item.name }}
                                                                {{ item.surname }}</a>
                                                        </div>
                                                    </td>
                                                    <td> {{ item.phone }}</td>
                                                    <td> {{ item.email }}</td>
                                                    <td>
                                                        <div class="badge badge-light fw-bold">3 days ago</div>
                                                    </td>
                                                    <td>
                                                        <div class="badge badge-light fw-bold">{{ item.state }}</div>
                                                    </td>
                                                    <td>
                                                        <div v-if="item.userType == 'admin'"
                                                            class="badge badge-success fw-bold">Admin</div>
                                                        <div v-if="item.userType == 'modaretor'"
                                                            class="badge badge-warning fw-bold">Yönetici</div>
                                                        <div v-if="item.userType == 'saleperson'"
                                                            class="badge badge-dark fw-bold">Emlak danışanı</div>
                                                    </td>
                                                    <td>{{ item.created_at }}</td>
                                                    <td>{{ item.description }}</td>
                                                    <td class="text-end">
                                                        <div class="d-flex align-center-items-center gap-2 gap-lg-3">
                                                            <router-link
                                                                :to="{ name: 'UserUpdate', params: { id: item.id } }">
                                                                <a href="#"
                                                                    class="btn btn-warning btn-active-light-primary btn-flex btn-center btn-sm"
                                                                    data-kt-menu-trigger="click"
                                                                    data-kt-menu-placement="bottom-end">Düzenle
                                                                </a>
                                                            </router-link>
                                                            <button class="btn btn-danger btn-flex btn-center btn-sm"
                                                                @click="deleteUser(item.id)">Sil</button>
                                                        </div>
                                                    </td>
                                                </tr>

                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="kt_scrolltop" class="scrolltop" data-kt-scrolltop="true">
        <i class="ki-duotone ki-arrow-up">
            <span class="path1"></span>
            <span class="path2"></span>
        </i>
    </div>
    <!--end:::Main-->
</template>

<script>
import axios from 'axios';

export default {
    name: "UserList",
    data() {
        return {
            userList: [],
            showForm: false,
            cardNumber: '',
            expiryDate: '',
            cvc: '',
            amount: ''
        };
    },
    created() {
        axios.post('/api/user/GetUsers', { 'Content-Type': 'application/json' }).then((response) => {
            this.userList = response.data;
        })
    },
    methods: {
        getListUsers() {
            axios.post('/api/user/GetUsers', { 'Content-Type': 'application/json' }).then((response) => {
                this.userList = response.data;
            })
        },
        deleteUser(id) {
            const params = {
                id: id
            }
            axios.post('/api/user/DeleteUser', params, { 'Content-Type': 'application/json' }).then((response) => {
                if (response.data.error == null || response.data.error == 'undefined' || response.data.error == '') {
                    this.getListUsers();
                    this.$swal('Başarılı', 'Kullanıcı silme işlemi başarılı', 'success')
                }
            })
        },
        async submitPayment() {
            const paymentData = {
                amount: this.amount, // Ödeme miktarı
                currency: 'USD',
                description: 'Payment for Order #12345',
                cardNumber: this.cardNumber,
                expiryDate: this.expiryDate,
                cvc: this.cvc,
                return_url: 'https://localhost:5173/user/list'
            };

            try {
                const response = await axios.post('https://pay.crypto.com/api/payments', paymentData, {
                    headers: {
                        Authorization: 'Bearer sk_test_xwHUe2zAiZNpTjS3awx4CySd',
                        'Content-Type': 'application/json'
                    }
                });

                console.log(response.data)
                this.response = response.data;

                // payment_url'e yönlendirme
                window.location.href = response.data.payment_url;
                this.showModal = false;
            } catch (error) {
                console.error(error);
                alert('Ödeme başarısız!');
            }
        }

    }
}
</script>
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
                                            Kullanıcı Listesi</h1>
                                        <ul class="breadcrumb breadcrumb-separatorless fw-semibold fs-7 my-0 pt-1">
                                            <li class="breadcrumb-item text-muted">
                                                <a href="index.html" class="text-muted text-hover-primary">Anasayfa</a>
                                            </li>
                                            <li class="breadcrumb-item">
                                                <span class="bullet bg-gray-500 w-5px h-2px"></span>
                                            </li>
                                            <li class="breadcrumb-item text-muted">Kullanıcı Yönetimi</li>
                                            <li class="breadcrumb-item">
                                                <span class="bullet bg-gray-500 w-5px h-2px"></span>
                                            </li>
                                            <li class="breadcrumb-item text-muted">Kullanıcı Listesi</li>
                                        </ul>
                                    </div>
                                </div>
                            </div>

                            <div id="kt_app_content" class="app-content flex-column-fluid">
                                <div id="kt_app_content_container" class="app-container container-xxl">
                                    <div class="card">
                                        <div class="card-header border-0 pt-6">
                                            <div class="card-title">
                                                <div class="d-flex align-items-center position-relative my-1">
                                                    <i class="ki-duotone ki-magnifier fs-3 position-absolute ms-5">
                                                        <span class="path1"></span>
                                                        <span class="path2"></span>
                                                    </i>
                                                    <input type="text" data-kt-user-table-filter="search"
                                                        class="form-control form-control-solid w-250px ps-13"
                                                        placeholder="Kullanıcı Ara" />
                                                </div>
                                            </div>
                                            <div class="card-toolbar">
                                                <div class="d-flex justify-content-end"
                                                    data-kt-user-table-toolbar="base">
                                                    <button type="button" class="btn btn-light-primary me-3"
                                                        data-kt-menu-trigger="click" data-kt-menu-placement="bottom-end"
                                                        @click="getListUsers()">
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
                                                        <th class="min-w-125px">Şehir</th>
                                                        <th class="min-w-125px">Kullanıcı Tipi</th>
                                                        <th class="min-w-125px">Oluşturulma Tarihi</th>
                                                        <th class="min-w-125px">Açıklama</th>
                                                        <th class="min-w-125px">İşlemler</th>
                                                    </tr>
                                                </thead>
                                                <tbody class="text-gray-600 fw-semibold">
                                                    <tr v-for="item of userList" v-bind:key="item.id">
                                                        <td class="d-flex align-items-center">
                                                            <div
                                                                class="symbol symbol-circle symbol-50px overflow-hidden me-3">
                                                                <a href="#">
                                                                    <div class="symbol-label">
                                                                    </div>
                                                                </a>
                                                            </div>
                                                            <div class="d-flex flex-column">
                                                                <a href="#"
                                                                    class="text-gray-800 text-hover-primary mb-1">{{
                                                                    item.name }}
                                                                    {{ item.surname }}</a>
                                                            </div>
                                                        </td>
                                                        <td>{{ item.phone }}</td>
                                                        <td>{{ item.email }}</td>
                                                        <td>
                                                            <div class="badge badge-light fw-bold">{{ item.state }}
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div v-if="item.userType == 'Admin'"
                                                                class="badge badge-success fw-bold">Admin</div>
                                                            <div v-if="item.userType == 'Moderator'"
                                                                class="badge badge-warning fw-bold">Yönetici</div>
                                                            <div v-if="item.userType == 'Saleperson'"
                                                                class="badge badge-dark fw-bold">Emlak danışanı</div>
                                                        </td>
                                                        <td>{{ item.created_at }}</td>
                                                        <td>{{ item.description }}</td>
                                                        <td class="text-end">
                                                            <div
                                                                class="d-flex align-center-items-center gap-2 gap-lg-3">
                                                                <router-link
                                                                    :to="{ name: 'UserUpdate', params: { id: item.id } }">
                                                                    <a href="#"
                                                                        class="btn btn-warning btn-active-light-primary btn-flex btn-center btn-sm"
                                                                        data-kt-menu-trigger="click"
                                                                        data-kt-menu-placement="bottom-end">Düzenle
                                                                    </a>
                                                                </router-link>
                                                                <button
                                                                    class="btn btn-danger btn-flex btn-center btn-sm"
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
    </div>
</template>

<script>
import axios from 'axios';
import SecureLS from "secure-ls";

export default {
    name: "UserList",
    data() {
        return {
            userList: [],
            sid: null
        };
    },
    created() {
        const userData = this.$getUser();
        this.sid = userData.session_id;
    },
    methods: {
        getListUsers() {
              const headers = {
                'Content-Type': 'application/json',
                'sid': this.sid
            };
            axios.post('/api/user/GetUsers', null, { headers })
                .then((response) => {
                    this.userList = response.data;
                }).catch(error => {
                    console.error("Kullanıcı listesi getirilirken hata oluştu:", error);
                    this.$swal("Hata", "Kullanıcı listesi getirilemedi. Oturumunuzun süresi dolmuş olabilir.", "error");
                });
        },
        deleteUser(id) {
            this.$swal
                .fire({
                    title: "Bu kullanıcıyı silmek istediğinize emin misiniz?",
                    confirmButtonColor: "#dc3545",
                    showDenyButton: false,
                    showCancelButton: true,
                    confirmButtonText: "Sil",
                    icon: 'warning'
                })
                .then((result) => {
                    if (result.isConfirmed) {
                        const headers = {
                            'Content-Type': 'application/json',
                            'sid': this.sid
                        };
                        const params = { id: id };
                        axios.post('/api/user/DeleteUser', params, { headers }).then((response) => {
                            if (response.data === "OK") {
                                this.getListUsers();
                                this.$swal('Başarılı', 'Kullanıcı silme işlemi başarılı', 'success');
                            } else {
                                this.$swal('Hata', response.data, 'error');
                            }
                        }).catch(error => {
                            this.$swal('Hata', 'Kullanıcı silme işlemi sırasında bir hata oluştu.', 'error');
                        });
                    }
                });
        }
    }
}
</script>
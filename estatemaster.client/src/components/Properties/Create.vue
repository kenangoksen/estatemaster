<template>
    <div class="d-flex flex-column flex-root app-root" id="kt_app_root">
        <div class="app-page flex-column flex-column-fluid" id="kt_app_page">
            <div class="app-wrapper flex-column flex-row-fluid" id="kt_app_wrapper">
                <!--begin::Main-->
                <div class="app-main flex-column flex-row-fluid" id="kt_app_main">
                    <div class="d-flex flex-cloumn flex-cloumn-fluid">
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
                                <div class="d-flex flex-cloumn flex-lg-row">
                                    <div class="flex-lg-row-fluid mb-10 mb-lg-0 me-lg-7 me-xl-10">
                                        <!--begin::Card-->
                                        <div class="card">
                                            <!--begin::Card body-->
                                            <div class="card-body p-12">
                                                <select class="form-select" aria-label="Select example"
                                                    data-placeholder="Emlak Türünü Seçiniz" data-allow-clear="true"
                                                    v-model="form.estateType" @change="activateForm">
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
                                        <div class="card">
                                            <!--begin::Card body-->
                                            <div class="card-body p-12">
                                                <!--begin::Form-->
                                                <form action="" id="kt_invoice_form">
                                                    <!--begin::Wrapper-->
                                                    <!--begin::Separator-->
                                                    <div class="separator separator-content border-dark my-15"><span class="w-350px fw-bold h1">{{ this.form.estateType.name }} Bilgileri</span></div>
                                                    <!--end::Separator-->
                                                    <!--begin::Wrapper-->
                                                    <div class="mb-0">
                                                        <!--begin::Row-->
                                                        <div class="mb-10">
                                                            <label for="exampleFormControlInput1"
                                                                class="required form-label">Başlık
                                                            </label>
                                                            <input type="titile" v-model="this.propertyInfo.title"class="form-control form-control-solid"
                                                                placeholder="Başlık" />
                                                        </div>
                                                        <div class="mb-0 mb-10">
                                                            <label class="form-label fs-6 fw-bold text-gray-700">İlan
                                                                Açıklaması</label>
                                                            <textarea name="notes" v-model="this.propertyInfo.description"
                                                                class="form-control form-control-solid" rows="3"
                                                                placeholder="İlan Açıklaması"></textarea>
                                                        </div>
                                                        <div class="row gx-10 mb-5">
                                                            <!--begin::Col-->
                                                            <div class="col-lg-6">

                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Fiyat
                                                                    </label>
                                                                    <input type="price" v-model="this.propertyInfo.price"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="Fiyat" />
                                                                </div>
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">m² (Brüt)
                                                                    </label>
                                                                    <input type="province" v-model="this.propertyInfo.squareMetersGross"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="m² (Brüt)" />
                                                                </div>
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">m² (Net)

                                                                    </label>
                                                                    <input type="district" v-model="this.propertyInfo.squareMetersNet"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="m² (Net)" />
                                                                </div>
                                                            </div>
                                                            <!--end::Col-->
                                                            <!--begin::Col-->
                                                            <div class="col-lg-6">
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Oda Sayısı
                                                                    </label>
                                                                    <input type="address" v-model="this.propertyInfo.roomNumber"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="Oda Sayısı" />
                                                                </div>
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Bina Yaşı
                                                                    </label>
                                                                    <input type="email" v-model="this.propertyInfo.buildingAge"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="Bina Yaşı" />
                                                                </div>
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Bulunduğu Kat
                                                                    </label>
                                                                    <input type="email" v-model="this.propertyInfo.locatedFloor"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="Bulunduğu Kat" />
                                                                </div>
                                                            </div>
                                                            <!--end::Col-->
                                                            <!--begin::Col-->
                                                            <div class="col-lg-6">
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Kat Sayısı
                                                                    </label>
                                                                    <input type="email" v-model="this.propertyInfo.floorNumber"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="Kat Sayısı" />
                                                                </div>
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Isıtma
                                                                    </label>
                                                                    <input type="address" v-model="this.propertyInfo.heating"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="Isıtma" />
                                                                </div>
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Banyo Sayısı
                                                                    </label>
                                                                    <input type="email" v-model="this.propertyInfo.bathroomNumber"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="Banyo Sayısı" />
                                                                </div>
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Mutfak
                                                                    </label>
                                                                    <input type="email" v-model="this.propertyInfo.kitchen"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="Mutfak" />
                                                                </div>
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Balkon
                                                                    </label>
                                                                    <input type="email" v-model="this.propertyInfo.balcony"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="Balkon" />
                                                                </div>
                                                            </div>
                                                            <!--end::Col-->
                                                            <!--begin::Col-->
                                                            <div class="col-lg-6">
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Asansör
                                                                    </label>
                                                                    <input type="address" v-model="this.propertyInfo.lift"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="Asansör" />
                                                                </div>
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Otopark
                                                                    </label>
                                                                    <input type="email" v-model="this.propertyInfo.parking"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="Otopark" />
                                                                </div>
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Eşyalı
                                                                    </label>
                                                                    <input type="email" v-model="this.propertyInfo.furnished"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="Eşyalı" />
                                                                </div>
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Kullanım Durumu
                                                                    </label>
                                                                    <input type="email" v-model="this.propertyInfo.usageStatus"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="Kullanım Durumu" />
                                                                </div>
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Aidat(TL)
                                                                    </label>
                                                                    <input type="address" v-model="this.propertyInfo.dues"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="Aidat(TL)" />
                                                                </div>
                                                            </div>
                                                            <!--end::Col-->
                                                            <!--begin::Col-->
                                                            <div class="col-lg-6">
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Krediye Uygun
                                                                    </label>
                                                                    <input type="email" v-model="this.propertyInfo.creditEligibility"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="Krediye Uygun" />
                                                                </div>
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Tapu Durumu
                                                                    </label>
                                                                    <input type="email" v-model="this.propertyInfo.titleDeedStatus"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="Tapu Durumu" />
                                                                </div>
                                                            </div>
                                                            <!--end::Col-->
                                                            <!--begin::Col-->
                                                            <div class="col-lg-6">
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Taşınmaz Durumu
                                                                    </label>
                                                                    <input type="email"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="Taşınmaz Durumu" />
                                                                </div>
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Kimden
                                                                    </label>
                                                                    <input type="address" v-model="this.propertyInfo.isSaleWho"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="Kimden" />
                                                                </div>
                                                            </div>
                                                            <!--end::Col-->
                                                            <!--begin::Separator-->
                                                            <div class="separator separator-content border-dark my-15"><span class="w-250px fw-bold h1">Adres Bilgileri</span></div>
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
                                                                    <input type="email" v-model="this.propertyInfo.province"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="İl" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">İlçe
                                                                    </label>
                                                                    <input type="email" v-model="this.propertyInfo.district"
                                                                        class="form-control form-control-solid"
                                                                        placeholder="İlçe" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <div class="mb-10">
                                                                    <label for="exampleFormControlInput1"
                                                                        class="required form-label">Mahalle
                                                                    </label>
                                                                    <input type="email" v-model="this.propertyInfo.quarter"
                                                                        class="form-control form-control-solid"
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
														<a href="#" class="fs-3 text-gray-800 text-hover-primary fw-bold mb-1"> 
                                                            <span v-if="this.propertyInfo.title !== null && this.propertyInfo.title !== ''"> {{ this.propertyInfo.title }} </span>
                                                            <span v-if="this.propertyInfo.title == null || this.propertyInfo.title == ''">Başlık</span>
                                                        </a>                                                       
														<!--end::Title-->
                                                        <!--begin::Description-->
														<div class="fs-5 fw-semibold text-muted mb-6">{{ this.propertyInfo.description }}</div>
														<!--end::Description--> 
														<!--begin::Info-->
														<div class="d-flex flex-wrap flex-center">
															<!--begin::Stats-->
															<div class="border border-gray-300 border-dashed rounded py-3 px-3 mb-3">
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
															<div class="border border-gray-300 border-dashed rounded py-3 px-3 mx-4 mb-3">
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
															<div class="border border-gray-300 border-dashed rounded py-3 px-3 mb-3">
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
														<div class="fw-bold rotate collapsible collapsed" data-bs-toggle="collapse" href="#kt_customer_view_details" role="button" aria-expanded="false" aria-controls="kt_customer_view_details">Detaylar 
														<span class="ms-2 rotate-180">
															<i class="ki-duotone ki-down fs-3"></i>
														</span></div>
														<span data-bs-toggle="tooltip" data-bs-trigger="hover" title="Edit customer details">
															<a href="#" class="btn btn-sm btn-light-primary" data-bs-toggle="modal" data-bs-target="#kt_modal_update_customer">Edit</a>
														</span>
													</div>
													<!--end::Details toggle-->
													<div class="separator separator-dashed my-3"></div>
													<!--begin::Details content-->
													<div id="kt_customer_view_details" class="collapse">
														<div class="py-5 fs-6">
															<!--begin::Details item-->
															<div class="fw-bold mt-5">Fiyat</div>
															<div v-if="this.propertyInfo.price !== null && this.propertyInfo.price !== ''" class="text-gray-600"> {{ this.propertyInfo.price }}</div>
															<div v-if="this.propertyInfo.price == null || this.propertyInfo.price == ''" class="text-gray-600"> Bilinmiyor</div>
															<!--end::Details item-->
                                                            <div class="separator my-5"></div>
															<!--begin::Details item-->
															<div class="fw-bold mt-5">m² (Brüt) </div>
															<div v-if="this.propertyInfo.squareMetersGross !== null && this.propertyInfo.squareMetersGross !== ''" class="text-gray-600"> {{ this.propertyInfo.squareMetersGross }}</div>
															<div v-if="this.propertyInfo.squareMetersGross == null || this.propertyInfo.squareMetersGross == ''" class="text-gray-600"> Bilinmiyor</div>
															<!--end::Details item-->
                                                            <div class="separator my-5"></div>
															<!--begin::Details item-->
															<div class="fw-bold mt-5">m² (Net) </div>
															<div v-if="this.propertyInfo.squareMetersNet !== null && this.propertyInfo.squareMetersNet !== ''" class="text-gray-600"> {{ this.propertyInfo.squareMetersNet }}</div>
															<div v-if="this.propertyInfo.squareMetersNet == null || this.propertyInfo.squareMetersNet == ''" class="text-gray-600"> Bilinmiyor</div>
															<!--end::Details item-->
                                                            <div class="separator my-5"></div>
															<!--begin::Details item-->
															<div class="fw-bold mt-5">Oda Sayısı </div>
															<div v-if="this.propertyInfo.roomNumber !== null && this.propertyInfo.roomNumber !== ''" class="text-gray-600"> {{ this.propertyInfo.roomNumber }}</div>
															<div v-if="this.propertyInfo.roomNumber == null || this.propertyInfo.roomNumber == ''" class="text-gray-600"> Bilinmiyor</div>
															<!--end::Details item-->
                                                            <div class="separator my-5"></div>
															<!--begin::Details item-->
															<div class="fw-bold mt-5">Bina Yaşı</div>
															<div v-if="this.propertyInfo.buildingAge !== null && this.propertyInfo.buildingAge !== ''" class="text-gray-600"> {{ this.propertyInfo.buildingAge }}</div>
															<div v-if="this.propertyInfo.buildingAge == null || this.propertyInfo.buildingAge == ''" class="text-gray-600"> Bilinmiyor</div>
															<!--end::Details item-->
                                                            <div class="separator my-5"></div>
															<!--begin::Details item-->
															<div class="fw-bold mt-5">Kat Sayısı </div>
															<div v-if="this.propertyInfo.floorNumber !== null && this.propertyInfo.floorNumber !== ''" class="text-gray-600"> {{ this.propertyInfo.floorNumber }}</div>
															<div v-if="this.propertyInfo.floorNumber == null || this.propertyInfo.floorNumber == ''" class="text-gray-600"> Bilinmiyor</div>
															<!--end::Details item-->
                                                            <div class="separator my-5"></div>
															<!--begin::Details item-->
															<div class="fw-bold mt-5">Bulunduğu Kat</div>
															<div v-if="this.propertyInfo.locatedFloor !== null && this.propertyInfo.locatedFloor !== ''" class="text-gray-600"> {{ this.propertyInfo.locatedFloor }}</div>
															<div v-if="this.propertyInfo.locatedFloor == null || this.propertyInfo.locatedFloor == ''" class="text-gray-600"> Bilinmiyor</div>
															<!--end::Details item-->
                                                            <div class="separator my-5"></div>
															<!--begin::Details item-->
															<div class="fw-bold mt-5">Isıtma</div>
															<div v-if="this.propertyInfo.heating !== null && this.propertyInfo.heating !== ''" class="text-gray-600"> {{ this.propertyInfo.heating }}</div>
															<div v-if="this.propertyInfo.heating == null || this.propertyInfo.heating == ''" class="text-gray-600"> Bilinmiyor</div>
															<!--end::Details item-->
                                                            <div class="separator my-5"></div>
															<!--begin::Details item-->
															<div class="fw-bold mt-5">Banyo Sayısı</div>
															<div v-if="this.propertyInfo.bathroomNumber !== null && this.propertyInfo.bathroomNumber !== ''" class="text-gray-600"> {{ this.propertyInfo.bathroomNumber }}</div>
															<div v-if="this.propertyInfo.bathroomNumber == null || this.propertyInfo.bathroomNumber == ''" class="text-gray-600"> Bilinmiyor</div>
															<!--end::Details item-->
                                                            <div class="separator my-5"></div>
															<!--begin::Details item-->
															<div class="fw-bold mt-5">Mutfak</div>
															<div v-if="this.propertyInfo.kitchen !== null && this.propertyInfo.kitchen !== ''" class="text-gray-600"> {{ this.propertyInfo.kitchen }}</div>
															<div v-if="this.propertyInfo.kitchen == null || this.propertyInfo.kitchen == ''" class="text-gray-600"> Bilinmiyor</div>
															<!--end::Details item-->
                                                            <div class="separator my-5"></div>
															<!--begin::Details item-->
															<div class="fw-bold mt-5">Balkon</div>
															<div v-if="this.propertyInfo.balcony !== null && this.propertyInfo.balcony !== ''" class="text-gray-600"> {{ this.propertyInfo.balcony }}</div>
															<div v-if="this.propertyInfo.balcony == null || this.propertyInfo.balcony == ''" class="text-gray-600"> Bilinmiyor</div>
															<!--end::Details item-->
                                                            <div class="separator my-5"></div>
															<!--begin::Details item-->
															<div class="fw-bold mt-5">Asansör</div>
															<div v-if="this.propertyInfo.lift !== null && this.propertyInfo.lift !== ''" class="text-gray-600"> {{ this.propertyInfo.lift }}</div>
															<div v-if="this.propertyInfo.lift == null || this.propertyInfo.lift == ''" class="text-gray-600"> Bilinmiyor</div>
															<!--end::Details item-->
                                                            <div class="separator my-5"></div>
															<!--begin::Details item-->
															<div class="fw-bold mt-5">Otopark</div>
															<div v-if="this.propertyInfo.parking !== null && this.propertyInfo.parking !== ''" class="text-gray-600"> {{ this.propertyInfo.parking }}</div>
															<div v-if="this.propertyInfo.parking == null || this.propertyInfo.parking == ''" class="text-gray-600"> Bilinmiyor</div>
															<!--end::Details item-->
                                                            <div class="separator my-5"></div>
															<!--begin::Details item-->
															<div class="fw-bold mt-5">Eşyalı</div>
															<div v-if="this.propertyInfo.furnished !== null && this.propertyInfo.furnished !== ''" class="text-gray-600"> {{ this.propertyInfo.furnished }}</div>
															<div v-if="this.propertyInfo.furnished == null || this.propertyInfo.furnished == ''" class="text-gray-600"> Bilinmiyor</div>
															<!--end::Details item-->
                                                            <div class="separator my-5"></div>
															<!--begin::Details item-->
															<div class="fw-bold mt-5">Kullanım Durumu</div>
															<div v-if="this.propertyInfo.usageStatus !== null && this.propertyInfo.usageStatus !== ''" class="text-gray-600"> {{ this.propertyInfo.usageStatus }}</div>
															<div v-if="this.propertyInfo.usageStatus == null || this.propertyInfo.usageStatus == ''" class="text-gray-600"> Bilinmiyor</div>
															<!--end::Details item-->
                                                            <div class="separator my-5"></div>
															<!--begin::Details item-->
															<div class="fw-bold mt-5">Aidat(TL)</div>
															<div v-if="this.propertyInfo.dues !== null && this.propertyInfo.dues !== ''" class="text-gray-600"> {{ this.propertyInfo.dues }}</div>
															<div v-if="this.propertyInfo.dues == null || this.propertyInfo.dues == ''" class="text-gray-600"> Bilinmiyor</div>
															<!--end::Details item-->
                                                            <div class="separator my-5"></div>
															<!--begin::Details item-->
															<div class="fw-bold mt-5">Taşınmaz Durumu</div>
															<div v-if="this.propertyInfo.dues !== null && this.propertyInfo.dues !== ''" class="text-gray-600"> {{ this.propertyInfo.dues }}</div>
															<div v-if="this.propertyInfo.dues == null || this.propertyInfo.dues == ''" class="text-gray-600"> Bilinmiyor</div>
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
import { mapGetters } from 'vuex'
export default {
    name: 'PropertiesCreate',
    data() {
        return {
            form: {
                estateType: { value: null, name: "Emlak Türünü Seçiniz" },
            },
            propertyInfo: {
                housingType: null,
                userId: null,
                title: null,
                description: null,
                price: null,
                postedDate: null,
                squareMetersNet: null,
                squareMetersGross: null,
                roomNumber: null,
                status: null,
                province: null,
                district: null,
                buildingAge: null,
                locatedFloor: null,
                floorNumber: null,
                heating: null,
                bathroomNumber: null,
                balcony: null,
                lift: null,
                parking: null,
                furnished: null,
                usageStatus: null,
                insadeSite: null,
                siteName: null,
                dues: null,
                deposit: null,
                adress: null,
                sahibindenId: null,
                squareMetersPrice: null,
                islandNo: null,
                parcelNo: null,
                sheetNumber: null,
                kaks: null,
                gabari: null,
                inReturnFloor: null,
                creditEligibility: null,
                titleDeedStatus: null,
                swap: null,
                zoningStatus: null,
                buildinStatus: null,
                kitcthen: null,
                querater: null,
            },
            estateTypeList: [],
            estateStatusTypeList: [],
            residentialPropertyList: [],
            formIsActive: false,
        }
    },
    created() {
        this.estateTypeList = this.getEstateTypeList;
        this.estateStatusTypeList = this.getEstateStatusTypeList;
        this.residentialPropertyList = this.getResidentialPropertyList;
    },
    methods: {
        activateForm() {
            if (this.form.estateType.value == null) {
                this.formIsActive = false;
            } else
                this.formIsActive = true;
        }
    },
    computed: {
        ...mapGetters(['getEstateTypeList']),
        ...mapGetters(['getEstateStatusTypeList']),
        ...mapGetters(['getResidentialPropertyList']),
    }
}
</script>
import { createStore } from 'vuex';
import { jwtDecode } from 'jwt-decode';
import { toRaw } from 'vue';

export default createStore({
    state: {
        userTypeList: [
            { value: 'admin', name: 'Admin' },
            { value: 'modaretor', name: 'Yönetici' },
            { value: 'saleperson', name: 'Emlak Danışmanı' }
        ],
        stateList: [
            { value: 1, name: 'Adana' },
            { value: 2, name: 'Adıyaman' },
            { value: 3, name: 'Afyonkarahisar' },
            { value: 4, name: 'Ağrı' },
            { value: 5, name: 'Amasya' },
            { value: 6, name: 'Ankara' },
            { value: 7, name: 'Antalya' },
            { value: 8, name: 'Artvin' },
            { value: 9, name: 'Aydın' },
            { value: 10, name: 'Balıkesir' },
            { value: 11, name: 'Bilecik' },
            { value: 12, name: 'Bingöl' },
            { value: 13, name: 'Bitlis' },
            { value: 14, name: 'Bolu' },
            { value: 15, name: 'Burdur' },
            { value: 16, name: 'Bursa' },
            { value: 17, name: 'Çanakkale' },
            { value: 18, name: 'Çankırı' },
            { value: 19, name: 'Çorum' },
            { value: 20, name: 'Denizli' },
            { value: 21, name: 'Diyarbakır' },
            { value: 22, name: 'Edirne' },
            { value: 23, name: 'Elazığ' },
            { value: 24, name: 'Erzincan' },
            { value: 25, name: 'Erzurum' },
            { value: 26, name: 'Eskişehir' },
            { value: 27, name: 'Gaziantep' },
            { value: 28, name: 'Giresun' },
            { value: 29, name: 'Gümüşhane' },
            { value: 30, name: 'Hakkari' },
            { value: 31, name: 'Hatay' },
            { value: 32, name: 'Isparta' },
            { value: 33, name: 'Mersin' },
            { value: 34, name: 'İstanbul' },
            { value: 35, name: 'İzmir' },
            { value: 36, name: 'Kars' },
            { value: 37, name: 'Kastamonu' },
            { value: 38, name: 'Kayseri' },
            { value: 39, name: 'Kırklareli' },
            { value: 40, name: 'Kırşehir' },
            { value: 41, name: 'Kocaeli' },
            { value: 42, name: 'Konya' },
            { value: 43, name: 'Kütahya' },
            { value: 44, name: 'Malatya' },
            { value: 45, name: 'Manisa' },
            { value: 46, name: 'Kahramanmaraş' },
            { value: 47, name: 'Mardin' },
            { value: 48, name: 'Muğla' },
            { value: 49, name: 'Muş' },
            { value: 50, name: 'Nevşehir' },
            { value: 51, name: 'Niğde' },
            { value: 52, name: 'Ordu' },
            { value: 53, name: 'Rize' },
            { value: 54, name: 'Sakarya' },
            { value: 55, name: 'Samsun' },
            { value: 56, name: 'Siirt' },
            { value: 57, name: 'Sinop' },
            { value: 58, name: 'Sivas' },
            { value: 59, name: 'Tekirdağ' },
            { value: 60, name: 'Tokat' },
            { value: 61, name: 'Trabzon' },
            { value: 62, name: 'Tunceli' },
            { value: 63, name: 'Şanlıurfa' },
            { value: 64, name: 'Uşak' },
            { value: 65, name: 'Van' },
            { value: 66, name: 'Yozgat' },
            { value: 67, name: 'Zonguldak' },
            { value: 68, name: 'Aksaray' },
            { value: 69, name: 'Bayburt' },
            { value: 70, name: 'Karaman' },
            { value: 71, name: 'Kırıkkale' },
            { value: 72, name: 'Batman' },
            { value: 73, name: 'Şırnak' },
            { value: 74, name: 'Bartın' },
            { value: 75, name: 'Ardahan' },
            { value: 76, name: 'Iğdır' },
            { value: 77, name: 'Yalova' },
            { value: 78, name: 'Karabük' },
            { value: 79, name: 'Kilis' },
            { value: 80, name: 'Osmaniye' },
            { value: 81, name: 'Düzce' }
        ],
        user: []
    },
    mutations: {
        setUser(state, user) {
            console.log(user);
            state.user = user;
        }
    },
    actions: {
        fetchUser({ commit }) {
            const token = localStorage.getItem('token');
            console.log(jwtDecode(token))
            if (token) {
                const user = jwtDecode(token);
                commit('setUser', toRaw(user));
            }
        }
    },
    modules: {

    },
    getters: {
        getUserTypeList: state => state.userTypeList,
        getStateList: state => state.stateList,
        getUser: state => toRaw(state.user)
    }
})
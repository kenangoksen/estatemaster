import axios from "axios";
import SecureLS from "secure-ls";
const ls = new SecureLS({ isCompression: true, encodingType: 'aes' }); // isCompression: true'yu eski hale getirdim

const state = {
  user: null,
  sessionID: null,
  isAuthenticated: false
};

const getters = {
  getUser: state => state.user,
  getSessionID: state => state.sessionID,
  isAuthenticated: state => state.isAuthenticated,
  // Eklenen getter: Kullanıcının rolüne kolay erişim
  getCurrentUserType: (state) => state.user ? state.user.userType : null,
  // Eklenen getter: Belirli bir role sahip mi
  hasRole: (state, getters) => (roles) => {
    if (!getters.getCurrentUserType) return false;
    const userRole = getters.getCurrentUserType;
    if (Array.isArray(roles)) {
      return roles.includes(userRole);
    }
    return userRole === roles;
  }
};

const mutations = {
  SET_USER(state, payload) {
    state.user = payload;
    state.sessionID = payload.session_id;
    state.isAuthenticated = true;

    // SecureLS'e kaydederken doğrudan LoginSessionResponse objesini kaydediyoruz
    ls.set('user_' + payload.session_id, payload);
    sessionStorage.setItem('sid', payload.session_id);
  },
  CLEAR_USER(state) {
    state.user = null;
    state.sessionID = null;
    state.isAuthenticated = false;

    ls.removeAll();
    sessionStorage.clear();
  }
};

const actions = {
  async LogIn({ commit }, loginPayload) {
    // console.log("Vuex LogIn action çalıştı."); 
    const params = {
      username: loginPayload.get("username"),
      password: loginPayload.get("password")
    };
    try {
      const response = await axios.post('/api/Auth/AuthUser', params);
      // console.log("API'den gelen response.data:", response.data); 

      // BURADA DÜZELTME: response.data.data (küçük 'd' ile) olarak değiştirildi
      if (response.data && response.data.isSuccess && response.data.data && response.data.data.id) {
        commit("SET_USER", response.data.data); // BURAYI DA KÜÇÜK 'd' İLE DÜZELTTİK
        // console.log("Kullanıcı başarıyla SET_USER ile kaydedildi.");
        return {
          success: true,
          message: response.data.message || "Giriş Başarılı",
          code: response.data.Code
        };
      } else {
        // console.log("API yanıtında başarı durumu yok veya data eksik.");
        commit("CLEAR_USER");
        return {
          success: false,
          message: response.data?.message || "Kullanıcı adı veya şifre hatalı.",
          code: response.data?.Code
        };
      }
    } catch (error) {
      // console.error("Vuex LogIn action error (catch bloğu):", error);
      commit("CLEAR_USER");
      if (error.response && error.response.data) {
        return {
          success: false,
          message: error.response.data.message || "Bilinmeyen bir sunucu hatası oluştu.",
          code: error.response.data.code
        };
      }
      return { success: false, message: "Bilinmeyen bir sunucu hatası oluştu." };
    }
  },

  LogOut({ commit }) {
    commit("CLEAR_USER");
    window.location.href = "/login";
  }
};


export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
};
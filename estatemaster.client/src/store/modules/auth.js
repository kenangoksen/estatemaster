// import axios from "axios"; 
// import SecureLS from "secure-ls";  
// const ls = new SecureLS({ isCompression: false });

// const state = {};

// const getters = { 
// };

// const actions = {   
//   async LogIn({commit}, user) {   
//     const params = {
//       username: user.get("username"),
//       password: user.get("password")
//     };
//     await axios.post('/api/Auth/AuthUser', params, {'Content-Type': 'application/json'})
//     .then((response) => {     
//         if(response.data.id != null){
//           ls.set('user_' + response.data.session_id, response.data);
//           window.location.href= "/";
//         }
//         else{ 
//           commit("removeUser");
//           this.$swal("Login failed.", "User not found..!", 'error');
//           sessionStorage.clear();
//           return;
//         }
//     })
//     .catch(function (error) { 
//         console.log(error);
//     }); 
//   }
// };

// const mutations = {  
//   removeUser() { 
//     sessionStorage.clear();
//   }
// };   
// export default {
//   state,
//   getters,
//   actions,
//   mutations
// };

import axios from "axios";
import SecureLS from "secure-ls";
const ls = new SecureLS({ isCompression: false });

const state = {
  user: null,
  sessionID: null,
  isAuthenticated: false
};

const getters = {
  getUser: state => state.user,
  getSessionID: state => state.sessionID,
  isAuthenticated: state => state.isAuthenticated
};

const mutations = {
  SET_USER(state, payload) {
    state.user = payload;
    state.sessionID = payload.session_id;
    state.isAuthenticated = true;

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
  async LogIn({ commit }, user) {
    const params = {
      username: user.get("username"),
      password: user.get("password")
    };
    try {
      const response = await axios.post('/api/Auth/AuthUser', params);
      if (response.data?.id) {
        commit("SET_USER", response.data);
        return { success: true };
      } else {
        commit("CLEAR_USER");
        return { success: false, message: "User not found." };
      }
    } catch (error) {
      console.log("Login error:", error);
      commit("CLEAR_USER");
      return { success: false, message: "Server error." };
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
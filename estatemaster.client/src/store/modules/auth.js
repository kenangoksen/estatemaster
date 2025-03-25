import axios from "axios"; 
import SecureLS from "secure-ls";  
const ls = new SecureLS({ isCompression: false });

const state = {};

const getters = { 
};

const actions = {   
  async LogIn({commit}, user) {   
    const params = {
      username: user.get("username"),
      password: user.get("password")
    };
    await axios.post('/api/Auth/AuthUser', params, {'Content-Type': 'application/json'})
    .then((response) => {     
        if(response.data.id != null){
          ls.set('user_' + response.data.session_id, response.data);
          window.location.href= "/";
        }
        else{ 
          commit("removeUser");
          this.$swal("Login failed.", "User not found..!", 'error');
          sessionStorage.clear();
          return;
        }
    })
    .catch(function (error) { 
        console.log(error);
    }); 
  }
};

const mutations = {  
  removeUser() { 
    sessionStorage.clear();
  }
};   
export default {
  state,
  getters,
  actions,
  mutations
};

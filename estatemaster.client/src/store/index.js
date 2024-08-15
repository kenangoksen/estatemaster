import { createStore } from 'vuex';

export default createStore( {
    state: {
        accessToken: false
    },
    mutations: {

    },
    actions: {
        
    },
    modules: {
        
    },
    getters: {
        isAuthenticated(state)
        {
            return state.accessToken !== false
        }
    }
})
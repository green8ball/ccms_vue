import Vue from 'vue';
import Vuex from 'vuex';
import auth from './modules/auth';
import user from './modules/user';

Vue.use(Vuex);

export default new Vue.Store({
    state: {

    },
    mutations: {

    },
    actions: {

    },
    modules: {
        auth: {
            namespaced: true,
            state: auth.state,
            mutations: auth.mutations,
            getters: auth.getters,
            actions: auth.actions
        },
        user: {
            namespaced: true,
            state: user.state,
            mutations: user.mutations,
            getters: user.getters,
            actions: user.actions
        },
    },
});
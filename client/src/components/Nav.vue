<template>
 <nav class="navbar is-white is-fixed-top" role="navigation" aria-label="main navigation" style="border-bottom: 2px solid #e5e5e5;border-right: 1px solid #e5e5e5;border-left: 1px solid #e5e5e5;">
  <!-- <div class="navbar-brand">    
    <router-link to="/" class="navbar-item"></router-link>
  </div> -->
  <div class="navbar-menu is-active">
    <div class="navbar-start">
      <router-link to="/dashboard/home"  class="navbar-item"  v-show="isAuthenticated">Dashboard</router-link>   
      <router-link to="/login"  class="navbar-item"  v-show="!isAuthenticated">Email login</router-link>
    </div>
    <div class="navbar-end">
      <a class="navbar-item" href="javascript:void(0)" v-on:click="logoff" v-show="isAuthenticated">Logoff {{profile.firstName}}</a>
    </div>
  </div>
 </nav>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import { EventBus } from '.././event-bus';
import { mapGetters } from 'vuex';

@Component({
  computed: mapGetters({
    isAuthenticated: 'auth/isAuthenticated',
    profile: 'user/profile',
  }),
})
export default class Nav extends Vue {

  private serverTime: string = '';

  private logoff() {
     this.$store.dispatch('auth/authLogout').then(() => {
        this.$router.push('/');
     });
  }
  private created() {
    EventBus.$on('logged-in', (payLoad: any) => {
      // this doesn't currently do anything in this demo but does get fired on successful login.
      // leaving it here to show how to allow communication between unrelated components - ie. Store -> Component
    });
  }

  private destroyed() {
    EventBus.$off('logged-in');
  }
}
</script>


<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.router-link-exact-active {
  color: #209cee !important;
}
</style>



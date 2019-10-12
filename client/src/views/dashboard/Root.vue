<template>
<div>
  <Nav />
  <!-- <Menu /> -->
  <router-view></router-view>
</div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import Nav from '@/components/Nav.vue';
// import Menu from '@/components/Menu.vue';

@Component({
  components: {
    Nav,
    // Menu,
  },
})
export default class DashboardRoot extends Vue {}
</script>

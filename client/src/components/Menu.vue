<template>
    <aside class="menu">
        <p class="menu-label">
            Admin
        </p>
        <ul class="menu-list">
            <li><a href="">Employee Definition</a></li>
            <li><a href="">Activity Codes</a></li>
        </ul>
        <p class="menu-label">
          Scheduling
        </p>
        <ul class = "menu-list">
          <li><a href="">Schedule Patterns</a></li>
          <li><a href="">Schedule Management</a></li>
        </ul>
    </aside>
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
export default class Menu extends Vue {

}

</script>

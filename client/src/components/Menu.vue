<template>
    <aside class="menu">
        <p class="menu-label">
            Admin
        </p>
        <ul class="menu-list">
            <li><a>Agent Definition</a></li>
            <li><a>Activity Codes</a></li>
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

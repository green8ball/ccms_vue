<template>
<div> 
 <Menu />
 <!-- <section class="container is-fluid">
    <div class="columns">
      <div class="column is-4 is-offset-4">
        <div class="card">          
          <div class="card-content">
            <div class="content">
              <h4>You've reached a protected area!</h4>
              <Spinner v-bind:show="isBusy" />            
              <p v-if="homeData.firstName"><strong>Name:</strong> {{name}}</p>
              <p v-if="homeData.ezLMID"><strong>ezLM ID:</strong> {{homeData.ezLMID}}</p>
              <p v-if="homeData.email"><strong>Email:</strong> {{homeData.email}}</p>
              <p v-if="homeData.adid"><strong>AD ID:</strong> {{homeData.adid}}</p>
            </div>
          </div>
        </div>
      </div>
    </div>
 </section> -->
 
 </div>
</template>

<script lang="ts">
import Spinner from '@/components/Spinner.vue'; // @ is an alias to /src
import { Component, Vue } from 'vue-property-decorator';
import { mapGetters } from 'vuex';
import { dashboardService } from '../../services/dashboard.service';
import Menu from '@/components/Menu.vue';

@Component({
  computed: mapGetters({
    profile: 'user/profile',
  }),
  components: {
    Spinner,
    Menu,
  },
})
export default class DashboardHome extends Vue {

  private isBusy: boolean = false;
  private homeData = {} as any;

  get name() {
      return this.homeData.firstName + ' ' + this.homeData.lastName;
  }

  private created() {
     this.isBusy = true;
     dashboardService.getHomeDetails().then((resp: any) => {
        this.homeData = resp.data;
        this.isBusy = false;
     });
  }
}
</script>

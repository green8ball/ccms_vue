import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import store from './store/store';

Vue.use(Router)

const router = new Router({
  //mode: 'history',
  //base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'dashboard',
      component: LoginForm
    },
    {
      path: '/about',
      name: 'about',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "about" */ './views/About.vue')
    }
  ]
});

router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.requiresAuth)) {
    if (!store.getters['auth/isAuthenticated']) {
      next({
        path: '/login',
        query: { redirect: to.fullPath},
      });
    } else {
      next();
    }
  } else {
    next();
  }
});

export default router;
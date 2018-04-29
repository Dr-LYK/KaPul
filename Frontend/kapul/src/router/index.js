import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import Trips from '@/components/Trips'
import Users from '@/components/Users'

Vue.use(Router);

export default new Router(
{
  routes:
  [
    {
      path: '/',
      alias: '/home',
      name: 'Home',
      component: Home
    },
    {
      path: '/trips',
      name: 'Trips',
      component: Trips
    },
    {
      path: '/users',
      name: "Users",
      component: Users
    }
  ]
})

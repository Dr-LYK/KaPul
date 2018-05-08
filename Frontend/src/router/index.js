import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import Trips from '@/components/Trips'
import Trip from '@/components/Trip'
import User from '@/components/User'
import Login from '@/components/Login'
import Register from '@/components/Register'

Vue.use(Router);

export default new Router(
{
  mode: 'history',
  routes:
  [
    {
      path: '/',
      alias: '/home',
      name: 'Home',
      component: Home
    },
    {
      path: "/login",
      name: "Login",
      component: Login
    },
    {
      path: "/register",
      name: "Register",
      component: Register
    },
    {
      path: '/trips',
      name: 'Trips',
      component: Trips
    },
    {
      path: "/trips/:id",
      name: "Trip",
      component: Trip
    },
    {
      path: '/users/:id',
      name: "User",
      component: User
    }
  ]
})

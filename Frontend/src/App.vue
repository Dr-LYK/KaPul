<template>
  <div id="app">
    <Navbar></Navbar>

    <router-view style="padding-top: 100px;"/>

    <Footer></Footer>
  </div>
</template>

<script>

  import Navbar from './components/Navbar.vue';
  import Footer from './components/Footer.vue';

  export default
  {
    name: 'App',
    components:
    {
      Navbar,
      Footer
    }
  }

</script>

<style>

  html, body
  {
    height: 100%;
  }

  body
  {
    position: relative;
    margin: 0;
    min-height: 100%;
    width: 100%;
  }
/*
  footer
  {
    position: absolute;
    height: 100px;
    bottom: 0;
    left: 0;
    right: 0;
    padding: 1rem;
    overflow-y: hidden;
  }
*/
  #app
  {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  .bg-LightGrey
  {
    background-color:rgb(240, 240, 240);
  }

  .bg-blue
  {
    background-color: #073863;
  }
  .white
  {
    color: white;
  }


</style>

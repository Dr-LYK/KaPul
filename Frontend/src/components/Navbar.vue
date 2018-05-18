<template>
  <div class="fixed-top">
    <el-menu default-active="/home" :router="true" class="el-menu" mode="horizontal">

      <el-menu-item index="/home" style="border: none; height: 50px;">
        <img src="../assets/img/logo.png" style="height: 50px;">
      </el-menu-item>


      <el-menu-item :index="profileURL" v-if="$session.exists()" style="float: right">
        <div>
          {{$session.get("surname")}} {{$session.get("name")}}
        </div>
      </el-menu-item>

      <el-menu-item index="/trips/new" v-if="$session.exists()" style="float: right;">
        <el-button type="primary">Création d'un trajet</el-button>
      </el-menu-item>

      <el-menu-item v-if="!$session.exists()" index="/login" style="float: right;">Connexion</el-menu-item>
      <el-menu-item v-if="!$session.exists()" index="/register" style="float: right;">Inscription</el-menu-item>

    </el-menu>

  </div>
</template>

<script>


  export default
  {
    data()
    {
      return {
        profileURL: "/users/"+this.$session.get('id')
      }
    },
    mounted: () =>
    {

    },
    beforeCreate: function()
    {
    }
  }

</script>

<style scoped>

</style>